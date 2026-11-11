using Microsoft.EntityFrameworkCore;
using OSDU.Data.MasterData;

namespace OSDU.Data;

public sealed class CatalogRow
{
    public string Dataset { get; set; } = "";
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Identifier { get; set; } = "";
    public string Field { get; set; } = "";
    public string Operator { get; set; } = "";
    public bool IsActive { get; set; }
    public int? FieldId { get; set; }
    public int? WellId { get; set; }
    public string? WellUwi { get; set; }
    public decimal? DrillTd { get; set; }
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }
    public int? CrsId { get; set; }
    public string? CrsName { get; set; }
}

public sealed record CatalogFilter(string? Dataset, string? Search, string? Field, string? Operator,
    string? Status, bool HasLocation);

public sealed class CatalogRepository(OsduDbContext db)
{
    private IQueryable<CatalogRow> Rows() =>
        db.WellRecords.AsNoTracking().Select(x => new CatalogRow {
            Dataset = "Wells", Id = x.WellId, Name = x.WellName, Identifier = x.Uwi,
            Field = x.FieldName ?? "", Operator = x.Operator ?? x.WellOwner ?? "", IsActive = x.IsActive,
            FieldId = x.FieldId, WellId = x.WellId, WellUwi = null, DrillTd = null,
            Latitude = x.XCoordinate, Longitude = x.YCoordinate, CrsId = x.CrsId, CrsName = x.CrsName
        }).Concat(db.WellboreRecords.AsNoTracking().Select(x => new CatalogRow {
            Dataset = "Wellbores", Id = x.WellboreId, Name = x.WellboreName ?? x.WellboreUwi, Identifier = x.WellboreUwi,
            Field = x.FieldName ?? "", Operator = "", IsActive = x.IsActive,
            FieldId = x.FieldId, WellId = x.WellId, WellUwi = x.WellUwi, DrillTd = x.DrillTd,
            Latitude = x.YCoordinate, Longitude = x.XCoordinate, CrsId = x.CrsId, CrsName = x.CrsName
        })).Concat(db.FieldRecords.AsNoTracking().Select(x => new CatalogRow {
            Dataset = "Fields", Id = x.FieldId, Name = x.FieldName, Identifier = x.FieldId.ToString(),
            Field = x.FieldName, Operator = "", IsActive = x.IsActive,
            FieldId = x.FieldId, WellId = null, WellUwi = null, DrillTd = null,
            Latitude = x.XCoordinate, Longitude = x.YCoordinate, CrsId = x.CrsId, CrsName = x.CrsName
        })).Concat(db.FacilityRecords.AsNoTracking().Select(x => new CatalogRow {
            Dataset = "Facilities", Id = x.FacilityId, Name = x.FacilityName, Identifier = x.FacilityId.ToString(),
            Field = "", Operator = x.CurrentOperator ?? "", IsActive = x.IsActive,
            FieldId = null, WellId = null, WellUwi = null, DrillTd = null,
            Latitude = x.YCoordinate, Longitude = x.XCoordinate, CrsId = x.CrsId, CrsName = x.CrsName
        }));

    private IQueryable<CatalogRow> Located(IQueryable<CatalogRow> rows) =>
        from row in rows
        join crs in db.Set<Cartoreferencesystem>().AsNoTracking() on row.CrsId equals (int?)crs.CrsId into systems
        from crs in systems.DefaultIfEmpty()
        let name = ((crs == null ? row.CrsName : crs.CrsName) ?? "").Trim().ToUpper()
        let normalized = name.Replace(" ", "").Replace(":", "").Replace("-", "")
        where row.Latitude >= -90 && row.Latitude <= 90 && row.Longitude >= -180 && row.Longitude <= 180
            && (normalized == "4326" || normalized == "EPSG4326" || normalized == "WGS84")
        select row;

    private IQueryable<CatalogRow> Filter(CatalogFilter filter, string? except = null)
    {
        var rows = Rows();
        if (!string.IsNullOrEmpty(filter.Dataset)) rows = rows.Where(x => x.Dataset == filter.Dataset);
        if (filter.Search?.Trim() is { Length: > 0 } search)
            rows = rows.Where(x => (x.Name + " " + x.Identifier + " " + x.Operator + " " + x.Field + " " + x.Dataset).ToLower().Contains(search.ToLower()));
        if (except != "operator" && !string.IsNullOrEmpty(filter.Operator)) rows = rows.Where(x => x.Operator == filter.Operator);
        if (except != "field" && !string.IsNullOrEmpty(filter.Field)) rows = rows.Where(x => x.Field == filter.Field);
        if (except != "status" && filter.Status is "Active" or "Inactive") rows = rows.Where(x => x.IsActive == (filter.Status == "Active"));
        return filter.HasLocation ? Located(rows) : rows;
    }

    public async Task<object> Search(CatalogFilter filter, int page, int size, string? sort, bool desc, CancellationToken ct)
    {
        var rows = Filter(filter);
        System.Linq.Expressions.Expression<Func<CatalogRow, string?>> order = sort switch {
            "Dataset" => x => x.Dataset,
            "Identifier" or "UWI" => x => x.Identifier,
            "Operator" => x => x.Operator,
            "Field" => x => x.Field,
            "Parent well" => x => x.WellUwi,
            _ => x => x.Name
        };
        var ordered = sort switch {
            "Status" => desc ? rows.OrderByDescending(x => x.IsActive) : rows.OrderBy(x => x.IsActive),
            "Drilled depth" => desc ? rows.OrderByDescending(x => x.DrillTd) : rows.OrderBy(x => x.DrillTd),
            _ => desc ? rows.OrderByDescending(order) : rows.OrderBy(order)
        };
        var total = await rows.CountAsync(ct);
        var actualPage = Math.Min(page, Math.Max(0, (total - 1) / size));
        var results = await ordered.ThenBy(x => x.Dataset).ThenBy(x => x.Id).Skip(actualPage * size).Take(size)
            .Select(x => new { x.Id, x.Dataset, x.Name, x.Identifier, x.Field, x.Operator, x.IsActive, x.WellUwi, x.DrillTd }).ToListAsync(ct);
        return new { total, page = actualPage, size, rows = results };
    }

    public async Task<object> Facets(CatalogFilter filter, CancellationToken ct)
    {
        var operators = await Filter(filter, "operator").Where(x => x.Operator != "").GroupBy(x => x.Operator)
            .Select(g => new { value = g.Key, count = g.Count() }).OrderBy(x => x.value).ToListAsync(ct);
        var fields = await Filter(filter, "field").Where(x => x.Field != "").GroupBy(x => x.Field)
            .Select(g => new { value = g.Key, count = g.Count() }).OrderBy(x => x.value).ToListAsync(ct);
        var statuses = await Filter(filter, "status").GroupBy(x => x.IsActive)
            .Select(g => new { value = g.Key ? "Active" : "Inactive", count = g.Count() }).ToListAsync(ct);
        return new { @operator = operators, field = fields, status = statuses };
    }

    public async Task<object> Map(CatalogFilter filter, CancellationToken ct)
    {
        var rows = Filter(filter with { HasLocation = false });
        var located = Located(rows);
        var total = await rows.CountAsync(ct);
        var mapped = await located.CountAsync(ct);
        var points = await located.OrderBy(x => x.Dataset).ThenBy(x => x.Id).Take(5000)
            .Select(x => new { x.Id, x.Name, x.Dataset, x = x.Longitude, y = x.Latitude }).ToListAsync(ct);
        return new { total, mapped, points };
    }

    public async Task<object> Related(string dataset, int id, CancellationToken ct)
    {
        var rows = Rows();
        var record = await rows.FirstOrDefaultAsync(x => x.Dataset == dataset && x.Id == id, ct);
        if (record is null) return Array.Empty<object>();
        var fieldId = record.FieldId;
        var wellId = record.WellId;
        var facilities = db.FacilityFieldRecords.AsNoTracking();
        return await rows.Where(x => (x.Dataset != dataset || x.Id != id) &&
            ((dataset == "Fields" && x.FieldId == id) ||
             (dataset != "Fields" && x.Dataset == "Fields" && x.Id == fieldId) ||
             (dataset == "Wells" && x.Dataset == "Wellbores" && x.WellId == id) ||
             (dataset == "Wellbores" && x.Dataset == "Wells" && x.Id == wellId) ||
             (dataset == "Fields" && x.Dataset == "Facilities" && facilities.Any(link => link.FieldId == id && link.FacilityId == x.Id)) ||
             (dataset == "Facilities" && x.Dataset == "Fields" && facilities.Any(link => link.FacilityId == id && link.FieldId == x.Id))))
            .OrderBy(x => x.Name).ThenBy(x => x.Dataset).ThenBy(x => x.Id).Take(100)
            .Select(x => new { x.Id, x.Name, x.Dataset }).ToListAsync(ct);
    }

    public async Task<object?> Detail(string dataset, int id, CancellationToken ct) => dataset switch {
        "Wells" => await db.WellRecords.AsNoTracking().SingleOrDefaultAsync(x => x.WellId == id, ct),
        "Wellbores" => await db.WellboreRecords.AsNoTracking().SingleOrDefaultAsync(x => x.WellboreId == id, ct),
        "Fields" => await db.FieldRecords.AsNoTracking().SingleOrDefaultAsync(x => x.FieldId == id, ct),
        "Facilities" => await db.FacilityRecords.AsNoTracking().SingleOrDefaultAsync(x => x.FacilityId == id, ct),
        _ => null
    };
}

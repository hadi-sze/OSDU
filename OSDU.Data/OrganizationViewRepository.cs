using Microsoft.EntityFrameworkCore;
using OSDU.Data.MasterData;
using System.ComponentModel.DataAnnotations;
namespace OSDU.Data;

public record OrganizationLink(int Id, string Kind, int OrgUnitId, int TargetId, DateTime? EffectiveDate, DateTime? ExpiryDate, string? Remark, bool IsActive);
public class OrganizationViewRepository(OsduDbContext db)
{
    public async Task<object> Read(CancellationToken ct)
    {
        var links = new List<OrganizationLink>();
        links.AddRange(await db.Set<FieldOrgUnit>().AsNoTracking().Select(x => new OrganizationLink(x.FieldOrgUnitId, "fields", x.OrgUnitId, x.FieldId, x.EffectiveDate, x.ExpiryDate, x.Remark, x.IsActive)).ToListAsync(ct));
        links.AddRange(await db.Set<WellOrgUnit>().AsNoTracking().Select(x => new OrganizationLink(x.WellOrgUnitId, "wells", x.OrgUnitId, x.WellId, x.EffectiveDate, x.ExpiryDate, x.Remark, x.IsActive)).ToListAsync(ct));
        links.AddRange(await db.Set<FacilityOrgUnit>().AsNoTracking().Select(x => new OrganizationLink(x.FacilityOrgUnitId, "facilities", x.OrgUnitId, x.FacilityId, x.EffectiveDate, x.ExpiryDate, x.Remark, x.IsActive)).ToListAsync(ct));
        return new {
            organizations = await db.Set<OrgUnit>().AsNoTracking().OrderBy(x=>x.OrgUnitName).ToListAsync(ct),
            fields = await db.Set<Field>().AsNoTracking().OrderBy(x=>x.FieldName).ToListAsync(ct),
            wells = await db.Set<Well>().AsNoTracking().OrderBy(x=>x.WellName).ToListAsync(ct),
            facilities = await db.Set<Facility>().AsNoTracking().OrderBy(x=>x.FacilityName).ToListAsync(ct),
            links
        };
    }

    public async Task Save(OrganizationLink input, string actor, CancellationToken ct)
    {
        if (!await db.Set<OrgUnit>().AnyAsync(x=>x.OrgUnitId==input.OrgUnitId,ct))
            throw new ValidationException("Choose an existing organization.");
        switch (input.Kind)
        {
            case "fields":
            {
                if (!await db.Set<Field>().AnyAsync(x=>x.FieldId==input.TargetId,ct))
                    throw new ValidationException("Choose an existing field.");
                var row = input.Id == 0 ? new FieldOrgUnit {RowCreatedBy=actor,RowCreatedDate=DateTime.UtcNow} : await db.Set<FieldOrgUnit>().SingleOrDefaultAsync(x=>x.FieldOrgUnitId==input.Id && x.OrgUnitId==input.OrgUnitId,ct);
                if (row is null) throw new KeyNotFoundException();
                if (await db.Set<FieldOrgUnit>().AnyAsync(x=>x.OrgUnitId==input.OrgUnitId && x.FieldId==input.TargetId && x.EffectiveDate==input.EffectiveDate && x.FieldOrgUnitId!=input.Id,ct))
                    throw new ValidationException("This relationship already exists for the effective date.");
                row.OrgUnitId=input.OrgUnitId;
                row.FieldId=input.TargetId;
                row.EffectiveDate=input.EffectiveDate;
                row.ExpiryDate=input.ExpiryDate;
                row.Remark=input.Remark?.Trim();
                row.IsActive=input.IsActive;
                row.RowChangedBy=actor;
                row.RowChangedDate=DateTime.UtcNow;
                if (input.Id==0) db.Add(row);
                break;
            }
            case "wells":
            {
                if (!await db.Set<Well>().AnyAsync(x=>x.WellId==input.TargetId,ct))
                    throw new ValidationException("Choose an existing well.");
                var row = input.Id == 0 ? new WellOrgUnit {RowCreatedBy=actor,RowCreatedDate=DateTime.UtcNow} : await db.Set<WellOrgUnit>().SingleOrDefaultAsync(x=>x.WellOrgUnitId==input.Id && x.OrgUnitId==input.OrgUnitId,ct);
                if (row is null) throw new KeyNotFoundException();
                if (await db.Set<WellOrgUnit>().AnyAsync(x=>x.OrgUnitId==input.OrgUnitId && x.WellId==input.TargetId && x.EffectiveDate==input.EffectiveDate && x.WellOrgUnitId!=input.Id,ct))
                    throw new ValidationException("This relationship already exists for the effective date.");
                row.OrgUnitId=input.OrgUnitId;
                row.WellId=input.TargetId;
                row.EffectiveDate=input.EffectiveDate;
                row.ExpiryDate=input.ExpiryDate;
                row.Remark=input.Remark?.Trim();
                row.IsActive=input.IsActive;
                row.RowChangedBy=actor;
                row.RowChangedDate=DateTime.UtcNow;
                if (input.Id==0) db.Add(row);
                break;
            }
            case "facilities":
            {
                if (!await db.Set<Facility>().AnyAsync(x=>x.FacilityId==input.TargetId,ct))
                    throw new ValidationException("Choose an existing facility.");
                var row = input.Id == 0 ? new FacilityOrgUnit {RowCreatedBy=actor,RowCreatedDate=DateTime.UtcNow} : await db.Set<FacilityOrgUnit>().SingleOrDefaultAsync(x=>x.FacilityOrgUnitId==input.Id && x.OrgUnitId==input.OrgUnitId,ct);
                if (row is null) throw new KeyNotFoundException();
                if (await db.Set<FacilityOrgUnit>().AnyAsync(x=>x.OrgUnitId==input.OrgUnitId && x.FacilityId==input.TargetId && x.EffectiveDate==input.EffectiveDate && x.FacilityOrgUnitId!=input.Id,ct))
                    throw new ValidationException("This relationship already exists for the effective date.");
                row.OrgUnitId=input.OrgUnitId;
                row.FacilityId=input.TargetId;
                row.EffectiveDate=input.EffectiveDate;
                row.ExpiryDate=input.ExpiryDate;
                row.Remark=input.Remark?.Trim();
                row.IsActive=input.IsActive;
                row.RowChangedBy=actor;
                row.RowChangedDate=DateTime.UtcNow;
                if (input.Id==0) db.Add(row);
                break;
            }
            default: throw new ValidationException("Unsupported relationship.");
        }
        await db.SaveChangesAsync(ct);
    }

    public async Task Delete(string kind, int orgId, int id, CancellationToken ct)
    {
        object? row = kind switch
        {
            "fields" => await db.Set<FieldOrgUnit>().SingleOrDefaultAsync(x=>x.FieldOrgUnitId==id && x.OrgUnitId==orgId,ct),
            "wells" => await db.Set<WellOrgUnit>().SingleOrDefaultAsync(x=>x.WellOrgUnitId==id && x.OrgUnitId==orgId,ct),
            "facilities" => await db.Set<FacilityOrgUnit>().SingleOrDefaultAsync(x=>x.FacilityOrgUnitId==id && x.OrgUnitId==orgId,ct),
            _ => throw new ValidationException("Unsupported relationship.")
        };
        if (row is null) throw new KeyNotFoundException();
        db.Remove(row);
        await db.SaveChangesAsync(ct);
    }
}

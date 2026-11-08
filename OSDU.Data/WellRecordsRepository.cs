using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OSDU.Data.MasterData;

namespace OSDU.Data;

public record WellReferenceOption(int Id, string Label, string? CopyValue);
public record WellRecordField(string Key, string Label, string Kind, bool Required, int? MaxLength, int? Scale, string? CopyTo);

public class WellRecordsRepository(OsduDbContext db)
{
    private static readonly Dictionary<string, Type> Tables = new()
    {
        ["field-org-units"] = typeof(FieldOrgUnit),
        ["facilities"] = typeof(Facility), ["facility-fields"] = typeof(FacilityField),
        ["coordinate-reference-systems"] = typeof(Cartoreferencesystem), ["field-records"] = typeof(Field),
        ["well-master"] = typeof(Well), ["pool-records"] = typeof(Pool), ["equipment-master"] = typeof(Equipment),
        ["org-unit-types"] = typeof(ROrgUnitType), ["field-types"] = typeof(RFieldType),
        ["pool-types"] = typeof(RPoolType), ["pool-statuses"] = typeof(RPoolStatus),
        ["well-status-types"] = typeof(RWellStatusType), ["well-statuses"] = typeof(RWellStatus),
        ["wellbores"] = typeof(Wellbore), ["completions"] = typeof(WellCompletion),
        ["directional-surveys"] = typeof(WellDirSrvy), ["equipment"] = typeof(WellEquipment),
        ["perforations"] = typeof(WellPerforation), ["pools"] = typeof(WellPool),
        ["production-method-history"] = typeof(WellProdMethodHistory), ["statuses"] = typeof(WellStatus),
        ["tubing-tallies"] = typeof(WellTubingTally), ["tubulars"] = typeof(WellTubular), ["zones"] = typeof(WellZone),
    };

    private static readonly Dictionary<Type, string> Labels = new()
    {
        [typeof(Facility)] = nameof(Facility.FacilityName), [typeof(OrgUnit)] = nameof(OrgUnit.OrgUnitName),
        [typeof(RFacilityType)] = nameof(RFacilityType.FacilityType), [typeof(REquipmentType)] = nameof(REquipmentType.EquipmentType),
        [typeof(REquipmentSubType)] = nameof(REquipmentSubType.EquipmentSubType), [typeof(RFieldType)] = nameof(RFieldType.FieldTypeName),
        [typeof(RDataAccessCategory)] = nameof(RDataAccessCategory.DataAccessCategory), [typeof(RWellClass)] = nameof(RWellClass.WellClass),
        [typeof(RPoolStatus)] = nameof(RPoolStatus.PoolStatus), [typeof(RPoolType)] = nameof(RPoolType.PoolType),
        [typeof(RWellStatusType)] = nameof(RWellStatusType.WellStatusType),
        [typeof(Well)] = nameof(Well.WellName), [typeof(Wellbore)] = nameof(Wellbore.WellboreUwi),
        [typeof(WellCompletion)] = nameof(WellCompletion.WellCompletionName), [typeof(Equipment)] = nameof(Equipment.EquipmentName),
        [typeof(Pool)] = nameof(Pool.PoolName), [typeof(Field)] = nameof(Field.FieldName), [typeof(Zone)] = nameof(Zone.ZoneName),
        [typeof(Cartoreferencesystem)] = nameof(Cartoreferencesystem.CrsName), [typeof(RWellDatumType)] = nameof(RWellDatumType.WellDatumType),
        [typeof(RNorthType)] = nameof(RNorthType.NorthType), [typeof(RSurveyType)] = nameof(RSurveyType.SurveyType),
        [typeof(RProductionMethod)] = nameof(RProductionMethod.ProductionMethod), [typeof(RTimezone)] = nameof(RTimezone.Timezone),
        [typeof(RPlotSymbol)] = nameof(RPlotSymbol.PlotSymbolType), [typeof(RCompletionType)] = nameof(RCompletionType.CompletionType),
        [typeof(RPerforationType)] = nameof(RPerforationType.PerforationType), [typeof(RPerforationMethod)] = nameof(RPerforationMethod.PerforationMethod),
        [typeof(RTubularType)] = nameof(RTubularType.TubularType), [typeof(RCouplingType)] = nameof(RCouplingType.CouplingType),
        [typeof(RFluidType)] = nameof(RFluidType.FluidType), [typeof(RWellStatus)] = nameof(RWellStatus.WellStatus),
        [typeof(ReportingEntity)] = nameof(ReportingEntity.AssociatedObjectName), [typeof(RSource)] = nameof(RSource.SourceName),
        [typeof(WellTubular)] = nameof(WellTubular.WellboreUwi),
    };

    private static readonly Dictionary<Type, string> UniqueNames = new()
    {
        [typeof(Well)] = nameof(Well.Uwi), [typeof(Field)] = nameof(Field.FieldName),
        [typeof(Pool)] = nameof(Pool.PoolName), [typeof(Equipment)] = nameof(Equipment.EquipmentName),
        [typeof(Cartoreferencesystem)] = nameof(Cartoreferencesystem.CrsName), [typeof(ROrgUnitType)] = nameof(ROrgUnitType.OrgUnitType),
        [typeof(RFieldType)] = nameof(RFieldType.FieldTypeName), [typeof(RPoolType)] = nameof(RPoolType.PoolType),
        [typeof(RPoolStatus)] = nameof(RPoolStatus.PoolStatus), [typeof(RWellStatus)] = nameof(RWellStatus.WellStatus),
        [typeof(RWellStatusType)] = nameof(RWellStatusType.WellStatusType),
    };

    private static readonly Dictionary<string, (string Destination, string Source)> Copies = new()
    {
        ["Well.RTimezoneId"] = ("SpudDateTz", "Timezone"),
        ["Well.RWellProfileId"] = ("WellProfile", "WellStatus"),
        ["Wellbore.WellId"] = ("WellUwi", "Uwi"),
        ["WellProdMethodHistory.WellId"] = ("Uwi", "Uwi"),
        ["WellTubingTally.WellTubingId"] = ("WellboreUwi", "WellboreUwi"),
        ["ParentWellboreId"] = ("ParentWellboreUwi", "WellboreUwi"),
        ["BhCrsId"] = ("BhCrsName", "CrsName"),
        ["DepthDatumId"] = ("DepthDatum", "WellDatumType"),
        ["ReportLogDatumId"] = ("ReportLogDatum", "WellDatumType"),
        ["RNorthId"] = ("AzimuthNorthType", "NorthType"),
        ["TopZoneId"] = ("TopZoneName", "ZoneName"),
        ["BaseZoneId"] = ("BaseZoneName", "ZoneName"),
    };

    private static readonly HashSet<string> CreateTables =
    [
        "wellbores", "completions", "directional-surveys", "equipment", "perforations", "pools",
        "production-method-history", "statuses", "tubing-tallies", "tubulars", "zones",
    ];

    public static bool SupportsCreate(string table) => CreateTables.Contains(table);

    public static bool Supports(string table) => Tables.ContainsKey(table);

    private IEntityType Entity(string table) => db.Model.FindEntityType(Tables[table])!;

    private static string Key(string name) => JsonNamingPolicy.CamelCase.ConvertName(name);
    private static string Label(string name) => Regex.Replace(name, "([a-z0-9])([A-Z])|([A-Z])([A-Z][a-z])", "$1$3 $2$4");
    private static bool Editable(IProperty property) => !property.IsPrimaryKey() && !property.Name.StartsWith("RowCreated") && !property.Name.StartsWith("RowChanged");
    private static IForeignKey? Reference(IProperty property) => property.GetContainingForeignKeys().SingleOrDefault();

    private static (string Destination, string Source)? Copy(IProperty property, IForeignKey reference)
    {
        if (Copies.TryGetValue(property.DeclaringType.ClrType.Name + "." + property.Name, out var copy) ||
            Copies.TryGetValue(property.Name, out copy))
            return copy;

        var source = Labels[reference.PrincipalEntityType.ClrType];
        return property.DeclaringType.FindProperty(source)?.ClrType == typeof(string) && source != property.Name
            ? (source, source)
            : null;
    }

    public async Task<object> Read(string table, CancellationToken ct, int? recordId = null)
    {
        var entity = Entity(table);
        var id = entity.FindPrimaryKey()!.Properties.Single().Name;
        var fields = new List<WellRecordField>();
        var lookups = new Dictionary<string, IReadOnlyList<WellReferenceOption>>();
        foreach (var property in entity.GetProperties().Where(Editable).OrderBy(p => p.PropertyInfo!.MetadataToken))
        {
            var reference = Reference(property);
            var type = Nullable.GetUnderlyingType(property.ClrType) ?? property.ClrType;
            var kind = reference != null ? "lookup" : type == typeof(bool) ? "boolean" :
                type == typeof(DateTime) ? "date" : type == typeof(string) ? "text" :
                type == typeof(int) ? "integer" : "decimal";
            string? copyTo = null;
            var label = property.Name;
            if (entity.ClrType == typeof(Facility) && property.Name == nameof(Facility.REquipmentCatalogueId))
            {
                kind = "lookup";
                label = "EquipmentCatalogue";
                copyTo = Key(nameof(Facility.EquipmentCatalogue));
                lookups[Key(property.Name)] = await QueryOptions<REquipmentCatalogue>(
                    nameof(REquipmentCatalogue.REquipmentCatalogueId), nameof(REquipmentCatalogue.EquipmentCatalogue),
                    nameof(REquipmentCatalogue.EquipmentCatalogue), ct);
            }
            if (reference != null)
            {
                var principal = reference.PrincipalEntityType;
                var copy = Copy(property, reference);
                copyTo = copy is { } pair ? Key(pair.Destination) : null;
                label = (label.StartsWith('R') && label.Length > 1 && char.IsUpper(label[1]) ? label[1..] : label)
                    .Replace("Id", "");
                lookups[Key(property.Name)] = await Lookup(principal, copy?.Source, ct);
            }
            fields.Add(new(Key(property.Name), Label(label), kind, !property.IsNullable && kind != "boolean",
                property.GetMaxLength(), property.GetScale(), copyTo));
        }
        if (recordId is int key)
        {
            var record = await db.FindAsync(entity.ClrType, [key], ct) ?? throw new KeyNotFoundException();
            return new { idKey = Key(id), fields, lookups, record };
        }
        var method = typeof(WellRecordsRepository).GetMethod(nameof(List), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!;
        var rows = await (Task<object>)method.MakeGenericMethod(entity.ClrType).Invoke(this, [id, ct])!;
        return new { idKey = Key(id), fields, lookups, rows };
    }

    private async Task<object> List<T>(string id, CancellationToken ct) where T : class =>
        await db.Set<T>().AsNoTracking().OrderByDescending(row => EF.Property<int>(row, id)).ToListAsync(ct);

    private Task<IReadOnlyList<WellReferenceOption>> Lookup(IEntityType principal, string? copy, CancellationToken ct)
    {
        var method = typeof(WellRecordsRepository).GetMethod(nameof(QueryOptions), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!;
        return (Task<IReadOnlyList<WellReferenceOption>>)method.MakeGenericMethod(principal.ClrType)
            .Invoke(this, [principal.FindPrimaryKey()!.Properties.Single().Name, Labels[principal.ClrType], copy, ct])!;
    }

    private async Task<IReadOnlyList<WellReferenceOption>> QueryOptions<T>(string id, string label, string? copy, CancellationToken ct) where T : class
    {
        var query = db.Set<T>().AsNoTracking().OrderBy(row => EF.Property<string>(row, label)).ThenBy(row => EF.Property<int>(row, id));
        return copy is null
            ? await query.Select(row => new WellReferenceOption(EF.Property<int>(row, id), EF.Property<string?>(row, label) ?? "", null)).ToListAsync(ct)
            : await query.Select(row => new WellReferenceOption(EF.Property<int>(row, id), EF.Property<string?>(row, label) ?? "", EF.Property<string?>(row, copy))).ToListAsync(ct);
    }

    public async Task<object> Create(string table, JsonElement input, string actor, CancellationToken ct, int? recordId = null)
    {
        if (input.ValueKind != JsonValueKind.Object)
            throw new ValidationException("Enter record details.");
        var entity = Entity(table);
        var row = recordId is int key
            ? await db.FindAsync(entity.ClrType, [key], ct) ?? throw new KeyNotFoundException()
            : Activator.CreateInstance(entity.ClrType)!;
        var properties = entity.GetProperties().Where(Editable).ToArray();
        foreach (var property in properties)
        {
            if (!input.TryGetProperty(Key(property.Name), out var value) || value.ValueKind == JsonValueKind.Null)
            {
                if (recordId.HasValue)
                {
                    if (value.ValueKind == JsonValueKind.Null)
                    {
                        if (!property.IsNullable) throw new ValidationException($"{Label(property.Name)} is required.");
                        property.PropertyInfo!.SetValue(row, null);
                    }
                    continue;
                }
                if (property.ClrType == typeof(int) || property.ClrType == typeof(decimal))
                    throw new ValidationException($"{Label(property.Name)} is required.");
                continue;
            }
            try
            {
                var parsed = value.Deserialize(property.ClrType);
                property.PropertyInfo!.SetValue(row, parsed is string text ? text.Trim() : parsed);
            }
            catch (JsonException)
            {
                throw new ValidationException($"{Label(property.Name)} has an invalid value.");
            }
        }

        foreach (var property in properties.Where(p => Reference(p) != null))
        {
            if (recordId.HasValue && !input.TryGetProperty(Key(property.Name), out _))
                continue;
            var reference = Reference(property)!;
            if (property.PropertyInfo!.GetValue(row) is not int id)
            {
                if (recordId.HasValue && Copy(property, reference) is { } cleared &&
                    entity.FindProperty(cleared.Destination) is { IsNullable: true } destination)
                    destination.PropertyInfo!.SetValue(row, null);
                continue;
            }
            var target = id > 0 ? await db.FindAsync(reference.PrincipalEntityType.ClrType, [id], ct) : null;
            if (target is null)
                throw new ValidationException($"Choose a valid {Label(property.Name)}.");
            if (Copy(property, reference) is { } copy)
            {
                var value = reference.PrincipalEntityType.FindProperty(copy.Source)!.PropertyInfo!.GetValue(target);
                entity.FindProperty(copy.Destination)!.PropertyInfo!.SetValue(row, value);
            }
        }

        foreach (var property in properties)
        {
            var value = property.PropertyInfo!.GetValue(row);
            var label = Label(property.Name);
            if (!property.IsNullable && (value is null || value is string text && string.IsNullOrWhiteSpace(text) ||
                value is DateTime date && date == default))
                throw new ValidationException($"{label} is required.");
            if (value is string str && property.GetMaxLength() is int max && str.Length > max)
                throw new ValidationException($"{label} must be at most {max} characters.");
            if (value is decimal number && property.GetScale() is int scale && property.GetPrecision() is int precision &&
                (decimal.Round(number, scale) != number || Math.Abs(number) >= (decimal)Math.Pow(10, precision - scale)))
                throw new ValidationException($"{label} exceeds the allowed precision.");
        }

        if (recordId is int existingId)
        {
            if (row is Facility facility && input.TryGetProperty(Key(nameof(Facility.REquipmentCatalogueId)), out _))
            {
                var catalogue = facility.REquipmentCatalogueId is int catalogueId
                    ? await db.Set<REquipmentCatalogue>().FindAsync([catalogueId], ct)
                    : null;
                if (facility.REquipmentCatalogueId.HasValue && catalogue is null)
                    throw new ValidationException("Choose a valid equipment catalogue.");
                facility.EquipmentCatalogue = catalogue?.EquipmentCatalogue;
            }
            await ValidateUpdate(entity, row, existingId, ct);
        }

        var now = DateTime.UtcNow;
        foreach (var property in entity.GetProperties().Where(p => !Editable(p) && !p.IsPrimaryKey()))
            if (!recordId.HasValue || !property.Name.StartsWith("RowCreated"))
                property.PropertyInfo!.SetValue(row, property.ClrType == typeof(string) ? actor : now);

        if (!recordId.HasValue) db.Add(row);
        try { await db.SaveChangesAsync(ct); }
        catch (DbUpdateException e) when (e.InnerException is SqlException { Number: 547 or 2601 or 2627 })
        {
            throw new ValidationException("The record conflicts with an existing record or reference.");
        }
        return row;
    }

    private async Task ValidateUpdate(IEntityType entity, object row, int id, CancellationToken ct)
    {
        foreach (var (start, end) in new[] { ("EffectiveDate", "ExpiryDate"), ("SurveyStartDate", "SurveyEndDate"),
            ("InstallDate", "RemoveDate"), ("CommissionDate", "DecommissionDate"), ("TubularInDate", "TubularOutDate"), ("CompletionDate", "ExpiryDate") })
        {
            if (entity.FindProperty(start)?.PropertyInfo?.GetValue(row) is DateTime first &&
                entity.FindProperty(end)?.PropertyInfo?.GetValue(row) is DateTime last && last < first)
                throw new ValidationException($"{Label(end)} must be on or after {Label(start)}.");
        }

        if (row is FacilityField association && await db.Set<FacilityField>().AnyAsync(item =>
            item.FacilityFieldId != id && item.FacilityId == association.FacilityId &&
            item.FieldId == association.FieldId && item.EffectiveDate == association.EffectiveDate, ct))
            throw new ValidationException("This facility and field association already exists for the effective date.");

        if (!UniqueNames.TryGetValue(entity.ClrType, out var name)) return;
        var method = typeof(WellRecordsRepository).GetMethod(nameof(NameExists), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!;
        var duplicate = await (Task<bool>)method.MakeGenericMethod(entity.ClrType).Invoke(this,
            [entity.FindPrimaryKey()!.Properties.Single().Name, name, entity.FindProperty(name)!.PropertyInfo!.GetValue(row), id, ct])!;
        if (duplicate) throw new ValidationException($"A record with this {Label(name)} already exists.");
    }

    private Task<bool> NameExists<T>(string key, string property, string value, int id, CancellationToken ct) where T : class =>
        db.Set<T>().AnyAsync(row => EF.Property<int>(row, key) != id && EF.Property<string>(row, property) == value, ct);

    public async Task Delete(string table, int id, CancellationToken ct)
    {
        var row = await db.FindAsync(Entity(table).ClrType, [id], ct) ?? throw new KeyNotFoundException();
        db.Remove(row);
        try { await db.SaveChangesAsync(ct); }
        catch (DbUpdateException e) when (e.InnerException is SqlException { Number: 547 })
        {
            throw new ValidationException("This record is referenced by other records and cannot be deleted.");
        }
    }
}


using Microsoft.EntityFrameworkCore;
namespace OSDU.Data;
public class Asset {
 public int Id { get; set; }
 public string Name { get; set; } = "";
 public string? Description { get; set; }
 public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
}
public class OsduDbContext(DbContextOptions<OsduDbContext> options) : DbContext(options) {
 public DbSet<MasterData.Cartoreferencesystem> CartoreferencesystemRecords => Set<MasterData.Cartoreferencesystem>();
 public DbSet<MasterData.Equipment> EquipmentRecords => Set<MasterData.Equipment>();
 public DbSet<MasterData.Facility> FacilityRecords => Set<MasterData.Facility>();
 public DbSet<MasterData.Field> FieldRecords => Set<MasterData.Field>();
 public DbSet<MasterData.FlowModel> FlowModelRecords => Set<MasterData.FlowModel>();
 public DbSet<MasterData.Formation> FormationRecords => Set<MasterData.Formation>();
 public DbSet<MasterData.OrgUnit> OrgUnitRecords => Set<MasterData.OrgUnit>();
 public DbSet<MasterData.Pool> PoolRecords => Set<MasterData.Pool>();
 public DbSet<MasterData.ReportingEntity> ReportingEntityRecords => Set<MasterData.ReportingEntity>();
 public DbSet<MasterData.RCompletionType> RCompletionTypeRecords => Set<MasterData.RCompletionType>();
 public DbSet<MasterData.RCouplingType> RCouplingTypeRecords => Set<MasterData.RCouplingType>();
 public DbSet<MasterData.RDataAccessCategory> RDataAccessCategoryRecords => Set<MasterData.RDataAccessCategory>();
 public DbSet<MasterData.REquipmentCatalogue> REquipmentCatalogueRecords => Set<MasterData.REquipmentCatalogue>();
 public DbSet<MasterData.REquipmentSubType> REquipmentSubTypeRecords => Set<MasterData.REquipmentSubType>();
 public DbSet<MasterData.REquipmentType> REquipmentTypeRecords => Set<MasterData.REquipmentType>();
 public DbSet<MasterData.RFacilityType> RFacilityTypeRecords => Set<MasterData.RFacilityType>();
 public DbSet<MasterData.RFieldType> RFieldTypeRecords => Set<MasterData.RFieldType>();
 public DbSet<MasterData.ROrgUnitCategory> ROrgUnitCategoryRecords => Set<MasterData.ROrgUnitCategory>();
 public DbSet<MasterData.ROrgUnitType> ROrgUnitTypeRecords => Set<MasterData.ROrgUnitType>();
 public DbSet<MasterData.RPerforationMethod> RPerforationMethodRecords => Set<MasterData.RPerforationMethod>();
 public DbSet<MasterData.RPerforationType> RPerforationTypeRecords => Set<MasterData.RPerforationType>();
 public DbSet<MasterData.RPlotSymbol> RPlotSymbolRecords => Set<MasterData.RPlotSymbol>();
 public DbSet<MasterData.RPoolStatus> RPoolStatusRecords => Set<MasterData.RPoolStatus>();
 public DbSet<MasterData.RPoolType> RPoolTypeRecords => Set<MasterData.RPoolType>();
 public DbSet<MasterData.RReportingEntityKind> RReportingEntityKindRecords => Set<MasterData.RReportingEntityKind>();
 public DbSet<MasterData.RSource> RSourceRecords => Set<MasterData.RSource>();
 public DbSet<MasterData.RTimezone> RTimezoneRecords => Set<MasterData.RTimezone>();
 public DbSet<MasterData.RTubularType> RTubularTypeRecords => Set<MasterData.RTubularType>();
 public DbSet<MasterData.RWellClass> RWellClassRecords => Set<MasterData.RWellClass>();
 public DbSet<MasterData.RWellDatumType> RWellDatumTypeRecords => Set<MasterData.RWellDatumType>();
 public DbSet<MasterData.RWellStatus> RWellStatusRecords => Set<MasterData.RWellStatus>();
 public DbSet<MasterData.RWellStatusType> RWellStatusTypeRecords => Set<MasterData.RWellStatusType>();
 public DbSet<MasterData.Well> WellRecords => Set<MasterData.Well>();
 public DbSet<MasterData.Wellbore> WellboreRecords => Set<MasterData.Wellbore>();
 public DbSet<MasterData.WellCompletion> WellCompletionRecords => Set<MasterData.WellCompletion>();
 public DbSet<MasterData.WellPerforation> WellPerforationRecords => Set<MasterData.WellPerforation>();
 public DbSet<MasterData.WellTubular> WellTubularRecords => Set<MasterData.WellTubular>();
 public DbSet<MasterData.Zone> ZoneRecords => Set<MasterData.Zone>();
 public DbSet<Asset> Assets => Set<Asset>();
 protected override void OnModelCreating(ModelBuilder b) {
  MasterDataConfiguration.Configure(b);
  b.Entity<Asset>().ToTable("Assets");
  b.Entity<Asset>().Property(x=>x.Name).HasMaxLength(200).IsRequired();
  b.Entity<Asset>().Property(x=>x.Description).HasMaxLength(2000);
 }
}
public class AssetRepository(OsduDbContext db) {
 public Task<List<Asset>> List(CancellationToken ct) => db.Assets.AsNoTracking().OrderBy(x=>x.Id).Take(100).ToListAsync(ct);
 public Task<Asset?> Find(int id, CancellationToken ct) => db.Assets.SingleOrDefaultAsync(x=>x.Id==id,ct);
 public async Task Add(Asset asset,CancellationToken ct) { db.Assets.Add(asset); await db.SaveChangesAsync(ct); }
 public Task Save(CancellationToken ct) => db.SaveChangesAsync(ct);
 public async Task Delete(Asset asset,CancellationToken ct) { db.Assets.Remove(asset); await db.SaveChangesAsync(ct); }
}

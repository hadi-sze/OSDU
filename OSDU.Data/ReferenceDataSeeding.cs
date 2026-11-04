using Microsoft.EntityFrameworkCore;
using OSDU.Data.MasterData;
namespace OSDU.Data;
public static class ReferenceDataSeeding {
 public static DbContextOptionsBuilder UseOsduSeeding(this DbContextOptionsBuilder options) =>
  options.UseSeeding((db,_)=>Seed(db,false,CancellationToken.None).GetAwaiter().GetResult())
   .UseAsyncSeeding((db,_,ct)=>Seed(db,true,ct));
 private static async Task Seed(DbContext db,bool useAsync,CancellationToken ct) {
  await SeedTable<RFacilityType>(db,nameof(RFacilityType.FacilityType),new[]{"Pipeline","Tank","Battery","Separator","Processing Plant","Terminal","Metering Station"},useAsync,ct);
  await SeedTable<ROrgUnitType>(db,nameof(ROrgUnitType.OrgUnitType),new[]{"Country","Province","District","Area","Company","Partner"},useAsync,ct);
  await SeedTable<ROrgUnitCategory>(db,nameof(ROrgUnitCategory.OrgUnitCategory),new[]{"Area Unit","Business Unit"},useAsync,ct);
  await SeedTable<RDataAccessCategory>(db,nameof(RDataAccessCategory.DataAccessCategory),new[]{"Public","Private","Confidential"},useAsync,ct);
  await SeedTable<REquipmentCatalogue>(db,nameof(REquipmentCatalogue.EquipmentCatalogue),new[]{"Production Equipment","Measurement Equipment","Processing Equipment"},useAsync,ct);
  await SeedTable<RDirectionType>(db,nameof(RDirectionType.DirectionType),new[]{"Inlet","Outlet","Unknown"},useAsync,ct);
  await SeedTable<RCompletionType>(db,nameof(RCompletionType.CompletionType),new[]{"Perforated","Open Hole","Gravel Pack","Combination"},useAsync,ct);
  await SeedTable<RTubularType>(db,nameof(RTubularType.TubularType),new[]{"Conductor","Surface Casing","Intermediate Casing","Production Casing","Tubing","Liner"},useAsync,ct);
  await SeedTable<RCouplingType>(db,nameof(RCouplingType.CouplingType),new[]{"Threaded","Premium"},useAsync,ct);
  await SeedTable<RPoolStatus>(db,nameof(RPoolStatus.PoolStatus),new[]{"Active","Inactive","Abandoned"},useAsync,ct);
  await SeedTable<RPoolType>(db,nameof(RPoolType.PoolType),new[]{"Conventional","Oil Sands","Administrative"},useAsync,ct);
  await SeedTable<RFieldType>(db,nameof(RFieldType.FieldTypeName),new[]{"Regulatory","Locally Assigned"},useAsync,ct);
  await SeedTable<RFluidType>(db,nameof(RFluidType.FluidType),new[]{"Oil","Gas","Water","Condensate","Mud"},useAsync,ct);
  await SeedTable<RProductionMethod>(db,nameof(RProductionMethod.ProductionMethod),new[]{"Flowing","Pumping","Gas Lift","Swabbing"},useAsync,ct);
  await SeedTable<RNorthType>(db,nameof(RNorthType.NorthType),new[]{"True North","Grid North","Magnetic North"},useAsync,ct);
  await SeedTable<RWellDatumType>(db,nameof(RWellDatumType.WellDatumType),new[]{"Kelly Bushing","Ground Level","Mean Sea Level","Derrick Floor"},useAsync,ct);
  await SeedTable<RWellClass>(db,nameof(RWellClass.WellClass),new[]{"New Field Wildcat","Deeper Pool Test","Outpost","Development"},useAsync,ct);
  await SeedTable<RPerforationType>(db,nameof(RPerforationType.PerforationType),new[]{"Bullet","Jet","Combination"},useAsync,ct);
  await SeedTable<RPerforationMethod>(db,nameof(RPerforationMethod.PerforationMethod),new[]{"Perforation","Open Hole","Combination"},useAsync,ct);
  await SeedTable<REventCategory>(db,nameof(REventCategory.EventCategory),new[]{"Maintenance","Workover","Stimulation","Equipment Failure"},useAsync,ct);
  await SeedTable<REventStatus>(db,nameof(REventStatus.EventStatus),new[]{"Open","Closed"},useAsync,ct);
  await SeedTable<RDownTimeType>(db,nameof(RDownTimeType.DownTimeType),new[]{"Planned","Unplanned","External"},useAsync,ct);
  await SeedTable<RReportingEntityKind>(db,nameof(RReportingEntityKind.ReportingEntityKind),new[]{"Well","Wellbore","Completion","Facility","Field","Pool"},useAsync,ct);
  await SeedTable<RReportingFacilityKind>(db,nameof(RReportingFacilityKind.ReportingFacilityKind),new[]{"Well","Facility"},useAsync,ct);
  await SeedTable<RScenarioType>(db,nameof(RScenarioType.ScenarioType),new[]{"Base","Alternate"},useAsync,ct);
  await SeedTable<RScenarioSource>(db,nameof(RScenarioSource.ScenarioSource),new[]{"Manual","Imported","Calculated"},useAsync,ct);
  await SeedTable<RSource>(db,nameof(RSource.SourceName),new[]{"Manual Entry","Import"},useAsync,ct);
  await SeedTable<RSurveyType>(db,nameof(RSurveyType.SurveyType),new[]{"Gyroscopic","Magnetic","MWD","Totco","Acid Bottle"},useAsync,ct);
  await SeedTable<RTimezone>(db,nameof(RTimezone.Timezone),new[]{"UTC"},useAsync,ct);
  await SeedTable<RWellStatusType>(db,nameof(RWellStatusType.WellStatusType),new[]{"Construction","Operating","Producing","Abandonment"},useAsync,ct);
  await SeedTable<RAlarmLevel>(db,nameof(RAlarmLevel.AlarmLevel),new[]{"Low","Medium","High","Critical"},useAsync,ct);
  await SeedTable<RAlarmType>(db,nameof(RAlarmType.AlarmType),new[]{"Threshold","Rate of Change"},useAsync,ct);
 }
 private static async Task SeedTable<T>(DbContext db,string property,string[] values,bool useAsync,CancellationToken ct) where T:class,new() {
  var entity=db.Model.FindEntityType(typeof(T))!;
  var table=entity.GetTableName()!;
  // A downgrade may remove seed tables; skip absent tables.
  var exists=db.Database.SqlQuery<int>($"SELECT CASE WHEN OBJECT_ID({table}, 'U') IS NULL THEN 0 ELSE 1 END AS [Value]");
  if((useAsync?await exists.SingleAsync(ct):exists.Single())==0)return;
  var query=db.Set<T>().Select(e=>EF.Property<string>(e,property));
  var current=useAsync?await query.ToListAsync(ct):query.ToList();
  var known=new HashSet<string>(current,StringComparer.OrdinalIgnoreCase);
  foreach(var value in values) {
   if(!known.Add(value))continue;
   var row=new T();
   typeof(T).GetProperty(property)!.SetValue(row,value);
   typeof(T).GetProperty("IsActive")?.SetValue(row,true);
   typeof(T).GetProperty("RowCreatedBy")?.SetValue(row,"OSDU.Seed");
   typeof(T).GetProperty("RowCreatedDate")?.SetValue(row,DateTime.UtcNow);
   db.Add(row);
  }
  if(useAsync)await db.SaveChangesAsync(ct);else db.SaveChanges();
 }
}

using OSDU.Data;
using OSDU.Data.MasterData;
namespace OSDU.Business;
public class FacilityService(FacilityRepository repository) {
 private static void CheckDates(DateTime? first,DateTime? last,string message) { if(first.HasValue && last.HasValue && last<first) throw new System.ComponentModel.DataAnnotations.ValidationException(message); }
 public Task<List<Facility>> List(CancellationToken ct)=>repository.List(ct);
 public Task<object> Lookups(CancellationToken ct)=>repository.Lookups(ct);
 public async Task<Facility> Create(FacilityInput input,string actor,CancellationToken ct) {
  CheckDates(input.ConstructedDate,input.ActiveDate,"Activation cannot precede construction.");
  CheckDates(input.ActiveDate,input.AbandonedDate,"Abandonment cannot precede activation.");
  CheckDates(input.OnProductionDate,input.LastProductionDate,"Last production cannot precede first production.");
  CheckDates(input.OnInjectionDate,input.LastInjectionDate,"Last injection cannot precede first injection.");
  foreach(var pair in new[]{(input.Depth,input.DepthUom),(input.Elevation,input.ElevationUom),(input.FacilityDiameter,input.FacilityDiameterUom)}) {
   if(pair.Item1.HasValue && pair.Item2 is not ("m" or "ft" or "in")) throw new System.ComponentModel.DataAnnotations.ValidationException("Choose a unit for every entered dimension.");
  }
  if(input.FacilityDiameter<0 || input.Depth<0) throw new System.ComponentModel.DataAnnotations.ValidationException("Depth and diameter cannot be negative.");
  var f=new Facility {
   DepthUom=input.DepthUom,ElevationUom=input.ElevationUom,FacilityDiameterUom=input.FacilityDiameterUom,
   FacilityName=input.FacilityName,
   FacilityTypeId=input.FacilityTypeId,
   FacilityType=input.FacilityType,
   IsActive=input.IsActive,
   ConstructedDate=input.ConstructedDate,
   ActiveDate=input.ActiveDate,
   AbandonedDate=input.AbandonedDate,
   OffshoreInd=input.OffshoreInd,
   REquipmentCatalogueId=input.REquipmentCatalogueId,
   EquipmentCatalogue=input.EquipmentCatalogue,
   XCoordinate=input.XCoordinate,
   YCoordinate=input.YCoordinate,
   CrsId=input.CrsId,
   CrsName=input.CrsName,
   CurrentOperator=input.CurrentOperator,
   Depth=input.Depth,
   Elevation=input.Elevation,
   FacilityDiameter=input.FacilityDiameter,
   FacilityFunction=input.FacilityFunction,
   FacilityNo=input.FacilityNo,
   FacilityShortName=input.FacilityShortName,
   FacilityLongName=input.FacilityLongName,
   LastInjectionDate=input.LastInjectionDate,
   LastProductionDate=input.LastProductionDate,
   LastReportedDate=input.LastReportedDate,
   OnInjectionDate=input.OnInjectionDate,
   OnProductionDate=input.OnProductionDate,
   Remark=input.Remark,
   IsVirtual=input.IsVirtual,
   Uidref=input.Uidref,
   RDataAccessCategoryId=input.RDataAccessCategoryId,
   RowCreatedBy=actor,RowChangedBy=actor,RowCreatedDate=DateTime.UtcNow,RowChangedDate=DateTime.UtcNow
  };
  f.FacilityName=f.FacilityName.Trim();
  await repository.Add(f,ct);return f;
 }
}

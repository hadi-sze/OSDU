using System.ComponentModel.DataAnnotations;
using OSDU.Data;
using OSDU.Data.MasterData;
namespace OSDU.Business;
public class WellInput {
 [Required][StringLength(50)] public string Uwi {get;set;}="";
 [Required][StringLength(50)] public string WellName {get;set;}="";
 [StringLength(255)] public string? WellAliasName {get;set;}
  public int? FieldId {get;set;}
 [StringLength(100)] public string? FieldName {get;set;}
  public bool OffshoreInd {get;set;}
  public bool IsActive {get;set;}=true;
 [StringLength(255)] public string? WellOwner {get;set;}
  public DateTime? SpudDate {get;set;}
 [StringLength(40)] public string? SpudDateTz {get;set;}
  public int? RTimezoneId {get;set;}
  public DateTime? CompletionDate {get;set;}
  public DateTime? ProductionStartDate {get;set;}
  public decimal? XCoordinate {get;set;}
  public decimal? YCoordinate {get;set;}
  public int? CrsId {get;set;}
 [StringLength(50)] public string? CrsName {get;set;}
  public int? CurrentClassId {get;set;}
 [StringLength(50)] public string? WellClass {get;set;}
  public decimal? DeepestDepth {get;set;}
  public decimal? MaxTvd {get;set;}
  public int? DepthDatumId {get;set;}
 [StringLength(50)] public string? DepthDatum {get;set;}
  public decimal? DepthDatumElev {get;set;}
  public decimal? GroundElev {get;set;}
  public decimal? BottomHoleXLon {get;set;}
  public decimal? BottomHoleYLat {get;set;}
  public DateTime? AbandonmentDate {get;set;}
  public DateTime? ExpiryDate {get;set;}
  public bool? FaultedInd {get;set;}
  public DateTime? FinalDrillDate {get;set;}
  public decimal? LogTd {get;set;}
  public decimal? NetPay {get;set;}
 [StringLength(40)] public string? Operator {get;set;}
 [StringLength(40)] public string? PlotName {get;set;}
  public decimal? PlugbackDepth {get;set;}
  public int? RWellProfileId {get;set;}
 [StringLength(60)] public string? WellProfile {get;set;}
  public decimal? WaterAcousticVel {get;set;}
  public decimal? WaterDepth {get;set;}
 [StringLength(40)] public string? WaterDepthDatum {get;set;}
  public bool? IsVirtual {get;set;}
  public int? RPlotSymbolId {get;set;}
 [StringLength(64)] public string? Uidref {get;set;}
  public int? RDataAccessCategoryId {get;set;}
}
public class WellService(WellRepository repository) {
 public Task<object> Page(int page,int size,string? search,string? status,string? sort,bool desc,CancellationToken ct)=>repository.Page(page,size,search,status,sort,desc,ct);
 public Task<List<Well>> List(CancellationToken ct)=>repository.List(ct);
 public Task<object> Lookups(CancellationToken ct)=>repository.Lookups(ct);
 public async Task<Well> Create(WellInput input,string actor,CancellationToken ct) {
 var row=new Well {
Uwi=input.Uwi.Trim(),
WellName=input.WellName.Trim(),
WellAliasName=input.WellAliasName?.Trim(),
FieldId=input.FieldId,
FieldName=input.FieldName?.Trim(),
OffshoreInd=input.OffshoreInd,
IsActive=input.IsActive,
WellOwner=input.WellOwner?.Trim(),
SpudDate=input.SpudDate,
SpudDateTz=input.SpudDateTz?.Trim(),
RTimezoneId=input.RTimezoneId,
CompletionDate=input.CompletionDate,
ProductionStartDate=input.ProductionStartDate,
XCoordinate=input.XCoordinate,
YCoordinate=input.YCoordinate,
CrsId=input.CrsId,
CrsName=input.CrsName?.Trim(),
CurrentClassId=input.CurrentClassId,
WellClass=input.WellClass?.Trim(),
DeepestDepth=input.DeepestDepth,
MaxTvd=input.MaxTvd,
DepthDatumId=input.DepthDatumId,
DepthDatum=input.DepthDatum?.Trim(),
DepthDatumElev=input.DepthDatumElev,
GroundElev=input.GroundElev,
BottomHoleXLon=input.BottomHoleXLon,
BottomHoleYLat=input.BottomHoleYLat,
AbandonmentDate=input.AbandonmentDate,
ExpiryDate=input.ExpiryDate,
FaultedInd=input.FaultedInd,
FinalDrillDate=input.FinalDrillDate,
LogTd=input.LogTd,
NetPay=input.NetPay,
Operator=input.Operator?.Trim(),
PlotName=input.PlotName?.Trim(),
PlugbackDepth=input.PlugbackDepth,
RWellProfileId=input.RWellProfileId,
WellProfile=input.WellProfile?.Trim(),
WaterAcousticVel=input.WaterAcousticVel,
WaterDepth=input.WaterDepth,
WaterDepthDatum=input.WaterDepthDatum?.Trim(),
IsVirtual=input.IsVirtual,
RPlotSymbolId=input.RPlotSymbolId,
Uidref=input.Uidref?.Trim(),
RDataAccessCategoryId=input.RDataAccessCategoryId,RowCreatedBy=actor,RowChangedBy=actor,RowCreatedDate=DateTime.UtcNow,RowChangedDate=DateTime.UtcNow};
 await repository.Add(row,ct);return row;
 }}
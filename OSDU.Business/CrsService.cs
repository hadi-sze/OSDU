using System.ComponentModel.DataAnnotations;
using OSDU.Data;
using OSDU.Data.MasterData;
namespace OSDU.Business;
public class CrsInput {
 [Required][StringLength(50)] public string CrsName {get;set;}="";
 [StringLength(50)] public string? CrsType {get;set;}
 [StringLength(50)] public string? GeodeticSource {get;set;}
 [StringLength(50)] public string? ProjectionType {get;set;}
  public bool IsActive {get;set;}=true;
 [StringLength(255)] public string? LongName {get;set;}
 [StringLength(30)] public string? ShortName {get;set;}
 [StringLength(2000)] public string? Remark {get;set;}
}
public class CrsService(CrsRepository repository) {
 public Task<List<Cartoreferencesystem>> List(CancellationToken ct)=>repository.List(ct);
 public Task<object> Lookups(CancellationToken ct)=>repository.Lookups(ct);
 public async Task<Cartoreferencesystem> Create(CrsInput input,string actor,CancellationToken ct) {
 var row=new Cartoreferencesystem {
CrsName=input.CrsName.Trim(),
CrsType=input.CrsType?.Trim(),
GeodeticSource=input.GeodeticSource?.Trim(),
ProjectionType=input.ProjectionType?.Trim(),
IsActive=input.IsActive,
LongName=input.LongName?.Trim(),
ShortName=input.ShortName?.Trim(),
Remark=input.Remark?.Trim(),RowCreatedBy=actor,RowChangedBy=actor,RowCreatedDate=DateTime.UtcNow,RowChangedDate=DateTime.UtcNow};
 await repository.Add(row,ct);return row;
 }}
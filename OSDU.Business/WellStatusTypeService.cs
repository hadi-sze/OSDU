using System.ComponentModel.DataAnnotations;
using OSDU.Data;
using OSDU.Data.MasterData;
namespace OSDU.Business;
public class WellStatusTypeInput {
 [Required,StringLength(60)] public string WellStatusType {get;set;}="";
 [StringLength(255)] public string? LongName {get;set;}
 [StringLength(30)] public string? ShortName {get;set;}
 [StringLength(2000)] public string? Remark {get;set;}
 public int? RSourceId {get;set;}
 public bool IsActive {get;set;}=true;
}
public class WellStatusTypeService(WellStatusTypeRepository repository) {
 public Task<List<RWellStatusType>> List(CancellationToken ct)=>repository.List(ct);
 public Task<object> Sources(CancellationToken ct)=>repository.Sources(ct);
 public async Task<RWellStatusType> Create(WellStatusTypeInput input,string actor,CancellationToken ct) {
  var row=new RWellStatusType {WellStatusType=input.WellStatusType.Trim(),LongName=input.LongName?.Trim(),ShortName=input.ShortName?.Trim(),Remark=input.Remark?.Trim(),RSourceId=input.RSourceId,IsActive=input.IsActive,RowCreatedBy=actor,RowChangedBy=actor,RowCreatedDate=DateTime.UtcNow,RowChangedDate=DateTime.UtcNow};
  await repository.Add(row,ct);return row;
 }
}

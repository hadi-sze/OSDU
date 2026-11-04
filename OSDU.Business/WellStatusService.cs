using System.ComponentModel.DataAnnotations;
using OSDU.Data;
using OSDU.Data.MasterData;
namespace OSDU.Business;
public class WellStatusInput {
 [Required,StringLength(60)] public string WellStatus {get;set;}="";
 [StringLength(255)] public string? LongName {get;set;}
 [StringLength(30)] public string? ShortName {get;set;}
 [StringLength(2000)] public string? Remark {get;set;}
 public int? RSourceId {get;set;}
 [Range(1,int.MaxValue)] public int RWellStatusTypeId {get;set;}
 public bool IsActive {get;set;}=true;
}
public class WellStatusService(WellStatusRepository repository) {
 public Task<List<RWellStatus>> List(CancellationToken ct)=>repository.List(ct);
 public Task<object> Types(CancellationToken ct)=>repository.Types(ct);
 public Task<object> Sources(CancellationToken ct)=>repository.Sources(ct);
 public async Task<RWellStatus> Create(WellStatusInput input,string actor,CancellationToken ct) {
  var row=new RWellStatus {WellStatus=input.WellStatus.Trim(),RWellStatusTypeId=input.RWellStatusTypeId,LongName=input.LongName?.Trim(),ShortName=input.ShortName?.Trim(),Remark=input.Remark?.Trim(),RSourceId=input.RSourceId,IsActive=input.IsActive,RowCreatedBy=actor,RowChangedBy=actor,RowCreatedDate=DateTime.UtcNow,RowChangedDate=DateTime.UtcNow};
  await repository.Add(row,ct);return row;
 }
}

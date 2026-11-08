using System.ComponentModel.DataAnnotations;
using OSDU.Data;
using OSDU.Data.MasterData;
namespace OSDU.Business;
public class PoolStatusInput {
 [StringLength(255)] public string? LongName {get;set;}
 [StringLength(30)] public string? ShortName {get;set;}
 [StringLength(2000)] public string? Remark {get;set;}
  public bool IsActive {get;set;}=true;
 [Required][StringLength(50)] public string PoolStatus {get;set;}="";
}
public class PoolStatusService(PoolStatusRepository repository) {
 public Task<List<RPoolStatus>> List(CancellationToken ct)=>repository.List(ct);
 public async Task<RPoolStatus> Create(PoolStatusInput input,string actor,CancellationToken ct) {
 var row=new RPoolStatus {
LongName=input.LongName?.Trim(),
ShortName=input.ShortName?.Trim(),
Remark=input.Remark?.Trim(),
IsActive=input.IsActive,
PoolStatus=input.PoolStatus.Trim(),RowCreatedBy=actor,RowChangedBy=actor,RowCreatedDate=DateTime.UtcNow,RowChangedDate=DateTime.UtcNow};
 await repository.Add(row,ct);return row;
 }}

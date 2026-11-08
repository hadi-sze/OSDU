using System.ComponentModel.DataAnnotations;
using OSDU.Data;
using OSDU.Data.MasterData;
namespace OSDU.Business;
public class PoolTypeInput {
 [StringLength(255)] public string? LongName {get;set;}
 [StringLength(30)] public string? ShortName {get;set;}
 [StringLength(2000)] public string? Remark {get;set;}
  public bool IsActive {get;set;}=true;
 [Required][StringLength(50)] public string PoolType {get;set;}="";
}
public class PoolTypeService(PoolTypeRepository repository) {
 public Task<List<RPoolType>> List(CancellationToken ct)=>repository.List(ct);
 public async Task<RPoolType> Create(PoolTypeInput input,string actor,CancellationToken ct) {
 var row=new RPoolType {
LongName=input.LongName?.Trim(),
ShortName=input.ShortName?.Trim(),
Remark=input.Remark?.Trim(),
IsActive=input.IsActive,
PoolType=input.PoolType.Trim(),RowCreatedBy=actor,RowChangedBy=actor,RowCreatedDate=DateTime.UtcNow,RowChangedDate=DateTime.UtcNow};
 await repository.Add(row,ct);return row;
 }}

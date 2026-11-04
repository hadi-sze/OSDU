using System.ComponentModel.DataAnnotations;
using OSDU.Data;
using OSDU.Data.MasterData;
namespace OSDU.Business;
public class PoolInput {
 [Required][StringLength(100)] public string PoolName {get;set;}="";
  public bool IsActive {get;set;}=true;
  public DateTime? DiscoveryDate {get;set;}
  public DateTime? EffectiveDate {get;set;}
  public DateTime? ExpiryDate {get;set;}
  public int? FieldId {get;set;}
 [StringLength(100)] public string? FieldName {get;set;}
 [StringLength(20)] public string? PoolCode {get;set;}
 [StringLength(12)] public string? PoolNameAbbreviation {get;set;}
  public int? RPoolStatusId {get;set;}
 [StringLength(50)] public string? PoolStatus {get;set;}
  public int? RPoolTypeId {get;set;}
 [StringLength(50)] public string? PoolType {get;set;}
  public int? RDataAccessCategoryId {get;set;}
}
public class PoolService(PoolRepository repository) {
 public Task<List<Pool>> List(CancellationToken ct)=>repository.List(ct);
 public Task<object> Lookups(CancellationToken ct)=>repository.Lookups(ct);
 public async Task<Pool> Create(PoolInput input,string actor,CancellationToken ct) {
 var row=new Pool {
PoolName=input.PoolName.Trim(),
IsActive=input.IsActive,
DiscoveryDate=input.DiscoveryDate,
EffectiveDate=input.EffectiveDate,
ExpiryDate=input.ExpiryDate,
FieldId=input.FieldId,
FieldName=input.FieldName?.Trim(),
PoolCode=input.PoolCode?.Trim(),
PoolNameAbbreviation=input.PoolNameAbbreviation?.Trim(),
RPoolStatusId=input.RPoolStatusId,
PoolStatus=input.PoolStatus?.Trim(),
RPoolTypeId=input.RPoolTypeId,
PoolType=input.PoolType?.Trim(),
RDataAccessCategoryId=input.RDataAccessCategoryId,RowCreatedBy=actor,RowChangedBy=actor,RowCreatedDate=DateTime.UtcNow,RowChangedDate=DateTime.UtcNow};
 await repository.Add(row,ct);return row;
 }}
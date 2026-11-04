using System.ComponentModel.DataAnnotations;
using OSDU.Data;
using OSDU.Data.MasterData;
namespace OSDU.Business;
public class FacilityFieldInput {
 [Range(1,int.MaxValue)] public int FacilityId {get;set;}
 [Range(1,int.MaxValue)] public int FieldId {get;set;}
 public DateTime? EffectiveDate {get;set;}
 public DateTime? ExpiryDate {get;set;}
 [StringLength(2000)] public string? Remark {get;set;}
 public bool IsActive {get;set;}=true;
}
public class FacilityFieldService(FacilityFieldRepository repository) {
 public Task<object> List(CancellationToken ct)=>repository.List(ct);
 public Task<object> Lookups(CancellationToken ct)=>repository.Lookups(ct);
 public async Task<FacilityField> Create(FacilityFieldInput input,string actor,CancellationToken ct) {
 var row=new FacilityField {FacilityId=input.FacilityId,FieldId=input.FieldId,EffectiveDate=input.EffectiveDate,ExpiryDate=input.ExpiryDate,Remark=input.Remark?.Trim(),IsActive=input.IsActive,RowCreatedBy=actor,RowChangedBy=actor,RowCreatedDate=DateTime.UtcNow,RowChangedDate=DateTime.UtcNow};
 await repository.Add(row,ct);return row;
 }}
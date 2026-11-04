using System.ComponentModel.DataAnnotations;
using OSDU.Data;
using OSDU.Data.MasterData;
namespace OSDU.Business;
public class FieldTypeInput {
 [StringLength(50)] public string? DisplayName {get;set;}
 [StringLength(255)] public string? LongName {get;set;}
 [StringLength(30)] public string? ShortName {get;set;}
 [StringLength(15)] public string? Abbreviation {get;set;}
 [StringLength(15)] public string? ColorCode {get;set;}
 [StringLength(2000)] public string? Remark {get;set;}
  public bool IsActive {get;set;}=true;
  public DateTime? EffectiveDate {get;set;}
  public DateTime? ExpiryDate {get;set;}
 [StringLength(50)] public string? SourceName {get;set;}
 [Required][StringLength(50)] public string FieldTypeName {get;set;}="";
}
public class FieldTypeService(FieldTypeRepository repository) {
 public Task<List<RFieldType>> List(CancellationToken ct)=>repository.List(ct);
 public Task<object> Lookups(CancellationToken ct)=>repository.Lookups(ct);
 public async Task<RFieldType> Create(FieldTypeInput input,string actor,CancellationToken ct) {
 var row=new RFieldType {
DisplayName=input.DisplayName?.Trim(),
LongName=input.LongName?.Trim(),
ShortName=input.ShortName?.Trim(),
Abbreviation=input.Abbreviation?.Trim(),
ColorCode=input.ColorCode?.Trim(),
Remark=input.Remark?.Trim(),
IsActive=input.IsActive,
EffectiveDate=input.EffectiveDate,
ExpiryDate=input.ExpiryDate,
SourceName=input.SourceName?.Trim(),
FieldTypeName=input.FieldTypeName.Trim(),RowCreatedBy=actor,RowChangedBy=actor,RowCreatedDate=DateTime.UtcNow,RowChangedDate=DateTime.UtcNow};
 await repository.Add(row,ct);return row;
 }}
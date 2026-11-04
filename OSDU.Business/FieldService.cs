using System.ComponentModel.DataAnnotations;
using OSDU.Data;
using OSDU.Data.MasterData;
namespace OSDU.Business;
public class FieldInput {
 [Required][StringLength(100)] public string FieldName {get;set;}="";
 [StringLength(50)] public string? FieldTypeName {get;set;}
 [StringLength(20)] public string? FieldAbbreviation {get;set;}
  public decimal? XCoordinate {get;set;}
  public decimal? YCoordinate {get;set;}
  public int? CrsId {get;set;}
 [StringLength(50)] public string? CrsName {get;set;}
 [StringLength(2000)] public string? Remark {get;set;}
  public bool IsActive {get;set;}=true;
 [StringLength(40)] public string? SourceName {get;set;}
  public int? RFieldTypeId {get;set;}
 [StringLength(64)] public string? Uidref {get;set;}
  public int? RDataAccessCategoryId {get;set;}
}
public class FieldService(FieldRepository repository) {
 public Task<List<Field>> List(CancellationToken ct)=>repository.List(ct);
 public Task<object> Lookups(CancellationToken ct)=>repository.Lookups(ct);
 public async Task<Field> Create(FieldInput input,string actor,CancellationToken ct) {
 var row=new Field {
FieldName=input.FieldName.Trim(),
FieldTypeName=input.FieldTypeName?.Trim(),
FieldAbbreviation=input.FieldAbbreviation?.Trim(),
XCoordinate=input.XCoordinate,
YCoordinate=input.YCoordinate,
CrsId=input.CrsId,
CrsName=input.CrsName?.Trim(),
Remark=input.Remark?.Trim(),
IsActive=input.IsActive,
SourceName=input.SourceName?.Trim(),
RFieldTypeId=input.RFieldTypeId,
Uidref=input.Uidref?.Trim(),
RDataAccessCategoryId=input.RDataAccessCategoryId,RowCreatedBy=actor,RowChangedBy=actor,RowCreatedDate=DateTime.UtcNow,RowChangedDate=DateTime.UtcNow};
 await repository.Add(row,ct);return row;
 }}
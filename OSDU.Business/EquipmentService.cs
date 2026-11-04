using System.ComponentModel.DataAnnotations;
using OSDU.Data;
using OSDU.Data.MasterData;
namespace OSDU.Business;
public class EquipmentInput {
  public DateTime? CommissionDate {get;set;}
  public DateTime? DecommissionDate {get;set;}
 [Required][StringLength(40)] public string EquipmentName {get;set;}="";
 [StringLength(40)] public string? EquipmentSubType {get;set;}
 [StringLength(40)] public string? EquipmentType {get;set;}
  public bool IsActive {get;set;}=true;
  public int? REquipmentSubTypeId {get;set;}
  public int? REquipmentTypeId {get;set;}
 [StringLength(2000)] public string? Remark {get;set;}
 [StringLength(40)] public string? EquipmentAliasName {get;set;}
  public int? SerialNum {get;set;}
  public int? ManufacturerBaId {get;set;}
  public int? RDataAccessCategoryId {get;set;}
}
public class EquipmentService(EquipmentRepository repository) {
 public Task<List<Equipment>> List(CancellationToken ct)=>repository.List(ct);
 public Task<object> Lookups(CancellationToken ct)=>repository.Lookups(ct);
 public async Task<Equipment> Create(EquipmentInput input,string actor,CancellationToken ct) {
 var row=new Equipment {
CommissionDate=input.CommissionDate,
DecommissionDate=input.DecommissionDate,
EquipmentName=input.EquipmentName.Trim(),
EquipmentSubType=input.EquipmentSubType?.Trim(),
EquipmentType=input.EquipmentType?.Trim(),
IsActive=input.IsActive,
REquipmentSubTypeId=input.REquipmentSubTypeId,
REquipmentTypeId=input.REquipmentTypeId,
Remark=input.Remark?.Trim(),
EquipmentAliasName=input.EquipmentAliasName?.Trim(),
SerialNum=input.SerialNum,
ManufacturerBaId=input.ManufacturerBaId,
RDataAccessCategoryId=input.RDataAccessCategoryId,RowCreatedBy=actor,RowChangedBy=actor,RowCreatedDate=DateTime.UtcNow,RowChangedDate=DateTime.UtcNow};
 await repository.Add(row,ct);return row;
 }}
using System.ComponentModel.DataAnnotations;
using OSDU.Data;
using OSDU.Data.MasterData;
namespace OSDU.Business;
public class OrganizationUnitInput {
 [Required][StringLength(255)] public string OrgUnitName {get;set;}="";
[Range(1,int.MaxValue)] public int ROrgUnitTypeId {get;set;}
  public int? ROrgUnitCategoryId {get;set;}
 [StringLength(2000)] public string? Remark {get;set;}
  public bool IsActive {get;set;}=true;
 [StringLength(40)] public string? OrgUnitShortName {get;set;}
 [StringLength(15)] public string? OrgUnitAbberivation {get;set;}
}
public class OrganizationUnitService(OrganizationUnitRepository repository) {
 public Task<List<OrgUnit>> List(CancellationToken ct)=>repository.List(ct);
 public Task<object> Lookups(CancellationToken ct)=>repository.Lookups(ct);
 public async Task<OrgUnit> Create(OrganizationUnitInput input,string actor,CancellationToken ct) {
 var row=new OrgUnit {
OrgUnitName=input.OrgUnitName.Trim(),
ROrgUnitTypeId=input.ROrgUnitTypeId,
ROrgUnitCategoryId=input.ROrgUnitCategoryId,
Remark=input.Remark?.Trim(),
IsActive=input.IsActive,
OrgUnitShortName=input.OrgUnitShortName?.Trim(),
OrgUnitAbberivation=input.OrgUnitAbberivation?.Trim(),RowCreatedBy=actor,RowChangedBy=actor,RowCreatedDate=DateTime.UtcNow,RowChangedDate=DateTime.UtcNow};
 await repository.Add(row,ct);return row;
 }}
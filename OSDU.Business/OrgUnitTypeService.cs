using System.ComponentModel.DataAnnotations;
using OSDU.Data;
using OSDU.Data.MasterData;
namespace OSDU.Business;
public class OrgUnitTypeInput {
 [Required,StringLength(50)] public string OrgUnitType {get;set;}="";
 [StringLength(255)] public string? LongName {get;set;}
 [StringLength(30)] public string? ShortName {get;set;}
 [StringLength(2000)] public string? Remark {get;set;}
 public bool IsActive {get;set;}=true;
}
public class OrgUnitTypeService(OrgUnitTypeRepository repository) {
 public Task<List<ROrgUnitType>> List(CancellationToken ct)=>repository.List(ct);
 public async Task<ROrgUnitType> Create(OrgUnitTypeInput input,string actor,CancellationToken ct) {
  var row=new ROrgUnitType {OrgUnitType=input.OrgUnitType.Trim(),LongName=input.LongName?.Trim(),ShortName=input.ShortName?.Trim(),Remark=input.Remark?.Trim(),IsActive=input.IsActive,RowCreatedBy=actor,RowChangedBy=actor,RowCreatedDate=DateTime.UtcNow,RowChangedDate=DateTime.UtcNow};
  await repository.Add(row,ct);return row;
 }
}
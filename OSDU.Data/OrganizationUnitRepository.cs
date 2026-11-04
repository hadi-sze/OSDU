using Microsoft.EntityFrameworkCore;
using OSDU.Data.MasterData;
using System.ComponentModel.DataAnnotations;
namespace OSDU.Data;
public class OrganizationUnitRepository(OsduDbContext db) {
 public Task<List<OrgUnit>> List(CancellationToken ct)=>db.Set<OrgUnit>().AsNoTracking().OrderBy(x=>x.OrgUnitName).ToListAsync(ct);
 public async Task<object> Lookups(CancellationToken ct) {
 var result=new Dictionary<string,object>();
 result["rOrgUnitTypeId"]=await db.Set<ROrgUnitType>().AsNoTracking().OrderBy(x=>x.OrgUnitType).Select(x=>new{id=x.ROrgUnitTypeId,label=x.OrgUnitType}).ToListAsync(ct);
 result["rOrgUnitCategoryId"]=await db.Set<ROrgUnitCategory>().AsNoTracking().OrderBy(x=>x.OrgUnitCategory).Select(x=>new{id=x.ROrgUnitCategoryId,label=x.OrgUnitCategory}).ToListAsync(ct);
return result; }
 public async Task Add(OrgUnit row,CancellationToken ct) {
 if(string.IsNullOrWhiteSpace(row.OrgUnitName))throw new ValidationException("Name is required.");
 if(await db.Set<OrgUnit>().AnyAsync(x=>x.OrgUnitName==row.OrgUnitName,ct))throw new ValidationException("A record with this name already exists.");
 if(row.ROrgUnitTypeId is int ROrgUnitTypeIdValue&&!await db.Set<ROrgUnitType>().AnyAsync(x=>x.ROrgUnitTypeId==ROrgUnitTypeIdValue,ct))throw new ValidationException("Choose a valid ROrgUnitTypeId.");
 if(row.ROrgUnitCategoryId is int ROrgUnitCategoryIdValue&&!await db.Set<ROrgUnitCategory>().AnyAsync(x=>x.ROrgUnitCategoryId==ROrgUnitCategoryIdValue,ct))throw new ValidationException("Choose a valid ROrgUnitCategoryId.");
db.Add(row);await db.SaveChangesAsync(ct); }}
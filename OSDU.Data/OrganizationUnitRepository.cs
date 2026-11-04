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
 public Task<OrgUnit?> Find(int id,CancellationToken ct)=>db.Set<OrgUnit>().SingleOrDefaultAsync(x=>x.OrgUnitId==id,ct);
 public async Task<bool> Delete(int id,CancellationToken ct) {
 var row=await Find(id,ct);if(row is null)return false;
 db.Remove(row);
 try {await db.SaveChangesAsync(ct);}catch(DbUpdateException e) when(e.InnerException is Microsoft.Data.SqlClient.SqlException sql && sql.Number==547){throw new ValidationException("This organization unit is referenced by other records and cannot be deleted.");}
 return true;
 }
 public async Task Add(OrgUnit row,CancellationToken ct) {
 if(string.IsNullOrWhiteSpace(row.OrgUnitName))throw new ValidationException("Name is required.");
 if(await db.Set<OrgUnit>().AnyAsync(x=>x.OrgUnitName==row.OrgUnitName&&x.OrgUnitId!=row.OrgUnitId,ct))throw new ValidationException("A record with this name already exists.");
 if(row.ROrgUnitTypeId is int ROrgUnitTypeIdValue&&!await db.Set<ROrgUnitType>().AnyAsync(x=>x.ROrgUnitTypeId==ROrgUnitTypeIdValue,ct))throw new ValidationException("Choose a valid ROrgUnitTypeId.");
 if(row.ROrgUnitCategoryId is int ROrgUnitCategoryIdValue&&!await db.Set<ROrgUnitCategory>().AnyAsync(x=>x.ROrgUnitCategoryId==ROrgUnitCategoryIdValue,ct))throw new ValidationException("Choose a valid ROrgUnitCategoryId.");
if(row.OrgUnitId==0)db.Add(row);await db.SaveChangesAsync(ct); }}
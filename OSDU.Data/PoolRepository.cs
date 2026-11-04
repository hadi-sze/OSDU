using Microsoft.EntityFrameworkCore;
using OSDU.Data.MasterData;
using System.ComponentModel.DataAnnotations;
namespace OSDU.Data;
public class PoolRepository(OsduDbContext db) {
 public Task<List<Pool>> List(CancellationToken ct)=>db.Set<Pool>().AsNoTracking().OrderBy(x=>x.PoolName).ToListAsync(ct);
 public async Task<object> Lookups(CancellationToken ct) {
 var result=new Dictionary<string,object>();
 result["fieldId"]=await db.Set<Field>().AsNoTracking().OrderBy(x=>x.FieldName).Select(x=>new{id=x.FieldId,label=x.FieldName}).ToListAsync(ct);
 result["rPoolStatusId"]=await db.Set<RPoolStatus>().AsNoTracking().OrderBy(x=>x.PoolStatus).Select(x=>new{id=x.RPoolStatusId,label=x.PoolStatus}).ToListAsync(ct);
 result["rPoolTypeId"]=await db.Set<RPoolType>().AsNoTracking().OrderBy(x=>x.PoolType).Select(x=>new{id=x.RPoolTypeId,label=x.PoolType}).ToListAsync(ct);
 result["rDataAccessCategoryId"]=await db.Set<RDataAccessCategory>().AsNoTracking().OrderBy(x=>x.DataAccessCategory).Select(x=>new{id=x.RDataAccessCategoryId,label=x.DataAccessCategory}).ToListAsync(ct);
return result; }
 public async Task Add(Pool row,CancellationToken ct) {
 if(string.IsNullOrWhiteSpace(row.PoolName))throw new ValidationException("Name is required.");
 if(await db.Set<Pool>().AnyAsync(x=>x.PoolName==row.PoolName,ct))throw new ValidationException("A record with this name already exists.");
 if(row.FieldId is int FieldIdValue&&!await db.Set<Field>().AnyAsync(x=>x.FieldId==FieldIdValue,ct))throw new ValidationException("Choose a valid FieldId.");
 if(row.RPoolStatusId is int RPoolStatusIdValue&&!await db.Set<RPoolStatus>().AnyAsync(x=>x.RPoolStatusId==RPoolStatusIdValue,ct))throw new ValidationException("Choose a valid RPoolStatusId.");
 if(row.RPoolTypeId is int RPoolTypeIdValue&&!await db.Set<RPoolType>().AnyAsync(x=>x.RPoolTypeId==RPoolTypeIdValue,ct))throw new ValidationException("Choose a valid RPoolTypeId.");
 if(row.RDataAccessCategoryId is int RDataAccessCategoryIdValue&&!await db.Set<RDataAccessCategory>().AnyAsync(x=>x.RDataAccessCategoryId==RDataAccessCategoryIdValue,ct))throw new ValidationException("Choose a valid RDataAccessCategoryId.");
 if(row.EffectiveDate.HasValue&&row.ExpiryDate.HasValue&&row.ExpiryDate<row.EffectiveDate)throw new ValidationException("Expiry date must be on or after the effective date.");
db.Add(row);await db.SaveChangesAsync(ct); }}
using Microsoft.EntityFrameworkCore;
using OSDU.Data.MasterData;
using System.ComponentModel.DataAnnotations;
namespace OSDU.Data;
public class FieldRepository(OsduDbContext db) {
 public Task<List<Field>> List(CancellationToken ct)=>db.Set<Field>().AsNoTracking().OrderBy(x=>x.FieldName).ToListAsync(ct);
 public async Task<object> Lookups(CancellationToken ct) {
 var result=new Dictionary<string,object>();
 result["crsId"]=await db.Set<Cartoreferencesystem>().AsNoTracking().OrderBy(x=>x.CrsName).Select(x=>new{id=x.CrsId,label=x.CrsName}).ToListAsync(ct);
 result["rFieldTypeId"]=await db.Set<RFieldType>().AsNoTracking().OrderBy(x=>x.DisplayName).Select(x=>new{id=x.RFieldTypeId,label=x.DisplayName}).ToListAsync(ct);
 result["rDataAccessCategoryId"]=await db.Set<RDataAccessCategory>().AsNoTracking().OrderBy(x=>x.DataAccessCategory).Select(x=>new{id=x.RDataAccessCategoryId,label=x.DataAccessCategory}).ToListAsync(ct);
return result; }
 public async Task Add(Field row,CancellationToken ct) {
 if(string.IsNullOrWhiteSpace(row.FieldName))throw new ValidationException("Field name is required.");
 if(await db.Set<Field>().AnyAsync(x=>x.FieldName==row.FieldName,ct))throw new ValidationException("A field with this name already exists.");
 if(row.CrsId is int CrsIdValue&&!await db.Set<Cartoreferencesystem>().AnyAsync(x=>x.CrsId==CrsIdValue,ct))throw new ValidationException("Choose a valid CrsId.");
 if(row.RFieldTypeId is int RFieldTypeIdValue&&!await db.Set<RFieldType>().AnyAsync(x=>x.RFieldTypeId==RFieldTypeIdValue,ct))throw new ValidationException("Choose a valid RFieldTypeId.");
 if(row.RDataAccessCategoryId is int RDataAccessCategoryIdValue&&!await db.Set<RDataAccessCategory>().AnyAsync(x=>x.RDataAccessCategoryId==RDataAccessCategoryIdValue,ct))throw new ValidationException("Choose a valid RDataAccessCategoryId.");
if(row.XCoordinate is decimal x && (x<=-1000000000m||x>=1000000000m) || row.YCoordinate is decimal y && (y<=-1000000000m||y>=1000000000m))throw new ValidationException("Coordinates must be between -999999999.999999999 and 999999999.999999999.");
 db.Add(row);await db.SaveChangesAsync(ct); }}
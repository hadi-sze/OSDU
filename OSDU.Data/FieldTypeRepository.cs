using Microsoft.EntityFrameworkCore;
using OSDU.Data.MasterData;
using System.ComponentModel.DataAnnotations;
namespace OSDU.Data;
public class FieldTypeRepository(OsduDbContext db) {
 public Task<List<RFieldType>> List(CancellationToken ct)=>db.Set<RFieldType>().AsNoTracking().OrderBy(x=>x.FieldTypeName).ToListAsync(ct);
 public async Task<object> Lookups(CancellationToken ct) {
 var result=new Dictionary<string,object>();
 await Task.CompletedTask;
return result; }
 public async Task Add(RFieldType row,CancellationToken ct) {
 if(string.IsNullOrWhiteSpace(row.FieldTypeName))throw new ValidationException("Name is required.");
 if(await db.Set<RFieldType>().AnyAsync(x=>x.FieldTypeName==row.FieldTypeName,ct))throw new ValidationException("A record with this name already exists.");
 if(row.EffectiveDate.HasValue&&row.ExpiryDate.HasValue&&row.ExpiryDate<row.EffectiveDate)throw new ValidationException("Expiry date must be on or after the effective date.");
db.Add(row);await db.SaveChangesAsync(ct); }}
using Microsoft.EntityFrameworkCore;
using OSDU.Data.MasterData;
using System.ComponentModel.DataAnnotations;
namespace OSDU.Data;
public class CrsRepository(OsduDbContext db) {
 public Task<List<Cartoreferencesystem>> List(CancellationToken ct)=>db.Set<Cartoreferencesystem>().AsNoTracking().OrderBy(x=>x.CrsName).ToListAsync(ct);
 public async Task<object> Lookups(CancellationToken ct) {
 var result=new Dictionary<string,object>();
 await Task.CompletedTask;
return result; }
 public async Task Add(Cartoreferencesystem row,CancellationToken ct) {
 if(string.IsNullOrWhiteSpace(row.CrsName))throw new ValidationException("Name is required.");
 if(await db.Set<Cartoreferencesystem>().AnyAsync(x=>x.CrsName==row.CrsName,ct))throw new ValidationException("A record with this name already exists.");
db.Add(row);await db.SaveChangesAsync(ct); }}
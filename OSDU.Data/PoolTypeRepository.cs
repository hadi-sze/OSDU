using Microsoft.EntityFrameworkCore;
using OSDU.Data.MasterData;
using System.ComponentModel.DataAnnotations;
namespace OSDU.Data;
public class PoolTypeRepository(OsduDbContext db) {
 public Task<List<RPoolType>> List(CancellationToken ct)=>db.Set<RPoolType>().AsNoTracking().OrderBy(x=>x.PoolType).ToListAsync(ct);
 public async Task Add(RPoolType row,CancellationToken ct) {
 if(string.IsNullOrWhiteSpace(row.PoolType))throw new ValidationException("Name is required.");
 if(await db.Set<RPoolType>().AnyAsync(x=>x.PoolType==row.PoolType,ct))throw new ValidationException("A record with this name already exists.");
db.Add(row);await db.SaveChangesAsync(ct); }}

using Microsoft.EntityFrameworkCore;
using OSDU.Data.MasterData;
using System.ComponentModel.DataAnnotations;
namespace OSDU.Data;
public class PoolStatusRepository(OsduDbContext db) {
 public Task<List<RPoolStatus>> List(CancellationToken ct)=>db.Set<RPoolStatus>().AsNoTracking().OrderBy(x=>x.PoolStatus).ToListAsync(ct);
 public async Task Add(RPoolStatus row,CancellationToken ct) {
 if(string.IsNullOrWhiteSpace(row.PoolStatus))throw new ValidationException("Name is required.");
 if(await db.Set<RPoolStatus>().AnyAsync(x=>x.PoolStatus==row.PoolStatus,ct))throw new ValidationException("A record with this name already exists.");
db.Add(row);await db.SaveChangesAsync(ct); }}

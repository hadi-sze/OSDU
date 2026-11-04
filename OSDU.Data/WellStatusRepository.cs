using Microsoft.EntityFrameworkCore;
using OSDU.Data.MasterData;
using System.ComponentModel.DataAnnotations;
namespace OSDU.Data;
public class WellStatusRepository(OsduDbContext db) {
 public Task<List<RWellStatus>> List(CancellationToken ct)=>db.Set<RWellStatus>().AsNoTracking().OrderBy(x=>x.WellStatus).ToListAsync(ct);
 public async Task<object> Sources(CancellationToken ct)=>await db.Set<RSource>().AsNoTracking().Select(x=>new{id=x.RSourceId,label=x.SourceName}).ToListAsync(ct);
 public async Task<object> Types(CancellationToken ct)=>await db.Set<RWellStatusType>().Where(x=>x.IsActive).Select(x=>new{id=x.RWellStatusTypeId,label=x.WellStatusType}).ToListAsync(ct);
 public async Task Add(RWellStatus row,CancellationToken ct) {
  if(await db.Set<RWellStatus>().AnyAsync(x=>x.WellStatus==row.WellStatus,ct))throw new ValidationException("This well status type already exists.");
  if(row.RSourceId is int id&&!await db.Set<RSource>().AnyAsync(x=>x.RSourceId==id,ct))throw new ValidationException("Choose a valid source.");
  if(!await db.Set<RWellStatusType>().AnyAsync(x=>x.RWellStatusTypeId==row.RWellStatusTypeId,ct))throw new ValidationException("Choose a valid well status type.");
  db.Add(row);await db.SaveChangesAsync(ct);
 }
}

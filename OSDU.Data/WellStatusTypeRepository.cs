using Microsoft.EntityFrameworkCore;
using OSDU.Data.MasterData;
using System.ComponentModel.DataAnnotations;
namespace OSDU.Data;
public class WellStatusTypeRepository(OsduDbContext db) {
 public Task<List<RWellStatusType>> List(CancellationToken ct)=>db.Set<RWellStatusType>().AsNoTracking().OrderBy(x=>x.WellStatusType).ToListAsync(ct);
 public async Task<object> Sources(CancellationToken ct)=>await db.Set<RSource>().AsNoTracking().Select(x=>new{id=x.RSourceId,label=x.SourceName}).ToListAsync(ct);
 public async Task Add(RWellStatusType row,CancellationToken ct) {
  if(await db.Set<RWellStatusType>().AnyAsync(x=>x.WellStatusType==row.WellStatusType,ct))throw new ValidationException("This well status type already exists.");
  if(row.RSourceId is int id&&!await db.Set<RSource>().AnyAsync(x=>x.RSourceId==id,ct))throw new ValidationException("Choose a valid source.");
  db.Add(row);await db.SaveChangesAsync(ct);
 }
}

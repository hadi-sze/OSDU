using Microsoft.EntityFrameworkCore;
using OSDU.Data.MasterData;
using System.ComponentModel.DataAnnotations;
namespace OSDU.Data;
public class OrgUnitTypeRepository(OsduDbContext db) {
 public Task<List<ROrgUnitType>> List(CancellationToken ct)=>db.Set<ROrgUnitType>().AsNoTracking().OrderBy(x=>x.OrgUnitType).ToListAsync(ct);
 public async Task Add(ROrgUnitType row,CancellationToken ct) {
  if(await db.Set<ROrgUnitType>().AnyAsync(x=>x.OrgUnitType==row.OrgUnitType,ct))throw new ValidationException("This organization unit type already exists.");
  db.Add(row);await db.SaveChangesAsync(ct);
 }
}
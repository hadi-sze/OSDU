using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using OSDU.Data.MasterData;
namespace OSDU.Data;
public class FacilityRepository(OsduDbContext db) {
 public Task<List<Facility>> List(CancellationToken ct) => db.Set<Facility>().AsNoTracking().OrderByDescending(x=>x.FacilityId).Take(100).ToListAsync(ct);
 public async Task<object> Lookups(CancellationToken ct) => new {
  facilityTypeId=await db.Set<RFacilityType>().AsNoTracking().Select(x=>new {id=x.RFacilityTypeId,label=x.FacilityType}).ToListAsync(ct),
  rEquipmentCatalogueId=await db.Set<REquipmentCatalogue>().AsNoTracking().Select(x=>new {id=x.REquipmentCatalogueId,label=x.EquipmentCatalogue}).ToListAsync(ct),
  crsId=await db.Set<Cartoreferencesystem>().AsNoTracking().Select(x=>new {id=x.CrsId,label=x.CrsName}).ToListAsync(ct),
  rDataAccessCategoryId=await db.Set<RDataAccessCategory>().AsNoTracking().Select(x=>new {id=x.RDataAccessCategoryId,label=x.DataAccessCategory}).ToListAsync(ct)
 };
 public async Task Add(Facility f,CancellationToken ct) {
  if(f.FacilityTypeId is int t && !await db.Set<RFacilityType>().AnyAsync(x=>x.RFacilityTypeId==t,ct)) throw new ValidationException("Choose a valid facility type.");
  if(f.CrsId is int c && !await db.Set<Cartoreferencesystem>().AnyAsync(x=>x.CrsId==c,ct)) throw new ValidationException("Choose a valid coordinate reference system.");
  if(f.RDataAccessCategoryId is int a && !await db.Set<RDataAccessCategory>().AnyAsync(x=>x.RDataAccessCategoryId==a,ct)) throw new ValidationException("Choose a valid data access category.");
  foreach(var p in db.Model.FindEntityType(typeof(Facility))!.GetProperties()) {
   if(p.ClrType==typeof(decimal?) && p.PropertyInfo!.GetValue(f) is decimal v) {
    var scale=p.GetScale()??9; var precision=p.GetPrecision()??18;
    if(decimal.Round(v,scale)!=v || Math.Abs(v)>=(decimal)Math.Pow(10,precision-scale)) throw new ValidationException(p.Name+" exceeds the table's numeric precision.");
   }
  }
  f.FacilityType = f.FacilityTypeId is int typeId ? (await db.Set<RFacilityType>().SingleAsync(x=>x.RFacilityTypeId==typeId,ct)).FacilityType : null;
  f.CrsName = f.CrsId is int crs ? (await db.Set<Cartoreferencesystem>().SingleAsync(x=>x.CrsId==crs,ct)).CrsName : null;
  if(f.REquipmentCatalogueId is int catalogue) {
   var entry=await db.Set<REquipmentCatalogue>().SingleOrDefaultAsync(x=>x.REquipmentCatalogueId==catalogue,ct);
   if(entry is null) throw new ValidationException("Choose a valid equipment catalogue.");
   f.EquipmentCatalogue=entry.EquipmentCatalogue;
  } else f.EquipmentCatalogue=null;
  db.Add(f); await db.SaveChangesAsync(ct);
 }
}

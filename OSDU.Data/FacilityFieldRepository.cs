using Microsoft.EntityFrameworkCore;
using OSDU.Data.MasterData;
using System.ComponentModel.DataAnnotations;
namespace OSDU.Data;
public class FacilityFieldRepository(OsduDbContext db) {
 public async Task<object> List(CancellationToken ct)=>await (
 from link in db.Set<FacilityField>().AsNoTracking()
 join facility in db.Set<Facility>() on link.FacilityId equals facility.FacilityId
 join field in db.Set<Field>() on link.FieldId equals field.FieldId
 orderby facility.FacilityName,field.FieldName
 select new {link.FacilityFieldId,link.FacilityId,facility.FacilityName,link.FieldId,field.FieldName,link.EffectiveDate,link.ExpiryDate,link.Remark,link.IsActive,link.RowCreatedBy,link.RowCreatedDate,link.RowChangedBy,link.RowChangedDate}).ToListAsync(ct);
 public async Task<object> Lookups(CancellationToken ct)=>new {
 facilityId=await db.Set<Facility>().AsNoTracking().OrderBy(x=>x.FacilityName).Select(x=>new{id=x.FacilityId,label=x.FacilityName}).ToListAsync(ct),
 fieldId=await db.Set<Field>().AsNoTracking().OrderBy(x=>x.FieldName).Select(x=>new{id=x.FieldId,label=x.FieldName}).ToListAsync(ct)};
 public async Task Add(FacilityField row,CancellationToken ct) {
 if(!await db.Set<Facility>().AnyAsync(x=>x.FacilityId==row.FacilityId,ct))throw new ValidationException("Choose a valid facility.");
 if(!await db.Set<Field>().AnyAsync(x=>x.FieldId==row.FieldId,ct))throw new ValidationException("Choose a valid field.");
 if(row.EffectiveDate.HasValue&&row.ExpiryDate.HasValue&&row.ExpiryDate<row.EffectiveDate)throw new ValidationException("Expiry date must be on or after the effective date.");
 if(await db.Set<FacilityField>().AnyAsync(x=>x.FacilityId==row.FacilityId&&x.FieldId==row.FieldId&&x.EffectiveDate==row.EffectiveDate,ct))throw new ValidationException("This facility and field association already exists for the effective date.");
 db.Add(row);await db.SaveChangesAsync(ct);
 }}
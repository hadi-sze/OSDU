using Microsoft.EntityFrameworkCore;
using OSDU.Data.MasterData;
using System.ComponentModel.DataAnnotations;
namespace OSDU.Data;
public class EquipmentRepository(OsduDbContext db) {
 public Task<List<Equipment>> List(CancellationToken ct)=>db.Set<Equipment>().AsNoTracking().OrderBy(x=>x.EquipmentName).ToListAsync(ct);
 public async Task<object> Lookups(CancellationToken ct) {
 var result=new Dictionary<string,object>();
 result["rEquipmentSubTypeId"]=await db.Set<REquipmentSubType>().AsNoTracking().OrderBy(x=>x.EquipmentSubType).Select(x=>new{id=x.REquipmentSubTypeId,label=x.EquipmentSubType}).ToListAsync(ct);
 result["rEquipmentTypeId"]=await db.Set<REquipmentType>().AsNoTracking().OrderBy(x=>x.EquipmentType).Select(x=>new{id=x.REquipmentTypeId,label=x.EquipmentType}).ToListAsync(ct);
 result["manufacturerBaId"]=await db.Set<OrgUnit>().AsNoTracking().OrderBy(x=>x.OrgUnitName).Select(x=>new{id=x.OrgUnitId,label=x.OrgUnitName}).ToListAsync(ct);
 result["rDataAccessCategoryId"]=await db.Set<RDataAccessCategory>().AsNoTracking().OrderBy(x=>x.DataAccessCategory).Select(x=>new{id=x.RDataAccessCategoryId,label=x.DataAccessCategory}).ToListAsync(ct);
return result; }
 public async Task Add(Equipment row,CancellationToken ct) {
 if(string.IsNullOrWhiteSpace(row.EquipmentName))throw new ValidationException("Name is required.");
 if(await db.Set<Equipment>().AnyAsync(x=>x.EquipmentName==row.EquipmentName,ct))throw new ValidationException("A record with this name already exists.");
 if(row.REquipmentSubTypeId is int REquipmentSubTypeIdValue&&!await db.Set<REquipmentSubType>().AnyAsync(x=>x.REquipmentSubTypeId==REquipmentSubTypeIdValue,ct))throw new ValidationException("Choose a valid REquipmentSubTypeId.");
 if(row.REquipmentTypeId is int REquipmentTypeIdValue&&!await db.Set<REquipmentType>().AnyAsync(x=>x.REquipmentTypeId==REquipmentTypeIdValue,ct))throw new ValidationException("Choose a valid REquipmentTypeId.");
 if(row.ManufacturerBaId is int ManufacturerBaIdValue&&!await db.Set<OrgUnit>().AnyAsync(x=>x.OrgUnitId==ManufacturerBaIdValue,ct))throw new ValidationException("Choose a valid ManufacturerBaId.");
 if(row.RDataAccessCategoryId is int RDataAccessCategoryIdValue&&!await db.Set<RDataAccessCategory>().AnyAsync(x=>x.RDataAccessCategoryId==RDataAccessCategoryIdValue,ct))throw new ValidationException("Choose a valid RDataAccessCategoryId.");
 if(row.CommissionDate.HasValue&&row.DecommissionDate.HasValue&&row.DecommissionDate<row.CommissionDate)throw new ValidationException("Decommission date must be on or after commission date.");
if(row.REquipmentTypeId is int typeId)row.EquipmentType=await db.Set<REquipmentType>().Where(x=>x.REquipmentTypeId==typeId).Select(x=>x.EquipmentType).SingleAsync(ct);
 if(row.REquipmentSubTypeId is int subTypeId)row.EquipmentSubType=await db.Set<REquipmentSubType>().Where(x=>x.REquipmentSubTypeId==subTypeId).Select(x=>x.EquipmentSubType).SingleAsync(ct);
 db.Add(row);await db.SaveChangesAsync(ct); }}
using Microsoft.EntityFrameworkCore;
using OSDU.Data.MasterData;
using System.ComponentModel.DataAnnotations;
namespace OSDU.Data;
public class WellRepository(OsduDbContext db) {
 public Task<List<Well>> List(CancellationToken ct)=>db.Set<Well>().AsNoTracking().OrderBy(x=>x.WellName).ToListAsync(ct);
 public async Task<object> Lookups(CancellationToken ct) {
 var result=new Dictionary<string,object>();
 result["fieldId"]=await db.Set<Field>().AsNoTracking().OrderBy(x=>x.FieldName).Select(x=>new{id=x.FieldId,label=x.FieldName}).ToListAsync(ct);
 result["rTimezoneId"]=await db.Set<RTimezone>().AsNoTracking().OrderBy(x=>x.Timezone).Select(x=>new{id=x.RTimezoneId,label=x.Timezone}).ToListAsync(ct);
 result["crsId"]=await db.Set<Cartoreferencesystem>().AsNoTracking().OrderBy(x=>x.CrsName).Select(x=>new{id=x.CrsId,label=x.CrsName}).ToListAsync(ct);
 result["currentClassId"]=await db.Set<RWellClass>().AsNoTracking().OrderBy(x=>x.WellClass).Select(x=>new{id=x.RWellClassId,label=x.WellClass}).ToListAsync(ct);
 result["depthDatumId"]=await db.Set<RWellDatumType>().AsNoTracking().OrderBy(x=>x.WellDatumType).Select(x=>new{id=x.WellDatumTypeId,label=x.WellDatumType}).ToListAsync(ct);
 result["rWellProfileId"]=await db.Set<RWellStatus>().AsNoTracking().OrderBy(x=>x.WellStatus).Select(x=>new{id=x.RWellStatusId,label=x.WellStatus}).ToListAsync(ct);
 result["rPlotSymbolId"]=await db.Set<RPlotSymbol>().AsNoTracking().OrderBy(x=>x.PlotSymbolType).Select(x=>new{id=x.RPlotSymbolId,label=x.PlotSymbolType}).ToListAsync(ct);
 result["rDataAccessCategoryId"]=await db.Set<RDataAccessCategory>().AsNoTracking().OrderBy(x=>x.DataAccessCategory).Select(x=>new{id=x.RDataAccessCategoryId,label=x.DataAccessCategory}).ToListAsync(ct);
return result; }
 public async Task Add(Well row,CancellationToken ct) {
 if(string.IsNullOrWhiteSpace(row.Uwi)||string.IsNullOrWhiteSpace(row.WellName))throw new ValidationException("UWI and well name are required.");
 if(await db.Set<Well>().AnyAsync(x=>x.Uwi==row.Uwi,ct))throw new ValidationException("A well with this UWI already exists.");
 if(row.FieldId is int FieldIdValue&&!await db.Set<Field>().AnyAsync(x=>x.FieldId==FieldIdValue,ct))throw new ValidationException("Choose a valid FieldId.");
 if(row.RTimezoneId is int RTimezoneIdValue&&!await db.Set<RTimezone>().AnyAsync(x=>x.RTimezoneId==RTimezoneIdValue,ct))throw new ValidationException("Choose a valid RTimezoneId.");
 if(row.CrsId is int CrsIdValue&&!await db.Set<Cartoreferencesystem>().AnyAsync(x=>x.CrsId==CrsIdValue,ct))throw new ValidationException("Choose a valid CrsId.");
 if(row.CurrentClassId is int CurrentClassIdValue&&!await db.Set<RWellClass>().AnyAsync(x=>x.RWellClassId==CurrentClassIdValue,ct))throw new ValidationException("Choose a valid CurrentClassId.");
 if(row.DepthDatumId is int DepthDatumIdValue&&!await db.Set<RWellDatumType>().AnyAsync(x=>x.WellDatumTypeId==DepthDatumIdValue,ct))throw new ValidationException("Choose a valid DepthDatumId.");
 if(row.RWellProfileId is int RWellProfileIdValue&&!await db.Set<RWellStatus>().AnyAsync(x=>x.RWellStatusId==RWellProfileIdValue,ct))throw new ValidationException("Choose a valid RWellProfileId.");
 if(row.RPlotSymbolId is int RPlotSymbolIdValue&&!await db.Set<RPlotSymbol>().AnyAsync(x=>x.RPlotSymbolId==RPlotSymbolIdValue,ct))throw new ValidationException("Choose a valid RPlotSymbolId.");
 if(row.RDataAccessCategoryId is int RDataAccessCategoryIdValue&&!await db.Set<RDataAccessCategory>().AnyAsync(x=>x.RDataAccessCategoryId==RDataAccessCategoryIdValue,ct))throw new ValidationException("Choose a valid RDataAccessCategoryId.");
foreach(var property in db.Model.FindEntityType(typeof(Well))!.GetProperties().Where(p=>p.ClrType==typeof(decimal?))) {
 if(property.PropertyInfo?.GetValue(row) is decimal value) {
 var precision=property.GetPrecision()??18;var scale=property.GetScale()??2;
 var limit=(decimal)Math.Pow(10,precision-scale);
 if(value<=-limit||value>=limit)throw new ValidationException($"{property.Name} is outside the supported range.");
 }
 }
 db.Add(row);await db.SaveChangesAsync(ct); }}

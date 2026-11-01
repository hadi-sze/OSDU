using System.ComponentModel.DataAnnotations;
using OSDU.Data;
namespace OSDU.Business;
public record AssetInput([Required, StringLength(200)] string Name, [StringLength(2000)] string? Description);
public class AssetService(AssetRepository repository) {
 public Task<List<Asset>> List(CancellationToken ct) => repository.List(ct);
 public Task<Asset?> Find(int id,CancellationToken ct) => repository.Find(id,ct);
 public async Task<Asset> Create(AssetInput input,CancellationToken ct) {
  var asset = new Asset { Name=input.Name.Trim(), Description=input.Description };
  await repository.Add(asset,ct); return asset;
 }
 public async Task<bool> Update(int id,AssetInput input,CancellationToken ct) {
  var asset=await repository.Find(id,ct); if(asset is null) return false;
  asset.Name=input.Name.Trim(); asset.Description=input.Description; await repository.Save(ct); return true;
 }
 public async Task<bool> Delete(int id,CancellationToken ct) {
  var asset=await repository.Find(id,ct); if(asset is null) return false;
  await repository.Delete(asset,ct); return true;
 }
}


using Microsoft.AspNetCore.Mvc;
using OSDU.Business;
namespace OSDU.Api;
[ApiController]
[Route("api/assets")]
public class AssetsController(AssetService service) : ControllerBase {
 [HttpGet] public async Task<IActionResult> List(CancellationToken ct) => Ok(await service.List(ct));
 [HttpGet("{id:int}")] public async Task<IActionResult> Get(int id,CancellationToken ct) => await service.Find(id,ct) is {} asset ? Ok(asset) : NotFound();
 [HttpPost] public async Task<IActionResult> Create(AssetInput input,CancellationToken ct) {
  var asset=await service.Create(input,ct); return CreatedAtAction(nameof(Get),new {id=asset.Id},asset);
 }
 [HttpPut("{id:int}")] public async Task<IActionResult> Update(int id,AssetInput input,CancellationToken ct) => await service.Update(id,input,ct) ? NoContent() : NotFound();
 [HttpDelete("{id:int}")] public async Task<IActionResult> Delete(int id,CancellationToken ct) => await service.Delete(id,ct) ? NoContent() : NotFound();
}

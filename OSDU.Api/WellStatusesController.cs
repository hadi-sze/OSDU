using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using OSDU.Business;
namespace OSDU.Api;
[ApiController,Route("api/reference/well-statuses")]
public class WellStatusesController(WellStatusService service):ControllerBase {
 [HttpGet] public async Task<IActionResult> List(CancellationToken ct)=>Ok(await service.List(ct));
 [HttpGet("sources")] public async Task<IActionResult> Sources(CancellationToken ct)=>Ok(await service.Sources(ct));
 [HttpGet("types")] public async Task<IActionResult> Types(CancellationToken ct)=>Ok(await service.Types(ct));
 [HttpPost] public async Task<IActionResult> Create(WellStatusInput input,CancellationToken ct) {
  try{return StatusCode(201,await service.Create(input,User.Identity!.Name!,ct));}
  catch(ValidationException e){return BadRequest(new{message=e.Message});}
 }
}

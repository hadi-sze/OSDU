using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using OSDU.Business;
namespace OSDU.Api;
[ApiController,Route("api/reference/well-status-types")]
public class WellStatusTypesController(WellStatusTypeService service):ControllerBase {
 [HttpGet] public async Task<IActionResult> List(CancellationToken ct)=>Ok(await service.List(ct));
 [HttpGet("sources")] public async Task<IActionResult> Sources(CancellationToken ct)=>Ok(await service.Sources(ct));
 [HttpPost] public async Task<IActionResult> Create(WellStatusTypeInput input,CancellationToken ct) {
  try{return StatusCode(201,await service.Create(input,User.Identity!.Name!,ct));}
  catch(ValidationException e){return BadRequest(new{message=e.Message});}
 }
}

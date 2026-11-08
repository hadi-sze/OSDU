using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using OSDU.Business;
namespace OSDU.Api;
[ApiController,Route("api/reference/pool-statuses")]
public class PoolStatusController(PoolStatusService service):ControllerBase {
 [HttpGet] public async Task<IActionResult> List(CancellationToken ct)=>Ok(await service.List(ct));
 [HttpPost] public async Task<IActionResult> Create(PoolStatusInput input,CancellationToken ct) {
  try{return StatusCode(201,await service.Create(input,User.Identity!.Name!,ct));}
  catch(ValidationException e){return BadRequest(new{message=e.Message});}
 }
}

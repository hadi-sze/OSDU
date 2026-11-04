using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using OSDU.Business;
namespace OSDU.Api;
[ApiController,Route("api/facilities")]
public class FacilitiesController(FacilityService service):ControllerBase {
 [HttpGet] public async Task<IActionResult> List(CancellationToken ct)=>Ok(await service.List(ct));
 [HttpGet("lookups")] public async Task<IActionResult> Lookups(CancellationToken ct)=>Ok(await service.Lookups(ct));
 [HttpPost] public async Task<IActionResult> Create(FacilityInput input,CancellationToken ct) {
  try {var f=await service.Create(input,User.Identity?.Name??"unknown",ct);return StatusCode(201,f);}
  catch(ValidationException e){return BadRequest(new {message=e.Message});}
 }
}

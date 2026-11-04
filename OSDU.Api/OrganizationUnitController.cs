using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using OSDU.Business;
namespace OSDU.Api;
[ApiController,Route("api/organization-units")]
public class OrganizationUnitController(OrganizationUnitService service):ControllerBase {
 [HttpGet] public async Task<IActionResult> List(CancellationToken ct)=>Ok(await service.List(ct));
 [HttpGet("lookups")] public async Task<IActionResult> Lookups(CancellationToken ct)=>Ok(await service.Lookups(ct));
 [HttpPost] public async Task<IActionResult> Create(OrganizationUnitInput input,CancellationToken ct) {
  try{return StatusCode(201,await service.Create(input,User.Identity!.Name!,ct));}
  catch(ValidationException e){return BadRequest(new{message=e.Message});}
 }
}

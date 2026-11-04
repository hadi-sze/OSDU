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
 [HttpPut("{id:int}")] public async Task<IActionResult> Update(int id,OrganizationUnitInput input,CancellationToken ct) {
 try {var row=await service.Update(id,input,User.Identity!.Name!,ct);return row is null?NotFound():Ok(row);}catch(ValidationException e){return BadRequest(new{message=e.Message});}
 }
 [HttpDelete("{id:int}")] public async Task<IActionResult> Delete(int id,CancellationToken ct) {
 try{return await service.Delete(id,ct)?NoContent():NotFound();}catch(ValidationException e){return Conflict(new{message=e.Message});}
 }
}
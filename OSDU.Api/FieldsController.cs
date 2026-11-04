using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using OSDU.Business;
namespace OSDU.Api;
[ApiController,Route("api/fields")]
public class FieldsController(FieldService service):ControllerBase {
 [HttpGet] public async Task<IActionResult> List(CancellationToken ct)=>Ok(await service.List(ct));
 [HttpGet("lookups")] public async Task<IActionResult> Lookups(CancellationToken ct)=>Ok(await service.Lookups(ct));
 [HttpPost] public async Task<IActionResult> Create(FieldInput input,CancellationToken ct) {
  try{return StatusCode(201,await service.Create(input,User.Identity!.Name!,ct));}
  catch(ValidationException e){return BadRequest(new{message=e.Message});}
 }
}

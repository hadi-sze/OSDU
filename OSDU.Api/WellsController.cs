using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using OSDU.Business;
namespace OSDU.Api;
[ApiController,Route("api/wells")]
public class WellsController(WellService service):ControllerBase {
 [HttpGet("page")] public async Task<IActionResult> Page(CancellationToken ct,int page=0,int size=10,string? search=null,string? status=null,string? sort=null,bool desc=false)=>Ok(await service.Page(page,size,search,status,sort,desc,ct));
 [HttpGet] public async Task<IActionResult> List(CancellationToken ct)=>Ok(await service.List(ct));
 [HttpGet("lookups")] public async Task<IActionResult> Lookups(CancellationToken ct)=>Ok(await service.Lookups(ct));
 [HttpPost] public async Task<IActionResult> Create(WellInput input,CancellationToken ct) {
  try{return StatusCode(201,await service.Create(input,User.Identity!.Name!,ct));}
  catch(ValidationException e){return BadRequest(new{message=e.Message});}
 }
}

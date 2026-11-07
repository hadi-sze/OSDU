using Microsoft.AspNetCore.Mvc;
using OSDU.Business;
using OSDU.Data;
using System.ComponentModel.DataAnnotations;
namespace OSDU.Api;

[ApiController,Route("api/organization-view")]
public class OrganizationViewController(OrganizationViewService service):ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Read(CancellationToken ct)=>Ok(await service.Read(ct));

    [HttpPost("links")]
    public async Task<IActionResult> Save(OrganizationLink input,CancellationToken ct)
    {
        try { await service.Save(input,User.Identity!.Name!,ct);return NoContent(); }
        catch(ValidationException e){return BadRequest(new{message=e.Message});}
        catch(KeyNotFoundException){return NotFound();}
    }

    [HttpDelete("{orgId:int}/{kind}/{id:int}")]
    public async Task<IActionResult> Delete(int orgId,string kind,int id,CancellationToken ct)
    {
        try {await service.Delete(kind,orgId,id,ct);return NoContent();}
        catch(ValidationException e){return BadRequest(new{message=e.Message});}
        catch(KeyNotFoundException){return NotFound();}
    }
}

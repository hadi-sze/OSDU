using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using OSDU.Business;

namespace OSDU.Api;

[ApiController, Route("api/well-records/{table}")]
public class WellRecordsController(WellRecordsService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Read(string table, CancellationToken ct) =>
        service.SupportsCreate(table) ? Ok(await service.Read(table, ct)) : NotFound();

    [HttpPost]
    public async Task<IActionResult> Create(string table, JsonElement input, CancellationToken ct)
    {
        if (!service.SupportsCreate(table)) return NotFound();
        try { return StatusCode(201, await service.Create(table, input, User.Identity!.Name!, ct)); }
        catch (ValidationException e) { return BadRequest(new { message = e.Message }); }
    }

    [HttpGet("/api/wells/references/{key}")]
    public async Task<IActionResult> WellLookup(string key, CancellationToken ct)
    {
        try { return Ok(await service.WellLookup(key, ct)); }
        catch (KeyNotFoundException) { return NotFound(); }
    }

    [HttpGet("/api/wells/form")]
    public async Task<IActionResult> WellTemplate(CancellationToken ct) => Ok(await service.ReadWellTemplate(ct));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> ReadRecord(string table, int id, CancellationToken ct)
    {
        if (!service.Supports(table)) return NotFound();
        try { return Ok(await service.Read(table, id, ct)); }
        catch (KeyNotFoundException) { return NotFound(); }
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> Update(string table, int id, JsonElement input, CancellationToken ct)
    {
        if (!service.Supports(table) || table == "field-org-units") return NotFound();
        try { return Ok(await service.Update(table, id, input, User.Identity!.Name!, ct)); }
        catch (KeyNotFoundException) { return NotFound(); }
        catch (ValidationException e) { return BadRequest(new { message = e.Message }); }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(string table, int id, CancellationToken ct)
    {
        if (!service.Supports(table) || table == "field-org-units") return NotFound();
        try { await service.Delete(table, id, ct); return NoContent(); }
        catch (KeyNotFoundException) { return NotFound(); }
        catch (ValidationException e) { return Conflict(new { message = e.Message }); }
    }
}

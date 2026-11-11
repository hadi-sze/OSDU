using Microsoft.AspNetCore.Mvc;
using OSDU.Business;
using OSDU.Data;

namespace OSDU.Api;

[ApiController, Route("api/catalog")]
public sealed class CatalogController(CatalogService service) : ControllerBase
{
    [HttpGet]
    public Task<object> Search([FromQuery] CatalogFilter filter, CancellationToken ct,
        int page = 0, int size = 25, string? sort = null, bool desc = false) =>
        service.Search(filter, page, size, sort, desc, ct);

    [HttpGet("facets")]
    public Task<object> Facets([FromQuery] CatalogFilter filter, CancellationToken ct) => service.Facets(filter, ct);

    [HttpGet("map")]
    public Task<object> Map([FromQuery] CatalogFilter filter, CancellationToken ct) => service.Map(filter, ct);

    [HttpGet("related/{dataset}/{id:int}")]
    public Task<object> Related(string dataset, int id, CancellationToken ct) => service.Related(dataset, id, ct);

    [HttpGet("detail/{dataset}/{id:int}")]
    public async Task<IActionResult> Detail(string dataset, int id, CancellationToken ct) =>
        await service.Detail(dataset, id, ct) is { } record ? Ok(record) : NotFound();
}

using OSDU.Data;

namespace OSDU.Business;

public sealed class CatalogService(CatalogRepository repository)
{
    public Task<object> Search(CatalogFilter filter, int page, int size, string? sort, bool desc, CancellationToken ct) =>
        repository.Search(filter, Math.Max(0, page), Math.Clamp(size, 1, 100), sort, desc, ct);

    public Task<object> Facets(CatalogFilter filter, CancellationToken ct) => repository.Facets(filter, ct);

    public Task<object> Map(CatalogFilter filter, CancellationToken ct) => repository.Map(filter, ct);

    public Task<object> Related(string dataset, int id, CancellationToken ct) => repository.Related(dataset, id, ct);

    public Task<object?> Detail(string dataset, int id, CancellationToken ct) => repository.Detail(dataset, id, ct);
}

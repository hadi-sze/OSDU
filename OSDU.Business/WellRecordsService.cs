using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using OSDU.Data;

namespace OSDU.Business;

public class WellRecordsService(WellRecordsRepository repository)
{
    public bool SupportsCreate(string table) => WellRecordsRepository.SupportsCreate(table);

    public bool Supports(string table) => WellRecordsRepository.Supports(table);

    public Task<object> Read(string table, CancellationToken ct) => repository.Read(table, ct);

    public Task<object> Create(string table, JsonElement input, string actor, CancellationToken ct)
    {
        foreach (var (start, end) in new[] { ("effectiveDate", "expiryDate"), ("surveyStartDate", "surveyEndDate"),
            ("installDate", "removeDate"), ("tubularInDate", "tubularOutDate"), ("completionDate", "expiryDate") })
        {
            if (input.ValueKind == JsonValueKind.Object && input.TryGetProperty(start, out var from) &&
                input.TryGetProperty(end, out var to) && from.ValueKind == JsonValueKind.String &&
                to.ValueKind == JsonValueKind.String && from.TryGetDateTime(out var first) &&
                to.TryGetDateTime(out var last) && last < first)
                throw new ValidationException("The end date must be on or after the start date.");
        }
        return repository.Create(table, input, actor, ct);
    }

    public Task<object> Read(string table, int id, CancellationToken ct) => repository.Read(table, ct, id);

    public Task<object> Update(string table, int id, JsonElement input, string actor, CancellationToken ct) =>
        repository.Create(table, input, actor, ct, id);

    public Task Delete(string table, int id, CancellationToken ct) => repository.Delete(table, id, ct);
}

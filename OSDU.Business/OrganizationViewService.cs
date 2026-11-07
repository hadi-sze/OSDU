using OSDU.Data;
using System.ComponentModel.DataAnnotations;
namespace OSDU.Business;

public class OrganizationViewService(OrganizationViewRepository repository)
{
    public Task<object> Read(CancellationToken ct) => repository.Read(ct);
    public Task Delete(string kind,int orgId,int id,CancellationToken ct) => repository.Delete(kind,orgId,id,ct);
    public Task Save(OrganizationLink input,string actor,CancellationToken ct)
    {
        if(input.Id<0 || input.OrgUnitId<=0 || input.TargetId<=0)
            throw new ValidationException("Choose an organization and related record.");
        if(input.ExpiryDate<input.EffectiveDate)
            throw new ValidationException("Expiry date must be on or after the effective date.");
        if(input.Remark?.Length>2000)
            throw new ValidationException("Remarks must be at most 2000 characters.");
        return repository.Save(input,actor,ct);
    }
}

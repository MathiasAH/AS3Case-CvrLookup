using AS3Case.Application.CompanyLookup.Contracts.Dto.Views;
namespace AS3Case.Application.CompanyLookup.UseCases
{
    public interface ICompanyLookup
    {
        Task<CompanyView> HandleRequestAsync(CompanyLookupRequest request);
    }
}
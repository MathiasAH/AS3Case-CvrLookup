using AS3Case.Application.CompanyLookup.Enums;

namespace AS3Case.Application.CompanyLookup.Contracts.Interfaces
{
    public interface ICompanyLookupProviderResolver
    {
        ICompanyLookupProvider GetProvider(Country country);
    }
}
using AS3Case.Application.Enums;

namespace AS3Case.Application.Contracts.Interfaces
{
    public interface ICompanyLookupProviderResolver
    {
        ICompanyLookupProvider GetProvider(Country country);
    }
}
using AS3Case.Application.Enums;

namespace AS3Case.Application.Interfaces
{
    public interface ICompanyLookupProviderResolver
    {
        ICompanyLookupProvider GetProvider(Country country);
    }
}
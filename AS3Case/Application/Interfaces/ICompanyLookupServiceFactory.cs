using AS3Case.Application.Enums;
using AS3Case.Domain.Interfaces;

namespace AS3Case.Application.Interfaces
{
    public interface ICompanyLookupServiceFactory
    {
        ICompanyLookupService GetService(Country country);
    }
}
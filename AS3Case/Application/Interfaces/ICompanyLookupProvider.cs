using AS3Case.Domain.Entities;
using AS3Case.Domain.ValueObjects;
namespace AS3Case.Application.Interfaces
{
    public interface ICompanyLookupProvider
    {
        Task<Company?> LookupByRegistrationNumberAsync(CvrNumber registrationNumber);
        Task<Company?> LookupByNameAsync(CompanyName name);
        Task<Company?> LookupByPhoneNumberAsync(PhoneNumber phoneNumber);
    }
}
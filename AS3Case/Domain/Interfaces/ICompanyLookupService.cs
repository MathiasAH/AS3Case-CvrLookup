using AS3Case.Domain.Entities;
using AS3Case.Domain.ValueObjects;
namespace AS3Case.Domain.Interfaces
{
    public interface ICompanyLookupService
    {
        Task<Company?> LookupByRegistrationNumberAsync(CvrNumber registrationNumber);
        Task<Company?> LookupByNameAsync(CompanyName name);
        Task<Company?> LookupByPhoneNumberAsync(PhoneNumber phoneNumber);
    }
}
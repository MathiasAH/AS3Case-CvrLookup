using AS3Case.Domain.Entities;
namespace AS3Case.Domain.Interfaces
{
    public interface ICompanyLookupService
    {
        Task<Company?> LookupByRegistrationNumberAsync(string registrationNumber);
        Task<Company?> LookupByNameAsync(string name);
        Task<Company?> LookupByPhoneNumberAsync(string phoneNumber);
    }
}
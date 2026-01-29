using AS3Case.Application.Contracts.Dto;
namespace AS3Case.Application.Contracts.Interfaces
{
    public interface ICompanyLookupProvider
    {
        Task<ExternalCompanyData> LookupByRegistrationNumberAsync(string registrationNumber);
        Task<ExternalCompanyData> LookupByNameAsync(string name);
        Task<ExternalCompanyData> LookupByPhoneNumberAsync(string phoneNumber);
    }
}
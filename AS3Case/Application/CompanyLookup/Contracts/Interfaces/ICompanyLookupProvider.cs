using AS3Case.Application.CompanyLookup.Contracts.Dto.ExternalData;

namespace AS3Case.Application.CompanyLookup.Contracts.Interfaces
{
    public interface ICompanyLookupProvider
    {
        Task<ExternalCompanyData> LookupByRegistrationNumberAsync(string registrationNumber);
        Task<ExternalCompanyData> LookupByNameAsync(string name);
        Task<ExternalCompanyData> LookupByPhoneNumberAsync(string phoneNumber);
    }
}
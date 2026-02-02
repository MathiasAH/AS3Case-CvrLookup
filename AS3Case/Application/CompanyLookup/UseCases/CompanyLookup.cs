using AS3Case.Application.CompanyLookup.Contracts.Dto.ExternalData;
using AS3Case.Application.CompanyLookup.Contracts.Dto.Views;
using AS3Case.Application.CompanyLookup.Contracts.Interfaces;
using AS3Case.Application.CompanyLookup.Enums;
using AS3Case.Application.CompanyLookup.Mappers;
using AS3Case.Domain.Entities;
namespace AS3Case.Application.CompanyLookup.UseCases
{
    public sealed class CompanyLookup : ICompanyLookup
    {
        private readonly ICompanyLookupProviderResolver _factory;

        public CompanyLookup(ICompanyLookupProviderResolver factory)
        {
            _factory = factory;
        }

        public async Task<CompanyView> HandleRequestAsync(CompanyLookupRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Value))
                throw new ArgumentException("Value cannot be empty");

            CompanyView result;

            Country country = request.Country.ToLower() switch
            {
                "dk" => Country.Denmark,
                "no" => Country.Norway,
                //"se" => Enums.Country.Sweden,
                "" => Country.Denmark, //default
                _ => throw new Exception("Please provide a valid country."),
            };

            ICompanyLookupProvider service = _factory.GetProvider(country);

            ExternalCompanyData extData = new();
            Company domainCompany;
            switch (request.Type)
            {
                case LookupType.Name:
                    extData = await service.LookupByNameAsync(request.Value);
                    domainCompany = CompanyMapper.FromExternalData(extData);
                    result = CompanyMapper.ToView(domainCompany);
                    break;
                case LookupType.Phone:
                    extData = await service.LookupByPhoneNumberAsync(request.Value);
                    domainCompany = CompanyMapper.FromExternalData(extData);
                    result = CompanyMapper.ToView(domainCompany);
                    break;
                case LookupType.RegistrationNumber:
                    extData = await service.LookupByRegistrationNumberAsync(request.Value);
                    domainCompany = CompanyMapper.FromExternalData(extData);
                    result = CompanyMapper.ToView(domainCompany);
                    break;
                default:
                    throw new NotSupportedException("Unsupported lookup type");
            }
            return result;
        }
    }
}
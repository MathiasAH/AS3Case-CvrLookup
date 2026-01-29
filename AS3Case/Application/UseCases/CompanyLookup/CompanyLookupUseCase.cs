using AS3Case.Application.Contracts.Dto;
using AS3Case.Application.Contracts.Interfaces;
using AS3Case.Application.Enums;
using AS3Case.Application.Mappers;
using AS3Case.Domain.Entities;
using AS3Case.Presentation.Console.Commands;
using System.ComponentModel.DataAnnotations;
namespace AS3Case.Application.UseCases.CompanyLookup
{
    public sealed class CompanyLookupUseCase : ICompanyLookupUseCase
    {
        private readonly ICompanyLookupProviderResolver _factory;

        public CompanyLookupUseCase(ICompanyLookupProviderResolver factory)
        {
            _factory = factory;
        }

        public async Task<Company> HandleRequestAsync(CompanyLookupRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Value))
                throw new ArgumentException("Value cannot be empty");

            Company result;

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
            switch (request.Type)
            {
                case LookupType.Name:
                    extData = await service.LookupByNameAsync(request.Value);
                    result = CompanyMapper.FromExternalData(extData);
                    break;
                case LookupType.Phone:
                    extData = await service.LookupByNameAsync(request.Value);
                    result = CompanyMapper.FromExternalData(extData);
                    break;
                case LookupType.RegistrationNumber:
                    extData = await service.LookupByNameAsync(request.Value);
                    result = CompanyMapper.FromExternalData(extData);
                    break;
                default:
                    throw new NotSupportedException("Unsupported lookup type");
            }
            return result;
        }
    }
}

using AS3Case.Application.Enums;
using AS3Case.Application.Interfaces;
using AS3Case.Domain.Entities;
using AS3Case.Domain.Interfaces;
using AS3Case.Domain.ValueObjects;
using AS3Case.Presentation.Console.Commands;
using System.ComponentModel.DataAnnotations;
namespace AS3Case.Application.UseCases.CompanyLookup
{
    public sealed class CompanyLookupUseCase : ICompanyLookupUseCase
    {
        private readonly ICompanyLookupServiceFactory _factory;

        public CompanyLookupUseCase(ICompanyLookupServiceFactory factory)
        {
            _factory = factory;
        }
        public CompanyLookupRequest ToRequest(LookupCompanyCommand cmd)
        {
            if (!string.IsNullOrWhiteSpace(cmd.Name))
            {
                return new CompanyLookupRequest(
                    LookupType.Name,
                    cmd.Name,
                    cmd.Country
                );
            }

            if (!string.IsNullOrWhiteSpace(cmd.Phone))
            {
                return new CompanyLookupRequest(
                    LookupType.Phone,
                    cmd.Phone,
                    cmd.Country
                );
            }

            if (!string.IsNullOrWhiteSpace(cmd.Cvr))
            {
                return new CompanyLookupRequest(
                    LookupType.RegistrationNumber,
                    cmd.Cvr,
                    cmd.Country
                );
            }
            throw new ValidationException("You must specify either name, phone, or registration number.");
        }
        public async Task<Company> HandleRequestAsync(CompanyLookupRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Value))
                throw new ArgumentException("Value cannot be empty");

            Company result;

            Enums.Country country = request.Country.ToLower() switch
            {
                "dk" => Enums.Country.Denmark,
                "no" => Enums.Country.Norway,
                //"se" => Enums.Country.Sweden,
                "" => Enums.Country.Denmark, //default
                _ => throw new Exception("Please provide a valid country."),
            };

            ICompanyLookupService service = _factory.GetService(country);

            switch (request.Type)
            {
                case LookupType.Name:
                    CompanyName name = CompanyName.Create(request.Value);
                    result = await service.LookupByNameAsync(name);
                    break;
                case LookupType.Phone:
                    PhoneNumber phoneNumber = PhoneNumber.Create(request.Value);
                    result = await service.LookupByPhoneNumberAsync(phoneNumber);
                    break;
                case LookupType.RegistrationNumber:
                    CvrNumber cvrNumber = CvrNumber.Create(request.Value);
                    result = await service.LookupByRegistrationNumberAsync(cvrNumber);
                    break;
                default:
                    throw new NotSupportedException("Unsupported lookup type");
            }
            return result;
        }
    }
}

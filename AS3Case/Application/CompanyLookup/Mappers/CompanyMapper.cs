using AS3Case.Application.CompanyLookup.Contracts.Dto.ExternalData;
using AS3Case.Application.CompanyLookup.Contracts.Dto.Views;
using AS3Case.Domain.ValueObjects;

namespace AS3Case.Application.CompanyLookup.Mappers
{
    public class CompanyMapper
    {
        public static Domain.Entities.Company FromExternalData(ExternalCompanyData data)
        {
            PhoneNumber phoneNumber = null;
            if(!string.IsNullOrWhiteSpace(data.PhoneNumber))
            {
                phoneNumber = PhoneNumber.Create(data.PhoneNumber);
            }
            return new Domain.Entities.Company(
                CompanyName.Create(data.Name),
                data.Address,
                data.City,
                data.ZipCode,
                phoneNumber
            );
        }
        public static CompanyView ToView(Domain.Entities.Company company)
        {
            return new CompanyView
            {
                Name = company.Name.Value,
                Address = company.Address,
                City = company.City,
                ZipCode = company.ZipCode,
                PhoneNumber = company.PhoneNumber?.Value
            };
        }
    }
}
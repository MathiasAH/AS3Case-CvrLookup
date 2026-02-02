using AS3Case.Application.CompanyLookup.Contracts.Dto.ExternalData;
using AS3Case.Infrastructure.ApiClients.DK.Dto;

namespace AS3Case.Infrastructure.ApiClients.DK
{
    public class DkCvrApiMapper
    {
        public static ExternalCompanyData ToExternalCompanyData(ApiResult data)
        {
            return new ExternalCompanyData
            {
                Name = data.Name,
                Address = data.Address,
                City = data.City,
                ZipCode = data.Zipcode,
                PhoneNumber = data.Phone
            };
        }
    }
}
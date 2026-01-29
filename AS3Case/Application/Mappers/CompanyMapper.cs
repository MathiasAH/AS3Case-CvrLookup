namespace AS3Case.Application.Mappers
{
    public class CompanyMapper
    {
        public static Domain.Entities.Company FromExternalData(Contracts.Dto.ExternalCompanyData data)
        {
            return new Domain.Entities.Company(
                data.Name,
                data.Address,
                data.City,
                data.ZipCode,
                data.PhoneNumber
            );
        }
    }
}
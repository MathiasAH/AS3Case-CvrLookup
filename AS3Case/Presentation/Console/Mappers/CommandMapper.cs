using AS3Case.Application.CompanyLookup.Enums;
using AS3Case.Application.CompanyLookup.UseCases;
using AS3Case.Presentation.Console.Commands;
using System.ComponentModel.DataAnnotations;

namespace AS3Case.Presentation.Console.Mappers
{
    public class CommandMapper
    {
        public static CompanyLookupRequest ToRequest(LookupCompanyCommand cmd)
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
    }
}

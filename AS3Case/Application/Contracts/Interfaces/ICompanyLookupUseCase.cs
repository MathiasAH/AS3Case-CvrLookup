using AS3Case.Application.UseCases.CompanyLookup;
using AS3Case.Domain.Entities;
using AS3Case.Presentation.Console.Commands;

namespace AS3Case.Application.Contracts.Interfaces
{
    public interface ICompanyLookupUseCase
    {
        Task<Company> HandleRequestAsync(CompanyLookupRequest request);
    }
}
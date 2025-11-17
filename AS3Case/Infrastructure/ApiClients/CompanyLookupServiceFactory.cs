using AS3Case.Application.Enums;
using AS3Case.Application.Interfaces;
using AS3Case.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AS3Case.Infrastructure.ApiClients
{
    public class CompanyLookupServiceFactory : ICompanyLookupServiceFactory
    {
        private readonly IServiceProvider _provider;

        public CompanyLookupServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public ICompanyLookupService GetService(Country country) =>
            country switch
            {
                Country.Denmark => _provider.GetRequiredService<DK.DkCvrApiService>(),
                Country.Norway => _provider.GetRequiredService<NO.NoCvrApiService>(),
                //Country.Sweden => _provider.GetRequiredService<SeCompanyLookupService>(),
                _ => throw new NotSupportedException()
            };
    }
}
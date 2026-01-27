using AS3Case.Application.Enums;
using AS3Case.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AS3Case.Infrastructure.ApiClients
{
    public class CompanyLookupProviderResolver : ICompanyLookupProviderResolver
    {
        private readonly IServiceProvider _provider;

        public CompanyLookupProviderResolver(IServiceProvider provider)
        {
            _provider = provider;
        }

        public ICompanyLookupProvider GetProvider(Country country) =>
            country switch
            {
                Country.Denmark => _provider.GetRequiredService<DK.DkCvrApiService>(),
                Country.Norway => _provider.GetRequiredService<NO.NoCvrApiService>(),
                //Country.Sweden => _provider.GetRequiredService<SeCompanyLookupService>(),
                _ => throw new NotSupportedException()
            };
    }
}
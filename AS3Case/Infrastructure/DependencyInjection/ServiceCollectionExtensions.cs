using AS3Case.Application.Interfaces;
using AS3Case.Application.UseCases.CompanyLookup;
using AS3Case.Infrastructure.ApiClients;
using Microsoft.Extensions.DependencyInjection;

namespace AS3Case.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCompanyLookupServices(this IServiceCollection services)
        {
            services.AddHttpClient<ApiClients.DK.DkCvrApiService>();
            services.AddHttpClient<ApiClients.NO.NoCvrApiService>();
            //  services.AddHttpClient<SeCompanyLookupService>();

            services.AddSingleton<ICompanyLookupServiceFactory, CompanyLookupServiceFactory>();

            services.AddSingleton<ICompanyLookupUseCase, CompanyLookupUseCase>();

            return services;
        }
    }
}
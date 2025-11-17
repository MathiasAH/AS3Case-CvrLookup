using AS3Case.Infrastructure.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace AS3Case.Presentation.Console.Configuration
{
    public static class SetupDI
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddCompanyLookupServices();
            return services;
        }

        public static ServiceProvider BuildServiceProvider()
        {
            var services = new ServiceCollection();
            services.ConfigureServices();
            return services.BuildServiceProvider();
        }
    }
}

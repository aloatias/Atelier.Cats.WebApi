using Atelier.Cats.WebApi.Interfaces;
using Atelier.Cats.WebApi.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Atelier.Cats.WebApi.Extensions
{
    public static class CoreServicesConfiguration
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<ICatService, CatService>();
        }
    }
}

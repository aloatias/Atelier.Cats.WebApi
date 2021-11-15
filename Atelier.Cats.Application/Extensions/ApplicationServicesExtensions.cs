using Atelier.Cats.Application.Common;
using Atelier.Cats.Application.Services;
using Atelier.Cats.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Atelier.Cats.Application
{
    public static class ApplicationServicesExtensions
    {
        public static void InjectServices(this IServiceCollection services)
        {
            services.AddScoped<ICatService, CatService>();
            services.AddScoped<IChallengeService, ChallengeService>();
            services.AddScoped<IDateGenerator, DateGenerator>();
        }
    }
}

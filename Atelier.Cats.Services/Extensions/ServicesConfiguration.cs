using Atelier.Cats.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Atelier.Cats.Services.Extensions
{
    public static class ServicesConfiguration
    {
        public static void InjectServices(this IServiceCollection services)
        {
            services.AddScoped<ICatService, CatService>();
            services.AddScoped<IChallengeService, ChallengeService>();
            services.AddScoped<IDateGeneratorService, DateGeneratorService>();
        }
    }
}

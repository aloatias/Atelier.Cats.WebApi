using Atelier.Gateway.Interfaces;
using Atelier.Gateway.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Atelier.Gateway.Extensions
{
    public static class CatsGatewayConfiguration
    {
        private const string _baseUrlSection = "Urls:Base";

        public static void InjectServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUrlFactory, UrlFactory>();
            services.AddScoped<IAtelierCatsGateway, AtelierCatsGateway>();

            services.AddHttpClient<AtelierCatsGateway>(
                client => client.BaseAddress = new Uri(configuration.GetSection(_baseUrlSection).Value));
        }
    }
}

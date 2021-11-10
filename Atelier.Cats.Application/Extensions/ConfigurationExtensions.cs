﻿using Atelier.Cats.Application.Abstractions.Services;
using Atelier.Cats.Application.Common;
using Atelier.Cats.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Atelier.Cats.Application
{
    public static class ConfigurationExtensions
    {
        public static void InjectServices(this IServiceCollection services)
        {
            services.AddScoped<ICatService, CatService>();
            services.AddScoped<IChallengeService, ChallengeService>();
            services.AddScoped<IDateGenerator, DateGenerator>();
        }
    }
}
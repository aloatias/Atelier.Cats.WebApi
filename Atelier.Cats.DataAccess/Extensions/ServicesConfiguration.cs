using Atelier.Cats.DataAccess.Entities;
using Atelier.Cats.DataAccess.Interfaces;
using Atelier.Cats.DataAccess.Repositories;
using Atelier.Cats.DataAccess.Tools;
using Atelier.Cats.DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace Atelier.Cats.DataAccess.Extensions
{
    public static class ServicesConfiguration
    {
        public static void InjectDataService(this IServiceCollection services)
        {
            // Real database
            //services.AddDbContext<AtelierCatsContext>(options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

            // In memory database
            services.AddDbContext<AtelierCatsContext>(options => options
                .UseInMemoryDatabase("AtelierCatsContext")
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning)));
        }

        public static void InjectDateService(this IServiceCollection services)
        {
            services.AddScoped<IDateGenerator, DateGenerator>();
        }

        public static void InjectRepositoryService(this IServiceCollection services)
        {
            services.AddScoped<ICatRepository, CatRepository>();
            services.AddScoped<IChallengeRepository, ChallengeRepository>();
        }

        public static void InjectUnitOfWorkService(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}

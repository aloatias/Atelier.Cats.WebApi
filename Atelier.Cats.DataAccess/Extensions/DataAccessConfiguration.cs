using Atelier.Cats.DataAccess.Entities;
using Atelier.Cats.DataAccess.Interfaces;
using Atelier.Cats.DataAccess.Repositories;
using Atelier.Cats.DataAccess.Tools;
using Atelier.Cats.DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Atelier.Cats.DataAccess.Extensions
{
    public static class DataAccessConfiguration
    {
        public static void InjectServices(IServiceCollection services, IConfiguration configuration)
        {
            // Real database
            services.AddDbContext<AtelierCatsContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // In memory database
            //services.AddDbContext<AtelierCatsContext>(options => options
            //    .UseInMemoryDatabase("AtelierCatsContext")
            //    .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning)));

            services.AddScoped<IDateGenerator, DateGenerator>();
            services.AddScoped<ICatRepository, CatRepository>();
            services.AddScoped<IChallengeRepository, ChallengeRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}

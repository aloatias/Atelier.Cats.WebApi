using Atelier.Cats.Domain.Repositories;
using Atelier.Cats.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Atelier.Cats.Infrastructure.Persistence.Extensions
{
    public static class PersistenceConfiguration
    {
        public static void InjectServices(IServiceCollection services, IConfiguration configuration)
        {
            // Real database
            services.AddDbContext<AtelierCatsContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // In memory database
            //services.AddDbContext<AtelierCatsContext>(options => options
            //    .UseInMemoryDatabase("AtelierCatsContext")
            //    .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning)));

            services.AddScoped<ICatRepository, CatRepository>();
            services.AddScoped<IChallengeRepository, ChallengeRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}

using Atelier.Cats.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Atelier.Cats.DataAccess.Extensions
{
    public static class DataService
    {
        public static void Inject(this IServiceCollection services)
        {
            // Real database
            //services.AddDbContext<AtelierCatsContext>(options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

            // In memory database
            services.AddDbContext<AtelierCatsContext>(options => options.UseInMemoryDatabase("AtelierCatsContext"));
        }
    }
}

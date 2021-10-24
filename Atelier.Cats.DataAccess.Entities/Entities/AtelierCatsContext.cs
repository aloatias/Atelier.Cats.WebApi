using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Atelier.Cats.DataAccess.Entities
{
    public class AtelierCatsContext : DbContext
    {
        public AtelierCatsContext(DbContextOptions<AtelierCatsContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AtelierCatsContext).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

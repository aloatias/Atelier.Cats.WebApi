using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atelier.Cats.DataAccess.Entities.Configurations
{
    public class CatConfiguration : IEntityTypeConfiguration<Cat>
    {
        public void Configure(EntityTypeBuilder<Cat> builder)
        {
            // AtelierEntity properties
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            // Alternate keys
            builder.HasAlternateKey(x => x.AtelierId);

            // Cat properties
            builder.Property(x => x.Url);
            builder.Property(x => x.CreationDate).IsRequired();
            builder.Property(x => x.LastUpdate).IsRequired();
        }
    }
}

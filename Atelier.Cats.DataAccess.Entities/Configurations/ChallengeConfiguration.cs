using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atelier.Cats.DataAccess.Entities.Configurations
{
    public class ChallengeConfiguration : IEntityTypeConfiguration<Challenge>
    {
        public void Configure(EntityTypeBuilder<Challenge> builder)
        {
            // AtelierEntity properties
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            // Alternate Keys
            builder.HasAlternateKey(x => new { x.ChallengerOneId, x.ChallengerTwoId });
            builder.HasAlternateKey(x => new { x.ChallengerTwoId, x.ChallengerOneId });

            // Challenge properties
            builder.Property(x => x.VoteDate).IsRequired();
            
            builder.Property(x => x.ChallengerOneId);
            builder.HasOne(x => x.ChallengerOne);

            builder.Property(x => x.ChallengerTwoId);
            builder.HasOne(x => x.ChallengerTwo);

            builder.Property(x => x.WinnerId);
            builder.HasOne(x => x.Winner);
        }
    }
}

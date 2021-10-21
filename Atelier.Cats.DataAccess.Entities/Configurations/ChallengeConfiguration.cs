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
            builder.HasOne(x => x.ChallengerOne)
                .WithMany(x => x.ChallengesAsContenderOne)
                .HasForeignKey(x => x.ChallengerOneId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.ChallengerTwoId);
            builder.HasOne(x => x.ChallengerTwo)
                .WithMany(x => x.ChallengesAsContenderTwo)
                .HasForeignKey(x => x.ChallengerTwoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.WinnerId);
            builder.HasOne(x => x.Winner)
                .WithMany(x => x.ChallengesWinner)
                .HasForeignKey(x => x.WinnerId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
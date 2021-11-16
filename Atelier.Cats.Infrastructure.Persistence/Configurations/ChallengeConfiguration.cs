using Atelier.Cats.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atelier.Cats.Infrastructure.Persistence.Configurations
{
    public class ChallengeConfiguration : IEntityTypeConfiguration<Challenge>
    {
        public void Configure(EntityTypeBuilder<Challenge> builder)
        {
            // AtelierEntity properties
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            // Alternate Keys
            builder.HasAlternateKey(x => new { x.WinnerId, x.LoserId });

            // Challenge properties
            builder.Property(x => x.VoteDate).IsRequired();

            builder.Property(x => x.WinnerId).IsRequired();
            builder.HasOne(x => x.Winner)
                .WithMany(x => x.ChallengesWinner)
                .HasForeignKey(x => x.WinnerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.LoserId);
            builder.HasOne(x => x.Loser)
                .WithMany(x => x.ChallengesLoser)
                .HasForeignKey(x => x.LoserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
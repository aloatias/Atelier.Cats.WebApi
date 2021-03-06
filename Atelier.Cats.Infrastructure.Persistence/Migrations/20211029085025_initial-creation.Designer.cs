// <auto-generated />
using System;
using Atelier.Cats.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Atelier.Cats.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(AtelierCatsContext))]
    [Migration("20211029085025_initial-creation")]
    partial class initialcreation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Atelier.Cats.Domain.Entities.Cat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AtelierId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasAlternateKey("AtelierId");

                    b.ToTable("Cat");
                });

            modelBuilder.Entity("Atelier.Cats.Domain.Entities.Challenge", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChallengerOneId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChallengerTwoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("VoteDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("WinnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasAlternateKey("ChallengerOneId", "ChallengerTwoId");

                    b.HasAlternateKey("ChallengerTwoId", "ChallengerOneId");

                    b.HasIndex("WinnerId");

                    b.ToTable("Challenge");
                });

            modelBuilder.Entity("Atelier.Cats.Domain.Entities.Challenge", b =>
                {
                    b.HasOne("Atelier.Cats.Domain.Entities.Cat", "ChallengerOne")
                        .WithMany("ChallengesAsContenderOne")
                        .HasForeignKey("ChallengerOneId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Atelier.Cats.Domain.Entities.Cat", "ChallengerTwo")
                        .WithMany("ChallengesAsContenderTwo")
                        .HasForeignKey("ChallengerTwoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Atelier.Cats.Domain.Entities.Cat", "Winner")
                        .WithMany("ChallengesWinner")
                        .HasForeignKey("WinnerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ChallengerOne");

                    b.Navigation("ChallengerTwo");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("Atelier.Cats.Domain.Entities.Cat", b =>
                {
                    b.Navigation("ChallengesAsContenderOne");

                    b.Navigation("ChallengesAsContenderTwo");

                    b.Navigation("ChallengesWinner");
                });
#pragma warning restore 612, 618
        }
    }
}

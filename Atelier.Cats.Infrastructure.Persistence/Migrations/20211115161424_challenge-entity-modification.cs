using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Atelier.Cats.Infrastructure.Persistence.Migrations
{
    public partial class challengeentitymodification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Challenge_Cat_ChallengerOneId",
                table: "Challenge");

            migrationBuilder.DropForeignKey(
                name: "FK_Challenge_Cat_ChallengerTwoId",
                table: "Challenge");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Challenge_ChallengerOneId_ChallengerTwoId",
                table: "Challenge");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Challenge_ChallengerTwoId_ChallengerOneId",
                table: "Challenge");

            migrationBuilder.DropIndex(
                name: "IX_Challenge_WinnerId",
                table: "Challenge");

            migrationBuilder.DropColumn(
                name: "ChallengerOneId",
                table: "Challenge");

            migrationBuilder.RenameColumn(
                name: "ChallengerTwoId",
                table: "Challenge",
                newName: "LoserId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Challenge_WinnerId_LoserId",
                table: "Challenge",
                columns: new[] { "WinnerId", "LoserId" });

            migrationBuilder.CreateIndex(
                name: "IX_Challenge_LoserId",
                table: "Challenge",
                column: "LoserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Challenge_Cat_LoserId",
                table: "Challenge",
                column: "LoserId",
                principalTable: "Cat",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Challenge_Cat_LoserId",
                table: "Challenge");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Challenge_WinnerId_LoserId",
                table: "Challenge");

            migrationBuilder.DropIndex(
                name: "IX_Challenge_LoserId",
                table: "Challenge");

            migrationBuilder.RenameColumn(
                name: "LoserId",
                table: "Challenge",
                newName: "ChallengerTwoId");

            migrationBuilder.AddColumn<Guid>(
                name: "ChallengerOneId",
                table: "Challenge",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Challenge_ChallengerOneId_ChallengerTwoId",
                table: "Challenge",
                columns: new[] { "ChallengerOneId", "ChallengerTwoId" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Challenge_ChallengerTwoId_ChallengerOneId",
                table: "Challenge",
                columns: new[] { "ChallengerTwoId", "ChallengerOneId" });

            migrationBuilder.CreateIndex(
                name: "IX_Challenge_WinnerId",
                table: "Challenge",
                column: "WinnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Challenge_Cat_ChallengerOneId",
                table: "Challenge",
                column: "ChallengerOneId",
                principalTable: "Cat",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Challenge_Cat_ChallengerTwoId",
                table: "Challenge",
                column: "ChallengerTwoId",
                principalTable: "Cat",
                principalColumn: "Id");
        }
    }
}

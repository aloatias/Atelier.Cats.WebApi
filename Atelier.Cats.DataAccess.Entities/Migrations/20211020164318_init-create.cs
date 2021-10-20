using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Atelier.Cats.DataAccess.Entities.Migrations
{
    public partial class initcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cat",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AtelierId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat", x => x.Id);
                    table.UniqueConstraint("AK_Cat_AtelierId", x => x.AtelierId);
                });

            migrationBuilder.CreateTable(
                name: "Challenge",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChallengerOneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChallengerTwoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WinnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoteDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challenge", x => x.Id);
                    table.UniqueConstraint("AK_Challenge_ChallengerOneId_ChallengerTwoId", x => new { x.ChallengerOneId, x.ChallengerTwoId });
                    table.UniqueConstraint("AK_Challenge_ChallengerTwoId_ChallengerOneId", x => new { x.ChallengerTwoId, x.ChallengerOneId });
                    table.ForeignKey(
                        name: "FK_Challenge_Cat_ChallengerOneId",
                        column: x => x.ChallengerOneId,
                        principalTable: "Cat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Challenge_Cat_ChallengerTwoId",
                        column: x => x.ChallengerTwoId,
                        principalTable: "Cat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Challenge_Cat_WinnerId",
                        column: x => x.WinnerId,
                        principalTable: "Cat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Challenge_WinnerId",
                table: "Challenge",
                column: "WinnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Challenge");

            migrationBuilder.DropTable(
                name: "Cat");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableContactCyberAwarenessScores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactCyberAwarenessScores",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ContactId = table.Column<long>(nullable: true),
                    CyberAwarenessScoreId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactCyberAwarenessScores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactCyberAwarenessScores_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContactCyberAwarenessScores_CyberAwarenessScores_CyberAwarenessScoreId",
                        column: x => x.CyberAwarenessScoreId,
                        principalTable: "CyberAwarenessScores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactCyberAwarenessScores_ContactId",
                table: "ContactCyberAwarenessScores",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactCyberAwarenessScores_CyberAwarenessScoreId",
                table: "ContactCyberAwarenessScores",
                column: "CyberAwarenessScoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactCyberAwarenessScores");
        }
    }
}

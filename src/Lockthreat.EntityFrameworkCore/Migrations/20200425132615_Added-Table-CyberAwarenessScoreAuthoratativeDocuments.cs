using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableCyberAwarenessScoreAuthoratativeDocuments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CyberAwarenessScoreAuthoratativeDocuments",
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
                    CyberAwarenessScoreId = table.Column<long>(nullable: true),
                    AuthoratativeDocumentId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CyberAwarenessScoreAuthoratativeDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CyberAwarenessScoreAuthoratativeDocuments_AuthoratativeDocuments_AuthoratativeDocumentId",
                        column: x => x.AuthoratativeDocumentId,
                        principalTable: "AuthoratativeDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CyberAwarenessScoreAuthoratativeDocuments_CyberAwarenessScores_CyberAwarenessScoreId",
                        column: x => x.CyberAwarenessScoreId,
                        principalTable: "CyberAwarenessScores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CyberAwarenessScoreAuthoratativeDocuments_AuthoratativeDocumentId",
                table: "CyberAwarenessScoreAuthoratativeDocuments",
                column: "AuthoratativeDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_CyberAwarenessScoreAuthoratativeDocuments_CyberAwarenessScoreId",
                table: "CyberAwarenessScoreAuthoratativeDocuments",
                column: "CyberAwarenessScoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CyberAwarenessScoreAuthoratativeDocuments");
        }
    }
}

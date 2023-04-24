using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableAuthoratativeDocumentCitations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthoratativeDocumentCitations",
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
                    AuthoratativeDocumentId = table.Column<long>(nullable: true),
                    CitationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthoratativeDocumentCitations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthoratativeDocumentCitations_AuthoratativeDocuments_AuthoratativeDocumentId",
                        column: x => x.AuthoratativeDocumentId,
                        principalTable: "AuthoratativeDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AuthoratativeDocumentCitations_Citations_CitationId",
                        column: x => x.CitationId,
                        principalTable: "Citations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthoratativeDocumentCitations_AuthoratativeDocumentId",
                table: "AuthoratativeDocumentCitations",
                column: "AuthoratativeDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthoratativeDocumentCitations_CitationId",
                table: "AuthoratativeDocumentCitations",
                column: "CitationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthoratativeDocumentCitations");
        }
    }
}

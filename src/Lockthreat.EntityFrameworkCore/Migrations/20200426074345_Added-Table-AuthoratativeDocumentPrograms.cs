using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableAuthoratativeDocumentPrograms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthoratativeDocumentPrograms",
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
                    GrcProgramId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthoratativeDocumentPrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthoratativeDocumentPrograms_AuthoratativeDocuments_AuthoratativeDocumentId",
                        column: x => x.AuthoratativeDocumentId,
                        principalTable: "AuthoratativeDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AuthoratativeDocumentPrograms_GrcPrograms_GrcProgramId",
                        column: x => x.GrcProgramId,
                        principalTable: "GrcPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthoratativeDocumentPrograms_AuthoratativeDocumentId",
                table: "AuthoratativeDocumentPrograms",
                column: "AuthoratativeDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthoratativeDocumentPrograms_GrcProgramId",
                table: "AuthoratativeDocumentPrograms",
                column: "GrcProgramId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthoratativeDocumentPrograms");
        }
    }
}

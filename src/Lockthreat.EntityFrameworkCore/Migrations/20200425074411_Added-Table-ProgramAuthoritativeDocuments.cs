using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableProgramAuthoritativeDocuments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgramAuthoritativeDocuments",
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
                    GrcProgramId = table.Column<long>(nullable: true),
                    AuthoratativeDocumentId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramAuthoritativeDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramAuthoritativeDocuments_AuthoratativeDocuments_AuthoratativeDocumentId",
                        column: x => x.AuthoratativeDocumentId,
                        principalTable: "AuthoratativeDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProgramAuthoritativeDocuments_GrcPrograms_GrcProgramId",
                        column: x => x.GrcProgramId,
                        principalTable: "GrcPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgramAuthoritativeDocuments_AuthoratativeDocumentId",
                table: "ProgramAuthoritativeDocuments",
                column: "AuthoratativeDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramAuthoritativeDocuments_GrcProgramId",
                table: "ProgramAuthoritativeDocuments",
                column: "GrcProgramId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgramAuthoritativeDocuments");
        }
    }
}

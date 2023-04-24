using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableInternalControlCitations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InternalControlCitations",
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
                    InternalControlId = table.Column<long>(nullable: true),
                    CitationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalControlCitations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InternalControlCitations_Citations_CitationId",
                        column: x => x.CitationId,
                        principalTable: "Citations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InternalControlCitations_InternalControls_InternalControlId",
                        column: x => x.InternalControlId,
                        principalTable: "InternalControls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InternalControlCitations_CitationId",
                table: "InternalControlCitations",
                column: "CitationId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalControlCitations_InternalControlId",
                table: "InternalControlCitations",
                column: "InternalControlId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InternalControlCitations");
        }
    }
}

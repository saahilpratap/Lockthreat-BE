using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTablePolicyRelatedControls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PolicyRelatedControls",
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
                    PolicyManagerId = table.Column<long>(nullable: true),
                    CitationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyRelatedControls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PolicyRelatedControls_Citations_CitationId",
                        column: x => x.CitationId,
                        principalTable: "Citations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PolicyRelatedControls_PolicyManagers_PolicyManagerId",
                        column: x => x.PolicyManagerId,
                        principalTable: "PolicyManagers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PolicyRelatedControls_CitationId",
                table: "PolicyRelatedControls",
                column: "CitationId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyRelatedControls_PolicyManagerId",
                table: "PolicyRelatedControls",
                column: "PolicyManagerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PolicyRelatedControls");
        }
    }
}

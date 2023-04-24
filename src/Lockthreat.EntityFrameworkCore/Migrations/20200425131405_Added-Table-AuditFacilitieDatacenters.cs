using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableAuditFacilitieDatacenters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditFacilitieDatacenters",
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
                    AuditId = table.Column<long>(nullable: true),
                    FacilitieDatacenterId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditFacilitieDatacenters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditFacilitieDatacenters_Audits_AuditId",
                        column: x => x.AuditId,
                        principalTable: "Audits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AuditFacilitieDatacenters_FacilitieDatacenters_FacilitieDatacenterId",
                        column: x => x.FacilitieDatacenterId,
                        principalTable: "FacilitieDatacenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditFacilitieDatacenters_AuditId",
                table: "AuditFacilitieDatacenters",
                column: "AuditId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditFacilitieDatacenters_FacilitieDatacenterId",
                table: "AuditFacilitieDatacenters",
                column: "FacilitieDatacenterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditFacilitieDatacenters");
        }
    }
}

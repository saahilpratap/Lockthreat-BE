using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableBIABusinessProcesses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BIABusinessProcesses",
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
                    BusinessProcessId = table.Column<long>(nullable: true),
                    BusinessImpactAnalysisId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BIABusinessProcesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BIABusinessProcesses_BusinessImpactAnalysises_BusinessImpactAnalysisId",
                        column: x => x.BusinessImpactAnalysisId,
                        principalTable: "BusinessImpactAnalysises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BIABusinessProcesses_BusinessProcess_BusinessProcessId",
                        column: x => x.BusinessProcessId,
                        principalTable: "BusinessProcess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BIABusinessProcesses_BusinessImpactAnalysisId",
                table: "BIABusinessProcesses",
                column: "BusinessImpactAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_BIABusinessProcesses_BusinessProcessId",
                table: "BIABusinessProcesses",
                column: "BusinessProcessId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BIABusinessProcesses");
        }
    }
}

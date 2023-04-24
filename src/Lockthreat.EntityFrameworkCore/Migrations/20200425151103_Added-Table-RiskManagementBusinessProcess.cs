using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableRiskManagementBusinessProcess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RiskManagementBusinessProcess",
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
                    RiskManagementId = table.Column<long>(nullable: true),
                    BusinessProcessId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskManagementBusinessProcess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RiskManagementBusinessProcess_BusinessProcess_BusinessProcessId",
                        column: x => x.BusinessProcessId,
                        principalTable: "BusinessProcess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RiskManagementBusinessProcess_RiskManagements_RiskManagementId",
                        column: x => x.RiskManagementId,
                        principalTable: "RiskManagements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RiskManagementBusinessProcess_BusinessProcessId",
                table: "RiskManagementBusinessProcess",
                column: "BusinessProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskManagementBusinessProcess_RiskManagementId",
                table: "RiskManagementBusinessProcess",
                column: "RiskManagementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RiskManagementBusinessProcess");
        }
    }
}

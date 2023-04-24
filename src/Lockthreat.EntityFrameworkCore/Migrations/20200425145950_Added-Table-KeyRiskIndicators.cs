using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableKeyRiskIndicators : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KeyRiskIndicators",
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
                    TenantId = table.Column<int>(nullable: true),
                    KeyRiskIndicatorsId = table.Column<string>(nullable: true),
                    StatusId = table.Column<int>(nullable: true),
                    KeyRiskIndicatorTitle = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    LockThreatOrganizationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyRiskIndicators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KeyRiskIndicators_LockThreatOrganizations_LockThreatOrganizationId",
                        column: x => x.LockThreatOrganizationId,
                        principalTable: "LockThreatOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KeyRiskIndicators_AbpDynamicParameterValues_StatusId",
                        column: x => x.StatusId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KeyRiskIndicators_LockThreatOrganizationId",
                table: "KeyRiskIndicators",
                column: "LockThreatOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_KeyRiskIndicators_StatusId",
                table: "KeyRiskIndicators",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeyRiskIndicators");
        }
    }
}

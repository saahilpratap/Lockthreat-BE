using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableKeyPerformanceIndicators : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KeyPerformanceIndicators",
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
                    KeyPerformanceIndicatorId = table.Column<string>(nullable: true),
                    KeyPerformanceIndicatorTitle = table.Column<string>(nullable: false),
                    StatusId = table.Column<int>(nullable: true),
                    FrequencyId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<long>(nullable: true),
                    LockThreatOrganizationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyPerformanceIndicators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KeyPerformanceIndicators_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KeyPerformanceIndicators_AbpDynamicParameterValues_FrequencyId",
                        column: x => x.FrequencyId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KeyPerformanceIndicators_LockThreatOrganizations_LockThreatOrganizationId",
                        column: x => x.LockThreatOrganizationId,
                        principalTable: "LockThreatOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KeyPerformanceIndicators_AbpDynamicParameterValues_StatusId",
                        column: x => x.StatusId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KeyPerformanceIndicators_EmployeeId",
                table: "KeyPerformanceIndicators",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_KeyPerformanceIndicators_FrequencyId",
                table: "KeyPerformanceIndicators",
                column: "FrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_KeyPerformanceIndicators_LockThreatOrganizationId",
                table: "KeyPerformanceIndicators",
                column: "LockThreatOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_KeyPerformanceIndicators_StatusId",
                table: "KeyPerformanceIndicators",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeyPerformanceIndicators");
        }
    }
}

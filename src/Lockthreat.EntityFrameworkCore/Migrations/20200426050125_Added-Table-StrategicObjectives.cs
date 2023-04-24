using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableStrategicObjectives : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StrategicObjectives",
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
                    StrategicObjectiveId = table.Column<string>(nullable: true),
                    ExecutiveSponsorId = table.Column<long>(nullable: true),
                    StrategicObjectiveTitle = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EffectiveDate = table.Column<DateTime>(nullable: true),
                    StatusId = table.Column<int>(nullable: true),
                    TypeId = table.Column<int>(nullable: true),
                    GoalId = table.Column<int>(nullable: true),
                    LockThreatOrganizationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrategicObjectives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrategicObjectives_Employees_ExecutiveSponsorId",
                        column: x => x.ExecutiveSponsorId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StrategicObjectives_AbpDynamicParameterValues_GoalId",
                        column: x => x.GoalId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StrategicObjectives_LockThreatOrganizations_LockThreatOrganizationId",
                        column: x => x.LockThreatOrganizationId,
                        principalTable: "LockThreatOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StrategicObjectives_AbpDynamicParameterValues_StatusId",
                        column: x => x.StatusId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StrategicObjectives_AbpDynamicParameterValues_TypeId",
                        column: x => x.TypeId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StrategicObjectives_ExecutiveSponsorId",
                table: "StrategicObjectives",
                column: "ExecutiveSponsorId");

            migrationBuilder.CreateIndex(
                name: "IX_StrategicObjectives_GoalId",
                table: "StrategicObjectives",
                column: "GoalId");

            migrationBuilder.CreateIndex(
                name: "IX_StrategicObjectives_LockThreatOrganizationId",
                table: "StrategicObjectives",
                column: "LockThreatOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_StrategicObjectives_StatusId",
                table: "StrategicObjectives",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_StrategicObjectives_TypeId",
                table: "StrategicObjectives",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StrategicObjectives");
        }
    }
}

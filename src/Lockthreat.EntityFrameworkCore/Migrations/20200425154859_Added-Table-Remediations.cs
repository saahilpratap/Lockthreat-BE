using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableRemediations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Remediations",
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
                    RemediationPlanId = table.Column<string>(nullable: true),
                    PlanTitle = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EstimatedCost = table.Column<int>(nullable: true),
                    PriorityId = table.Column<int>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    CompletionDate = table.Column<DateTime>(nullable: true),
                    TreatmentActionId = table.Column<int>(nullable: true),
                    RemediationsTypeId = table.Column<int>(nullable: true),
                    SubmissionStatusId = table.Column<int>(nullable: true),
                    PlanOwnerId = table.Column<long>(nullable: true),
                    PlanManagerId = table.Column<long>(nullable: true),
                    PlanStatusId = table.Column<int>(nullable: true),
                    MitigationCost = table.Column<int>(nullable: true),
                    RemediationActivity = table.Column<string>(nullable: true),
                    StartDateActual = table.Column<DateTime>(nullable: true),
                    CompletionDateActual = table.Column<DateTime>(nullable: true),
                    RiskManagementId = table.Column<long>(nullable: true),
                    RiskManagementsId = table.Column<long>(nullable: true),
                    ActualCostIncurred = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Remediations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Remediations_Employees_PlanManagerId",
                        column: x => x.PlanManagerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Remediations_Employees_PlanOwnerId",
                        column: x => x.PlanOwnerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Remediations_AbpDynamicParameterValues_PlanStatusId",
                        column: x => x.PlanStatusId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Remediations_AbpDynamicParameterValues_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Remediations_AbpDynamicParameterValues_RemediationsTypeId",
                        column: x => x.RemediationsTypeId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Remediations_RiskManagements_RiskManagementId",
                        column: x => x.RiskManagementId,
                        principalTable: "RiskManagements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Remediations_RiskManagements_RiskManagementsId",
                        column: x => x.RiskManagementsId,
                        principalTable: "RiskManagements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Remediations_AbpDynamicParameterValues_SubmissionStatusId",
                        column: x => x.SubmissionStatusId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Remediations_AbpDynamicParameterValues_TreatmentActionId",
                        column: x => x.TreatmentActionId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Remediations_PlanManagerId",
                table: "Remediations",
                column: "PlanManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Remediations_PlanOwnerId",
                table: "Remediations",
                column: "PlanOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Remediations_PlanStatusId",
                table: "Remediations",
                column: "PlanStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Remediations_PriorityId",
                table: "Remediations",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Remediations_RemediationsTypeId",
                table: "Remediations",
                column: "RemediationsTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Remediations_RiskManagementId",
                table: "Remediations",
                column: "RiskManagementId");

            migrationBuilder.CreateIndex(
                name: "IX_Remediations_RiskManagementsId",
                table: "Remediations",
                column: "RiskManagementsId");

            migrationBuilder.CreateIndex(
                name: "IX_Remediations_SubmissionStatusId",
                table: "Remediations",
                column: "SubmissionStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Remediations_TreatmentActionId",
                table: "Remediations",
                column: "TreatmentActionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Remediations");
        }
    }
}

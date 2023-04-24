using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableRiskTreatments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RiskTreatments",
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
                    RiskTreatmentPlanId = table.Column<string>(nullable: true),
                    RiskTreatmentTitle = table.Column<string>(nullable: true),
                    RiskManagementId = table.Column<long>(nullable: true),
                    OwnerId = table.Column<long>(nullable: true),
                    TreatmentActionId = table.Column<int>(nullable: true),
                    MitigationOwnerId = table.Column<long>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: true),
                    MitigationCost = table.Column<int>(nullable: true),
                    MitigationActivity = table.Column<string>(nullable: true),
                    MitigationStatusId = table.Column<int>(nullable: true),
                    RiskAvoidancePlan = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    ResidualImpactRatingId = table.Column<int>(nullable: true),
                    ResidualLikelihoodRatingId = table.Column<int>(nullable: true),
                    ResidualRiskNotes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskTreatments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RiskTreatments_Employees_MitigationOwnerId",
                        column: x => x.MitigationOwnerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RiskTreatments_AbpDynamicParameterValues_MitigationStatusId",
                        column: x => x.MitigationStatusId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RiskTreatments_Employees_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RiskTreatments_AbpDynamicParameterValues_ResidualImpactRatingId",
                        column: x => x.ResidualImpactRatingId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RiskTreatments_AbpDynamicParameterValues_ResidualLikelihoodRatingId",
                        column: x => x.ResidualLikelihoodRatingId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RiskTreatments_RiskManagements_RiskManagementId",
                        column: x => x.RiskManagementId,
                        principalTable: "RiskManagements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RiskTreatments_AbpDynamicParameterValues_TreatmentActionId",
                        column: x => x.TreatmentActionId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RiskTreatments_MitigationOwnerId",
                table: "RiskTreatments",
                column: "MitigationOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskTreatments_MitigationStatusId",
                table: "RiskTreatments",
                column: "MitigationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskTreatments_OwnerId",
                table: "RiskTreatments",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskTreatments_ResidualImpactRatingId",
                table: "RiskTreatments",
                column: "ResidualImpactRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskTreatments_ResidualLikelihoodRatingId",
                table: "RiskTreatments",
                column: "ResidualLikelihoodRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskTreatments_RiskManagementId",
                table: "RiskTreatments",
                column: "RiskManagementId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskTreatments_TreatmentActionId",
                table: "RiskTreatments",
                column: "TreatmentActionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RiskTreatments");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableBusinessImpactAnalysises : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessImpactAnalysises",
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
                    BIAId = table.Column<string>(nullable: true),
                    LockThreatOrganizationId = table.Column<long>(nullable: true),
                    BusinessUnitId = table.Column<long>(nullable: true),
                    BIATitle = table.Column<string>(nullable: true),
                    BIAOwnerId = table.Column<long>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    BIAManagerId = table.Column<long>(nullable: true),
                    RiskCategoryId = table.Column<int>(nullable: true),
                    NextReviewDate = table.Column<DateTime>(nullable: true),
                    Criticality = table.Column<int>(nullable: false),
                    BIATypeId = table.Column<int>(nullable: true),
                    RiskLikelihoodId = table.Column<int>(nullable: true),
                    NextEvaluation = table.Column<DateTime>(nullable: true),
                    RiskImpactId = table.Column<int>(nullable: true),
                    PersistenceId = table.Column<int>(nullable: true),
                    EvaluationFrequency = table.Column<int>(nullable: true),
                    EvaluationIRR = table.Column<DateTime>(nullable: true),
                    VelocityId = table.Column<int>(nullable: true),
                    DurationId = table.Column<int>(nullable: true),
                    ResidualRiskId = table.Column<int>(nullable: true),
                    ExpectedLoss = table.Column<int>(nullable: true),
                    InherentRiskId = table.Column<int>(nullable: true),
                    RiskTreatmentSelectedId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessImpactAnalysises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessImpactAnalysises_Employees_BIAManagerId",
                        column: x => x.BIAManagerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessImpactAnalysises_Employees_BIAOwnerId",
                        column: x => x.BIAOwnerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessImpactAnalysises_AbpDynamicParameterValues_BIATypeId",
                        column: x => x.BIATypeId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessImpactAnalysises_BusinessUnits_BusinessUnitId",
                        column: x => x.BusinessUnitId,
                        principalTable: "BusinessUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessImpactAnalysises_AbpDynamicParameterValues_DurationId",
                        column: x => x.DurationId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessImpactAnalysises_AbpDynamicParameterValues_InherentRiskId",
                        column: x => x.InherentRiskId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessImpactAnalysises_LockThreatOrganizations_LockThreatOrganizationId",
                        column: x => x.LockThreatOrganizationId,
                        principalTable: "LockThreatOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessImpactAnalysises_AbpDynamicParameterValues_PersistenceId",
                        column: x => x.PersistenceId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessImpactAnalysises_AbpDynamicParameterValues_ResidualRiskId",
                        column: x => x.ResidualRiskId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessImpactAnalysises_AbpDynamicParameterValues_RiskCategoryId",
                        column: x => x.RiskCategoryId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessImpactAnalysises_AbpDynamicParameterValues_RiskImpactId",
                        column: x => x.RiskImpactId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessImpactAnalysises_AbpDynamicParameterValues_RiskLikelihoodId",
                        column: x => x.RiskLikelihoodId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessImpactAnalysises_AbpDynamicParameterValues_RiskTreatmentSelectedId",
                        column: x => x.RiskTreatmentSelectedId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessImpactAnalysises_AbpDynamicParameterValues_VelocityId",
                        column: x => x.VelocityId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessImpactAnalysises_BIAManagerId",
                table: "BusinessImpactAnalysises",
                column: "BIAManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessImpactAnalysises_BIAOwnerId",
                table: "BusinessImpactAnalysises",
                column: "BIAOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessImpactAnalysises_BIATypeId",
                table: "BusinessImpactAnalysises",
                column: "BIATypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessImpactAnalysises_BusinessUnitId",
                table: "BusinessImpactAnalysises",
                column: "BusinessUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessImpactAnalysises_DurationId",
                table: "BusinessImpactAnalysises",
                column: "DurationId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessImpactAnalysises_InherentRiskId",
                table: "BusinessImpactAnalysises",
                column: "InherentRiskId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessImpactAnalysises_LockThreatOrganizationId",
                table: "BusinessImpactAnalysises",
                column: "LockThreatOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessImpactAnalysises_PersistenceId",
                table: "BusinessImpactAnalysises",
                column: "PersistenceId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessImpactAnalysises_ResidualRiskId",
                table: "BusinessImpactAnalysises",
                column: "ResidualRiskId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessImpactAnalysises_RiskCategoryId",
                table: "BusinessImpactAnalysises",
                column: "RiskCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessImpactAnalysises_RiskImpactId",
                table: "BusinessImpactAnalysises",
                column: "RiskImpactId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessImpactAnalysises_RiskLikelihoodId",
                table: "BusinessImpactAnalysises",
                column: "RiskLikelihoodId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessImpactAnalysises_RiskTreatmentSelectedId",
                table: "BusinessImpactAnalysises",
                column: "RiskTreatmentSelectedId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessImpactAnalysises_VelocityId",
                table: "BusinessImpactAnalysises",
                column: "VelocityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessImpactAnalysises");
        }
    }
}

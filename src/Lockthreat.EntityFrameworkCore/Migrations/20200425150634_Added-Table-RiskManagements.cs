using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableRiskManagements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RiskManagements",
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
                    RiskId = table.Column<string>(nullable: true),
                    RiskTitle = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Criticality = table.Column<int>(nullable: false),
                    LastEvaluationDate = table.Column<DateTime>(nullable: true),
                    RiskTriggerEvent = table.Column<string>(nullable: true),
                    RiskTypeId = table.Column<int>(nullable: true),
                    RiskCategoryId = table.Column<int>(nullable: true),
                    RiskSourceId = table.Column<int>(nullable: true),
                    RiskStateId = table.Column<int>(nullable: true),
                    RiskStatusId = table.Column<int>(nullable: true),
                    CompanyNameId = table.Column<long>(nullable: true),
                    RiskOwnerId = table.Column<long>(nullable: true),
                    RiskManagerId = table.Column<long>(nullable: true),
                    BusinessUnitId = table.Column<long>(nullable: true),
                    RiskScoringMethodId = table.Column<int>(nullable: true),
                    NextEvaluation = table.Column<DateTime>(nullable: true),
                    NextEvaluationIRRBased = table.Column<DateTime>(nullable: true),
                    RiskLikelihoodId = table.Column<int>(nullable: true),
                    RiskImpactId = table.Column<int>(nullable: true),
                    RiskLiRiskImpactkelihoodId = table.Column<int>(nullable: true),
                    EvaluationFrequency = table.Column<int>(nullable: true),
                    RiskScore = table.Column<int>(nullable: true),
                    PersistenceId = table.Column<int>(nullable: true),
                    VelocityId = table.Column<int>(nullable: true),
                    ResidualRiskId = table.Column<int>(nullable: true),
                    InherentRiskId = table.Column<int>(nullable: true),
                    RiskTreatmentId = table.Column<int>(nullable: true),
                    DurationId = table.Column<int>(nullable: true),
                    ExpectedLoss = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskManagements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RiskManagements_BusinessUnits_BusinessUnitId",
                        column: x => x.BusinessUnitId,
                        principalTable: "BusinessUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RiskManagements_LockThreatOrganizations_CompanyNameId",
                        column: x => x.CompanyNameId,
                        principalTable: "LockThreatOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RiskManagements_AbpDynamicParameterValues_DurationId",
                        column: x => x.DurationId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RiskManagements_AbpDynamicParameterValues_InherentRiskId",
                        column: x => x.InherentRiskId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RiskManagements_AbpDynamicParameterValues_PersistenceId",
                        column: x => x.PersistenceId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RiskManagements_AbpDynamicParameterValues_ResidualRiskId",
                        column: x => x.ResidualRiskId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RiskManagements_AbpDynamicParameterValues_RiskCategoryId",
                        column: x => x.RiskCategoryId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RiskManagements_AbpDynamicParameterValues_RiskLiRiskImpactkelihoodId",
                        column: x => x.RiskLiRiskImpactkelihoodId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RiskManagements_AbpDynamicParameterValues_RiskLikelihoodId",
                        column: x => x.RiskLikelihoodId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RiskManagements_Employees_RiskManagerId",
                        column: x => x.RiskManagerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RiskManagements_Employees_RiskOwnerId",
                        column: x => x.RiskOwnerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RiskManagements_AbpDynamicParameterValues_RiskScoringMethodId",
                        column: x => x.RiskScoringMethodId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RiskManagements_AbpDynamicParameterValues_RiskSourceId",
                        column: x => x.RiskSourceId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RiskManagements_AbpDynamicParameterValues_RiskStateId",
                        column: x => x.RiskStateId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RiskManagements_AbpDynamicParameterValues_RiskStatusId",
                        column: x => x.RiskStatusId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RiskManagements_AbpDynamicParameterValues_RiskTreatmentId",
                        column: x => x.RiskTreatmentId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RiskManagements_AbpDynamicParameterValues_RiskTypeId",
                        column: x => x.RiskTypeId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RiskManagements_AbpDynamicParameterValues_VelocityId",
                        column: x => x.VelocityId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RiskManagements_BusinessUnitId",
                table: "RiskManagements",
                column: "BusinessUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskManagements_CompanyNameId",
                table: "RiskManagements",
                column: "CompanyNameId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskManagements_DurationId",
                table: "RiskManagements",
                column: "DurationId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskManagements_InherentRiskId",
                table: "RiskManagements",
                column: "InherentRiskId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskManagements_PersistenceId",
                table: "RiskManagements",
                column: "PersistenceId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskManagements_ResidualRiskId",
                table: "RiskManagements",
                column: "ResidualRiskId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskManagements_RiskCategoryId",
                table: "RiskManagements",
                column: "RiskCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskManagements_RiskLiRiskImpactkelihoodId",
                table: "RiskManagements",
                column: "RiskLiRiskImpactkelihoodId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskManagements_RiskLikelihoodId",
                table: "RiskManagements",
                column: "RiskLikelihoodId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskManagements_RiskManagerId",
                table: "RiskManagements",
                column: "RiskManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskManagements_RiskOwnerId",
                table: "RiskManagements",
                column: "RiskOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskManagements_RiskScoringMethodId",
                table: "RiskManagements",
                column: "RiskScoringMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskManagements_RiskSourceId",
                table: "RiskManagements",
                column: "RiskSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskManagements_RiskStateId",
                table: "RiskManagements",
                column: "RiskStateId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskManagements_RiskStatusId",
                table: "RiskManagements",
                column: "RiskStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskManagements_RiskTreatmentId",
                table: "RiskManagements",
                column: "RiskTreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskManagements_RiskTypeId",
                table: "RiskManagements",
                column: "RiskTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskManagements_VelocityId",
                table: "RiskManagements",
                column: "VelocityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RiskManagements");
        }
    }
}

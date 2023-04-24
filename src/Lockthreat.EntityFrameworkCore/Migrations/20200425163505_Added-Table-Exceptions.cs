using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableExceptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exceptions",
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
                    ExceptionId = table.Column<string>(nullable: true),
                    RequestedDate = table.Column<DateTime>(nullable: true),
                    BusinessJustification = table.Column<string>(nullable: true),
                    ExceptionTitle = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    ExpertReviewerId = table.Column<long>(nullable: true),
                    ReviewDate = table.Column<DateTime>(nullable: true),
                    ApprovedTill = table.Column<DateTime>(nullable: true),
                    NextReview = table.Column<DateTime>(nullable: true),
                    RiskDetails = table.Column<string>(nullable: true),
                    CritcalityId = table.Column<int>(nullable: true),
                    ReviewPriorityId = table.Column<int>(nullable: true),
                    TypeId = table.Column<int>(nullable: true),
                    ExceptionStatusId = table.Column<int>(nullable: true),
                    ReviewStatusId = table.Column<int>(nullable: true),
                    LockThreatOrganizationId = table.Column<long>(nullable: true),
                    EmployeeId = table.Column<long>(nullable: true),
                    BusinessUnitId = table.Column<long>(nullable: true),
                    AssetInformationId = table.Column<long>(nullable: true),
                    PolicyManagerId = table.Column<long>(nullable: true),
                    SystemApplicationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exceptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exceptions_AssetInformations_AssetInformationId",
                        column: x => x.AssetInformationId,
                        principalTable: "AssetInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exceptions_BusinessUnits_BusinessUnitId",
                        column: x => x.BusinessUnitId,
                        principalTable: "BusinessUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exceptions_AbpDynamicParameterValues_CritcalityId",
                        column: x => x.CritcalityId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exceptions_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exceptions_AbpDynamicParameterValues_ExceptionStatusId",
                        column: x => x.ExceptionStatusId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exceptions_Employees_ExpertReviewerId",
                        column: x => x.ExpertReviewerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exceptions_LockThreatOrganizations_LockThreatOrganizationId",
                        column: x => x.LockThreatOrganizationId,
                        principalTable: "LockThreatOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exceptions_PolicyManagers_PolicyManagerId",
                        column: x => x.PolicyManagerId,
                        principalTable: "PolicyManagers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exceptions_AbpDynamicParameterValues_ReviewPriorityId",
                        column: x => x.ReviewPriorityId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exceptions_AbpDynamicParameterValues_ReviewStatusId",
                        column: x => x.ReviewStatusId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exceptions_SystemApplications_SystemApplicationId",
                        column: x => x.SystemApplicationId,
                        principalTable: "SystemApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exceptions_AbpDynamicParameterValues_TypeId",
                        column: x => x.TypeId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exceptions_AssetInformationId",
                table: "Exceptions",
                column: "AssetInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Exceptions_BusinessUnitId",
                table: "Exceptions",
                column: "BusinessUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Exceptions_CritcalityId",
                table: "Exceptions",
                column: "CritcalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Exceptions_EmployeeId",
                table: "Exceptions",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Exceptions_ExceptionStatusId",
                table: "Exceptions",
                column: "ExceptionStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Exceptions_ExpertReviewerId",
                table: "Exceptions",
                column: "ExpertReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_Exceptions_LockThreatOrganizationId",
                table: "Exceptions",
                column: "LockThreatOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Exceptions_PolicyManagerId",
                table: "Exceptions",
                column: "PolicyManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Exceptions_ReviewPriorityId",
                table: "Exceptions",
                column: "ReviewPriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Exceptions_ReviewStatusId",
                table: "Exceptions",
                column: "ReviewStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Exceptions_SystemApplicationId",
                table: "Exceptions",
                column: "SystemApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Exceptions_TypeId",
                table: "Exceptions",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exceptions");
        }
    }
}

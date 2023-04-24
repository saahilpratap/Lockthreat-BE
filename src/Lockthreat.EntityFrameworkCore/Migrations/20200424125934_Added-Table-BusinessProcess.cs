using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableBusinessProcess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessProcess",
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
                    BusinessProcessId = table.Column<string>(nullable: true),
                    BusinessProcessName = table.Column<string>(nullable: false),
                    StatusId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ProcessTypeId = table.Column<int>(nullable: true),
                    SlaApplicableId = table.Column<int>(nullable: true),
                    ActivityCycleId = table.Column<int>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    LockThreatOrganizationId = table.Column<long>(nullable: true),
                    ProcessManagerId = table.Column<long>(nullable: true),
                    ProcessOwnerId = table.Column<long>(nullable: true),
                    BusinessUnitId = table.Column<long>(nullable: true),
                    RegulatoryId = table.Column<int>(nullable: true),
                    ProcessPriorityId = table.Column<int>(nullable: true),
                    OthersId = table.Column<int>(nullable: true),
                    ConfidentialityId = table.Column<int>(nullable: true),
                    ReviewPeriodId = table.Column<int>(nullable: true),
                    IntergrityId = table.Column<int>(nullable: true),
                    AvailibilityId = table.Column<int>(nullable: true),
                    Documents = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessProcess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessProcess_AbpDynamicParameterValues_ActivityCycleId",
                        column: x => x.ActivityCycleId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessProcess_AbpDynamicParameterValues_AvailibilityId",
                        column: x => x.AvailibilityId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessProcess_BusinessUnits_BusinessUnitId",
                        column: x => x.BusinessUnitId,
                        principalTable: "BusinessUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessProcess_AbpDynamicParameterValues_ConfidentialityId",
                        column: x => x.ConfidentialityId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessProcess_AbpDynamicParameterValues_CountryId",
                        column: x => x.CountryId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessProcess_AbpDynamicParameterValues_IntergrityId",
                        column: x => x.IntergrityId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessProcess_LockThreatOrganizations_LockThreatOrganizationId",
                        column: x => x.LockThreatOrganizationId,
                        principalTable: "LockThreatOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessProcess_AbpDynamicParameterValues_OthersId",
                        column: x => x.OthersId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessProcess_Employees_ProcessManagerId",
                        column: x => x.ProcessManagerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessProcess_Employees_ProcessOwnerId",
                        column: x => x.ProcessOwnerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessProcess_AbpDynamicParameterValues_ProcessPriorityId",
                        column: x => x.ProcessPriorityId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessProcess_AbpDynamicParameterValues_ProcessTypeId",
                        column: x => x.ProcessTypeId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessProcess_AbpDynamicParameterValues_RegulatoryId",
                        column: x => x.RegulatoryId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessProcess_AbpDynamicParameterValues_ReviewPeriodId",
                        column: x => x.ReviewPeriodId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessProcess_AbpDynamicParameterValues_SlaApplicableId",
                        column: x => x.SlaApplicableId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessProcess_AbpDynamicParameterValues_StatusId",
                        column: x => x.StatusId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProcess_ActivityCycleId",
                table: "BusinessProcess",
                column: "ActivityCycleId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProcess_AvailibilityId",
                table: "BusinessProcess",
                column: "AvailibilityId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProcess_BusinessUnitId",
                table: "BusinessProcess",
                column: "BusinessUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProcess_ConfidentialityId",
                table: "BusinessProcess",
                column: "ConfidentialityId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProcess_CountryId",
                table: "BusinessProcess",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProcess_IntergrityId",
                table: "BusinessProcess",
                column: "IntergrityId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProcess_LockThreatOrganizationId",
                table: "BusinessProcess",
                column: "LockThreatOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProcess_OthersId",
                table: "BusinessProcess",
                column: "OthersId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProcess_ProcessManagerId",
                table: "BusinessProcess",
                column: "ProcessManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProcess_ProcessOwnerId",
                table: "BusinessProcess",
                column: "ProcessOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProcess_ProcessPriorityId",
                table: "BusinessProcess",
                column: "ProcessPriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProcess_ProcessTypeId",
                table: "BusinessProcess",
                column: "ProcessTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProcess_RegulatoryId",
                table: "BusinessProcess",
                column: "RegulatoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProcess_ReviewPeriodId",
                table: "BusinessProcess",
                column: "ReviewPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProcess_SlaApplicableId",
                table: "BusinessProcess",
                column: "SlaApplicableId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProcess_StatusId",
                table: "BusinessProcess",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessProcess");
        }
    }
}

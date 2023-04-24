using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableAudits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Audits",
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
                    AuditId = table.Column<string>(nullable: true),
                    AuditTitle = table.Column<string>(nullable: true),
                    AuditTypes = table.Column<int>(nullable: false),
                    AuditTypeseother = table.Column<string>(nullable: true),
                    FinacialYearId = table.Column<int>(nullable: true),
                    FinacialYearOther = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    AuditDuration = table.Column<int>(nullable: true),
                    StatusId = table.Column<int>(nullable: true),
                    AuditLocationAddressOne = table.Column<string>(nullable: true),
                    AuditLocationAddressTwo = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    AuditAreaId = table.Column<int>(nullable: true),
                    AuditReference = table.Column<string>(nullable: true),
                    LeadAuditorId = table.Column<long>(nullable: true),
                    AuditContactId = table.Column<long>(nullable: true),
                    AuditServicesProviderId = table.Column<int>(nullable: true),
                    BudgetedHours = table.Column<int>(nullable: true),
                    LockThreatOrganizationId = table.Column<long>(nullable: true),
                    RelatedBsinessId = table.Column<long>(nullable: true),
                    AuditScope = table.Column<string>(nullable: true),
                    AuditBackground = table.Column<string>(nullable: true),
                    AuditObjectives = table.Column<string>(nullable: true),
                    AuditMemo = table.Column<string>(nullable: true),
                    DocumentChecklist = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Audits_AbpDynamicParameterValues_AuditAreaId",
                        column: x => x.AuditAreaId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audits_Employees_AuditContactId",
                        column: x => x.AuditContactId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audits_AbpDynamicParameterValues_AuditServicesProviderId",
                        column: x => x.AuditServicesProviderId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audits_AbpDynamicParameterValues_CountryId",
                        column: x => x.CountryId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audits_AbpDynamicParameterValues_FinacialYearId",
                        column: x => x.FinacialYearId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audits_Employees_LeadAuditorId",
                        column: x => x.LeadAuditorId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audits_LockThreatOrganizations_LockThreatOrganizationId",
                        column: x => x.LockThreatOrganizationId,
                        principalTable: "LockThreatOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audits_BusinessUnits_RelatedBsinessId",
                        column: x => x.RelatedBsinessId,
                        principalTable: "BusinessUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audits_AbpDynamicParameterValues_StatusId",
                        column: x => x.StatusId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Audits_AuditAreaId",
                table: "Audits",
                column: "AuditAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Audits_AuditContactId",
                table: "Audits",
                column: "AuditContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Audits_AuditServicesProviderId",
                table: "Audits",
                column: "AuditServicesProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Audits_CountryId",
                table: "Audits",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Audits_FinacialYearId",
                table: "Audits",
                column: "FinacialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Audits_LeadAuditorId",
                table: "Audits",
                column: "LeadAuditorId");

            migrationBuilder.CreateIndex(
                name: "IX_Audits_LockThreatOrganizationId",
                table: "Audits",
                column: "LockThreatOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Audits_RelatedBsinessId",
                table: "Audits",
                column: "RelatedBsinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Audits_StatusId",
                table: "Audits",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Audits");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableInternalControls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InternalControls",
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
                    InternalControlId = table.Column<string>(nullable: true),
                    FrequencyTypeId = table.Column<int>(nullable: true),
                    InternalAuditControlId = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    FindingId = table.Column<long>(nullable: true),
                    ControlFrequencyId = table.Column<int>(nullable: true),
                    ControlStatusId = table.Column<int>(nullable: true),
                    TestingProcedure = table.Column<string>(nullable: true),
                    ICId = table.Column<string>(nullable: true),
                    IcTypeId = table.Column<int>(nullable: true),
                    ControlDescription = table.Column<string>(nullable: true),
                    AutomationId = table.Column<int>(nullable: true),
                    SampleSize = table.Column<int>(nullable: true),
                    PriorityId = table.Column<int>(nullable: true),
                    ComplianceStatusId = table.Column<int>(nullable: true),
                    EmployeeId = table.Column<long>(nullable: true),
                    LockThreatOrganizationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalControls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InternalControls_AbpDynamicParameterValues_AutomationId",
                        column: x => x.AutomationId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InternalControls_AbpDynamicParameterValues_ComplianceStatusId",
                        column: x => x.ComplianceStatusId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InternalControls_AbpDynamicParameterValues_ControlFrequencyId",
                        column: x => x.ControlFrequencyId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InternalControls_AbpDynamicParameterValues_ControlStatusId",
                        column: x => x.ControlStatusId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InternalControls_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InternalControls_Findings_FindingId",
                        column: x => x.FindingId,
                        principalTable: "Findings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InternalControls_AbpDynamicParameterValues_FrequencyTypeId",
                        column: x => x.FrequencyTypeId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InternalControls_AbpDynamicParameterValues_IcTypeId",
                        column: x => x.IcTypeId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InternalControls_AbpDynamicParameterValues_InternalAuditControlId",
                        column: x => x.InternalAuditControlId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InternalControls_LockThreatOrganizations_LockThreatOrganizationId",
                        column: x => x.LockThreatOrganizationId,
                        principalTable: "LockThreatOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InternalControls_AbpDynamicParameterValues_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InternalControls_AutomationId",
                table: "InternalControls",
                column: "AutomationId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalControls_ComplianceStatusId",
                table: "InternalControls",
                column: "ComplianceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalControls_ControlFrequencyId",
                table: "InternalControls",
                column: "ControlFrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalControls_ControlStatusId",
                table: "InternalControls",
                column: "ControlStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalControls_EmployeeId",
                table: "InternalControls",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalControls_FindingId",
                table: "InternalControls",
                column: "FindingId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalControls_FrequencyTypeId",
                table: "InternalControls",
                column: "FrequencyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalControls_IcTypeId",
                table: "InternalControls",
                column: "IcTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalControls_InternalAuditControlId",
                table: "InternalControls",
                column: "InternalAuditControlId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalControls_LockThreatOrganizationId",
                table: "InternalControls",
                column: "LockThreatOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalControls_PriorityId",
                table: "InternalControls",
                column: "PriorityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InternalControls");
        }
    }
}

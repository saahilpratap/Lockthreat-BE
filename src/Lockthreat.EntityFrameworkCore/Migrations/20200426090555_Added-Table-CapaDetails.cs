using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableCapaDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CapaDetails",
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
                    CAPAId = table.Column<string>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    CAPATitle = table.Column<string>(nullable: true),
                    InternalAuditorId = table.Column<long>(nullable: true),
                    AuditId = table.Column<long>(nullable: true),
                    AuditorExternalId = table.Column<long>(nullable: true),
                    LockThreatOrganizationId = table.Column<long>(nullable: true),
                    BusinessProcessId = table.Column<long>(nullable: true),
                    TypeId = table.Column<int>(nullable: true),
                    FindingorNC = table.Column<string>(nullable: true),
                    Correction = table.Column<string>(nullable: true),
                    RootCause = table.Column<string>(nullable: true),
                    FollowUpAction = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: true),
                    AuditeeId = table.Column<long>(nullable: true),
                    FollowUpUpdates = table.Column<string>(nullable: true),
                    ActionPlanAccepted = table.Column<bool>(nullable: false),
                    DateAccepted = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapaDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CapaDetails_Audits_AuditId",
                        column: x => x.AuditId,
                        principalTable: "Audits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CapaDetails_Employees_AuditeeId",
                        column: x => x.AuditeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CapaDetails_Contacts_AuditorExternalId",
                        column: x => x.AuditorExternalId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CapaDetails_BusinessProcess_BusinessProcessId",
                        column: x => x.BusinessProcessId,
                        principalTable: "BusinessProcess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CapaDetails_Employees_InternalAuditorId",
                        column: x => x.InternalAuditorId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CapaDetails_LockThreatOrganizations_LockThreatOrganizationId",
                        column: x => x.LockThreatOrganizationId,
                        principalTable: "LockThreatOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CapaDetails_AbpDynamicParameterValues_TypeId",
                        column: x => x.TypeId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CapaDetails_AuditId",
                table: "CapaDetails",
                column: "AuditId");

            migrationBuilder.CreateIndex(
                name: "IX_CapaDetails_AuditeeId",
                table: "CapaDetails",
                column: "AuditeeId");

            migrationBuilder.CreateIndex(
                name: "IX_CapaDetails_AuditorExternalId",
                table: "CapaDetails",
                column: "AuditorExternalId");

            migrationBuilder.CreateIndex(
                name: "IX_CapaDetails_BusinessProcessId",
                table: "CapaDetails",
                column: "BusinessProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_CapaDetails_InternalAuditorId",
                table: "CapaDetails",
                column: "InternalAuditorId");

            migrationBuilder.CreateIndex(
                name: "IX_CapaDetails_LockThreatOrganizationId",
                table: "CapaDetails",
                column: "LockThreatOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_CapaDetails_TypeId",
                table: "CapaDetails",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CapaDetails");
        }
    }
}

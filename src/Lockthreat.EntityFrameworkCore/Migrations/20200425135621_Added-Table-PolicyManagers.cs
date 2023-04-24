using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTablePolicyManagers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PolicyManagers",
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
                    PolicyId = table.Column<string>(nullable: true),
                    PolicyTypeId = table.Column<int>(nullable: true),
                    RelatedPoliciesId = table.Column<long>(nullable: true),
                    PolicyStatusId = table.Column<int>(nullable: true),
                    PolicyOwnerId = table.Column<long>(nullable: true),
                    PolicyManagersId = table.Column<long>(nullable: true),
                    LockThreatOrganizationId = table.Column<long>(nullable: true),
                    PolicyName = table.Column<string>(nullable: true),
                    Purpose = table.Column<string>(nullable: true),
                    PolicyScope = table.Column<string>(nullable: true),
                    OriginalPolicy = table.Column<string>(nullable: true),
                    PolicyContent = table.Column<string>(nullable: true),
                    PolicyDocument = table.Column<string>(nullable: true),
                    ApprovalById = table.Column<long>(nullable: true),
                    ApproverComments = table.Column<string>(nullable: true),
                    ApprovedBySignature = table.Column<string>(nullable: true),
                    FinalReviewerId = table.Column<long>(nullable: true),
                    ReviewerNotes = table.Column<string>(nullable: true),
                    FinalReviewerSignature = table.Column<string>(nullable: true),
                    EffectiveFrom = table.Column<DateTime>(nullable: true),
                    UpcomingReview = table.Column<DateTime>(nullable: true),
                    EffectiveTo = table.Column<DateTime>(nullable: true),
                    ScheduledReview = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyManagers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PolicyManagers_Employees_ApprovalById",
                        column: x => x.ApprovalById,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PolicyManagers_Employees_FinalReviewerId",
                        column: x => x.FinalReviewerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PolicyManagers_LockThreatOrganizations_LockThreatOrganizationId",
                        column: x => x.LockThreatOrganizationId,
                        principalTable: "LockThreatOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PolicyManagers_Employees_PolicyManagersId",
                        column: x => x.PolicyManagersId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PolicyManagers_Employees_PolicyOwnerId",
                        column: x => x.PolicyOwnerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PolicyManagers_AbpDynamicParameterValues_PolicyStatusId",
                        column: x => x.PolicyStatusId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PolicyManagers_AbpDynamicParameterValues_PolicyTypeId",
                        column: x => x.PolicyTypeId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PolicyManagers_ApprovalById",
                table: "PolicyManagers",
                column: "ApprovalById");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyManagers_FinalReviewerId",
                table: "PolicyManagers",
                column: "FinalReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyManagers_LockThreatOrganizationId",
                table: "PolicyManagers",
                column: "LockThreatOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyManagers_PolicyManagersId",
                table: "PolicyManagers",
                column: "PolicyManagersId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyManagers_PolicyOwnerId",
                table: "PolicyManagers",
                column: "PolicyOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyManagers_PolicyStatusId",
                table: "PolicyManagers",
                column: "PolicyStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyManagers_PolicyTypeId",
                table: "PolicyManagers",
                column: "PolicyTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PolicyManagers");
        }
    }
}

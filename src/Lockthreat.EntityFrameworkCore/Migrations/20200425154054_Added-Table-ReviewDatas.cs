using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableReviewDatas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReviewDatas",
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
                    ReviewId = table.Column<string>(nullable: true),
                    ReviewLeadId = table.Column<long>(nullable: true),
                    ReviewAssessmentId = table.Column<long>(nullable: true),
                    CyberAwarenessScoreId = table.Column<long>(nullable: true),
                    LockThreatOrganizationId = table.Column<long>(nullable: true),
                    AnswerPoints = table.Column<int>(nullable: true),
                    ResponseTime = table.Column<DateTime>(nullable: true),
                    BusinessUnitId = table.Column<long>(nullable: true),
                    VendorId = table.Column<long>(nullable: true),
                    ContactsId = table.Column<long>(nullable: true),
                    QuestionId = table.Column<long>(nullable: true),
                    QuestionLibraryId = table.Column<long>(nullable: true),
                    QuestionAssignedToId = table.Column<long>(nullable: true),
                    SelectedAnswer = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    RespondedById = table.Column<long>(nullable: true),
                    VerifierId = table.Column<long>(nullable: true),
                    ReviewFeedback = table.Column<string>(nullable: true),
                    VerfiedTime = table.Column<DateTime>(nullable: true),
                    ReviewQuestionStatusId = table.Column<int>(nullable: true),
                    QuestionAnswered = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewDatas_BusinessUnits_BusinessUnitId",
                        column: x => x.BusinessUnitId,
                        principalTable: "BusinessUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReviewDatas_Contacts_ContactsId",
                        column: x => x.ContactsId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReviewDatas_CyberAwarenessScores_CyberAwarenessScoreId",
                        column: x => x.CyberAwarenessScoreId,
                        principalTable: "CyberAwarenessScores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReviewDatas_LockThreatOrganizations_LockThreatOrganizationId",
                        column: x => x.LockThreatOrganizationId,
                        principalTable: "LockThreatOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReviewDatas_Employees_QuestionAssignedToId",
                        column: x => x.QuestionAssignedToId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReviewDatas_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReviewDatas_Questions_QuestionLibraryId",
                        column: x => x.QuestionLibraryId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReviewDatas_Employees_RespondedById",
                        column: x => x.RespondedById,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReviewDatas_ReviewAssessments_ReviewAssessmentId",
                        column: x => x.ReviewAssessmentId,
                        principalTable: "ReviewAssessments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReviewDatas_Employees_ReviewLeadId",
                        column: x => x.ReviewLeadId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReviewDatas_AbpDynamicParameterValues_ReviewQuestionStatusId",
                        column: x => x.ReviewQuestionStatusId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReviewDatas_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReviewDatas_Employees_VerifierId",
                        column: x => x.VerifierId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReviewDatas_BusinessUnitId",
                table: "ReviewDatas",
                column: "BusinessUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewDatas_ContactsId",
                table: "ReviewDatas",
                column: "ContactsId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewDatas_CyberAwarenessScoreId",
                table: "ReviewDatas",
                column: "CyberAwarenessScoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewDatas_LockThreatOrganizationId",
                table: "ReviewDatas",
                column: "LockThreatOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewDatas_QuestionAssignedToId",
                table: "ReviewDatas",
                column: "QuestionAssignedToId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewDatas_QuestionId",
                table: "ReviewDatas",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewDatas_QuestionLibraryId",
                table: "ReviewDatas",
                column: "QuestionLibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewDatas_RespondedById",
                table: "ReviewDatas",
                column: "RespondedById");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewDatas_ReviewAssessmentId",
                table: "ReviewDatas",
                column: "ReviewAssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewDatas_ReviewLeadId",
                table: "ReviewDatas",
                column: "ReviewLeadId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewDatas_ReviewQuestionStatusId",
                table: "ReviewDatas",
                column: "ReviewQuestionStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewDatas_VendorId",
                table: "ReviewDatas",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewDatas_VerifierId",
                table: "ReviewDatas",
                column: "VerifierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReviewDatas");
        }
    }
}

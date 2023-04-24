using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableIssueManagements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IssueManagements",
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
                    IssueId = table.Column<string>(nullable: true),
                    IssueTitle = table.Column<string>(nullable: true),
                    IssueDetails = table.Column<string>(nullable: true),
                    OccuranceDate = table.Column<DateTime>(nullable: true),
                    ReportedDate = table.Column<DateTime>(nullable: true),
                    MeetingId = table.Column<int>(nullable: true),
                    MeetingId1 = table.Column<long>(nullable: true),
                    IssueCategoryId = table.Column<int>(nullable: true),
                    RiskAssessmentRequired = table.Column<bool>(nullable: false),
                    ReporterId = table.Column<long>(nullable: true),
                    OwnerId = table.Column<long>(nullable: true),
                    ActionTypes = table.Column<int>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: true),
                    Completed = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    CompletedById = table.Column<long>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CompletedDate = table.Column<DateTime>(nullable: true),
                    AssignedToId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueManagements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueManagements_Employees_AssignedToId",
                        column: x => x.AssignedToId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IssueManagements_Employees_CompletedById",
                        column: x => x.CompletedById,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IssueManagements_AbpDynamicParameterValues_IssueCategoryId",
                        column: x => x.IssueCategoryId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IssueManagements_Meetings_MeetingId1",
                        column: x => x.MeetingId1,
                        principalTable: "Meetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IssueManagements_Employees_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IssueManagements_Employees_ReporterId",
                        column: x => x.ReporterId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IssueManagements_AssignedToId",
                table: "IssueManagements",
                column: "AssignedToId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueManagements_CompletedById",
                table: "IssueManagements",
                column: "CompletedById");

            migrationBuilder.CreateIndex(
                name: "IX_IssueManagements_IssueCategoryId",
                table: "IssueManagements",
                column: "IssueCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueManagements_MeetingId1",
                table: "IssueManagements",
                column: "MeetingId1");

            migrationBuilder.CreateIndex(
                name: "IX_IssueManagements_OwnerId",
                table: "IssueManagements",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueManagements_ReporterId",
                table: "IssueManagements",
                column: "ReporterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssueManagements");
        }
    }
}

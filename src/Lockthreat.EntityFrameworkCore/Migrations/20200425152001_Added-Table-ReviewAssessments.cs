using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableReviewAssessments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReviewAssessments",
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
                    Summary = table.Column<string>(nullable: true),
                    ReviewTitle = table.Column<string>(nullable: false),
                    ReviewTypeId = table.Column<int>(nullable: true),
                    AssignedToId = table.Column<long>(nullable: true),
                    ScheduleId = table.Column<int>(nullable: true),
                    EveryDays = table.Column<int>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    PeriodicReviewEndDate = table.Column<DateTime>(nullable: true),
                    QuestionId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewAssessments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewAssessments_Employees_AssignedToId",
                        column: x => x.AssignedToId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReviewAssessments_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReviewAssessments_AbpDynamicParameterValues_ReviewTypeId",
                        column: x => x.ReviewTypeId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReviewAssessments_AbpDynamicParameterValues_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReviewAssessments_AssignedToId",
                table: "ReviewAssessments",
                column: "AssignedToId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewAssessments_QuestionId",
                table: "ReviewAssessments",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewAssessments_ReviewTypeId",
                table: "ReviewAssessments",
                column: "ReviewTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewAssessments_ScheduleId",
                table: "ReviewAssessments",
                column: "ScheduleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReviewAssessments");
        }
    }
}

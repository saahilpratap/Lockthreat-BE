using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableReviewAssessmentQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReviewAssessmentQuestions",
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
                    QuestionId = table.Column<long>(nullable: true),
                    ReviewAssessmentId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewAssessmentQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewAssessmentQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReviewAssessmentQuestions_ReviewAssessments_ReviewAssessmentId",
                        column: x => x.ReviewAssessmentId,
                        principalTable: "ReviewAssessments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReviewAssessmentQuestions_QuestionId",
                table: "ReviewAssessmentQuestions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewAssessmentQuestions_ReviewAssessmentId",
                table: "ReviewAssessmentQuestions",
                column: "ReviewAssessmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReviewAssessmentQuestions");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableReviewAssessmentAuthoratativeDocuments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReviewAssessmentAuthoratativeDocuments",
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
                    ReviewAssessmentsId = table.Column<long>(nullable: true),
                    ReviewAssessmentId = table.Column<long>(nullable: true),
                    AuthoratativeDocumentId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewAssessmentAuthoratativeDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewAssessmentAuthoratativeDocuments_AuthoratativeDocuments_AuthoratativeDocumentId",
                        column: x => x.AuthoratativeDocumentId,
                        principalTable: "AuthoratativeDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReviewAssessmentAuthoratativeDocuments_ReviewAssessments_ReviewAssessmentId",
                        column: x => x.ReviewAssessmentId,
                        principalTable: "ReviewAssessments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReviewAssessmentAuthoratativeDocuments_AuthoratativeDocumentId",
                table: "ReviewAssessmentAuthoratativeDocuments",
                column: "AuthoratativeDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewAssessmentAuthoratativeDocuments_ReviewAssessmentId",
                table: "ReviewAssessmentAuthoratativeDocuments",
                column: "ReviewAssessmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReviewAssessmentAuthoratativeDocuments");
        }
    }
}

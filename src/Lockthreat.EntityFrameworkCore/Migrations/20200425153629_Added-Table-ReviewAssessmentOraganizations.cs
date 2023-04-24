using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableReviewAssessmentOraganizations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReviewAssessmentOraganizations",
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
                    ReviewAssessmentId = table.Column<long>(nullable: true),
                    LockThreatOrganizationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewAssessmentOraganizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewAssessmentOraganizations_LockThreatOrganizations_LockThreatOrganizationId",
                        column: x => x.LockThreatOrganizationId,
                        principalTable: "LockThreatOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReviewAssessmentOraganizations_ReviewAssessments_ReviewAssessmentId",
                        column: x => x.ReviewAssessmentId,
                        principalTable: "ReviewAssessments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReviewAssessmentOraganizations_LockThreatOrganizationId",
                table: "ReviewAssessmentOraganizations",
                column: "LockThreatOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewAssessmentOraganizations_ReviewAssessmentId",
                table: "ReviewAssessmentOraganizations",
                column: "ReviewAssessmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReviewAssessmentOraganizations");
        }
    }
}

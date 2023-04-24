using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableFindings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Findings",
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
                    FindingId = table.Column<string>(nullable: true),
                    FindingTitle = table.Column<string>(nullable: true),
                    FindingDetails = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    CategoryOther = table.Column<string>(nullable: true),
                    FindingStatusId = table.Column<int>(nullable: true),
                    RankingId = table.Column<int>(nullable: true),
                    ClassificationId = table.Column<int>(nullable: true),
                    FindingManagerId = table.Column<long>(nullable: true),
                    FindingCoordinatorId = table.Column<long>(nullable: true),
                    FindingOwnerId = table.Column<long>(nullable: true),
                    Criteria = table.Column<string>(nullable: true),
                    Cause = table.Column<string>(nullable: true),
                    Condition = table.Column<string>(nullable: true),
                    Consequence = table.Column<string>(nullable: true),
                    ActionId = table.Column<int>(nullable: true),
                    ReviewedId = table.Column<long>(nullable: true),
                    ResponseId = table.Column<int>(nullable: true),
                    PotentialCost = table.Column<int>(nullable: true),
                    AssignedId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Findings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Findings_AbpDynamicParameterValues_ActionId",
                        column: x => x.ActionId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Findings_Employees_AssignedId",
                        column: x => x.AssignedId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Findings_AbpDynamicParameterValues_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Findings_AbpDynamicParameterValues_ClassificationId",
                        column: x => x.ClassificationId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Findings_Employees_FindingCoordinatorId",
                        column: x => x.FindingCoordinatorId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Findings_Employees_FindingManagerId",
                        column: x => x.FindingManagerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Findings_Employees_FindingOwnerId",
                        column: x => x.FindingOwnerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Findings_AbpDynamicParameterValues_FindingStatusId",
                        column: x => x.FindingStatusId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Findings_AbpDynamicParameterValues_RankingId",
                        column: x => x.RankingId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Findings_AbpDynamicParameterValues_ResponseId",
                        column: x => x.ResponseId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Findings_Employees_ReviewedId",
                        column: x => x.ReviewedId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Findings_ActionId",
                table: "Findings",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_Findings_AssignedId",
                table: "Findings",
                column: "AssignedId");

            migrationBuilder.CreateIndex(
                name: "IX_Findings_CategoryId",
                table: "Findings",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Findings_ClassificationId",
                table: "Findings",
                column: "ClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Findings_FindingCoordinatorId",
                table: "Findings",
                column: "FindingCoordinatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Findings_FindingManagerId",
                table: "Findings",
                column: "FindingManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Findings_FindingOwnerId",
                table: "Findings",
                column: "FindingOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Findings_FindingStatusId",
                table: "Findings",
                column: "FindingStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Findings_RankingId",
                table: "Findings",
                column: "RankingId");

            migrationBuilder.CreateIndex(
                name: "IX_Findings_ResponseId",
                table: "Findings",
                column: "ResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_Findings_ReviewedId",
                table: "Findings",
                column: "ReviewedId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Findings");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
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
                    QuestionId = table.Column<string>(nullable: true),
                    QuestionnaireTitle = table.Column<string>(nullable: false),
                    SourceQuestion = table.Column<string>(nullable: true),
                    DisplayQuestion = table.Column<string>(nullable: true),
                    QuestionTitle = table.Column<string>(nullable: true),
                    SectionId = table.Column<int>(nullable: true),
                    QuestionAreaId = table.Column<int>(nullable: true),
                    QuestionCategoryId = table.Column<int>(nullable: true),
                    QuestionStatusId = table.Column<int>(nullable: true),
                    AnswerTypeId = table.Column<int>(nullable: true),
                    AnswerTypes = table.Column<bool>(nullable: false),
                    AnswerValues = table.Column<string>(nullable: true),
                    AnswerText = table.Column<string>(nullable: true),
                    AnswerPoints = table.Column<int>(nullable: true),
                    TotalPoints = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_AbpDynamicParameterValues_AnswerTypeId",
                        column: x => x.AnswerTypeId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Questions_AbpDynamicParameterValues_QuestionAreaId",
                        column: x => x.QuestionAreaId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Questions_AbpDynamicParameterValues_QuestionCategoryId",
                        column: x => x.QuestionCategoryId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Questions_AbpDynamicParameterValues_QuestionStatusId",
                        column: x => x.QuestionStatusId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Questions_AbpDynamicParameterValues_SectionId",
                        column: x => x.SectionId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_AnswerTypeId",
                table: "Questions",
                column: "AnswerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuestionAreaId",
                table: "Questions",
                column: "QuestionAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuestionCategoryId",
                table: "Questions",
                column: "QuestionCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuestionStatusId",
                table: "Questions",
                column: "QuestionStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SectionId",
                table: "Questions",
                column: "SectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}

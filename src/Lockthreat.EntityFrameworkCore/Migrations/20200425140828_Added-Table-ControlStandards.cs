using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableControlStandards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ControlStandards",
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
                    ControlId = table.Column<string>(nullable: true),
                    Source = table.Column<string>(nullable: true),
                    SourceVersion = table.Column<string>(nullable: true),
                    UCFCId = table.Column<string>(nullable: true),
                    ControlName = table.Column<string>(nullable: true),
                    ControlStandardId = table.Column<string>(nullable: true),
                    FrameworkObjectiveId = table.Column<int>(nullable: true),
                    ControlClassificationId = table.Column<int>(nullable: true),
                    TypeId = table.Column<int>(nullable: true),
                    ControlFrequencyId = table.Column<int>(nullable: true),
                    FrequencyTypeId = table.Column<int>(nullable: true),
                    ControlCategoryId = table.Column<int>(nullable: true),
                    ControlAreaId = table.Column<int>(nullable: true),
                    ControlObjective = table.Column<string>(nullable: true),
                    ControlDescription = table.Column<string>(nullable: true),
                    ControlRequirements = table.Column<string>(nullable: true),
                    CustomApplicability = table.Column<string>(nullable: true),
                    TestingProcedure = table.Column<string>(nullable: true),
                    SampleSize = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlStandards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControlStandards_AbpDynamicParameterValues_ControlAreaId",
                        column: x => x.ControlAreaId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ControlStandards_AbpDynamicParameterValues_ControlCategoryId",
                        column: x => x.ControlCategoryId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ControlStandards_AbpDynamicParameterValues_ControlClassificationId",
                        column: x => x.ControlClassificationId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ControlStandards_AbpDynamicParameterValues_ControlFrequencyId",
                        column: x => x.ControlFrequencyId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ControlStandards_AbpDynamicParameterValues_FrameworkObjectiveId",
                        column: x => x.FrameworkObjectiveId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ControlStandards_AbpDynamicParameterValues_FrequencyTypeId",
                        column: x => x.FrequencyTypeId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ControlStandards_AbpDynamicParameterValues_TypeId",
                        column: x => x.TypeId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ControlStandards_ControlAreaId",
                table: "ControlStandards",
                column: "ControlAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlStandards_ControlCategoryId",
                table: "ControlStandards",
                column: "ControlCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlStandards_ControlClassificationId",
                table: "ControlStandards",
                column: "ControlClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlStandards_ControlFrequencyId",
                table: "ControlStandards",
                column: "ControlFrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlStandards_FrameworkObjectiveId",
                table: "ControlStandards",
                column: "FrameworkObjectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlStandards_FrequencyTypeId",
                table: "ControlStandards",
                column: "FrequencyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlStandards_TypeId",
                table: "ControlStandards",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ControlStandards");
        }
    }
}

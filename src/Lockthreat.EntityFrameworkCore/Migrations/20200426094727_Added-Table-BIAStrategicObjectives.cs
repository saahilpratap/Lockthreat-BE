using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableBIAStrategicObjectives : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BIAStrategicObjectives",
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
                    BusinessImpactAnalysisId = table.Column<long>(nullable: true),
                    StrategicObjectiveId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BIAStrategicObjectives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BIAStrategicObjectives_BusinessImpactAnalysises_BusinessImpactAnalysisId",
                        column: x => x.BusinessImpactAnalysisId,
                        principalTable: "BusinessImpactAnalysises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BIAStrategicObjectives_StrategicObjectives_StrategicObjectiveId",
                        column: x => x.StrategicObjectiveId,
                        principalTable: "StrategicObjectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BIAStrategicObjectives_BusinessImpactAnalysisId",
                table: "BIAStrategicObjectives",
                column: "BusinessImpactAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_BIAStrategicObjectives_StrategicObjectiveId",
                table: "BIAStrategicObjectives",
                column: "StrategicObjectiveId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BIAStrategicObjectives");
        }
    }
}

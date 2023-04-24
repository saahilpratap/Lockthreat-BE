using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableFindingStrategicObjectives : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FindingStrategicObjectives",
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
                    FindingId = table.Column<long>(nullable: true),
                    StrategicObjectiveId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FindingStrategicObjectives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FindingStrategicObjectives_Findings_FindingId",
                        column: x => x.FindingId,
                        principalTable: "Findings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FindingStrategicObjectives_StrategicObjectives_StrategicObjectiveId",
                        column: x => x.StrategicObjectiveId,
                        principalTable: "StrategicObjectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FindingStrategicObjectives_FindingId",
                table: "FindingStrategicObjectives",
                column: "FindingId");

            migrationBuilder.CreateIndex(
                name: "IX_FindingStrategicObjectives_StrategicObjectiveId",
                table: "FindingStrategicObjectives",
                column: "StrategicObjectiveId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FindingStrategicObjectives");
        }
    }
}

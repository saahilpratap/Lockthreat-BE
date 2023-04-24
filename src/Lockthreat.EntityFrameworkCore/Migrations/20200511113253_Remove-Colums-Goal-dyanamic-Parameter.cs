using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class RemoveColumsGoaldyanamicParameter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StrategicObjectives_AbpDynamicParameterValues_GoalId",
                table: "StrategicObjectives");

            migrationBuilder.DropIndex(
                name: "IX_StrategicObjectives_GoalId",
                table: "StrategicObjectives");

            migrationBuilder.DropColumn(
                name: "GoalId",
                table: "StrategicObjectives");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GoalId",
                table: "StrategicObjectives",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StrategicObjectives_GoalId",
                table: "StrategicObjectives",
                column: "GoalId");

            migrationBuilder.AddForeignKey(
                name: "FK_StrategicObjectives_AbpDynamicParameterValues_GoalId",
                table: "StrategicObjectives",
                column: "GoalId",
                principalTable: "AbpDynamicParameterValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

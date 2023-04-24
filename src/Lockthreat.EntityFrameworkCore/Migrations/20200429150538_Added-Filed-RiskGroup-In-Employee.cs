using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedFiledRiskGroupInEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RiskGroupId",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RiskGroupId",
                table: "Employees",
                column: "RiskGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AbpDynamicParameterValues_RiskGroupId",
                table: "Employees",
                column: "RiskGroupId",
                principalTable: "AbpDynamicParameterValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AbpDynamicParameterValues_RiskGroupId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_RiskGroupId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "RiskGroupId",
                table: "Employees");
        }
    }
}

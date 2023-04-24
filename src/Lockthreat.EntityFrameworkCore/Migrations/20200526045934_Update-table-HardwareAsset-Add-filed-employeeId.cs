using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class UpdatetableHardwareAssetAddfiledemployeeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "EmployeeId",
                table: "HardwareAssets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HardwareAssets_EmployeeId",
                table: "HardwareAssets",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_HardwareAssets_Employees_EmployeeId",
                table: "HardwareAssets",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HardwareAssets_Employees_EmployeeId",
                table: "HardwareAssets");

            migrationBuilder.DropIndex(
                name: "IX_HardwareAssets_EmployeeId",
                table: "HardwareAssets");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "HardwareAssets");
        }
    }
}

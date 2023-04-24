using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class UpdatetableFacilitieDatacenterAddfiledemployeeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "EmployeeId",
                table: "FacilitieDatacenters",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FacilitieDatacenters_EmployeeId",
                table: "FacilitieDatacenters",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_FacilitieDatacenters_Employees_EmployeeId",
                table: "FacilitieDatacenters",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacilitieDatacenters_Employees_EmployeeId",
                table: "FacilitieDatacenters");

            migrationBuilder.DropIndex(
                name: "IX_FacilitieDatacenters_EmployeeId",
                table: "FacilitieDatacenters");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "FacilitieDatacenters");
        }
    }
}

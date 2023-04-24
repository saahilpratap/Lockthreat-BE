using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class UpdatetablesysteamApplicationAddfiledBusinessUnitGaurdianId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BusinessUnitGaurdianId",
                table: "SystemApplications",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SystemApplications_BusinessUnitGaurdianId",
                table: "SystemApplications",
                column: "BusinessUnitGaurdianId");

            migrationBuilder.AddForeignKey(
                name: "FK_SystemApplications_BusinessUnits_BusinessUnitGaurdianId",
                table: "SystemApplications",
                column: "BusinessUnitGaurdianId",
                principalTable: "BusinessUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SystemApplications_BusinessUnits_BusinessUnitGaurdianId",
                table: "SystemApplications");

            migrationBuilder.DropIndex(
                name: "IX_SystemApplications_BusinessUnitGaurdianId",
                table: "SystemApplications");

            migrationBuilder.DropColumn(
                name: "BusinessUnitGaurdianId",
                table: "SystemApplications");
        }
    }
}

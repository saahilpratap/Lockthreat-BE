using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedfiledBusinessUnitOwnerandBusinessUnitGaurdianforhardwareAssset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BusinessUnitGaurdianId",
                table: "HardwareAssets",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BusinessUnitOwnerId",
                table: "HardwareAssets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HardwareAssets_BusinessUnitGaurdianId",
                table: "HardwareAssets",
                column: "BusinessUnitGaurdianId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareAssets_BusinessUnitOwnerId",
                table: "HardwareAssets",
                column: "BusinessUnitOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_HardwareAssets_BusinessUnits_BusinessUnitGaurdianId",
                table: "HardwareAssets",
                column: "BusinessUnitGaurdianId",
                principalTable: "BusinessUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HardwareAssets_BusinessUnits_BusinessUnitOwnerId",
                table: "HardwareAssets",
                column: "BusinessUnitOwnerId",
                principalTable: "BusinessUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HardwareAssets_BusinessUnits_BusinessUnitGaurdianId",
                table: "HardwareAssets");

            migrationBuilder.DropForeignKey(
                name: "FK_HardwareAssets_BusinessUnits_BusinessUnitOwnerId",
                table: "HardwareAssets");

            migrationBuilder.DropIndex(
                name: "IX_HardwareAssets_BusinessUnitGaurdianId",
                table: "HardwareAssets");

            migrationBuilder.DropIndex(
                name: "IX_HardwareAssets_BusinessUnitOwnerId",
                table: "HardwareAssets");

            migrationBuilder.DropColumn(
                name: "BusinessUnitGaurdianId",
                table: "HardwareAssets");

            migrationBuilder.DropColumn(
                name: "BusinessUnitOwnerId",
                table: "HardwareAssets");
        }
    }
}

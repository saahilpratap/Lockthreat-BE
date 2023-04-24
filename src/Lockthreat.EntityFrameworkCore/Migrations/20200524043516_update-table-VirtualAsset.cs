using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class updatetableVirtualAsset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BusinessUnitGaurdianId",
                table: "VirtualAssets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VirtualAssets_BusinessUnitGaurdianId",
                table: "VirtualAssets",
                column: "BusinessUnitGaurdianId");

            migrationBuilder.AddForeignKey(
                name: "FK_VirtualAssets_BusinessUnits_BusinessUnitGaurdianId",
                table: "VirtualAssets",
                column: "BusinessUnitGaurdianId",
                principalTable: "BusinessUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VirtualAssets_BusinessUnits_BusinessUnitGaurdianId",
                table: "VirtualAssets");

            migrationBuilder.DropIndex(
                name: "IX_VirtualAssets_BusinessUnitGaurdianId",
                table: "VirtualAssets");

            migrationBuilder.DropColumn(
                name: "BusinessUnitGaurdianId",
                table: "VirtualAssets");
        }
    }
}

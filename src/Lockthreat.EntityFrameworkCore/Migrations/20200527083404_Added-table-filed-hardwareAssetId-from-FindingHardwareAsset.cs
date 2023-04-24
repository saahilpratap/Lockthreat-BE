using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedtablefiledhardwareAssetIdfromFindingHardwareAsset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "HardwareAssetId",
                table: "FindingHardwareAssets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FindingHardwareAssets_HardwareAssetId",
                table: "FindingHardwareAssets",
                column: "HardwareAssetId");

            migrationBuilder.AddForeignKey(
                name: "FK_FindingHardwareAssets_HardwareAssets_HardwareAssetId",
                table: "FindingHardwareAssets",
                column: "HardwareAssetId",
                principalTable: "HardwareAssets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FindingHardwareAssets_HardwareAssets_HardwareAssetId",
                table: "FindingHardwareAssets");

            migrationBuilder.DropIndex(
                name: "IX_FindingHardwareAssets_HardwareAssetId",
                table: "FindingHardwareAssets");

            migrationBuilder.DropColumn(
                name: "HardwareAssetId",
                table: "FindingHardwareAssets");
        }
    }
}

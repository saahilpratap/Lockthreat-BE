using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class removetablefiledhardwareAssetIdfromFindingHardwareAsset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FindingHardwareAssets_HardwareAssets_HardwareAssetId",
                table: "FindingHardwareAssets");

            migrationBuilder.DropIndex(
                name: "IX_FindingHardwareAssets_HardwareAssetId",
                table: "FindingHardwareAssets");

            migrationBuilder.DropColumn(
                name: "HardwareAssetI",
                table: "FindingHardwareAssets");

            migrationBuilder.DropColumn(
                name: "HardwareAssetId",
                table: "FindingHardwareAssets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "HardwareAssetI",
                table: "FindingHardwareAssets",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "HardwareAssetId",
                table: "FindingHardwareAssets",
                type: "bigint",
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
    }
}

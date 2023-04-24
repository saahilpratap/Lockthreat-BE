using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class UpdatetableAssetInformationaddedfiled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BusinessUnitGaurdianId",
                table: "AssetInformations",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BusinessUnitOwnerId",
                table: "AssetInformations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssetInformations_BusinessUnitGaurdianId",
                table: "AssetInformations",
                column: "BusinessUnitGaurdianId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetInformations_BusinessUnitOwnerId",
                table: "AssetInformations",
                column: "BusinessUnitOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetInformations_BusinessUnits_BusinessUnitGaurdianId",
                table: "AssetInformations",
                column: "BusinessUnitGaurdianId",
                principalTable: "BusinessUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetInformations_BusinessUnits_BusinessUnitOwnerId",
                table: "AssetInformations",
                column: "BusinessUnitOwnerId",
                principalTable: "BusinessUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetInformations_BusinessUnits_BusinessUnitGaurdianId",
                table: "AssetInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetInformations_BusinessUnits_BusinessUnitOwnerId",
                table: "AssetInformations");

            migrationBuilder.DropIndex(
                name: "IX_AssetInformations_BusinessUnitGaurdianId",
                table: "AssetInformations");

            migrationBuilder.DropIndex(
                name: "IX_AssetInformations_BusinessUnitOwnerId",
                table: "AssetInformations");

            migrationBuilder.DropColumn(
                name: "BusinessUnitGaurdianId",
                table: "AssetInformations");

            migrationBuilder.DropColumn(
                name: "BusinessUnitOwnerId",
                table: "AssetInformations");
        }
    }
}

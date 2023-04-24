using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class UpdatetableVirtualAssetAddedfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AvailibilityId",
                table: "VirtualAssets",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConfidentialityId",
                table: "VirtualAssets",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IntegrityId",
                table: "VirtualAssets",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OthersId",
                table: "VirtualAssets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VirtualAssets_AvailibilityId",
                table: "VirtualAssets",
                column: "AvailibilityId");

            migrationBuilder.CreateIndex(
                name: "IX_VirtualAssets_ConfidentialityId",
                table: "VirtualAssets",
                column: "ConfidentialityId");

            migrationBuilder.CreateIndex(
                name: "IX_VirtualAssets_IntegrityId",
                table: "VirtualAssets",
                column: "IntegrityId");

            migrationBuilder.CreateIndex(
                name: "IX_VirtualAssets_OthersId",
                table: "VirtualAssets",
                column: "OthersId");

            migrationBuilder.AddForeignKey(
                name: "FK_VirtualAssets_AbpDynamicParameterValues_AvailibilityId",
                table: "VirtualAssets",
                column: "AvailibilityId",
                principalTable: "AbpDynamicParameterValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VirtualAssets_AbpDynamicParameterValues_ConfidentialityId",
                table: "VirtualAssets",
                column: "ConfidentialityId",
                principalTable: "AbpDynamicParameterValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VirtualAssets_AbpDynamicParameterValues_IntegrityId",
                table: "VirtualAssets",
                column: "IntegrityId",
                principalTable: "AbpDynamicParameterValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VirtualAssets_AbpDynamicParameterValues_OthersId",
                table: "VirtualAssets",
                column: "OthersId",
                principalTable: "AbpDynamicParameterValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VirtualAssets_AbpDynamicParameterValues_AvailibilityId",
                table: "VirtualAssets");

            migrationBuilder.DropForeignKey(
                name: "FK_VirtualAssets_AbpDynamicParameterValues_ConfidentialityId",
                table: "VirtualAssets");

            migrationBuilder.DropForeignKey(
                name: "FK_VirtualAssets_AbpDynamicParameterValues_IntegrityId",
                table: "VirtualAssets");

            migrationBuilder.DropForeignKey(
                name: "FK_VirtualAssets_AbpDynamicParameterValues_OthersId",
                table: "VirtualAssets");

            migrationBuilder.DropIndex(
                name: "IX_VirtualAssets_AvailibilityId",
                table: "VirtualAssets");

            migrationBuilder.DropIndex(
                name: "IX_VirtualAssets_ConfidentialityId",
                table: "VirtualAssets");

            migrationBuilder.DropIndex(
                name: "IX_VirtualAssets_IntegrityId",
                table: "VirtualAssets");

            migrationBuilder.DropIndex(
                name: "IX_VirtualAssets_OthersId",
                table: "VirtualAssets");

            migrationBuilder.DropColumn(
                name: "AvailibilityId",
                table: "VirtualAssets");

            migrationBuilder.DropColumn(
                name: "ConfidentialityId",
                table: "VirtualAssets");

            migrationBuilder.DropColumn(
                name: "IntegrityId",
                table: "VirtualAssets");

            migrationBuilder.DropColumn(
                name: "OthersId",
                table: "VirtualAssets");
        }
    }
}

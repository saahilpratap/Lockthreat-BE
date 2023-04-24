using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class RemoveFieldfromVirtualAsset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VirtualAssets_HardwareAssets_ParentVirtualHostId",
                table: "VirtualAssets");

            migrationBuilder.DropIndex(
                name: "IX_VirtualAssets_ParentVirtualHostId",
                table: "VirtualAssets");

            migrationBuilder.DropColumn(
                name: "ParentVirtualHostId",
                table: "VirtualAssets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ParentVirtualHostId",
                table: "VirtualAssets",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VirtualAssets_ParentVirtualHostId",
                table: "VirtualAssets",
                column: "ParentVirtualHostId");

            migrationBuilder.AddForeignKey(
                name: "FK_VirtualAssets_HardwareAssets_ParentVirtualHostId",
                table: "VirtualAssets",
                column: "ParentVirtualHostId",
                principalTable: "HardwareAssets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

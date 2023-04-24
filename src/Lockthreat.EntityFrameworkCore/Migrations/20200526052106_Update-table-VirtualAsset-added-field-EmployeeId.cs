using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class UpdatetableVirtualAssetaddedfieldEmployeeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BusinessOwnerId",
                table: "VirtualAssets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VirtualAssets_BusinessOwnerId",
                table: "VirtualAssets",
                column: "BusinessOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_VirtualAssets_Employees_BusinessOwnerId",
                table: "VirtualAssets",
                column: "BusinessOwnerId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VirtualAssets_Employees_BusinessOwnerId",
                table: "VirtualAssets");

            migrationBuilder.DropIndex(
                name: "IX_VirtualAssets_BusinessOwnerId",
                table: "VirtualAssets");

            migrationBuilder.DropColumn(
                name: "BusinessOwnerId",
                table: "VirtualAssets");
        }
    }
}

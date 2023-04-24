using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedcolumVendorServiceVendorProductservices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VendorServiceId",
                table: "VendorProductServices",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VendorProductServices_VendorServiceId",
                table: "VendorProductServices",
                column: "VendorServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_VendorProductServices_AbpDynamicParameterValues_VendorServiceId",
                table: "VendorProductServices",
                column: "VendorServiceId",
                principalTable: "AbpDynamicParameterValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VendorProductServices_AbpDynamicParameterValues_VendorServiceId",
                table: "VendorProductServices");

            migrationBuilder.DropIndex(
                name: "IX_VendorProductServices_VendorServiceId",
                table: "VendorProductServices");

            migrationBuilder.DropColumn(
                name: "VendorServiceId",
                table: "VendorProductServices");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class RemovecolumIndustryIdVendorProductservices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VendorProductServices_AbpDynamicParameterValues_IndustryId",
                table: "VendorProductServices");

            migrationBuilder.DropIndex(
                name: "IX_VendorProductServices_IndustryId",
                table: "VendorProductServices");

            migrationBuilder.DropColumn(
                name: "IndustryId",
                table: "VendorProductServices");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IndustryId",
                table: "VendorProductServices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VendorProductServices_IndustryId",
                table: "VendorProductServices",
                column: "IndustryId");

            migrationBuilder.AddForeignKey(
                name: "FK_VendorProductServices_AbpDynamicParameterValues_IndustryId",
                table: "VendorProductServices",
                column: "IndustryId",
                principalTable: "AbpDynamicParameterValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

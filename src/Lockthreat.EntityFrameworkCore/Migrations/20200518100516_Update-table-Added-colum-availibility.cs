using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class UpdatetableAddedcolumavailibility : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AvailibilityId",
                table: "ITServices",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ITServices_AvailibilityId",
                table: "ITServices",
                column: "AvailibilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ITServices_AbpDynamicParameterValues_AvailibilityId",
                table: "ITServices",
                column: "AvailibilityId",
                principalTable: "AbpDynamicParameterValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ITServices_AbpDynamicParameterValues_AvailibilityId",
                table: "ITServices");

            migrationBuilder.DropIndex(
                name: "IX_ITServices_AvailibilityId",
                table: "ITServices");

            migrationBuilder.DropColumn(
                name: "AvailibilityId",
                table: "ITServices");
        }
    }
}

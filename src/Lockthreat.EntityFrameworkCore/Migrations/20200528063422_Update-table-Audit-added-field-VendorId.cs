using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class UpdatetableAuditaddedfieldVendorId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "VendorId",
                table: "Audits",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Audits_VendorId",
                table: "Audits",
                column: "VendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Audits_Vendors_VendorId",
                table: "Audits",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Audits_Vendors_VendorId",
                table: "Audits");

            migrationBuilder.DropIndex(
                name: "IX_Audits_VendorId",
                table: "Audits");

            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "Audits");
        }
    }
}

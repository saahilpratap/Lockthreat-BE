using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class UpdateTableAudit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ProjectNameId",
                table: "Audits",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Audits_ProjectNameId",
                table: "Audits",
                column: "ProjectNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Audits_Projects_ProjectNameId",
                table: "Audits",
                column: "ProjectNameId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Audits_Projects_ProjectNameId",
                table: "Audits");

            migrationBuilder.DropIndex(
                name: "IX_Audits_ProjectNameId",
                table: "Audits");

            migrationBuilder.DropColumn(
                name: "ProjectNameId",
                table: "Audits");
        }
    }
}

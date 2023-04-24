using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class UpdatetableAuditremovefieldserviceprovider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Audits_AbpDynamicParameterValues_AuditServicesProviderId",
                table: "Audits");

            migrationBuilder.DropIndex(
                name: "IX_Audits_AuditServicesProviderId",
                table: "Audits");

            migrationBuilder.DropColumn(
                name: "AuditServicesProviderId",
                table: "Audits");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuditServicesProviderId",
                table: "Audits",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Audits_AuditServicesProviderId",
                table: "Audits",
                column: "AuditServicesProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Audits_AbpDynamicParameterValues_AuditServicesProviderId",
                table: "Audits",
                column: "AuditServicesProviderId",
                principalTable: "AbpDynamicParameterValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

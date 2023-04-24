using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class UpdatetableContractremoveBusinessProcess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_BusinessProcess_BusinessProcessId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_BusinessProcessId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "BusinessProcessId",
                table: "Contracts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BusinessProcessId",
                table: "Contracts",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_BusinessProcessId",
                table: "Contracts",
                column: "BusinessProcessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_BusinessProcess_BusinessProcessId",
                table: "Contracts",
                column: "BusinessProcessId",
                principalTable: "BusinessProcess",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

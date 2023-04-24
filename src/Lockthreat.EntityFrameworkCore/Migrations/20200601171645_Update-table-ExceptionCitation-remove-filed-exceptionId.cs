using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class UpdatetableExceptionCitationremovefiledexceptionId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExceptionInfoId",
                table: "ExceptionCitations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ExceptionInfoId",
                table: "ExceptionCitations",
                type: "bigint",
                nullable: true);
        }
    }
}

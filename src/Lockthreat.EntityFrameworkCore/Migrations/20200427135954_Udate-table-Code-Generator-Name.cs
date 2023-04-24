using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class UdatetableCodeGeneratorName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CodeGenerators",
                table: "CodeGenerators");

            migrationBuilder.RenameTable(
                name: "CodeGenerators",
                newName: "IDGenerators");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IDGenerators",
                table: "IDGenerators",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_IDGenerators",
                table: "IDGenerators");

            migrationBuilder.RenameTable(
                name: "IDGenerators",
                newName: "CodeGenerators");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CodeGenerators",
                table: "CodeGenerators",
                column: "Id");
        }
    }
}

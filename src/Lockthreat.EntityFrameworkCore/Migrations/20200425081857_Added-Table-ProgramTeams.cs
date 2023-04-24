using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableProgramTeams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgramTeams",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    GrcProgramId = table.Column<long>(nullable: true),
                    ProgramTeamsId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramTeams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramTeams_GrcPrograms_GrcProgramId",
                        column: x => x.GrcProgramId,
                        principalTable: "GrcPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProgramTeams_Employees_ProgramTeamsId",
                        column: x => x.ProgramTeamsId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgramTeams_GrcProgramId",
                table: "ProgramTeams",
                column: "GrcProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramTeams_ProgramTeamsId",
                table: "ProgramTeams",
                column: "ProgramTeamsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgramTeams");
        }
    }
}

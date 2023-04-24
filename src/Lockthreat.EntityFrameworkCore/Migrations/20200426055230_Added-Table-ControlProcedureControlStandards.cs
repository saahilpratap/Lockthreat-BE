using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableControlProcedureControlStandards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ControlProcedureControlStandards",
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
                    ControlProcedureId = table.Column<long>(nullable: true),
                    ControlStandardId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlProcedureControlStandards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControlProcedureControlStandards_ControlProcedures_ControlProcedureId",
                        column: x => x.ControlProcedureId,
                        principalTable: "ControlProcedures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ControlProcedureControlStandards_ControlStandards_ControlStandardId",
                        column: x => x.ControlStandardId,
                        principalTable: "ControlStandards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ControlProcedureControlStandards_ControlProcedureId",
                table: "ControlProcedureControlStandards",
                column: "ControlProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlProcedureControlStandards_ControlStandardId",
                table: "ControlProcedureControlStandards",
                column: "ControlStandardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ControlProcedureControlStandards");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableControlOperatingTestControlStandards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ControlOperatingTestControlStandards",
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
                    ControlOperatingTestId = table.Column<long>(nullable: true),
                    ControlStandardId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlOperatingTestControlStandards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControlOperatingTestControlStandards_ControlOperatingTests_ControlOperatingTestId",
                        column: x => x.ControlOperatingTestId,
                        principalTable: "ControlOperatingTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ControlOperatingTestControlStandards_ControlStandards_ControlStandardId",
                        column: x => x.ControlStandardId,
                        principalTable: "ControlStandards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ControlOperatingTestControlStandards_ControlOperatingTestId",
                table: "ControlOperatingTestControlStandards",
                column: "ControlOperatingTestId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlOperatingTestControlStandards_ControlStandardId",
                table: "ControlOperatingTestControlStandards",
                column: "ControlStandardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ControlOperatingTestControlStandards");
        }
    }
}

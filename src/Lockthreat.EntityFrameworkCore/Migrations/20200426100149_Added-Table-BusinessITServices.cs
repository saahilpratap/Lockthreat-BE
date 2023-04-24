using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableBusinessITServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessITServices",
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
                    BusinessProcessId = table.Column<long>(nullable: true),
                    BusinessServiceId = table.Column<long>(nullable: true),
                    ITServiceId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessITServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessITServices_BusinessServices_BusinessServiceId",
                        column: x => x.BusinessServiceId,
                        principalTable: "BusinessServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessITServices_ITServices_ITServiceId",
                        column: x => x.ITServiceId,
                        principalTable: "ITServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessITServices_BusinessServiceId",
                table: "BusinessITServices",
                column: "BusinessServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessITServices_ITServiceId",
                table: "BusinessITServices",
                column: "ITServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessITServices");
        }
    }
}

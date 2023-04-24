using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableFacilitieDatacenterITService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FacilitieDatacenterITServices",
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
                    FacilitieDatacenterId = table.Column<long>(nullable: true),
                    ITServiceId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilitieDatacenterITServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacilitieDatacenterITServices_FacilitieDatacenters_FacilitieDatacenterId",
                        column: x => x.FacilitieDatacenterId,
                        principalTable: "FacilitieDatacenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FacilitieDatacenterITServices_ITServices_ITServiceId",
                        column: x => x.ITServiceId,
                        principalTable: "ITServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FacilitieDatacenterITServices_FacilitieDatacenterId",
                table: "FacilitieDatacenterITServices",
                column: "FacilitieDatacenterId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilitieDatacenterITServices_ITServiceId",
                table: "FacilitieDatacenterITServices",
                column: "ITServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacilitieDatacenterITServices");
        }
    }
}

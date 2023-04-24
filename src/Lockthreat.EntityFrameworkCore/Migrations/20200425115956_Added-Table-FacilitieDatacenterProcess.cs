using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableFacilitieDatacenterProcess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FacilitieDatacenterBusinessProcess",
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
                    BusinessProcessId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilitieDatacenterBusinessProcess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacilitieDatacenterBusinessProcess_BusinessProcess_BusinessProcessId",
                        column: x => x.BusinessProcessId,
                        principalTable: "BusinessProcess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FacilitieDatacenterBusinessProcess_FacilitieDatacenters_FacilitieDatacenterId",
                        column: x => x.FacilitieDatacenterId,
                        principalTable: "FacilitieDatacenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FacilitieDatacenterBusinessProcess_BusinessProcessId",
                table: "FacilitieDatacenterBusinessProcess",
                column: "BusinessProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilitieDatacenterBusinessProcess_FacilitieDatacenterId",
                table: "FacilitieDatacenterBusinessProcess",
                column: "FacilitieDatacenterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacilitieDatacenterBusinessProcess");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableInternalControlFacilitieDatacenters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InternalControlFacilitieDatacenters",
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
                    InternalControlId = table.Column<long>(nullable: true),
                    FacilitieDatacenterId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalControlFacilitieDatacenters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InternalControlFacilitieDatacenters_FacilitieDatacenters_FacilitieDatacenterId",
                        column: x => x.FacilitieDatacenterId,
                        principalTable: "FacilitieDatacenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InternalControlFacilitieDatacenters_InternalControls_InternalControlId",
                        column: x => x.InternalControlId,
                        principalTable: "InternalControls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InternalControlFacilitieDatacenters_FacilitieDatacenterId",
                table: "InternalControlFacilitieDatacenters",
                column: "FacilitieDatacenterId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalControlFacilitieDatacenters_InternalControlId",
                table: "InternalControlFacilitieDatacenters",
                column: "InternalControlId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InternalControlFacilitieDatacenters");
        }
    }
}

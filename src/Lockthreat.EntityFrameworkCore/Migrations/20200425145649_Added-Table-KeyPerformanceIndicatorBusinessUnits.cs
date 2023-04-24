using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableKeyPerformanceIndicatorBusinessUnits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KeyPerformanceIndicatorBusinessUnits",
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
                    KeyPerformanceIndicatorId = table.Column<long>(nullable: true),
                    BusinessUnitId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyPerformanceIndicatorBusinessUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KeyPerformanceIndicatorBusinessUnits_BusinessUnits_BusinessUnitId",
                        column: x => x.BusinessUnitId,
                        principalTable: "BusinessUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KeyPerformanceIndicatorBusinessUnits_KeyPerformanceIndicators_KeyPerformanceIndicatorId",
                        column: x => x.KeyPerformanceIndicatorId,
                        principalTable: "KeyPerformanceIndicators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KeyPerformanceIndicatorBusinessUnits_BusinessUnitId",
                table: "KeyPerformanceIndicatorBusinessUnits",
                column: "BusinessUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_KeyPerformanceIndicatorBusinessUnits_KeyPerformanceIndicatorId",
                table: "KeyPerformanceIndicatorBusinessUnits",
                column: "KeyPerformanceIndicatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeyPerformanceIndicatorBusinessUnits");
        }
    }
}

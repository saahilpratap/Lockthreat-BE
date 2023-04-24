using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableKeyPerformanceIndicatorAdministrators : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KeyPerformanceIndicatorAdministrators",
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
                    EmployeeId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyPerformanceIndicatorAdministrators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KeyPerformanceIndicatorAdministrators_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KeyPerformanceIndicatorAdministrators_KeyPerformanceIndicators_KeyPerformanceIndicatorId",
                        column: x => x.KeyPerformanceIndicatorId,
                        principalTable: "KeyPerformanceIndicators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KeyPerformanceIndicatorAdministrators_EmployeeId",
                table: "KeyPerformanceIndicatorAdministrators",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_KeyPerformanceIndicatorAdministrators_KeyPerformanceIndicatorId",
                table: "KeyPerformanceIndicatorAdministrators",
                column: "KeyPerformanceIndicatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeyPerformanceIndicatorAdministrators");
        }
    }
}

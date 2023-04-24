using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableKeyRiskIndicatorBusinessUnits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KeyRiskIndicatorBusinessUnits",
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
                    BusinessUnitId = table.Column<long>(nullable: true),
                    KeyRiskIndicatorId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyRiskIndicatorBusinessUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KeyRiskIndicatorBusinessUnits_BusinessUnits_BusinessUnitId",
                        column: x => x.BusinessUnitId,
                        principalTable: "BusinessUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KeyRiskIndicatorBusinessUnits_KeyRiskIndicators_KeyRiskIndicatorId",
                        column: x => x.KeyRiskIndicatorId,
                        principalTable: "KeyRiskIndicators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KeyRiskIndicatorBusinessUnits_BusinessUnitId",
                table: "KeyRiskIndicatorBusinessUnits",
                column: "BusinessUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_KeyRiskIndicatorBusinessUnits_KeyRiskIndicatorId",
                table: "KeyRiskIndicatorBusinessUnits",
                column: "KeyRiskIndicatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeyRiskIndicatorBusinessUnits");
        }
    }
}

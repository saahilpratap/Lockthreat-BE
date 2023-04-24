using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableCyberAwarenessScoreBusinessUnits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CyberAwarenessScoreBusinessUnits",
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
                    CyberAwarenessScoreId = table.Column<long>(nullable: true),
                    BusinessUnitId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CyberAwarenessScoreBusinessUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CyberAwarenessScoreBusinessUnits_BusinessUnits_BusinessUnitId",
                        column: x => x.BusinessUnitId,
                        principalTable: "BusinessUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CyberAwarenessScoreBusinessUnits_CyberAwarenessScores_CyberAwarenessScoreId",
                        column: x => x.CyberAwarenessScoreId,
                        principalTable: "CyberAwarenessScores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CyberAwarenessScoreBusinessUnits_BusinessUnitId",
                table: "CyberAwarenessScoreBusinessUnits",
                column: "BusinessUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_CyberAwarenessScoreBusinessUnits_CyberAwarenessScoreId",
                table: "CyberAwarenessScoreBusinessUnits",
                column: "CyberAwarenessScoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CyberAwarenessScoreBusinessUnits");
        }
    }
}

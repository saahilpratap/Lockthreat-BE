using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableFindingHardwareAssets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FindingHardwareAssets",
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
                    FindingId = table.Column<long>(nullable: true),
                    HardwareAssetI = table.Column<long>(nullable: true),
                    HardwareAssetId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FindingHardwareAssets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FindingHardwareAssets_Findings_FindingId",
                        column: x => x.FindingId,
                        principalTable: "Findings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FindingHardwareAssets_HardwareAssets_HardwareAssetId",
                        column: x => x.HardwareAssetId,
                        principalTable: "HardwareAssets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FindingHardwareAssets_FindingId",
                table: "FindingHardwareAssets",
                column: "FindingId");

            migrationBuilder.CreateIndex(
                name: "IX_FindingHardwareAssets_HardwareAssetId",
                table: "FindingHardwareAssets",
                column: "HardwareAssetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FindingHardwareAssets");
        }
    }
}

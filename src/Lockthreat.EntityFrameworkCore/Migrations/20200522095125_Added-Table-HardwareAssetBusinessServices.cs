using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableHardwareAssetBusinessServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HardwareAssetBusinessServices",
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
                    HardwareAssetId = table.Column<long>(nullable: true),
                    BusinessServiceId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardwareAssetBusinessServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HardwareAssetBusinessServices_BusinessServices_BusinessServiceId",
                        column: x => x.BusinessServiceId,
                        principalTable: "BusinessServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HardwareAssetBusinessServices_HardwareAssets_HardwareAssetId",
                        column: x => x.HardwareAssetId,
                        principalTable: "HardwareAssets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HardwareAssetBusinessServices_BusinessServiceId",
                table: "HardwareAssetBusinessServices",
                column: "BusinessServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareAssetBusinessServices_HardwareAssetId",
                table: "HardwareAssetBusinessServices",
                column: "HardwareAssetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HardwareAssetBusinessServices");
        }
    }
}

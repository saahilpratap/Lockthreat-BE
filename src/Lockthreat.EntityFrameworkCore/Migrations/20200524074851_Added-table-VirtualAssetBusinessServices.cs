using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedtableVirtualAssetBusinessServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VirtualAssetBusinessServices",
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
                    VirtualAssetId = table.Column<long>(nullable: true),
                    BusinessServiceId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VirtualAssetBusinessServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VirtualAssetBusinessServices_BusinessServices_BusinessServiceId",
                        column: x => x.BusinessServiceId,
                        principalTable: "BusinessServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                        table.ForeignKey(
                        name: "FK_VirtualAssetBusinessServices_VirtualAssets_VirtualAssetId",
                        column: x => x.VirtualAssetId,
                        principalTable: "VirtualAssets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VirtualAssetBusinessServices_BusinessServiceId",
                table: "VirtualAssetBusinessServices",
                column: "BusinessServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_VirtualAssetBusinessServices_VirtualAssetId",
                table: "VirtualAssetBusinessServices",
                column: "VirtualAssetId");
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VirtualAssetBusinessServices");
        }
    }
}

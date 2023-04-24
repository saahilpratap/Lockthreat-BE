using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedtableVirtualAssetBusinessprocess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VirtualAssetBusinessprocess",
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
                    BusinessProcessId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VirtualAssetBusinessprocess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VirtualAssetBusinessprocess_BusinessProcess_BusinessProcessId",
                        column: x => x.BusinessProcessId,
                        principalTable: "BusinessProcess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VirtualAssetBusinessprocess_VirtualAssets_VirtualAssetId",
                        column: x => x.VirtualAssetId,
                        principalTable: "VirtualAssets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VirtualAssetBusinessprocess_BusinessProcessId",
                table: "VirtualAssetBusinessprocess",
                column: "BusinessProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_VirtualAssetBusinessprocess_VirtualAssetId",
                table: "VirtualAssetBusinessprocess",
                column: "VirtualAssetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VirtualAssetBusinessprocess");
        }
    }
}

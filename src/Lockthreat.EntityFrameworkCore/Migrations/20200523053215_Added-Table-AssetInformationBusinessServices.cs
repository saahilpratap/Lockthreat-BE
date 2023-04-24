using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableAssetInformationBusinessServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetInformationBusinessServices",
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
                    AssetInformationId = table.Column<long>(nullable: true),
                    BusinessServiceId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetInformationBusinessServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetInformationBusinessServices_AssetInformations_AssetInformationId",
                        column: x => x.AssetInformationId,
                        principalTable: "AssetInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetInformationBusinessServices_BusinessServices_BusinessServiceId",
                        column: x => x.BusinessServiceId,
                        principalTable: "BusinessServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetInformationBusinessServices_AssetInformationId",
                table: "AssetInformationBusinessServices",
                column: "AssetInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetInformationBusinessServices_BusinessServiceId",
                table: "AssetInformationBusinessServices",
                column: "BusinessServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetInformationBusinessServices");
        }
    }
}

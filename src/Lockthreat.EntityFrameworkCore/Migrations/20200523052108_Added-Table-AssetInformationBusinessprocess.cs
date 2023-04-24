using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableAssetInformationBusinessprocess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetInformationBusinessprocess",
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
                    BusinessProcessId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetInformationBusinessprocess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetInformationBusinessprocess_AssetInformations_AssetInformationId",
                        column: x => x.AssetInformationId,
                        principalTable: "AssetInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetInformationBusinessprocess_BusinessProcess_BusinessProcessId",
                        column: x => x.BusinessProcessId,
                        principalTable: "BusinessProcess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetInformationBusinessprocess_AssetInformationId",
                table: "AssetInformationBusinessprocess",
                column: "AssetInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetInformationBusinessprocess_BusinessProcessId",
                table: "AssetInformationBusinessprocess",
                column: "BusinessProcessId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetInformationBusinessprocess");
        }
    }
}

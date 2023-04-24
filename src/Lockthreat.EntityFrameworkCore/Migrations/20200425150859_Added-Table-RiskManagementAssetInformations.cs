using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableRiskManagementAssetInformations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RiskManagementAssetInformations",
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
                    RiskManagementId = table.Column<long>(nullable: true),
                    AssetInformationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskManagementAssetInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RiskManagementAssetInformations_AssetInformations_AssetInformationId",
                        column: x => x.AssetInformationId,
                        principalTable: "AssetInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RiskManagementAssetInformations_RiskManagements_RiskManagementId",
                        column: x => x.RiskManagementId,
                        principalTable: "RiskManagements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RiskManagementAssetInformations_AssetInformationId",
                table: "RiskManagementAssetInformations",
                column: "AssetInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskManagementAssetInformations_RiskManagementId",
                table: "RiskManagementAssetInformations",
                column: "RiskManagementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RiskManagementAssetInformations");
        }
    }
}

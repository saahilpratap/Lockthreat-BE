using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableBIAInformationAssets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BIAInformationAssets",
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
                    BusinessImpactAnalysisId = table.Column<long>(nullable: true),
                    AssetInformationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BIAInformationAssets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BIAInformationAssets_AssetInformations_AssetInformationId",
                        column: x => x.AssetInformationId,
                        principalTable: "AssetInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BIAInformationAssets_BusinessImpactAnalysises_BusinessImpactAnalysisId",
                        column: x => x.BusinessImpactAnalysisId,
                        principalTable: "BusinessImpactAnalysises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BIAInformationAssets_AssetInformationId",
                table: "BIAInformationAssets",
                column: "AssetInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_BIAInformationAssets_BusinessImpactAnalysisId",
                table: "BIAInformationAssets",
                column: "BusinessImpactAnalysisId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BIAInformationAssets");
        }
    }
}

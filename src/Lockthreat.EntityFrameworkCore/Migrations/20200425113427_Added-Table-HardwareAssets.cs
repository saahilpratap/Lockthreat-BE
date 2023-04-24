using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableHardwareAssets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HardwareAssets",
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
                    TenantId = table.Column<int>(nullable: true),
                    AssetId = table.Column<string>(nullable: true),
                    HardwareAssetName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    AssetHardwareId = table.Column<string>(nullable: true),
                    LocationsId = table.Column<long>(nullable: true),
                    LockThreatOrganizationId = table.Column<long>(nullable: true),
                    ConfidentialityId = table.Column<int>(nullable: true),
                    AvailibilityId = table.Column<int>(nullable: true),
                    OthersId = table.Column<int>(nullable: true),
                    IntegrityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardwareAssets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HardwareAssets_AbpDynamicParameterValues_AvailibilityId",
                        column: x => x.AvailibilityId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HardwareAssets_AbpDynamicParameterValues_ConfidentialityId",
                        column: x => x.ConfidentialityId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HardwareAssets_AbpDynamicParameterValues_IntegrityId",
                        column: x => x.IntegrityId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HardwareAssets_FacilitieDatacenters_LocationsId",
                        column: x => x.LocationsId,
                        principalTable: "FacilitieDatacenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HardwareAssets_LockThreatOrganizations_LockThreatOrganizationId",
                        column: x => x.LockThreatOrganizationId,
                        principalTable: "LockThreatOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HardwareAssets_AbpDynamicParameterValues_OthersId",
                        column: x => x.OthersId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HardwareAssets_AvailibilityId",
                table: "HardwareAssets",
                column: "AvailibilityId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareAssets_ConfidentialityId",
                table: "HardwareAssets",
                column: "ConfidentialityId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareAssets_IntegrityId",
                table: "HardwareAssets",
                column: "IntegrityId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareAssets_LocationsId",
                table: "HardwareAssets",
                column: "LocationsId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareAssets_LockThreatOrganizationId",
                table: "HardwareAssets",
                column: "LockThreatOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareAssets_OthersId",
                table: "HardwareAssets",
                column: "OthersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HardwareAssets");
        }
    }
}

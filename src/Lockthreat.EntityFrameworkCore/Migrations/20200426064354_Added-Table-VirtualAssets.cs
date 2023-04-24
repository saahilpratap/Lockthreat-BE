using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableVirtualAssets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VirtualAssets",
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
                    VirtualAssetId = table.Column<string>(nullable: true),
                    VirtualAssetName = table.Column<string>(nullable: false),
                    VirtualAssetUniqueIdentity = table.Column<string>(nullable: true),
                    VirtualMachine = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ParentVirtualHostId = table.Column<long>(nullable: true),
                    HostedServerNameId = table.Column<long>(nullable: true),
                    LockThreatOrganizationId = table.Column<long>(nullable: true),
                    BusinessUnitId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VirtualAssets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VirtualAssets_BusinessUnits_BusinessUnitId",
                        column: x => x.BusinessUnitId,
                        principalTable: "BusinessUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VirtualAssets_HardwareAssets_HostedServerNameId",
                        column: x => x.HostedServerNameId,
                        principalTable: "HardwareAssets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VirtualAssets_LockThreatOrganizations_LockThreatOrganizationId",
                        column: x => x.LockThreatOrganizationId,
                        principalTable: "LockThreatOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VirtualAssets_HardwareAssets_ParentVirtualHostId",
                        column: x => x.ParentVirtualHostId,
                        principalTable: "HardwareAssets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VirtualAssets_BusinessUnitId",
                table: "VirtualAssets",
                column: "BusinessUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_VirtualAssets_HostedServerNameId",
                table: "VirtualAssets",
                column: "HostedServerNameId");

            migrationBuilder.CreateIndex(
                name: "IX_VirtualAssets_LockThreatOrganizationId",
                table: "VirtualAssets",
                column: "LockThreatOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_VirtualAssets_ParentVirtualHostId",
                table: "VirtualAssets",
                column: "ParentVirtualHostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VirtualAssets");
        }
    }
}

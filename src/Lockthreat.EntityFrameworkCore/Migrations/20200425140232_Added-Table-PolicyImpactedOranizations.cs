using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTablePolicyImpactedOranizations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PolicyImpactedOranizations",
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
                    PolicyManagerId = table.Column<long>(nullable: true),
                    LockThreatOrganizationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyImpactedOranizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PolicyImpactedOranizations_LockThreatOrganizations_LockThreatOrganizationId",
                        column: x => x.LockThreatOrganizationId,
                        principalTable: "LockThreatOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PolicyImpactedOranizations_PolicyManagers_PolicyManagerId",
                        column: x => x.PolicyManagerId,
                        principalTable: "PolicyManagers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PolicyImpactedOranizations_LockThreatOrganizationId",
                table: "PolicyImpactedOranizations",
                column: "LockThreatOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyImpactedOranizations_PolicyManagerId",
                table: "PolicyImpactedOranizations",
                column: "PolicyManagerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PolicyImpactedOranizations");
        }
    }
}

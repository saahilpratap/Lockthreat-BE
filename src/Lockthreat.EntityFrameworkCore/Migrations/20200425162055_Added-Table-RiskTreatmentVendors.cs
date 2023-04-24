using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableRiskTreatmentVendors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RiskTreatmentVendors",
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
                    VendorId = table.Column<long>(nullable: true),
                    RiskTreatmentId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskTreatmentVendors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RiskTreatmentVendors_RiskTreatments_RiskTreatmentId",
                        column: x => x.RiskTreatmentId,
                        principalTable: "RiskTreatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RiskTreatmentVendors_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RiskTreatmentVendors_RiskTreatmentId",
                table: "RiskTreatmentVendors",
                column: "RiskTreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskTreatmentVendors_VendorId",
                table: "RiskTreatmentVendors",
                column: "VendorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RiskTreatmentVendors");
        }
    }
}

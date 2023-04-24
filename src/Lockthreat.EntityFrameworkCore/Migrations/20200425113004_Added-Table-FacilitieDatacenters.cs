using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableFacilitieDatacenters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FacilitieDatacenters",
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
                    FacilityId = table.Column<string>(nullable: true),
                    FacilityName = table.Column<string>(nullable: true),
                    FacilityAddressOne = table.Column<string>(nullable: true),
                    FacilityAddressTwo = table.Column<string>(nullable: true),
                    FacilityTypeId = table.Column<int>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    LockThreatOrganizationId = table.Column<long>(nullable: true),
                    BusinessUnitOwnerId = table.Column<long>(nullable: true),
                    BusinessUnitGaurdianId = table.Column<long>(nullable: true),
                    ConfidentialityId = table.Column<int>(nullable: true),
                    IntegrityId = table.Column<int>(nullable: true),
                    AvailibilityId = table.Column<int>(nullable: true),
                    OthersId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilitieDatacenters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacilitieDatacenters_AbpDynamicParameterValues_AvailibilityId",
                        column: x => x.AvailibilityId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FacilitieDatacenters_BusinessUnits_BusinessUnitGaurdianId",
                        column: x => x.BusinessUnitGaurdianId,
                        principalTable: "BusinessUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FacilitieDatacenters_BusinessUnits_BusinessUnitOwnerId",
                        column: x => x.BusinessUnitOwnerId,
                        principalTable: "BusinessUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FacilitieDatacenters_AbpDynamicParameterValues_ConfidentialityId",
                        column: x => x.ConfidentialityId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FacilitieDatacenters_AbpDynamicParameterValues_CountryId",
                        column: x => x.CountryId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FacilitieDatacenters_AbpDynamicParameterValues_FacilityTypeId",
                        column: x => x.FacilityTypeId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FacilitieDatacenters_AbpDynamicParameterValues_IntegrityId",
                        column: x => x.IntegrityId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FacilitieDatacenters_LockThreatOrganizations_LockThreatOrganizationId",
                        column: x => x.LockThreatOrganizationId,
                        principalTable: "LockThreatOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FacilitieDatacenters_AbpDynamicParameterValues_OthersId",
                        column: x => x.OthersId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FacilitieDatacenters_AvailibilityId",
                table: "FacilitieDatacenters",
                column: "AvailibilityId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilitieDatacenters_BusinessUnitGaurdianId",
                table: "FacilitieDatacenters",
                column: "BusinessUnitGaurdianId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilitieDatacenters_BusinessUnitOwnerId",
                table: "FacilitieDatacenters",
                column: "BusinessUnitOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilitieDatacenters_ConfidentialityId",
                table: "FacilitieDatacenters",
                column: "ConfidentialityId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilitieDatacenters_CountryId",
                table: "FacilitieDatacenters",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilitieDatacenters_FacilityTypeId",
                table: "FacilitieDatacenters",
                column: "FacilityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilitieDatacenters_IntegrityId",
                table: "FacilitieDatacenters",
                column: "IntegrityId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilitieDatacenters_LockThreatOrganizationId",
                table: "FacilitieDatacenters",
                column: "LockThreatOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilitieDatacenters_OthersId",
                table: "FacilitieDatacenters",
                column: "OthersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacilitieDatacenters");
        }
    }
}

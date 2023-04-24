using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableSystemApplications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SystemApplications",
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
                    SystemId = table.Column<string>(nullable: true),
                    SystemApplicationName = table.Column<string>(nullable: true),
                    AddressOne = table.Column<string>(nullable: true),
                    AddressTwo = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    LockThreatOrganizationId = table.Column<long>(nullable: true),
                    BusinessUnitId = table.Column<long>(nullable: true),
                    BusinessOwnerId = table.Column<long>(nullable: true),
                    ConfidentialityId = table.Column<int>(nullable: true),
                    AvailibilityId = table.Column<int>(nullable: true),
                    IntegrityId = table.Column<int>(nullable: true),
                    OthersId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemApplications_AbpDynamicParameterValues_AvailibilityId",
                        column: x => x.AvailibilityId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SystemApplications_Employees_BusinessOwnerId",
                        column: x => x.BusinessOwnerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SystemApplications_BusinessUnits_BusinessUnitId",
                        column: x => x.BusinessUnitId,
                        principalTable: "BusinessUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SystemApplications_AbpDynamicParameterValues_ConfidentialityId",
                        column: x => x.ConfidentialityId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SystemApplications_AbpDynamicParameterValues_CountryId",
                        column: x => x.CountryId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SystemApplications_AbpDynamicParameterValues_IntegrityId",
                        column: x => x.IntegrityId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SystemApplications_LockThreatOrganizations_LockThreatOrganizationId",
                        column: x => x.LockThreatOrganizationId,
                        principalTable: "LockThreatOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SystemApplications_AbpDynamicParameterValues_OthersId",
                        column: x => x.OthersId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SystemApplications_AvailibilityId",
                table: "SystemApplications",
                column: "AvailibilityId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemApplications_BusinessOwnerId",
                table: "SystemApplications",
                column: "BusinessOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemApplications_BusinessUnitId",
                table: "SystemApplications",
                column: "BusinessUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemApplications_ConfidentialityId",
                table: "SystemApplications",
                column: "ConfidentialityId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemApplications_CountryId",
                table: "SystemApplications",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemApplications_IntegrityId",
                table: "SystemApplications",
                column: "IntegrityId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemApplications_LockThreatOrganizationId",
                table: "SystemApplications",
                column: "LockThreatOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemApplications_OthersId",
                table: "SystemApplications",
                column: "OthersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemApplications");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableLockThreatOrganization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LockThreatOrganizations",
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
                    CompanyId = table.Column<string>(nullable: false),
                    CompanyName = table.Column<string>(nullable: false),
                    Leveltype = table.Column<int>(nullable: false),
                    OrganizationUnitId = table.Column<long>(nullable: true),
                    ParentOrganizationId = table.Column<long>(nullable: true),
                    IndustrySectorId = table.Column<int>(nullable: true),
                    IsAuditableEntity = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    EmployeeSize = table.Column<int>(nullable: false),
                    CompanyWebsite = table.Column<string>(nullable: true),
                    CompanyLogo = table.Column<string>(nullable: true),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    AddressCountryId = table.Column<int>(nullable: true),
                    ContactFirstName = table.Column<string>(nullable: true),
                    ContactLastName = table.Column<string>(nullable: true),
                    JobTitle = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    PrimaryContactId = table.Column<long>(nullable: true),
                    CompanyAdministratorId = table.Column<long>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LockThreatOrganizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LockThreatOrganizations_AbpDynamicParameterValues_AddressCountryId",
                        column: x => x.AddressCountryId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LockThreatOrganizations_AbpDynamicParameterValues_CountryId",
                        column: x => x.CountryId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LockThreatOrganizations_AbpDynamicParameterValues_IndustrySectorId",
                        column: x => x.IndustrySectorId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LockThreatOrganizations_AddressCountryId",
                table: "LockThreatOrganizations",
                column: "AddressCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_LockThreatOrganizations_CountryId",
                table: "LockThreatOrganizations",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_LockThreatOrganizations_IndustrySectorId",
                table: "LockThreatOrganizations",
                column: "IndustrySectorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LockThreatOrganizations");
        }
    }
}

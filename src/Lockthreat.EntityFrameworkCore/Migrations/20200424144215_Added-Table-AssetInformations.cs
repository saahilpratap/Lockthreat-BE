using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableAssetInformations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetInformations",
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
                    AssetTitle = table.Column<string>(nullable: true),
                    AddressLineOne = table.Column<string>(nullable: true),
                    AddressLineTwo = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    AssetIdLV = table.Column<int>(nullable: true),
                    AssetTypeId = table.Column<int>(nullable: true),
                    AssetCategoryId = table.Column<int>(nullable: true),
                    AssetLabelId = table.Column<int>(nullable: true),
                    LockThreatOrganizationId = table.Column<long>(nullable: true),
                    EmployeeId = table.Column<long>(nullable: true),
                    ConfidentialityId = table.Column<int>(nullable: true),
                    AvailibilityId = table.Column<int>(nullable: true),
                    IntegrityId = table.Column<int>(nullable: true),
                    OtherId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetInformations_AbpDynamicParameterValues_AssetCategoryId",
                        column: x => x.AssetCategoryId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetInformations_AbpDynamicParameterValues_AssetLabelId",
                        column: x => x.AssetLabelId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetInformations_AbpDynamicParameterValues_AssetTypeId",
                        column: x => x.AssetTypeId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetInformations_AbpDynamicParameterValues_AvailibilityId",
                        column: x => x.AvailibilityId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetInformations_AbpDynamicParameterValues_ConfidentialityId",
                        column: x => x.ConfidentialityId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetInformations_AbpDynamicParameterValues_CountryId",
                        column: x => x.CountryId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetInformations_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetInformations_AbpDynamicParameterValues_IntegrityId",
                        column: x => x.IntegrityId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetInformations_LockThreatOrganizations_LockThreatOrganizationId",
                        column: x => x.LockThreatOrganizationId,
                        principalTable: "LockThreatOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetInformations_AbpDynamicParameterValues_OtherId",
                        column: x => x.OtherId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetInformations_AssetCategoryId",
                table: "AssetInformations",
                column: "AssetCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetInformations_AssetLabelId",
                table: "AssetInformations",
                column: "AssetLabelId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetInformations_AssetTypeId",
                table: "AssetInformations",
                column: "AssetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetInformations_AvailibilityId",
                table: "AssetInformations",
                column: "AvailibilityId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetInformations_ConfidentialityId",
                table: "AssetInformations",
                column: "ConfidentialityId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetInformations_CountryId",
                table: "AssetInformations",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetInformations_EmployeeId",
                table: "AssetInformations",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetInformations_IntegrityId",
                table: "AssetInformations",
                column: "IntegrityId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetInformations_LockThreatOrganizationId",
                table: "AssetInformations",
                column: "LockThreatOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetInformations_OtherId",
                table: "AssetInformations",
                column: "OtherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetInformations");
        }
    }
}

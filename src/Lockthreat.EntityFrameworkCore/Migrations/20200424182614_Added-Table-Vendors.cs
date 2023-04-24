using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableVendors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vendors",
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
                    VendorId = table.Column<string>(nullable: true),
                    VendorName = table.Column<string>(nullable: false),
                    RegistrationDate = table.Column<DateTime>(nullable: true),
                    ContactFirstName = table.Column<string>(nullable: true),
                    ContactLastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    CellPhoneNumber = table.Column<string>(nullable: true),
                    FaxNumber = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    AddressLine = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    PostalCode = table.Column<int>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    VendorTypeId = table.Column<int>(nullable: true),
                    IndustryId = table.Column<int>(nullable: true),
                    VendorCriticalRatingId = table.Column<int>(nullable: true),
                    VendorInitialRatingId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendors_AbpDynamicParameterValues_CountryId",
                        column: x => x.CountryId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vendors_AbpDynamicParameterValues_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vendors_AbpDynamicParameterValues_VendorCriticalRatingId",
                        column: x => x.VendorCriticalRatingId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vendors_AbpDynamicParameterValues_VendorInitialRatingId",
                        column: x => x.VendorInitialRatingId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vendors_AbpDynamicParameterValues_VendorTypeId",
                        column: x => x.VendorTypeId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_CountryId",
                table: "Vendors",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_IndustryId",
                table: "Vendors",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_VendorCriticalRatingId",
                table: "Vendors",
                column: "VendorCriticalRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_VendorInitialRatingId",
                table: "Vendors",
                column: "VendorInitialRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_VendorTypeId",
                table: "Vendors",
                column: "VendorTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vendors");
        }
    }
}

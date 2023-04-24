using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableITServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ITServices",
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
                    ITServicesId = table.Column<string>(nullable: true),
                    ITServiceName = table.Column<string>(nullable: false),
                    ServiceTypeId = table.Column<int>(nullable: true),
                    ServiceClassificationId = table.Column<int>(nullable: true),
                    AddressLineOne = table.Column<string>(nullable: true),
                    AddressLineTwo = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    LockThreatOrganizationId = table.Column<long>(nullable: true),
                    ITServiceOwnerId = table.Column<long>(nullable: true),
                    ITServiceManagerId = table.Column<long>(nullable: true),
                    BusinessUnitId = table.Column<long>(nullable: true),
                    RegulatoryMandateId = table.Column<int>(nullable: true),
                    ConfidentialityId = table.Column<int>(nullable: true),
                    IntegrityId = table.Column<int>(nullable: true),
                    OthersId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ITServices_BusinessUnits_BusinessUnitId",
                        column: x => x.BusinessUnitId,
                        principalTable: "BusinessUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ITServices_AbpDynamicParameterValues_ConfidentialityId",
                        column: x => x.ConfidentialityId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ITServices_AbpDynamicParameterValues_CountryId",
                        column: x => x.CountryId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ITServices_Employees_ITServiceManagerId",
                        column: x => x.ITServiceManagerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ITServices_Employees_ITServiceOwnerId",
                        column: x => x.ITServiceOwnerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ITServices_AbpDynamicParameterValues_IntegrityId",
                        column: x => x.IntegrityId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ITServices_LockThreatOrganizations_LockThreatOrganizationId",
                        column: x => x.LockThreatOrganizationId,
                        principalTable: "LockThreatOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ITServices_AbpDynamicParameterValues_OthersId",
                        column: x => x.OthersId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ITServices_AbpDynamicParameterValues_RegulatoryMandateId",
                        column: x => x.RegulatoryMandateId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ITServices_AbpDynamicParameterValues_ServiceClassificationId",
                        column: x => x.ServiceClassificationId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ITServices_AbpDynamicParameterValues_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ITServices_BusinessUnitId",
                table: "ITServices",
                column: "BusinessUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ITServices_ConfidentialityId",
                table: "ITServices",
                column: "ConfidentialityId");

            migrationBuilder.CreateIndex(
                name: "IX_ITServices_CountryId",
                table: "ITServices",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ITServices_ITServiceManagerId",
                table: "ITServices",
                column: "ITServiceManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_ITServices_ITServiceOwnerId",
                table: "ITServices",
                column: "ITServiceOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ITServices_IntegrityId",
                table: "ITServices",
                column: "IntegrityId");

            migrationBuilder.CreateIndex(
                name: "IX_ITServices_LockThreatOrganizationId",
                table: "ITServices",
                column: "LockThreatOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ITServices_OthersId",
                table: "ITServices",
                column: "OthersId");

            migrationBuilder.CreateIndex(
                name: "IX_ITServices_RegulatoryMandateId",
                table: "ITServices",
                column: "RegulatoryMandateId");

            migrationBuilder.CreateIndex(
                name: "IX_ITServices_ServiceClassificationId",
                table: "ITServices",
                column: "ServiceClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_ITServices_ServiceTypeId",
                table: "ITServices",
                column: "ServiceTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ITServices");
        }
    }
}

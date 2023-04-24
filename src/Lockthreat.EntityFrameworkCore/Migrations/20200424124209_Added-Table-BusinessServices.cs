using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableBusinessServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessServices",
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
                    BusinessServiceId = table.Column<string>(nullable: true),
                    BusinessServiceName = table.Column<string>(nullable: true),
                    BusinessUnitDependentId = table.Column<long>(nullable: true),
                    BusinessUnitprimaryId = table.Column<long>(nullable: true),
                    LockThreatOrganizationId = table.Column<long>(nullable: true),
                    BusinessServiceOwnerId = table.Column<long>(nullable: true),
                    BusinessServiceManagerId = table.Column<long>(nullable: true),
                    ServiceTypeId = table.Column<int>(nullable: true),
                    ConfidentialityId = table.Column<int>(nullable: true),
                    IntergrityId = table.Column<int>(nullable: true),
                    OthersId = table.Column<int>(nullable: true),
                    AvailibilityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessServices_AbpDynamicParameterValues_AvailibilityId",
                        column: x => x.AvailibilityId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessServices_Employees_BusinessServiceManagerId",
                        column: x => x.BusinessServiceManagerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessServices_Employees_BusinessServiceOwnerId",
                        column: x => x.BusinessServiceOwnerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessServices_BusinessUnits_BusinessUnitDependentId",
                        column: x => x.BusinessUnitDependentId,
                        principalTable: "BusinessUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessServices_BusinessUnits_BusinessUnitprimaryId",
                        column: x => x.BusinessUnitprimaryId,
                        principalTable: "BusinessUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessServices_AbpDynamicParameterValues_ConfidentialityId",
                        column: x => x.ConfidentialityId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessServices_AbpDynamicParameterValues_IntergrityId",
                        column: x => x.IntergrityId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessServices_LockThreatOrganizations_LockThreatOrganizationId",
                        column: x => x.LockThreatOrganizationId,
                        principalTable: "LockThreatOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessServices_AbpDynamicParameterValues_OthersId",
                        column: x => x.OthersId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessServices_AbpDynamicParameterValues_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessServices_AvailibilityId",
                table: "BusinessServices",
                column: "AvailibilityId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessServices_BusinessServiceManagerId",
                table: "BusinessServices",
                column: "BusinessServiceManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessServices_BusinessServiceOwnerId",
                table: "BusinessServices",
                column: "BusinessServiceOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessServices_BusinessUnitDependentId",
                table: "BusinessServices",
                column: "BusinessUnitDependentId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessServices_BusinessUnitprimaryId",
                table: "BusinessServices",
                column: "BusinessUnitprimaryId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessServices_ConfidentialityId",
                table: "BusinessServices",
                column: "ConfidentialityId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessServices_IntergrityId",
                table: "BusinessServices",
                column: "IntergrityId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessServices_LockThreatOrganizationId",
                table: "BusinessServices",
                column: "LockThreatOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessServices_OthersId",
                table: "BusinessServices",
                column: "OthersId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessServices_ServiceTypeId",
                table: "BusinessServices",
                column: "ServiceTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessServices");
        }
    }
}

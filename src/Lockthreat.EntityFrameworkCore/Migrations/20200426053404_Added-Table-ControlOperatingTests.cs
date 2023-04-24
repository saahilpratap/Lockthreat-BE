using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableControlOperatingTests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ControlOperatingTests",
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
                    COTId = table.Column<string>(nullable: true),
                    TestStatusId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    TestDetails = table.Column<string>(nullable: true),
                    ExpectedResult = table.Column<string>(nullable: true),
                    TestEffectiveDate = table.Column<DateTime>(nullable: true),
                    SampleSize = table.Column<int>(nullable: true),
                    InternalControlId = table.Column<long>(nullable: true),
                    PerformedbyId = table.Column<long>(nullable: true),
                    DataCollectionPurposeId = table.Column<int>(nullable: true),
                    ActualResult = table.Column<string>(nullable: true),
                    TestNotes = table.Column<string>(nullable: true),
                    CollectionSampleSize = table.Column<int>(nullable: true),
                    DataCollectionDetails = table.Column<string>(nullable: true),
                    AuditId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlOperatingTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControlOperatingTests_Audits_AuditId",
                        column: x => x.AuditId,
                        principalTable: "Audits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ControlOperatingTests_AbpDynamicParameterValues_DataCollectionPurposeId",
                        column: x => x.DataCollectionPurposeId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ControlOperatingTests_InternalControls_InternalControlId",
                        column: x => x.InternalControlId,
                        principalTable: "InternalControls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ControlOperatingTests_Employees_PerformedbyId",
                        column: x => x.PerformedbyId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ControlOperatingTests_AbpDynamicParameterValues_TestStatusId",
                        column: x => x.TestStatusId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ControlOperatingTests_AuditId",
                table: "ControlOperatingTests",
                column: "AuditId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlOperatingTests_DataCollectionPurposeId",
                table: "ControlOperatingTests",
                column: "DataCollectionPurposeId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlOperatingTests_InternalControlId",
                table: "ControlOperatingTests",
                column: "InternalControlId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlOperatingTests_PerformedbyId",
                table: "ControlOperatingTests",
                column: "PerformedbyId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlOperatingTests_TestStatusId",
                table: "ControlOperatingTests",
                column: "TestStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ControlOperatingTests");
        }
    }
}

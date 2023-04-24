using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableControlProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ControlProcedures",
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
                    ControlProcedureId = table.Column<string>(nullable: true),
                    ProcedureName = table.Column<string>(nullable: true),
                    ControlProcedureTypeId = table.Column<int>(nullable: true),
                    OperationalFrequencyId = table.Column<int>(nullable: true),
                    ActivityCycleId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ProcedureCategoryId = table.Column<int>(nullable: true),
                    BusinessUnitId = table.Column<long>(nullable: true),
                    ProcedureManagerId = table.Column<long>(nullable: true),
                    ProcedureOwnerId = table.Column<long>(nullable: true),
                    TestTypeId = table.Column<int>(nullable: true),
                    TesterId = table.Column<long>(nullable: true),
                    CitationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlProcedures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControlProcedures_AbpDynamicParameterValues_ActivityCycleId",
                        column: x => x.ActivityCycleId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ControlProcedures_BusinessUnits_BusinessUnitId",
                        column: x => x.BusinessUnitId,
                        principalTable: "BusinessUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ControlProcedures_Citations_CitationId",
                        column: x => x.CitationId,
                        principalTable: "Citations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ControlProcedures_AbpDynamicParameterValues_ControlProcedureTypeId",
                        column: x => x.ControlProcedureTypeId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ControlProcedures_AbpDynamicParameterValues_OperationalFrequencyId",
                        column: x => x.OperationalFrequencyId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ControlProcedures_AbpDynamicParameterValues_ProcedureCategoryId",
                        column: x => x.ProcedureCategoryId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ControlProcedures_Employees_ProcedureManagerId",
                        column: x => x.ProcedureManagerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ControlProcedures_Employees_ProcedureOwnerId",
                        column: x => x.ProcedureOwnerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ControlProcedures_AbpDynamicParameterValues_TestTypeId",
                        column: x => x.TestTypeId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ControlProcedures_Employees_TesterId",
                        column: x => x.TesterId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ControlProcedures_ActivityCycleId",
                table: "ControlProcedures",
                column: "ActivityCycleId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlProcedures_BusinessUnitId",
                table: "ControlProcedures",
                column: "BusinessUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlProcedures_CitationId",
                table: "ControlProcedures",
                column: "CitationId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlProcedures_ControlProcedureTypeId",
                table: "ControlProcedures",
                column: "ControlProcedureTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlProcedures_OperationalFrequencyId",
                table: "ControlProcedures",
                column: "OperationalFrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlProcedures_ProcedureCategoryId",
                table: "ControlProcedures",
                column: "ProcedureCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlProcedures_ProcedureManagerId",
                table: "ControlProcedures",
                column: "ProcedureManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlProcedures_ProcedureOwnerId",
                table: "ControlProcedures",
                column: "ProcedureOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlProcedures_TestTypeId",
                table: "ControlProcedures",
                column: "TestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlProcedures_TesterId",
                table: "ControlProcedures",
                column: "TesterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ControlProcedures");
        }
    }
}

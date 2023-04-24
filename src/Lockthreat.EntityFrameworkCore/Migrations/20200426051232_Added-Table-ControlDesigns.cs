using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableControlDesigns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ControlDesigns",
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
                    ControlDesignId = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    ResultStatusId = table.Column<int>(nullable: true),
                    InternalControlId = table.Column<long>(nullable: true),
                    EmployeeId = table.Column<long>(nullable: true),
                    TestEffectiveDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlDesigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControlDesigns_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ControlDesigns_InternalControls_InternalControlId",
                        column: x => x.InternalControlId,
                        principalTable: "InternalControls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ControlDesigns_AbpDynamicParameterValues_ResultStatusId",
                        column: x => x.ResultStatusId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ControlDesigns_EmployeeId",
                table: "ControlDesigns",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlDesigns_InternalControlId",
                table: "ControlDesigns",
                column: "InternalControlId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlDesigns_ResultStatusId",
                table: "ControlDesigns",
                column: "ResultStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ControlDesigns");
        }
    }
}

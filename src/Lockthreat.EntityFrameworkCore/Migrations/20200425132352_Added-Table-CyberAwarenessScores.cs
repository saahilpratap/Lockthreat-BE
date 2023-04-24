using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableCyberAwarenessScores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CyberAwarenessScores",
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
                    CASId = table.Column<string>(nullable: true),
                    CASName = table.Column<string>(nullable: false),
                    EmployeeId = table.Column<long>(nullable: true),
                    TargetTypeId = table.Column<int>(nullable: true),
                    SatusId = table.Column<int>(nullable: true),
                    StatusId = table.Column<int>(nullable: true),
                    SourceId = table.Column<int>(nullable: true),
                    ScheduleId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    IsQuestionarieGenerated = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CyberAwarenessScores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CyberAwarenessScores_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CyberAwarenessScores_AbpDynamicParameterValues_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CyberAwarenessScores_AbpDynamicParameterValues_SourceId",
                        column: x => x.SourceId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CyberAwarenessScores_AbpDynamicParameterValues_StatusId",
                        column: x => x.StatusId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CyberAwarenessScores_AbpDynamicParameterValues_TargetTypeId",
                        column: x => x.TargetTypeId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CyberAwarenessScores_EmployeeId",
                table: "CyberAwarenessScores",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_CyberAwarenessScores_ScheduleId",
                table: "CyberAwarenessScores",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_CyberAwarenessScores_SourceId",
                table: "CyberAwarenessScores",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_CyberAwarenessScores_StatusId",
                table: "CyberAwarenessScores",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CyberAwarenessScores_TargetTypeId",
                table: "CyberAwarenessScores",
                column: "TargetTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CyberAwarenessScores");
        }
    }
}

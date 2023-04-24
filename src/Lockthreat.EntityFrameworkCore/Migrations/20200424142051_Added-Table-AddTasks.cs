using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableAddTasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Keywords",
                table: "AuthoratativeDocuments");

            migrationBuilder.AddColumn<string>(
                name: "Keyword",
                table: "AuthoratativeDocuments",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AddTasks",
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
                    TaskId = table.Column<string>(nullable: true),
                    TaskDescription = table.Column<string>(nullable: true),
                    TaskTitle = table.Column<string>(nullable: true),
                    Frequencys = table.Column<int>(nullable: false),
                    Prioritys = table.Column<int>(nullable: false),
                    Tags = table.Column<string>(nullable: true),
                    Days = table.Column<int>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    ActualCompleted = table.Column<DateTime>(nullable: true),
                    TaskTypeId = table.Column<int>(nullable: true),
                    LinkedToId = table.Column<int>(nullable: true),
                    StatusId = table.Column<int>(nullable: true),
                    RiskLevelId = table.Column<int>(nullable: true),
                    RequestedById = table.Column<long>(nullable: true),
                    AssignedUserId = table.Column<long>(nullable: true),
                    AssignedToId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddTasks_Employees_AssignedToId",
                        column: x => x.AssignedToId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AddTasks_Employees_AssignedUserId",
                        column: x => x.AssignedUserId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AddTasks_AbpDynamicParameterValues_LinkedToId",
                        column: x => x.LinkedToId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AddTasks_Employees_RequestedById",
                        column: x => x.RequestedById,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AddTasks_AbpDynamicParameterValues_RiskLevelId",
                        column: x => x.RiskLevelId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AddTasks_AbpDynamicParameterValues_StatusId",
                        column: x => x.StatusId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AddTasks_AbpDynamicParameterValues_TaskTypeId",
                        column: x => x.TaskTypeId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddTasks_AssignedToId",
                table: "AddTasks",
                column: "AssignedToId");

            migrationBuilder.CreateIndex(
                name: "IX_AddTasks_AssignedUserId",
                table: "AddTasks",
                column: "AssignedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AddTasks_LinkedToId",
                table: "AddTasks",
                column: "LinkedToId");

            migrationBuilder.CreateIndex(
                name: "IX_AddTasks_RequestedById",
                table: "AddTasks",
                column: "RequestedById");

            migrationBuilder.CreateIndex(
                name: "IX_AddTasks_RiskLevelId",
                table: "AddTasks",
                column: "RiskLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_AddTasks_StatusId",
                table: "AddTasks",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AddTasks_TaskTypeId",
                table: "AddTasks",
                column: "TaskTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddTasks");

            migrationBuilder.DropColumn(
                name: "Keyword",
                table: "AuthoratativeDocuments");

            migrationBuilder.AddColumn<string>(
                name: "Keywords",
                table: "AuthoratativeDocuments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

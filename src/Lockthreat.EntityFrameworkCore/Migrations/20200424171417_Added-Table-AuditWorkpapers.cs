using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableAuditWorkpapers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditWorkpapers",
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
                    WorkpaperId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    WorkpaperTitle = table.Column<string>(nullable: false),
                    PreparedOn = table.Column<DateTime>(nullable: true),
                    AuditId = table.Column<int>(nullable: true),
                    AuditId1 = table.Column<long>(nullable: true),
                    EmployeeId = table.Column<long>(nullable: true),
                    TypeId = table.Column<int>(nullable: true),
                    Signature = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    WorkpaperAttachment = table.Column<string>(nullable: true),
                    WorkpaperLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditWorkpapers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditWorkpapers_Audits_AuditId1",
                        column: x => x.AuditId1,
                        principalTable: "Audits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AuditWorkpapers_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AuditWorkpapers_AbpDynamicParameterValues_TypeId",
                        column: x => x.TypeId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditWorkpapers_AuditId1",
                table: "AuditWorkpapers",
                column: "AuditId1");

            migrationBuilder.CreateIndex(
                name: "IX_AuditWorkpapers_EmployeeId",
                table: "AuditWorkpapers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditWorkpapers_TypeId",
                table: "AuditWorkpapers",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditWorkpapers");
        }
    }
}

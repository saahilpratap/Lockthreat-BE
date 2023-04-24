using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableAuditWorkpaperEvidences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditWorkpaperEvidences",
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
                    DocumentSourceId = table.Column<int>(nullable: true),
                    Attachment = table.Column<string>(nullable: true),
                    DocumentLink = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<long>(nullable: true),
                    AuditId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditWorkpaperEvidences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditWorkpaperEvidences_Audits_AuditId",
                        column: x => x.AuditId,
                        principalTable: "Audits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AuditWorkpaperEvidences_AbpDynamicParameterValues_DocumentSourceId",
                        column: x => x.DocumentSourceId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AuditWorkpaperEvidences_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditWorkpaperEvidences_AuditId",
                table: "AuditWorkpaperEvidences",
                column: "AuditId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditWorkpaperEvidences_DocumentSourceId",
                table: "AuditWorkpaperEvidences",
                column: "DocumentSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditWorkpaperEvidences_EmployeeId",
                table: "AuditWorkpaperEvidences",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditWorkpaperEvidences");
        }
    }
}

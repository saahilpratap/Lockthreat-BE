using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableAuditWorkpaperReviewers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditWorkpaperReviewers",
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
                    EmployeeId = table.Column<long>(nullable: true),
                    AuditWorkpaperId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditWorkpaperReviewers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditWorkpaperReviewers_AuditWorkpapers_AuditWorkpaperId",
                        column: x => x.AuditWorkpaperId,
                        principalTable: "AuditWorkpapers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AuditWorkpaperReviewers_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditWorkpaperReviewers_AuditWorkpaperId",
                table: "AuditWorkpaperReviewers",
                column: "AuditWorkpaperId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditWorkpaperReviewers_EmployeeId",
                table: "AuditWorkpaperReviewers",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditWorkpaperReviewers");
        }
    }
}

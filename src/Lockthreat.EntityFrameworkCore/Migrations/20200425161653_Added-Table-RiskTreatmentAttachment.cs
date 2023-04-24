using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableRiskTreatmentAttachment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RiskTreatmentAttachments",
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
                    RiskTreatmentId = table.Column<long>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<long>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskTreatmentAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RiskTreatmentAttachments_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RiskTreatmentAttachments_RiskTreatments_RiskTreatmentId",
                        column: x => x.RiskTreatmentId,
                        principalTable: "RiskTreatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RiskTreatmentAttachments_EmployeeId",
                table: "RiskTreatmentAttachments",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskTreatmentAttachments_RiskTreatmentId",
                table: "RiskTreatmentAttachments",
                column: "RiskTreatmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RiskTreatmentAttachments");
        }
    }
}

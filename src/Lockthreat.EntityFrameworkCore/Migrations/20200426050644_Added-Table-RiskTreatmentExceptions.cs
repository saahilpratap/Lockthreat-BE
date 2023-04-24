using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableRiskTreatmentExceptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RiskTreatmentExceptions",
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
                    ExceptionId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskTreatmentExceptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RiskTreatmentExceptions_Exceptions_ExceptionId",
                        column: x => x.ExceptionId,
                        principalTable: "Exceptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RiskTreatmentExceptions_RiskTreatments_RiskTreatmentId",
                        column: x => x.RiskTreatmentId,
                        principalTable: "RiskTreatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RiskTreatmentExceptions_ExceptionId",
                table: "RiskTreatmentExceptions",
                column: "ExceptionId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskTreatmentExceptions_RiskTreatmentId",
                table: "RiskTreatmentExceptions",
                column: "RiskTreatmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RiskTreatmentExceptions");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableContractRiskTreatments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContractRiskTreatments",
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
                    ContractsId = table.Column<long>(nullable: true),
                    ContractId = table.Column<long>(nullable: true),
                    RiskTreatmentId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractRiskTreatments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractRiskTreatments_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContractRiskTreatments_RiskTreatments_RiskTreatmentId",
                        column: x => x.RiskTreatmentId,
                        principalTable: "RiskTreatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContractRiskTreatments_ContractId",
                table: "ContractRiskTreatments",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractRiskTreatments_RiskTreatmentId",
                table: "ContractRiskTreatments",
                column: "RiskTreatmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractRiskTreatments");
        }
    }
}

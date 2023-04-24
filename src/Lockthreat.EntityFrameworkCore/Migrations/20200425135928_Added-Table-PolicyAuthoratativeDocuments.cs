using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTablePolicyAuthoratativeDocuments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PolicyAuthoratativeDocuments",
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
                    PolicyManagerId = table.Column<long>(nullable: true),
                    AuthoratativeDocumentsId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyAuthoratativeDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PolicyAuthoratativeDocuments_AuthoratativeDocuments_AuthoratativeDocumentsId",
                        column: x => x.AuthoratativeDocumentsId,
                        principalTable: "AuthoratativeDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PolicyAuthoratativeDocuments_PolicyManagers_PolicyManagerId",
                        column: x => x.PolicyManagerId,
                        principalTable: "PolicyManagers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PolicyAuthoratativeDocuments_AuthoratativeDocumentsId",
                table: "PolicyAuthoratativeDocuments",
                column: "AuthoratativeDocumentsId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyAuthoratativeDocuments_PolicyManagerId",
                table: "PolicyAuthoratativeDocuments",
                column: "PolicyManagerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PolicyAuthoratativeDocuments");
        }
    }
}

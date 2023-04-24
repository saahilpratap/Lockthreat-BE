using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableAuthoratativeDocumentBusinessUnits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthoratativeDocumentBusinessUnits",
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
                    AuthoratativeDocumentsId = table.Column<long>(nullable: true),
                    BusinessUnitId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthoratativeDocumentBusinessUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthoratativeDocumentBusinessUnits_AuthoratativeDocuments_AuthoratativeDocumentsId",
                        column: x => x.AuthoratativeDocumentsId,
                        principalTable: "AuthoratativeDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AuthoratativeDocumentBusinessUnits_BusinessUnits_BusinessUnitId",
                        column: x => x.BusinessUnitId,
                        principalTable: "BusinessUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthoratativeDocumentBusinessUnits_AuthoratativeDocumentsId",
                table: "AuthoratativeDocumentBusinessUnits",
                column: "AuthoratativeDocumentsId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthoratativeDocumentBusinessUnits_BusinessUnitId",
                table: "AuthoratativeDocumentBusinessUnits",
                column: "BusinessUnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthoratativeDocumentBusinessUnits");
        }
    }
}

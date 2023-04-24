using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableBusinessProcessAuthoratativeDocuments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthoratativeDocuments",
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
                    AuthorityDocumentId = table.Column<string>(nullable: true),
                    AuthorityDocumentOrigin = table.Column<string>(nullable: true),
                    AuthoratativeDocumentTitle = table.Column<string>(nullable: true),
                    MandateTypeId = table.Column<int>(nullable: true),
                    TypeId = table.Column<int>(nullable: true),
                    Keywords = table.Column<string>(nullable: true),
                    AuthoratativeDocumentName = table.Column<string>(nullable: true),
                    DocumentURL = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    EffectiveDate = table.Column<DateTime>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    ImportantNotice = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthoratativeDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthoratativeDocuments_AbpDynamicParameterValues_MandateTypeId",
                        column: x => x.MandateTypeId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AuthoratativeDocuments_AbpDynamicParameterValues_TypeId",
                        column: x => x.TypeId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessProcessAuthoratativeDocuments",
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
                    BusinessProcessId = table.Column<long>(nullable: true),
                    AuthoratativeDocumentId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessProcessAuthoratativeDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessProcessAuthoratativeDocuments_AuthoratativeDocuments_AuthoratativeDocumentId",
                        column: x => x.AuthoratativeDocumentId,
                        principalTable: "AuthoratativeDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessProcessAuthoratativeDocuments_BusinessProcess_BusinessProcessId",
                        column: x => x.BusinessProcessId,
                        principalTable: "BusinessProcess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthoratativeDocuments_MandateTypeId",
                table: "AuthoratativeDocuments",
                column: "MandateTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthoratativeDocuments_TypeId",
                table: "AuthoratativeDocuments",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProcessAuthoratativeDocuments_AuthoratativeDocumentId",
                table: "BusinessProcessAuthoratativeDocuments",
                column: "AuthoratativeDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProcessAuthoratativeDocuments_BusinessProcessId",
                table: "BusinessProcessAuthoratativeDocuments",
                column: "BusinessProcessId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessProcessAuthoratativeDocuments");

            migrationBuilder.DropTable(
                name: "AuthoratativeDocuments");
        }
    }
}

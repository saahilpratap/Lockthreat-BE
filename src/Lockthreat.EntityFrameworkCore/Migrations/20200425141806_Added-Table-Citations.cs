using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableCitations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Citations",
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
                    AuthoratativeDocumentId = table.Column<long>(nullable: true),
                    ParentCitationId = table.Column<int>(nullable: true),
                    CitationTypeId = table.Column<int>(nullable: true),
                    CitationId = table.Column<string>(nullable: true),
                    ControlRequirements = table.Column<string>(nullable: true),
                    CitationOriginId = table.Column<string>(nullable: true),
                    FrameworkObjectivesId = table.Column<int>(nullable: true),
                    CitationTitle = table.Column<string>(nullable: true),
                    CitationClassId = table.Column<int>(nullable: true),
                    CustomApplicability = table.Column<string>(nullable: true),
                    UCFCId = table.Column<string>(nullable: true),
                    CITLV = table.Column<int>(nullable: true),
                    ControlObjective = table.Column<string>(nullable: true),
                    IconDocument = table.Column<string>(nullable: true),
                    RelatedContentImage = table.Column<string>(nullable: true),
                    CitationDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Citations_AuthoratativeDocuments_AuthoratativeDocumentId",
                        column: x => x.AuthoratativeDocumentId,
                        principalTable: "AuthoratativeDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Citations_AbpDynamicParameterValues_CitationClassId",
                        column: x => x.CitationClassId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Citations_AbpDynamicParameterValues_CitationTypeId",
                        column: x => x.CitationTypeId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Citations_AbpDynamicParameterValues_FrameworkObjectivesId",
                        column: x => x.FrameworkObjectivesId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citations_AuthoratativeDocumentId",
                table: "Citations",
                column: "AuthoratativeDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Citations_CitationClassId",
                table: "Citations",
                column: "CitationClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Citations_CitationTypeId",
                table: "Citations",
                column: "CitationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Citations_FrameworkObjectivesId",
                table: "Citations",
                column: "FrameworkObjectivesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Citations");
        }
    }
}

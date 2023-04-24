using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableAuthoratativeDocumentProjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthoratativeDocumentProjects",
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
                    AuthoratativeDocumentId = table.Column<long>(nullable: true),
                    ProjectId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthoratativeDocumentProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthoratativeDocumentProjects_AuthoratativeDocuments_AuthoratativeDocumentId",
                        column: x => x.AuthoratativeDocumentId,
                        principalTable: "AuthoratativeDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AuthoratativeDocumentProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthoratativeDocumentProjects_AuthoratativeDocumentId",
                table: "AuthoratativeDocumentProjects",
                column: "AuthoratativeDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthoratativeDocumentProjects_ProjectId",
                table: "AuthoratativeDocumentProjects",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthoratativeDocumentProjects");
        }
    }
}

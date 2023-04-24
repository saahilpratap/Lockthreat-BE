using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableProjectTeamMemberExternals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectTeamMemberExternals",
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
                    ProjectId = table.Column<long>(nullable: true),
                    TeamMembersExternalId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTeamMemberExternals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectTeamMemberExternals_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectTeamMemberExternals_Employees_TeamMembersExternalId",
                        column: x => x.TeamMembersExternalId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTeamMemberExternals_ProjectId",
                table: "ProjectTeamMemberExternals",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTeamMemberExternals_TeamMembersExternalId",
                table: "ProjectTeamMemberExternals",
                column: "TeamMembersExternalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectTeamMemberExternals");
        }
    }
}

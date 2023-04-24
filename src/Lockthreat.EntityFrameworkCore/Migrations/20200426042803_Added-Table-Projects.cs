using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableProjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
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
                    ProjectId = table.Column<string>(nullable: true),
                    ProjectName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    IndustryId = table.Column<int>(nullable: true),
                    ProjectLogo = table.Column<string>(nullable: true),
                    LockThreatOrganizationId = table.Column<long>(nullable: true),
                    ParentProgramId = table.Column<long>(nullable: true),
                    ProjectScope = table.Column<string>(nullable: true),
                    ProjectSponsorId = table.Column<long>(nullable: true),
                    ProjectDirectorId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_AbpDynamicParameterValues_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_LockThreatOrganizations_LockThreatOrganizationId",
                        column: x => x.LockThreatOrganizationId,
                        principalTable: "LockThreatOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_GrcPrograms_ParentProgramId",
                        column: x => x.ParentProgramId,
                        principalTable: "GrcPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_Employees_ProjectDirectorId",
                        column: x => x.ProjectDirectorId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_Employees_ProjectSponsorId",
                        column: x => x.ProjectSponsorId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_IndustryId",
                table: "Projects",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_LockThreatOrganizationId",
                table: "Projects",
                column: "LockThreatOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ParentProgramId",
                table: "Projects",
                column: "ParentProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectDirectorId",
                table: "Projects",
                column: "ProjectDirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectSponsorId",
                table: "Projects",
                column: "ProjectSponsorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}

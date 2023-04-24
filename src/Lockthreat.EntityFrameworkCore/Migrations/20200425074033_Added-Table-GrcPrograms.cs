using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableGrcPrograms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GrcPrograms",
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
                    ProgramId = table.Column<string>(nullable: true),
                    ProgramTitle = table.Column<string>(nullable: true),
                    ProgramTeamEmail = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ProgramLogo = table.Column<string>(nullable: true),
                    LockThreatOrganizationId = table.Column<long>(nullable: true),
                    ProgramSponsorId = table.Column<long>(nullable: true),
                    ProgramDirectorId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrcPrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrcPrograms_LockThreatOrganizations_LockThreatOrganizationId",
                        column: x => x.LockThreatOrganizationId,
                        principalTable: "LockThreatOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GrcPrograms_Employees_ProgramDirectorId",
                        column: x => x.ProgramDirectorId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GrcPrograms_Employees_ProgramSponsorId",
                        column: x => x.ProgramSponsorId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GrcPrograms_LockThreatOrganizationId",
                table: "GrcPrograms",
                column: "LockThreatOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_GrcPrograms_ProgramDirectorId",
                table: "GrcPrograms",
                column: "ProgramDirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_GrcPrograms_ProgramSponsorId",
                table: "GrcPrograms",
                column: "ProgramSponsorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrcPrograms");
        }
    }
}

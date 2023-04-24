using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableInternalControlSystemApplications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InternalControlSystemApplications",
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
                    InternalControlId = table.Column<long>(nullable: true),
                    SystemApplicationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalControlSystemApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InternalControlSystemApplications_InternalControls_InternalControlId",
                        column: x => x.InternalControlId,
                        principalTable: "InternalControls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InternalControlSystemApplications_SystemApplications_SystemApplicationId",
                        column: x => x.SystemApplicationId,
                        principalTable: "SystemApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InternalControlSystemApplications_InternalControlId",
                table: "InternalControlSystemApplications",
                column: "InternalControlId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalControlSystemApplications_SystemApplicationId",
                table: "InternalControlSystemApplications",
                column: "SystemApplicationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InternalControlSystemApplications");
        }
    }
}

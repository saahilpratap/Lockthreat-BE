using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTabelSysteamApplicationBusinessProcess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SysteamApplicationBusinessProcess",
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
                    SystemApplicationId = table.Column<long>(nullable: true),
                    BusinessProcessId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysteamApplicationBusinessProcess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SysteamApplicationBusinessProcess_BusinessProcess_BusinessProcessId",
                        column: x => x.BusinessProcessId,
                        principalTable: "BusinessProcess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SysteamApplicationBusinessProcess_SystemApplications_SystemApplicationId",
                        column: x => x.SystemApplicationId,
                        principalTable: "SystemApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SysteamApplicationBusinessProcess_BusinessProcessId",
                table: "SysteamApplicationBusinessProcess",
                column: "BusinessProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_SysteamApplicationBusinessProcess_SystemApplicationId",
                table: "SysteamApplicationBusinessProcess",
                column: "SystemApplicationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SysteamApplicationBusinessProcess");
        }

    }

}

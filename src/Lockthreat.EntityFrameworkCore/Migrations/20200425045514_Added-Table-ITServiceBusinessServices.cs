﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableITServiceBusinessServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ITServiceBusinessServices",
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
                    ITServiceId = table.Column<long>(nullable: true),
                    BusinessServiceId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITServiceBusinessServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ITServiceBusinessServices_BusinessServices_BusinessServiceId",
                        column: x => x.BusinessServiceId,
                        principalTable: "BusinessServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ITServiceBusinessServices_ITServices_ITServiceId",
                        column: x => x.ITServiceId,
                        principalTable: "ITServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ITServiceBusinessServices_BusinessServiceId",
                table: "ITServiceBusinessServices",
                column: "BusinessServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ITServiceBusinessServices_ITServiceId",
                table: "ITServiceBusinessServices",
                column: "ITServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ITServiceBusinessServices");
        }
    }
}

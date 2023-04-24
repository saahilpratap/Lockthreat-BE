﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableBIAInternalControls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BIAInternalControls",
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
                    BusinessImpactAnalysisId = table.Column<long>(nullable: true),
                    InternalControlId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BIAInternalControls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BIAInternalControls_BusinessImpactAnalysises_BusinessImpactAnalysisId",
                        column: x => x.BusinessImpactAnalysisId,
                        principalTable: "BusinessImpactAnalysises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BIAInternalControls_InternalControls_InternalControlId",
                        column: x => x.InternalControlId,
                        principalTable: "InternalControls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BIAInternalControls_BusinessImpactAnalysisId",
                table: "BIAInternalControls",
                column: "BusinessImpactAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_BIAInternalControls_InternalControlId",
                table: "BIAInternalControls",
                column: "InternalControlId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BIAInternalControls");
        }
    }
}

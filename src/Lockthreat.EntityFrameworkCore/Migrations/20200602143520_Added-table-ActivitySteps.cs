﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedtableActivitySteps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivitySteps",
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
                    ActivityId = table.Column<long>(nullable: true),
                    ActivityCriteria = table.Column<string>(nullable: true),
                    ActivityActors = table.Column<int>(nullable: false),
                    IsActivityMand = table.Column<bool>(nullable: false),
                    ActivityType = table.Column<bool>(nullable: false),
                    ActivityDuration = table.Column<int>(nullable: false),
                    ActivityDurationType = table.Column<int>(nullable: false),
                    ActivityAutoCon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivitySteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivitySteps_Activitys_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activitys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivitySteps_ActivityId",
                table: "ActivitySteps",
                column: "ActivityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivitySteps");
        }
    }
}

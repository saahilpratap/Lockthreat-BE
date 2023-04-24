using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableMeetingIssueIdentifieds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeetingIssueIdentifieds",
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
                    IssueManagementId = table.Column<long>(nullable: true),
                    MeetingId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingIssueIdentifieds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeetingIssueIdentifieds_IssueManagements_IssueManagementId",
                        column: x => x.IssueManagementId,
                        principalTable: "IssueManagements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeetingIssueIdentifieds_Meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeetingIssueIdentifieds_IssueManagementId",
                table: "MeetingIssueIdentifieds",
                column: "IssueManagementId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingIssueIdentifieds_MeetingId",
                table: "MeetingIssueIdentifieds",
                column: "MeetingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeetingIssueIdentifieds");
        }
    }
}

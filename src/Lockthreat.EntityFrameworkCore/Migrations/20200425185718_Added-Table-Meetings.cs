using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableMeetings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meetings",
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
                    MeetingId = table.Column<string>(nullable: true),
                    MeetingTitle = table.Column<string>(nullable: true),
                    MeetingDescription = table.Column<string>(nullable: true),
                    MeetingStartDate = table.Column<DateTime>(nullable: true),
                    MeetingEndDate = table.Column<DateTime>(nullable: true),
                    MeetingVenue = table.Column<string>(nullable: true),
                    MeetingLocation = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    MeetingAgenda = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<long>(nullable: true),
                    MinutesofMeeting = table.Column<string>(nullable: true),
                    MinutesofMeetingAttachedment = table.Column<string>(nullable: true),
                    MeetingConclusion = table.Column<string>(nullable: true),
                    OrganizerId = table.Column<long>(nullable: true),
                    MeetingTypeId = table.Column<int>(nullable: true),
                    MeetingClassificationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meetings_AbpDynamicParameterValues_CountryId",
                        column: x => x.CountryId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meetings_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meetings_AbpDynamicParameterValues_MeetingClassificationId",
                        column: x => x.MeetingClassificationId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meetings_AbpDynamicParameterValues_MeetingTypeId",
                        column: x => x.MeetingTypeId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meetings_Employees_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_CountryId",
                table: "Meetings",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_EmployeeId",
                table: "Meetings",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_MeetingClassificationId",
                table: "Meetings",
                column: "MeetingClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_MeetingTypeId",
                table: "Meetings",
                column: "MeetingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_OrganizerId",
                table: "Meetings",
                column: "OrganizerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meetings");
        }
    }
}

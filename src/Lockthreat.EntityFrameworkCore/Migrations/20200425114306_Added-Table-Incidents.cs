using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedTableIncidents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Incidents",
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
                    IncidentId = table.Column<string>(nullable: true),
                    TechnologyId = table.Column<string>(nullable: true),
                    IncidentTitle = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IncidentCategoryId = table.Column<int>(nullable: true),
                    IncidentTypesId = table.Column<int>(nullable: true),
                    IncidentPriorityId = table.Column<int>(nullable: true),
                    IncidentSeverityId = table.Column<int>(nullable: true),
                    OccuredDate = table.Column<DateTime>(nullable: true),
                    AdversaryId = table.Column<int>(nullable: true),
                    ReportedDate = table.Column<DateTime>(nullable: true),
                    ReporterFirstName = table.Column<string>(nullable: true),
                    ReporterLastName = table.Column<string>(nullable: true),
                    ReportedById = table.Column<long>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DetectionDate = table.Column<DateTime>(nullable: true),
                    NotifierFirstName = table.Column<string>(nullable: true),
                    NotifierLastName = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<long>(nullable: true),
                    VoilationDetails = table.Column<string>(nullable: true),
                    RepeatIncident = table.Column<bool>(nullable: false),
                    EffectId = table.Column<int>(nullable: true),
                    CriticalityId = table.Column<int>(nullable: true),
                    Identification = table.Column<string>(nullable: true),
                    Correction = table.Column<string>(nullable: true),
                    Eradication = table.Column<string>(nullable: true),
                    RecoveryMeasures = table.Column<string>(nullable: true),
                    IncidentImpactId = table.Column<int>(nullable: true),
                    FollowUpAction = table.Column<string>(nullable: true),
                    IncidentClosedById = table.Column<long>(nullable: true),
                    FollowUpCompletedById = table.Column<long>(nullable: true),
                    IncidentStatusId = table.Column<int>(nullable: true),
                    DetectedbyInternalControlsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incidents_AbpDynamicParameterValues_AdversaryId",
                        column: x => x.AdversaryId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incidents_AbpDynamicParameterValues_CriticalityId",
                        column: x => x.CriticalityId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incidents_AbpDynamicParameterValues_DetectedbyInternalControlsId",
                        column: x => x.DetectedbyInternalControlsId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incidents_AbpDynamicParameterValues_EffectId",
                        column: x => x.EffectId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incidents_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incidents_Employees_FollowUpCompletedById",
                        column: x => x.FollowUpCompletedById,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incidents_AbpDynamicParameterValues_IncidentCategoryId",
                        column: x => x.IncidentCategoryId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incidents_Employees_IncidentClosedById",
                        column: x => x.IncidentClosedById,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incidents_AbpDynamicParameterValues_IncidentImpactId",
                        column: x => x.IncidentImpactId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incidents_AbpDynamicParameterValues_IncidentPriorityId",
                        column: x => x.IncidentPriorityId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incidents_AbpDynamicParameterValues_IncidentSeverityId",
                        column: x => x.IncidentSeverityId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incidents_AbpDynamicParameterValues_IncidentStatusId",
                        column: x => x.IncidentStatusId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incidents_AbpDynamicParameterValues_IncidentTypesId",
                        column: x => x.IncidentTypesId,
                        principalTable: "AbpDynamicParameterValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incidents_Employees_ReportedById",
                        column: x => x.ReportedById,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_AdversaryId",
                table: "Incidents",
                column: "AdversaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_CriticalityId",
                table: "Incidents",
                column: "CriticalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_DetectedbyInternalControlsId",
                table: "Incidents",
                column: "DetectedbyInternalControlsId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_EffectId",
                table: "Incidents",
                column: "EffectId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_EmployeeId",
                table: "Incidents",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_FollowUpCompletedById",
                table: "Incidents",
                column: "FollowUpCompletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_IncidentCategoryId",
                table: "Incidents",
                column: "IncidentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_IncidentClosedById",
                table: "Incidents",
                column: "IncidentClosedById");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_IncidentImpactId",
                table: "Incidents",
                column: "IncidentImpactId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_IncidentPriorityId",
                table: "Incidents",
                column: "IncidentPriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_IncidentSeverityId",
                table: "Incidents",
                column: "IncidentSeverityId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_IncidentStatusId",
                table: "Incidents",
                column: "IncidentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_IncidentTypesId",
                table: "Incidents",
                column: "IncidentTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_ReportedById",
                table: "Incidents",
                column: "ReportedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incidents");
        }
    }
}

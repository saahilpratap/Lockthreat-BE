using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lockthreat.Migrations
{
    public partial class AddedtablePageFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PageFields",
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
                    PageId = table.Column<long>(nullable: true),
                    PageFieldName = table.Column<string>(nullable: true),
                    PageFieldDescription = table.Column<string>(nullable: true),
                    PageFieldType = table.Column<bool>(nullable: false),
                    FieldIsMandatory = table.Column<bool>(nullable: false),
                    FieldIsPII = table.Column<bool>(nullable: false),
                    FieldIsEnc = table.Column<bool>(nullable: false),
                    FieldIsVis = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PageFields_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PageFields_PageId",
                table: "PageFields",
                column: "PageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PageFields");
        }
    }
}

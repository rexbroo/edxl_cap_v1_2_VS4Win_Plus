using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace edxl_cap_v1_2.Migrations
{
    public partial class EdxlCapMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreaViewModel",
                columns: table => new
                {
                    AreaIndex = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    SelectedAlertIndex = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaViewModel", x => x.AreaIndex);
                });

            migrationBuilder.CreateTable(
                name: "EdxlCapMessage",
                columns: table => new
                {
                    AlertIndex = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Addresses = table.Column<string>(nullable: true),
                    Alert_Identifier = table.Column<string>(nullable: true),
                    Altitude = table.Column<string>(nullable: true),
                    AreaDesc = table.Column<string>(nullable: true),
                    AreaIndex = table.Column<int>(nullable: false),
                    Audience = table.Column<string>(nullable: true),
                    Ceiling = table.Column<string>(nullable: true),
                    Circle = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    DerefUri = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Digest = table.Column<string>(nullable: true),
                    Effective = table.Column<DateTime>(nullable: false),
                    Event = table.Column<string>(nullable: true),
                    EventCode = table.Column<string>(nullable: true),
                    Expires = table.Column<DateTime>(nullable: false),
                    Geocode = table.Column<string>(nullable: true),
                    Headline = table.Column<string>(nullable: true),
                    Incidents = table.Column<string>(nullable: true),
                    InfoIndex = table.Column<int>(nullable: false),
                    Instruction = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    MimeType = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    Onset = table.Column<DateTime>(nullable: false),
                    Parameter = table.Column<string>(nullable: true),
                    Polygon = table.Column<string>(nullable: true),
                    References = table.Column<string>(nullable: true),
                    ResourceDesc = table.Column<string>(nullable: true),
                    ResourceIndex = table.Column<int>(nullable: false),
                    Restriction = table.Column<string>(nullable: true),
                    SelectedAlertIndex = table.Column<int>(nullable: true),
                    Sender = table.Column<string>(nullable: true),
                    SenderName = table.Column<string>(nullable: true),
                    Sent = table.Column<DateTime>(nullable: false),
                    Size = table.Column<int>(nullable: false),
                    Source = table.Column<string>(nullable: true),
                    Uri = table.Column<string>(nullable: true),
                    Web = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EdxlCapMessage", x => x.AlertIndex);
                });

            migrationBuilder.CreateTable(
                name: "InfoViewModel",
                columns: table => new
                {
                    InfoIndex = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    SelectedAlertIndex = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoViewModel", x => x.InfoIndex);
                });

            migrationBuilder.CreateTable(
                name: "ResourceViewModel",
                columns: table => new
                {
                    AlertIndex = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    SelectedAlertIndex = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceViewModel", x => x.AlertIndex);
                });

            migrationBuilder.CreateTable(
                name: "AreaVm",
                columns: table => new
                {
                    AreaIndex = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Alert_Identifier = table.Column<string>(maxLength: 150, nullable: true),
                    AreaViewModelAreaIndex = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaVm", x => x.AreaIndex);
                    table.ForeignKey(
                        name: "FK_AreaVm_AreaViewModel_AreaViewModelAreaIndex",
                        column: x => x.AreaViewModelAreaIndex,
                        principalTable: "AreaViewModel",
                        principalColumn: "AreaIndex",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InfoVm",
                columns: table => new
                {
                    InfoIndex = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Alert_Identifier = table.Column<string>(maxLength: 150, nullable: true),
                    InfoViewModelInfoIndex = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoVm", x => x.InfoIndex);
                    table.ForeignKey(
                        name: "FK_InfoVm_InfoViewModel_InfoViewModelInfoIndex",
                        column: x => x.InfoViewModelInfoIndex,
                        principalTable: "InfoViewModel",
                        principalColumn: "InfoIndex",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResourceVm",
                columns: table => new
                {
                    ResourceIndex = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Alert_Identifier = table.Column<string>(maxLength: 150, nullable: true),
                    ResourceViewModelAlertIndex = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceVm", x => x.ResourceIndex);
                    table.ForeignKey(
                        name: "FK_ResourceVm_ResourceViewModel_ResourceViewModelAlertIndex",
                        column: x => x.ResourceViewModelAlertIndex,
                        principalTable: "ResourceViewModel",
                        principalColumn: "AlertIndex",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AreaVm_AreaViewModelAreaIndex",
                table: "AreaVm",
                column: "AreaViewModelAreaIndex");

            migrationBuilder.CreateIndex(
                name: "IX_InfoVm_InfoViewModelInfoIndex",
                table: "InfoVm",
                column: "InfoViewModelInfoIndex");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceVm_ResourceViewModelAlertIndex",
                table: "ResourceVm",
                column: "ResourceViewModelAlertIndex");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlertVm_EdxlCapMessageViewModel_EdxlCapMessageViewModelAlertIndex",
                table: "AlertVm");

            migrationBuilder.DropTable(
                name: "AreaVm");

            migrationBuilder.DropTable(
                name: "EdxlCapMessage");

            migrationBuilder.DropTable(
                name: "InfoVm");

            migrationBuilder.DropTable(
                name: "ResourceVm");

            migrationBuilder.DropTable(
                name: "AreaViewModel");

            migrationBuilder.DropTable(
                name: "InfoViewModel");

            migrationBuilder.DropTable(
                name: "ResourceViewModel");

            migrationBuilder.DropIndex(
                name: "IX_AlertVm_EdxlCapMessageViewModelAlertIndex",
                table: "AlertVm");

            migrationBuilder.DropColumn(
                name: "SelectedAlertIndex",
                table: "EdxlCapMessageViewModel");

            migrationBuilder.DropColumn(
                name: "EdxlCapMessageViewModelAlertIndex",
                table: "AlertVm");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OSDU.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddOrganizationUnitAssociations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FACILITY_ORG_UNIT",
                columns: table => new
                {
                    FACILITY_ORG_UNIT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FACILITY_ID = table.Column<int>(type: "int", nullable: false),
                    ORG_UNIT_ID = table.Column<int>(type: "int", nullable: false),
                    EFFECTIVE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EXPIRY_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FACILITY_ORG_UNIT", x => x.FACILITY_ORG_UNIT_ID);
                    table.CheckConstraint("CK_FACILITY_ORG_UNIT_DateRange", "[EXPIRY_DATE] IS NULL OR [EFFECTIVE_DATE] IS NULL OR [EXPIRY_DATE] >= [EFFECTIVE_DATE]");
                    table.ForeignKey(
                        name: "FK_FACILITY_ORG_UNIT_FACILITY_FACILITY_ID",
                        column: x => x.FACILITY_ID,
                        principalTable: "FACILITY",
                        principalColumn: "FACILITY_ID");
                    table.ForeignKey(
                        name: "FK_FACILITY_ORG_UNIT_ORG_UNIT_ORG_UNIT_ID",
                        column: x => x.ORG_UNIT_ID,
                        principalTable: "ORG_UNIT",
                        principalColumn: "ORG_UNIT_ID");
                });

            migrationBuilder.CreateTable(
                name: "FIELD_ORG_UNIT",
                columns: table => new
                {
                    FIELD_ORG_UNIT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIELD_ID = table.Column<int>(type: "int", nullable: false),
                    ORG_UNIT_ID = table.Column<int>(type: "int", nullable: false),
                    EFFECTIVE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EXPIRY_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FIELD_ORG_UNIT", x => x.FIELD_ORG_UNIT_ID);
                    table.CheckConstraint("CK_FIELD_ORG_UNIT_DateRange", "[EXPIRY_DATE] IS NULL OR [EFFECTIVE_DATE] IS NULL OR [EXPIRY_DATE] >= [EFFECTIVE_DATE]");
                    table.ForeignKey(
                        name: "FK_FIELD_ORG_UNIT_FIELD_FIELD_ID",
                        column: x => x.FIELD_ID,
                        principalTable: "FIELD",
                        principalColumn: "FIELD_ID");
                    table.ForeignKey(
                        name: "FK_FIELD_ORG_UNIT_ORG_UNIT_ORG_UNIT_ID",
                        column: x => x.ORG_UNIT_ID,
                        principalTable: "ORG_UNIT",
                        principalColumn: "ORG_UNIT_ID");
                });

            migrationBuilder.CreateTable(
                name: "WELL_ORG_UNIT",
                columns: table => new
                {
                    WELL_ORG_UNIT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WELL_ID = table.Column<int>(type: "int", nullable: false),
                    ORG_UNIT_ID = table.Column<int>(type: "int", nullable: false),
                    EFFECTIVE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EXPIRY_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WELL_ORG_UNIT", x => x.WELL_ORG_UNIT_ID);
                    table.CheckConstraint("CK_WELL_ORG_UNIT_DateRange", "[EXPIRY_DATE] IS NULL OR [EFFECTIVE_DATE] IS NULL OR [EXPIRY_DATE] >= [EFFECTIVE_DATE]");
                    table.ForeignKey(
                        name: "FK_WELL_ORG_UNIT_ORG_UNIT_ORG_UNIT_ID",
                        column: x => x.ORG_UNIT_ID,
                        principalTable: "ORG_UNIT",
                        principalColumn: "ORG_UNIT_ID");
                    table.ForeignKey(
                        name: "FK_WELL_ORG_UNIT_WELL_WELL_ID",
                        column: x => x.WELL_ID,
                        principalTable: "WELL",
                        principalColumn: "WELL_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FACILITY_ORG_UNIT_FACILITY_ID",
                table: "FACILITY_ORG_UNIT",
                column: "FACILITY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FACILITY_ORG_UNIT_ORG_UNIT_ID",
                table: "FACILITY_ORG_UNIT",
                column: "ORG_UNIT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FIELD_ORG_UNIT_FIELD_ID",
                table: "FIELD_ORG_UNIT",
                column: "FIELD_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FIELD_ORG_UNIT_ORG_UNIT_ID",
                table: "FIELD_ORG_UNIT",
                column: "ORG_UNIT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_ORG_UNIT_ORG_UNIT_ID",
                table: "WELL_ORG_UNIT",
                column: "ORG_UNIT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_ORG_UNIT_WELL_ID",
                table: "WELL_ORG_UNIT",
                column: "WELL_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FACILITY_ORG_UNIT");

            migrationBuilder.DropTable(
                name: "FIELD_ORG_UNIT");

            migrationBuilder.DropTable(
                name: "WELL_ORG_UNIT");
        }
    }
}

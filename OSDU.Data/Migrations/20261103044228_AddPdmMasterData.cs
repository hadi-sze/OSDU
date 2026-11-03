using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OSDU.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPdmMasterData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CARTOREFERENCESYSTEM",
                columns: table => new
                {
                    CRS_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CRS_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CRS_TYPE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GEODETIC_SOURCE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PROJECTION_TYPE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARTOREFERENCESYSTEM", x => x.CRS_ID);
                });

            migrationBuilder.CreateTable(
                name: "FORMATION",
                columns: table => new
                {
                    FORMATION_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FORMATION_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TEST_BIT = table.Column<bool>(type: "bit", nullable: true),
                    ATTR_SMALLINT = table.Column<short>(type: "smallint", nullable: true),
                    ATTR_INT = table.Column<int>(type: "int", nullable: true),
                    ATTR_BIGINT = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FORMATION", x => x.FORMATION_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_COMPLETION_TYPE",
                columns: table => new
                {
                    R_COMPLETION_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COMPLETION_TYPE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_COMPLETION_TYPE", x => x.R_COMPLETION_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_COUPLING_TYPE",
                columns: table => new
                {
                    R_COUPLING_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COUPLING_TYPE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_COUPLING_TYPE", x => x.R_COUPLING_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_DATA_ACCESS_CATEGORY",
                columns: table => new
                {
                    R_DATA_ACCESS_CATEGORY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DATA_ACCESS_CATEGORY = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_DATA_ACCESS_CATEGORY", x => x.R_DATA_ACCESS_CATEGORY_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_EQUIPMENT_CATALOGUE",
                columns: table => new
                {
                    R_EQUIPMENT_CATALOGUE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EQUIPMENT_CATALOGUE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_EQUIPMENT_CATALOGUE", x => x.R_EQUIPMENT_CATALOGUE_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_FACILITY_TYPE",
                columns: table => new
                {
                    R_FACILITY_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FACILITY_TYPE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_FACILITY_TYPE", x => x.R_FACILITY_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_FIELD_TYPE",
                columns: table => new
                {
                    R_FIELD_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DISPLAY_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ABBREVIATION = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    COLOR_CODE = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    EFFECTIVE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EXPIRY_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SOURCE_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FIELD_TYPE_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_FIELD_TYPE", x => x.R_FIELD_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_ORG_UNIT_CATEGORY",
                columns: table => new
                {
                    R_ORG_UNIT_CATEGORY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ORG_UNIT_CATEGORY = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_ORG_UNIT_CATEGORY", x => x.R_ORG_UNIT_CATEGORY_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_ORG_UNIT_TYPE",
                columns: table => new
                {
                    R_ORG_UNIT_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ORG_UNIT_TYPE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_ORG_UNIT_TYPE", x => x.R_ORG_UNIT_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_PERFORATION_METHOD",
                columns: table => new
                {
                    R_PERFORATION_METHOD_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PERFORATION_METHOD = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_PERFORATION_METHOD", x => x.R_PERFORATION_METHOD_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_PERFORATION_TYPE",
                columns: table => new
                {
                    R_PERFORATION_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PERFORATION_TYPE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_PERFORATION_TYPE", x => x.R_PERFORATION_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_PLOT_SYMBOL",
                columns: table => new
                {
                    R_PLOT_SYMBOL_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COLOR_CODE = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    PLOT_SYMBOL = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PLOT_SYMBOL_TYPE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_PLOT_SYMBOL", x => x.R_PLOT_SYMBOL_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_POOL_STATUS",
                columns: table => new
                {
                    R_POOL_STATUS_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    POOL_STATUS = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_POOL_STATUS", x => x.R_POOL_STATUS_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_POOL_TYPE",
                columns: table => new
                {
                    R_POOL_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    POOL_TYPE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_POOL_TYPE", x => x.R_POOL_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_REPORTING_ENTITY_KIND",
                columns: table => new
                {
                    R_REPORTING_ENTITY_KIND_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REPORTING_ENTITY_KIND = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_REPORTING_ENTITY_KIND", x => x.R_REPORTING_ENTITY_KIND_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_SOURCE",
                columns: table => new
                {
                    R_SOURCE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DISPLAY_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ABBREVIATION = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    COLOR_CODE = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    EFFECTIVE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EXPIRY_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SOURCE_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_SOURCE", x => x.R_SOURCE_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_TIMEZONE",
                columns: table => new
                {
                    R_TIMEZONE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TIMEZONE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_TIMEZONE", x => x.R_TIMEZONE_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_TUBULAR_TYPE",
                columns: table => new
                {
                    R_TUBULAR_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TUBULAR_TYPE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_TUBULAR_TYPE", x => x.R_TUBULAR_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_WELL_CLASS",
                columns: table => new
                {
                    R_WELL_CLASS_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WELL_CLASS = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_WELL_CLASS", x => x.R_WELL_CLASS_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_WELL_DATUM_TYPE",
                columns: table => new
                {
                    WELL_DATUM_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WELL_DATUM_TYPE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ABBREVIATION = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LONG_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_WELL_DATUM_TYPE", x => x.WELL_DATUM_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_EQUIPMENT_TYPE",
                columns: table => new
                {
                    R_EQUIPMENT_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EQUIPMENT_CATALOGUE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    EQUIPMENT_TYPE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    R_EQUIPMENT_CATALOGUE_ID = table.Column<int>(type: "int", nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_EQUIPMENT_TYPE", x => x.R_EQUIPMENT_TYPE_ID);
                    table.ForeignKey(
                        name: "FK_R_EQUIPMENT_TYPE_R_EQUIPMENT_CATALOGUE_R_EQUIPMENT_CATALOGUE_ID",
                        column: x => x.R_EQUIPMENT_CATALOGUE_ID,
                        principalTable: "R_EQUIPMENT_CATALOGUE",
                        principalColumn: "R_EQUIPMENT_CATALOGUE_ID");
                });

            migrationBuilder.CreateTable(
                name: "FACILITY",
                columns: table => new
                {
                    FACILITY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FACILITY_NAME = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    FACILITY_TYPE_ID = table.Column<int>(type: "int", nullable: true),
                    FACILITY_TYPE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    CONSTRUCTED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ACTIVE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ABANDONED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OFFSHORE_IND = table.Column<bool>(type: "bit", nullable: false),
                    R_EQUIPMENT_CATALOGUE_ID = table.Column<int>(type: "int", nullable: true),
                    EQUIPMENT_CATALOGUE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    X_COORDINATE = table.Column<decimal>(type: "decimal(18,9)", precision: 18, scale: 9, nullable: true),
                    Y_COORDINATE = table.Column<decimal>(type: "decimal(18,9)", precision: 18, scale: 9, nullable: true),
                    CRS_ID = table.Column<int>(type: "int", nullable: true),
                    CRS_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CURRENT_OPERATOR = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    DEPTH = table.Column<decimal>(type: "decimal(18,9)", precision: 18, scale: 9, nullable: true),
                    ELEVATION = table.Column<decimal>(type: "decimal(18,9)", precision: 18, scale: 9, nullable: true),
                    FACILITY_DIAMETER = table.Column<decimal>(type: "decimal(18,9)", precision: 18, scale: 9, nullable: true),
                    FACILITY_FUNCTION = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    FACILITY_NO = table.Column<int>(type: "int", nullable: true),
                    FACILITY_SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    FACILITY_LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LAST_INJECTION_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LAST_PRODUCTION_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LAST_REPORTED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ON_INJECTION_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ON_PRODUCTION_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_VIRTUAL = table.Column<bool>(type: "bit", nullable: true),
                    UIDREF = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    R_DATA_ACCESS_CATEGORY_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FACILITY", x => x.FACILITY_ID);
                    table.ForeignKey(
                        name: "FK_FACILITY_CARTOREFERENCESYSTEM_CRS_ID",
                        column: x => x.CRS_ID,
                        principalTable: "CARTOREFERENCESYSTEM",
                        principalColumn: "CRS_ID");
                    table.ForeignKey(
                        name: "FK_FACILITY_R_DATA_ACCESS_CATEGORY_R_DATA_ACCESS_CATEGORY_ID",
                        column: x => x.R_DATA_ACCESS_CATEGORY_ID,
                        principalTable: "R_DATA_ACCESS_CATEGORY",
                        principalColumn: "R_DATA_ACCESS_CATEGORY_ID");
                    table.ForeignKey(
                        name: "FK_FACILITY_R_FACILITY_TYPE_FACILITY_TYPE_ID",
                        column: x => x.FACILITY_TYPE_ID,
                        principalTable: "R_FACILITY_TYPE",
                        principalColumn: "R_FACILITY_TYPE_ID");
                });

            migrationBuilder.CreateTable(
                name: "FIELD",
                columns: table => new
                {
                    FIELD_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIELD_NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FIELD_TYPE_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FIELD_ABBREVIATION = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    X_COORDINATE = table.Column<decimal>(type: "decimal(18,9)", precision: 18, scale: 9, nullable: true),
                    Y_COORDINATE = table.Column<decimal>(type: "decimal(18,9)", precision: 18, scale: 9, nullable: true),
                    CRS_ID = table.Column<int>(type: "int", nullable: true),
                    CRS_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SOURCE_NAME = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    R_FIELD_TYPE_ID = table.Column<int>(type: "int", nullable: true),
                    UIDREF = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    R_DATA_ACCESS_CATEGORY_ID = table.Column<int>(name: "R_DATA_ACCESS_ CATEGORY_ID", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FIELD", x => x.FIELD_ID);
                    table.ForeignKey(
                        name: "FK_FIELD_CARTOREFERENCESYSTEM_CRS_ID",
                        column: x => x.CRS_ID,
                        principalTable: "CARTOREFERENCESYSTEM",
                        principalColumn: "CRS_ID");
                    table.ForeignKey(
                        name: "FK_FIELD_R_DATA_ACCESS_CATEGORY_R_DATA_ACCESS_ CATEGORY_ID",
                        column: x => x.R_DATA_ACCESS_CATEGORY_ID,
                        principalTable: "R_DATA_ACCESS_CATEGORY",
                        principalColumn: "R_DATA_ACCESS_CATEGORY_ID");
                    table.ForeignKey(
                        name: "FK_FIELD_R_FIELD_TYPE_R_FIELD_TYPE_ID",
                        column: x => x.R_FIELD_TYPE_ID,
                        principalTable: "R_FIELD_TYPE",
                        principalColumn: "R_FIELD_TYPE_ID");
                });

            migrationBuilder.CreateTable(
                name: "ORG_UNIT",
                columns: table => new
                {
                    ORG_UNIT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ORG_UNIT_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    R_ORG_UNIT_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    R_ORG_UNIT_CATEGORY_ID = table.Column<int>(type: "int", nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ORG_UNIT_SHORT_NAME = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    ORG_UNIT_ABBERIVATION = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORG_UNIT", x => x.ORG_UNIT_ID);
                    table.ForeignKey(
                        name: "FK_ORG_UNIT_R_ORG_UNIT_CATEGORY_R_ORG_UNIT_CATEGORY_ID",
                        column: x => x.R_ORG_UNIT_CATEGORY_ID,
                        principalTable: "R_ORG_UNIT_CATEGORY",
                        principalColumn: "R_ORG_UNIT_CATEGORY_ID");
                    table.ForeignKey(
                        name: "FK_ORG_UNIT_R_ORG_UNIT_TYPE_R_ORG_UNIT_TYPE_ID",
                        column: x => x.R_ORG_UNIT_TYPE_ID,
                        principalTable: "R_ORG_UNIT_TYPE",
                        principalColumn: "R_ORG_UNIT_TYPE_ID");
                });

            migrationBuilder.CreateTable(
                name: "REPORTING_ENTITY",
                columns: table => new
                {
                    REPORTING_ENTITY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    R_REPORTING_ENTITY_KIND_ID = table.Column<int>(type: "int", nullable: false),
                    ASSOCIATED_OBJECT_ID = table.Column<int>(type: "int", nullable: false),
                    ASSOCIATED_OBJECT_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REPORTING_ENTITY", x => x.REPORTING_ENTITY_ID);
                    table.ForeignKey(
                        name: "FK_REPORTING_ENTITY_R_REPORTING_ENTITY_KIND_R_REPORTING_ENTITY_KIND_ID",
                        column: x => x.R_REPORTING_ENTITY_KIND_ID,
                        principalTable: "R_REPORTING_ENTITY_KIND",
                        principalColumn: "R_REPORTING_ENTITY_KIND_ID");
                });

            migrationBuilder.CreateTable(
                name: "R_WELL_STATUS_TYPE",
                columns: table => new
                {
                    R_WELL_STATUS_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WELL_STATUS_TYPE = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    R_SOURCE_ID = table.Column<int>(type: "int", nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_WELL_STATUS_TYPE", x => x.R_WELL_STATUS_TYPE_ID);
                    table.ForeignKey(
                        name: "FK_R_WELL_STATUS_TYPE_R_SOURCE_R_SOURCE_ID",
                        column: x => x.R_SOURCE_ID,
                        principalTable: "R_SOURCE",
                        principalColumn: "R_SOURCE_ID");
                });

            migrationBuilder.CreateTable(
                name: "R_EQUIPMENT_SUB_TYPE",
                columns: table => new
                {
                    R_EQUIPMENT_SUB_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EQUIPMENT_SUB_TYPE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    R_EQUIPMENT_TYPE_ID = table.Column<int>(type: "int", nullable: true),
                    EQUIPMENT_TYPE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    BARRIER_ELEMENT = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_EQUIPMENT_SUB_TYPE", x => x.R_EQUIPMENT_SUB_TYPE_ID);
                    table.ForeignKey(
                        name: "FK_R_EQUIPMENT_SUB_TYPE_R_EQUIPMENT_TYPE_R_EQUIPMENT_TYPE_ID",
                        column: x => x.R_EQUIPMENT_TYPE_ID,
                        principalTable: "R_EQUIPMENT_TYPE",
                        principalColumn: "R_EQUIPMENT_TYPE_ID");
                });

            migrationBuilder.CreateTable(
                name: "POOL",
                columns: table => new
                {
                    POOL_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    POOL_NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    DISCOVERY_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EFFECTIVE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EXPIRY_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FIELD_ID = table.Column<int>(type: "int", nullable: true),
                    FIELD_NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    POOL_CODE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    POOL_NAME_ABBREVIATION = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    R_POOL_STATUS_ID = table.Column<int>(type: "int", nullable: true),
                    POOL_STATUS = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    R_POOL_TYPE_ID = table.Column<int>(type: "int", nullable: true),
                    POOL_TYPE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    R_DATA_ACCESS_CATEGORY_ID = table.Column<int>(name: "R_DATA_ACCESS_ CATEGORY_ID", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POOL", x => x.POOL_ID);
                    table.ForeignKey(
                        name: "FK_POOL_FIELD_FIELD_ID",
                        column: x => x.FIELD_ID,
                        principalTable: "FIELD",
                        principalColumn: "FIELD_ID");
                    table.ForeignKey(
                        name: "FK_POOL_R_DATA_ACCESS_CATEGORY_R_DATA_ACCESS_ CATEGORY_ID",
                        column: x => x.R_DATA_ACCESS_CATEGORY_ID,
                        principalTable: "R_DATA_ACCESS_CATEGORY",
                        principalColumn: "R_DATA_ACCESS_CATEGORY_ID");
                    table.ForeignKey(
                        name: "FK_POOL_R_POOL_STATUS_R_POOL_STATUS_ID",
                        column: x => x.R_POOL_STATUS_ID,
                        principalTable: "R_POOL_STATUS",
                        principalColumn: "R_POOL_STATUS_ID");
                    table.ForeignKey(
                        name: "FK_POOL_R_POOL_TYPE_R_POOL_TYPE_ID",
                        column: x => x.R_POOL_TYPE_ID,
                        principalTable: "R_POOL_TYPE",
                        principalColumn: "R_POOL_TYPE_ID");
                });

            migrationBuilder.CreateTable(
                name: "FLOW_MODEL",
                columns: table => new
                {
                    FLOW_MODEL_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FLOW_MODEL_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    INSTALLATION_ID = table.Column<int>(type: "int", nullable: true),
                    EXPIRY_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EFFECTIVE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    COMMENT = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FLOW_MODEL", x => x.FLOW_MODEL_ID);
                    table.ForeignKey(
                        name: "FK_FLOW_MODEL_REPORTING_ENTITY_INSTALLATION_ID",
                        column: x => x.INSTALLATION_ID,
                        principalTable: "REPORTING_ENTITY",
                        principalColumn: "REPORTING_ENTITY_ID");
                });

            migrationBuilder.CreateTable(
                name: "R_WELL_STATUS",
                columns: table => new
                {
                    R_WELL_STATUS_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WELL_STATUS = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    R_WELL_STATUS_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    R_SOURCE_ID = table.Column<int>(type: "int", nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_WELL_STATUS", x => x.R_WELL_STATUS_ID);
                    table.ForeignKey(
                        name: "FK_R_WELL_STATUS_R_SOURCE_R_SOURCE_ID",
                        column: x => x.R_SOURCE_ID,
                        principalTable: "R_SOURCE",
                        principalColumn: "R_SOURCE_ID");
                    table.ForeignKey(
                        name: "FK_R_WELL_STATUS_R_WELL_STATUS_TYPE_R_WELL_STATUS_TYPE_ID",
                        column: x => x.R_WELL_STATUS_TYPE_ID,
                        principalTable: "R_WELL_STATUS_TYPE",
                        principalColumn: "R_WELL_STATUS_TYPE_ID");
                });

            migrationBuilder.CreateTable(
                name: "EQUIPMENT",
                columns: table => new
                {
                    EQUIPMENT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COMMISSION_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DECOMMISSION_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EQUIPMENT_NAME = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    EQUIPMENT_SUB_TYPE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    EQUIPMENT_TYPE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    R_EQUIPMENT_SUB_TYPE_ID = table.Column<int>(type: "int", nullable: true),
                    R_EQUIPMENT_TYPE_ID = table.Column<int>(type: "int", nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EQUIPMENT_ALIAS_NAME = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    SERIAL_NUM = table.Column<int>(type: "int", nullable: true),
                    MANUFACTURER_BA_ID = table.Column<int>(type: "int", nullable: true),
                    R_DATA_ACCESS_CATEGORY_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EQUIPMENT", x => x.EQUIPMENT_ID);
                    table.ForeignKey(
                        name: "FK_EQUIPMENT_ORG_UNIT_MANUFACTURER_BA_ID",
                        column: x => x.MANUFACTURER_BA_ID,
                        principalTable: "ORG_UNIT",
                        principalColumn: "ORG_UNIT_ID");
                    table.ForeignKey(
                        name: "FK_EQUIPMENT_R_DATA_ACCESS_CATEGORY_R_DATA_ACCESS_CATEGORY_ID",
                        column: x => x.R_DATA_ACCESS_CATEGORY_ID,
                        principalTable: "R_DATA_ACCESS_CATEGORY",
                        principalColumn: "R_DATA_ACCESS_CATEGORY_ID");
                    table.ForeignKey(
                        name: "FK_EQUIPMENT_R_EQUIPMENT_SUB_TYPE_R_EQUIPMENT_SUB_TYPE_ID",
                        column: x => x.R_EQUIPMENT_SUB_TYPE_ID,
                        principalTable: "R_EQUIPMENT_SUB_TYPE",
                        principalColumn: "R_EQUIPMENT_SUB_TYPE_ID");
                    table.ForeignKey(
                        name: "FK_EQUIPMENT_R_EQUIPMENT_TYPE_R_EQUIPMENT_TYPE_ID",
                        column: x => x.R_EQUIPMENT_TYPE_ID,
                        principalTable: "R_EQUIPMENT_TYPE",
                        principalColumn: "R_EQUIPMENT_TYPE_ID");
                });

            migrationBuilder.CreateTable(
                name: "ZONE",
                columns: table => new
                {
                    ZONE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZONE_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    POOL_ID = table.Column<int>(type: "int", nullable: true),
                    POOL_NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    R_DATA_ACCESS_CATEGORY_ID = table.Column<int>(name: "R_DATA_ACCESS_ CATEGORY_ID", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZONE", x => x.ZONE_ID);
                    table.ForeignKey(
                        name: "FK_ZONE_POOL_POOL_ID",
                        column: x => x.POOL_ID,
                        principalTable: "POOL",
                        principalColumn: "POOL_ID");
                    table.ForeignKey(
                        name: "FK_ZONE_R_DATA_ACCESS_CATEGORY_R_DATA_ACCESS_ CATEGORY_ID",
                        column: x => x.R_DATA_ACCESS_CATEGORY_ID,
                        principalTable: "R_DATA_ACCESS_CATEGORY",
                        principalColumn: "R_DATA_ACCESS_CATEGORY_ID");
                });

            migrationBuilder.CreateTable(
                name: "WELL",
                columns: table => new
                {
                    WELL_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UWI = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WELL_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WELL_ALIAS_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FIELD_ID = table.Column<int>(type: "int", nullable: true),
                    FIELD_NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OFFSHORE_IND = table.Column<bool>(type: "bit", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    WELL_OWNER = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SPUD_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SPUD_DATE_TZ = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    R_TIMEZONE_ID = table.Column<int>(type: "int", nullable: true),
                    COMPLETION_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PRODUCTION_START_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    X_COORDINATE = table.Column<decimal>(type: "decimal(18,9)", precision: 18, scale: 9, nullable: true),
                    Y_COORDINATE = table.Column<decimal>(type: "decimal(18,9)", precision: 18, scale: 9, nullable: true),
                    CRS_ID = table.Column<int>(type: "int", nullable: true),
                    CRS_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CURRENT_CLASS_ID = table.Column<int>(type: "int", nullable: true),
                    WELL_CLASS = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DEEPEST_DEPTH = table.Column<decimal>(type: "decimal(18,9)", precision: 18, scale: 9, nullable: true),
                    MAX_TVD = table.Column<decimal>(type: "decimal(18,9)", precision: 18, scale: 9, nullable: true),
                    DEPTH_DATUM_ID = table.Column<int>(type: "int", nullable: true),
                    DEPTH_DATUM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DEPTH_DATUM_ELEV = table.Column<decimal>(type: "decimal(18,9)", precision: 18, scale: 9, nullable: true),
                    GROUND_ELEV = table.Column<decimal>(type: "decimal(18,9)", precision: 18, scale: 9, nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BOTTOM_HOLE_X_LON = table.Column<decimal>(type: "decimal(18,9)", precision: 18, scale: 9, nullable: true),
                    BOTTOM_HOLE_Y_LAT = table.Column<decimal>(type: "decimal(18,9)", precision: 18, scale: 9, nullable: true),
                    ABANDONMENT_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EXPIRY_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FAULTED_IND = table.Column<bool>(type: "bit", nullable: true),
                    FINAL_DRILL_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LOG_TD = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: true),
                    NET_PAY = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: true),
                    OPERATOR = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    PLOT_NAME = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    PLUGBACK_DEPTH = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: true),
                    R_WELL_PROFILE_ID = table.Column<int>(type: "int", nullable: true),
                    WELL_PROFILE = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    WATER_ACOUSTIC_VEL = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: true),
                    WATER_DEPTH = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: true),
                    WATER_DEPTH_DATUM = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IS_VIRTUAL = table.Column<bool>(type: "bit", nullable: true),
                    R_PLOT_SYMBOL_ID = table.Column<int>(type: "int", nullable: true),
                    UIDREF = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    R_DATA_ACCESS_CATEGORY_ID = table.Column<int>(name: "R_DATA_ACCESS_ CATEGORY_ID", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WELL", x => x.WELL_ID);
                    table.ForeignKey(
                        name: "FK_WELL_CARTOREFERENCESYSTEM_CRS_ID",
                        column: x => x.CRS_ID,
                        principalTable: "CARTOREFERENCESYSTEM",
                        principalColumn: "CRS_ID");
                    table.ForeignKey(
                        name: "FK_WELL_FIELD_FIELD_ID",
                        column: x => x.FIELD_ID,
                        principalTable: "FIELD",
                        principalColumn: "FIELD_ID");
                    table.ForeignKey(
                        name: "FK_WELL_R_DATA_ACCESS_CATEGORY_R_DATA_ACCESS_ CATEGORY_ID",
                        column: x => x.R_DATA_ACCESS_CATEGORY_ID,
                        principalTable: "R_DATA_ACCESS_CATEGORY",
                        principalColumn: "R_DATA_ACCESS_CATEGORY_ID");
                    table.ForeignKey(
                        name: "FK_WELL_R_PLOT_SYMBOL_R_PLOT_SYMBOL_ID",
                        column: x => x.R_PLOT_SYMBOL_ID,
                        principalTable: "R_PLOT_SYMBOL",
                        principalColumn: "R_PLOT_SYMBOL_ID");
                    table.ForeignKey(
                        name: "FK_WELL_R_TIMEZONE_R_TIMEZONE_ID",
                        column: x => x.R_TIMEZONE_ID,
                        principalTable: "R_TIMEZONE",
                        principalColumn: "R_TIMEZONE_ID");
                    table.ForeignKey(
                        name: "FK_WELL_R_WELL_CLASS_CURRENT_CLASS_ID",
                        column: x => x.CURRENT_CLASS_ID,
                        principalTable: "R_WELL_CLASS",
                        principalColumn: "R_WELL_CLASS_ID");
                    table.ForeignKey(
                        name: "FK_WELL_R_WELL_DATUM_TYPE_DEPTH_DATUM_ID",
                        column: x => x.DEPTH_DATUM_ID,
                        principalTable: "R_WELL_DATUM_TYPE",
                        principalColumn: "WELL_DATUM_TYPE_ID");
                    table.ForeignKey(
                        name: "FK_WELL_R_WELL_STATUS_R_WELL_PROFILE_ID",
                        column: x => x.R_WELL_PROFILE_ID,
                        principalTable: "R_WELL_STATUS",
                        principalColumn: "R_WELL_STATUS_ID");
                });

            migrationBuilder.CreateTable(
                name: "WELLBORE",
                columns: table => new
                {
                    WELLBORE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WELL_ID = table.Column<int>(type: "int", nullable: false),
                    WELL_UWI = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WELLBORE_UWI = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WELLBORE_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    WELLBORE_NUMBER = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    X_COORDINATE = table.Column<decimal>(type: "decimal(18,9)", precision: 18, scale: 9, nullable: true),
                    Y_COORDINATE = table.Column<decimal>(type: "decimal(18,9)", precision: 18, scale: 9, nullable: true),
                    CRS_ID = table.Column<int>(type: "int", nullable: true),
                    CRS_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BH_X_COORDINATE = table.Column<decimal>(type: "decimal(18,9)", precision: 18, scale: 9, nullable: true),
                    BH_Y_COORDINATE = table.Column<decimal>(type: "decimal(18,9)", precision: 18, scale: 9, nullable: true),
                    BH_CRS_ID = table.Column<int>(type: "int", nullable: true),
                    BH_CRS_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FIELD_ID = table.Column<int>(type: "int", nullable: true),
                    FIELD_NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    KB_ELEV = table.Column<decimal>(type: "decimal(18,9)", precision: 18, scale: 9, nullable: true),
                    GROUND_ELEV = table.Column<decimal>(type: "decimal(18,9)", precision: 18, scale: 9, nullable: true),
                    DERRICK_FLOOR_ELEV = table.Column<decimal>(type: "decimal(18,9)", precision: 18, scale: 9, nullable: true),
                    DEPTH_DATUM_ID = table.Column<int>(type: "int", nullable: true),
                    DEPTH_DATUM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DEPTH_DATUM_ELEV = table.Column<decimal>(type: "decimal(18,9)", precision: 18, scale: 9, nullable: true),
                    SPUD_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SPUD_DATE_TZ = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    R_TIMEZONE_ID = table.Column<int>(type: "int", nullable: true),
                    COMPLETION_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DRILL_TD = table.Column<decimal>(type: "decimal(18,9)", precision: 18, scale: 9, nullable: true),
                    PLUGBACK_DEPTH = table.Column<decimal>(type: "decimal(18,9)", precision: 18, scale: 9, nullable: true),
                    KICK_OFF_DEPTH = table.Column<decimal>(type: "decimal(18,9)", precision: 18, scale: 9, nullable: true),
                    WATER_DEPTH = table.Column<decimal>(type: "decimal(18,9)", precision: 18, scale: 9, nullable: true),
                    PARENT_WELLBORE_ID = table.Column<int>(type: "int", nullable: true),
                    PARENT_WELLBORE_UWI = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FORMATION_AT_TD = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    UIDREF = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    R_PLOT_SYMBOL_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WELLBORE", x => x.WELLBORE_ID);
                    table.ForeignKey(
                        name: "FK_WELLBORE_CARTOREFERENCESYSTEM_BH_CRS_ID",
                        column: x => x.BH_CRS_ID,
                        principalTable: "CARTOREFERENCESYSTEM",
                        principalColumn: "CRS_ID");
                    table.ForeignKey(
                        name: "FK_WELLBORE_CARTOREFERENCESYSTEM_CRS_ID",
                        column: x => x.CRS_ID,
                        principalTable: "CARTOREFERENCESYSTEM",
                        principalColumn: "CRS_ID");
                    table.ForeignKey(
                        name: "FK_WELLBORE_FIELD_FIELD_ID",
                        column: x => x.FIELD_ID,
                        principalTable: "FIELD",
                        principalColumn: "FIELD_ID");
                    table.ForeignKey(
                        name: "FK_WELLBORE_R_PLOT_SYMBOL_R_PLOT_SYMBOL_ID",
                        column: x => x.R_PLOT_SYMBOL_ID,
                        principalTable: "R_PLOT_SYMBOL",
                        principalColumn: "R_PLOT_SYMBOL_ID");
                    table.ForeignKey(
                        name: "FK_WELLBORE_R_TIMEZONE_R_TIMEZONE_ID",
                        column: x => x.R_TIMEZONE_ID,
                        principalTable: "R_TIMEZONE",
                        principalColumn: "R_TIMEZONE_ID");
                    table.ForeignKey(
                        name: "FK_WELLBORE_R_WELL_DATUM_TYPE_DEPTH_DATUM_ID",
                        column: x => x.DEPTH_DATUM_ID,
                        principalTable: "R_WELL_DATUM_TYPE",
                        principalColumn: "WELL_DATUM_TYPE_ID");
                    table.ForeignKey(
                        name: "FK_WELLBORE_WELLBORE_PARENT_WELLBORE_ID",
                        column: x => x.PARENT_WELLBORE_ID,
                        principalTable: "WELLBORE",
                        principalColumn: "WELLBORE_ID");
                    table.ForeignKey(
                        name: "FK_WELLBORE_WELL_WELL_ID",
                        column: x => x.WELL_ID,
                        principalTable: "WELL",
                        principalColumn: "WELL_ID");
                });

            migrationBuilder.CreateTable(
                name: "WELL_COMPLETION",
                columns: table => new
                {
                    WELL_COMPLETION_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WELLBORE_ID = table.Column<int>(type: "int", nullable: true),
                    WELLBORE_UWI = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    COMPLETION_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    COMPLETION_OBS_NO = table.Column<int>(type: "int", nullable: true),
                    COMPLETION_TYPE_ID = table.Column<int>(type: "int", nullable: true),
                    COMPLETION_TYPE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    EXPIRY_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TOP_DEPTH = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: true),
                    BASE_DEPTH = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: true),
                    ZONE_ID = table.Column<int>(type: "int", nullable: true),
                    ZONE_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WELL_COMPLETION_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UIDREF = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WELL_COMPLETION", x => x.WELL_COMPLETION_ID);
                    table.ForeignKey(
                        name: "FK_WELL_COMPLETION_R_COMPLETION_TYPE_COMPLETION_TYPE_ID",
                        column: x => x.COMPLETION_TYPE_ID,
                        principalTable: "R_COMPLETION_TYPE",
                        principalColumn: "R_COMPLETION_TYPE_ID");
                    table.ForeignKey(
                        name: "FK_WELL_COMPLETION_WELLBORE_WELLBORE_ID",
                        column: x => x.WELLBORE_ID,
                        principalTable: "WELLBORE",
                        principalColumn: "WELLBORE_ID");
                    table.ForeignKey(
                        name: "FK_WELL_COMPLETION_ZONE_ZONE_ID",
                        column: x => x.ZONE_ID,
                        principalTable: "ZONE",
                        principalColumn: "ZONE_ID");
                });

            migrationBuilder.CreateTable(
                name: "WELL_TUBULAR",
                columns: table => new
                {
                    WELL_TUBULAR_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WELLBORE_ID = table.Column<int>(type: "int", nullable: false),
                    WELLBORE_UWI = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    R_TUBULAR_TYPE_ID = table.Column<int>(type: "int", nullable: true),
                    TUBULAR_TYPE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    R_COUPLING_TYPE_ID = table.Column<int>(type: "int", nullable: true),
                    COUPLING_TYPE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    TUBULAR_IN_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TUBULAR_OUT_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TOP_DEPTH = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: true),
                    BASE_DEPTH = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: true),
                    INSIDE_DIAMETER = table.Column<decimal>(type: "decimal(8,3)", precision: 8, scale: 3, nullable: true),
                    OUTSIDE_DIAMETER = table.Column<decimal>(type: "decimal(8,3)", precision: 8, scale: 3, nullable: true),
                    TUBULAR_THICKNESS = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: true),
                    JOINT_COUNT = table.Column<int>(type: "int", nullable: true),
                    JOINT_LENGTH = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: true),
                    ROUGHNESS = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: true),
                    TUBULAR_DENSITY = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: true),
                    TUBULAR_GRADE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    TUBULAR_STRENGTH = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: true),
                    TUBULAR_WEIGHT = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: true),
                    PACKER_SET_DEPTH = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WELL_TUBULAR", x => x.WELL_TUBULAR_ID);
                    table.ForeignKey(
                        name: "FK_WELL_TUBULAR_R_COUPLING_TYPE_R_COUPLING_TYPE_ID",
                        column: x => x.R_COUPLING_TYPE_ID,
                        principalTable: "R_COUPLING_TYPE",
                        principalColumn: "R_COUPLING_TYPE_ID");
                    table.ForeignKey(
                        name: "FK_WELL_TUBULAR_R_TUBULAR_TYPE_R_TUBULAR_TYPE_ID",
                        column: x => x.R_TUBULAR_TYPE_ID,
                        principalTable: "R_TUBULAR_TYPE",
                        principalColumn: "R_TUBULAR_TYPE_ID");
                    table.ForeignKey(
                        name: "FK_WELL_TUBULAR_WELLBORE_WELLBORE_ID",
                        column: x => x.WELLBORE_ID,
                        principalTable: "WELLBORE",
                        principalColumn: "WELLBORE_ID");
                });

            migrationBuilder.CreateTable(
                name: "WELL_PERFORATION",
                columns: table => new
                {
                    WELL_PERFORATION_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WELL_COMPLETION_ID = table.Column<int>(type: "int", nullable: false),
                    PERFORATION_OBS_NO = table.Column<int>(type: "int", nullable: false),
                    PERFORATION_TYPE_ID = table.Column<int>(type: "int", nullable: true),
                    PERFORATION_TYPE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PERFORATION_METHOD_ID = table.Column<int>(type: "int", nullable: true),
                    PERFORATION_METHOD = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EXPIRY_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TOP_DEPTH = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: true),
                    TOP_ZONE_ID = table.Column<int>(type: "int", nullable: true),
                    TOP_ZONE_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BASE_DEPTH = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: true),
                    BASE_ZONE_ID = table.Column<int>(type: "int", nullable: true),
                    BASE_ZONE_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PERFORATION_ANGLE = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    PERFORATION_COUNT = table.Column<int>(type: "int", nullable: true),
                    PERFORATION_DENSITY = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    PERFORATION_DIAMETER = table.Column<decimal>(type: "decimal(8,3)", precision: 8, scale: 3, nullable: true),
                    PERFORATION_PHASE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WELL_COMPLETION_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WELL_PERFORATION", x => x.WELL_PERFORATION_ID);
                    table.ForeignKey(
                        name: "FK_WELL_PERFORATION_R_PERFORATION_METHOD_PERFORATION_METHOD_ID",
                        column: x => x.PERFORATION_METHOD_ID,
                        principalTable: "R_PERFORATION_METHOD",
                        principalColumn: "R_PERFORATION_METHOD_ID");
                    table.ForeignKey(
                        name: "FK_WELL_PERFORATION_R_PERFORATION_TYPE_PERFORATION_TYPE_ID",
                        column: x => x.PERFORATION_TYPE_ID,
                        principalTable: "R_PERFORATION_TYPE",
                        principalColumn: "R_PERFORATION_TYPE_ID");
                    table.ForeignKey(
                        name: "FK_WELL_PERFORATION_WELL_COMPLETION_WELL_COMPLETION_ID",
                        column: x => x.WELL_COMPLETION_ID,
                        principalTable: "WELL_COMPLETION",
                        principalColumn: "WELL_COMPLETION_ID");
                    table.ForeignKey(
                        name: "FK_WELL_PERFORATION_ZONE_BASE_ZONE_ID",
                        column: x => x.BASE_ZONE_ID,
                        principalTable: "ZONE",
                        principalColumn: "ZONE_ID");
                    table.ForeignKey(
                        name: "FK_WELL_PERFORATION_ZONE_TOP_ZONE_ID",
                        column: x => x.TOP_ZONE_ID,
                        principalTable: "ZONE",
                        principalColumn: "ZONE_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EQUIPMENT_MANUFACTURER_BA_ID",
                table: "EQUIPMENT",
                column: "MANUFACTURER_BA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EQUIPMENT_R_DATA_ACCESS_CATEGORY_ID",
                table: "EQUIPMENT",
                column: "R_DATA_ACCESS_CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EQUIPMENT_R_EQUIPMENT_SUB_TYPE_ID",
                table: "EQUIPMENT",
                column: "R_EQUIPMENT_SUB_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EQUIPMENT_R_EQUIPMENT_TYPE_ID",
                table: "EQUIPMENT",
                column: "R_EQUIPMENT_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FACILITY_CRS_ID",
                table: "FACILITY",
                column: "CRS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FACILITY_FACILITY_TYPE_ID",
                table: "FACILITY",
                column: "FACILITY_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FACILITY_R_DATA_ACCESS_CATEGORY_ID",
                table: "FACILITY",
                column: "R_DATA_ACCESS_CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FIELD_CRS_ID",
                table: "FIELD",
                column: "CRS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FIELD_R_DATA_ACCESS_ CATEGORY_ID",
                table: "FIELD",
                column: "R_DATA_ACCESS_ CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FIELD_R_FIELD_TYPE_ID",
                table: "FIELD",
                column: "R_FIELD_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLOW_MODEL_INSTALLATION_ID",
                table: "FLOW_MODEL",
                column: "INSTALLATION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ORG_UNIT_R_ORG_UNIT_CATEGORY_ID",
                table: "ORG_UNIT",
                column: "R_ORG_UNIT_CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ORG_UNIT_R_ORG_UNIT_TYPE_ID",
                table: "ORG_UNIT",
                column: "R_ORG_UNIT_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_POOL_FIELD_ID",
                table: "POOL",
                column: "FIELD_ID");

            migrationBuilder.CreateIndex(
                name: "IX_POOL_R_DATA_ACCESS_ CATEGORY_ID",
                table: "POOL",
                column: "R_DATA_ACCESS_ CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_POOL_R_POOL_STATUS_ID",
                table: "POOL",
                column: "R_POOL_STATUS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_POOL_R_POOL_TYPE_ID",
                table: "POOL",
                column: "R_POOL_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_R_EQUIPMENT_SUB_TYPE_R_EQUIPMENT_TYPE_ID",
                table: "R_EQUIPMENT_SUB_TYPE",
                column: "R_EQUIPMENT_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_R_EQUIPMENT_TYPE_R_EQUIPMENT_CATALOGUE_ID",
                table: "R_EQUIPMENT_TYPE",
                column: "R_EQUIPMENT_CATALOGUE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_R_WELL_STATUS_R_SOURCE_ID",
                table: "R_WELL_STATUS",
                column: "R_SOURCE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_R_WELL_STATUS_R_WELL_STATUS_TYPE_ID",
                table: "R_WELL_STATUS",
                column: "R_WELL_STATUS_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_R_WELL_STATUS_TYPE_R_SOURCE_ID",
                table: "R_WELL_STATUS_TYPE",
                column: "R_SOURCE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_REPORTING_ENTITY_R_REPORTING_ENTITY_KIND_ID",
                table: "REPORTING_ENTITY",
                column: "R_REPORTING_ENTITY_KIND_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_CRS_ID",
                table: "WELL",
                column: "CRS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_CURRENT_CLASS_ID",
                table: "WELL",
                column: "CURRENT_CLASS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_DEPTH_DATUM_ID",
                table: "WELL",
                column: "DEPTH_DATUM_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_FIELD_ID",
                table: "WELL",
                column: "FIELD_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_R_DATA_ACCESS_ CATEGORY_ID",
                table: "WELL",
                column: "R_DATA_ACCESS_ CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_R_PLOT_SYMBOL_ID",
                table: "WELL",
                column: "R_PLOT_SYMBOL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_R_TIMEZONE_ID",
                table: "WELL",
                column: "R_TIMEZONE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_R_WELL_PROFILE_ID",
                table: "WELL",
                column: "R_WELL_PROFILE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_COMPLETION_COMPLETION_TYPE_ID",
                table: "WELL_COMPLETION",
                column: "COMPLETION_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_COMPLETION_WELLBORE_ID",
                table: "WELL_COMPLETION",
                column: "WELLBORE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_COMPLETION_ZONE_ID",
                table: "WELL_COMPLETION",
                column: "ZONE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_PERFORATION_BASE_ZONE_ID",
                table: "WELL_PERFORATION",
                column: "BASE_ZONE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_PERFORATION_PERFORATION_METHOD_ID",
                table: "WELL_PERFORATION",
                column: "PERFORATION_METHOD_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_PERFORATION_PERFORATION_TYPE_ID",
                table: "WELL_PERFORATION",
                column: "PERFORATION_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_PERFORATION_TOP_ZONE_ID",
                table: "WELL_PERFORATION",
                column: "TOP_ZONE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_PERFORATION_WELL_COMPLETION_ID",
                table: "WELL_PERFORATION",
                column: "WELL_COMPLETION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_TUBULAR_R_COUPLING_TYPE_ID",
                table: "WELL_TUBULAR",
                column: "R_COUPLING_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_TUBULAR_R_TUBULAR_TYPE_ID",
                table: "WELL_TUBULAR",
                column: "R_TUBULAR_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_TUBULAR_WELLBORE_ID",
                table: "WELL_TUBULAR",
                column: "WELLBORE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELLBORE_BH_CRS_ID",
                table: "WELLBORE",
                column: "BH_CRS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELLBORE_CRS_ID",
                table: "WELLBORE",
                column: "CRS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELLBORE_DEPTH_DATUM_ID",
                table: "WELLBORE",
                column: "DEPTH_DATUM_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELLBORE_FIELD_ID",
                table: "WELLBORE",
                column: "FIELD_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELLBORE_PARENT_WELLBORE_ID",
                table: "WELLBORE",
                column: "PARENT_WELLBORE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELLBORE_R_PLOT_SYMBOL_ID",
                table: "WELLBORE",
                column: "R_PLOT_SYMBOL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELLBORE_R_TIMEZONE_ID",
                table: "WELLBORE",
                column: "R_TIMEZONE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELLBORE_WELL_ID",
                table: "WELLBORE",
                column: "WELL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ZONE_POOL_ID",
                table: "ZONE",
                column: "POOL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ZONE_R_DATA_ACCESS_ CATEGORY_ID",
                table: "ZONE",
                column: "R_DATA_ACCESS_ CATEGORY_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EQUIPMENT");

            migrationBuilder.DropTable(
                name: "FACILITY");

            migrationBuilder.DropTable(
                name: "FLOW_MODEL");

            migrationBuilder.DropTable(
                name: "FORMATION");

            migrationBuilder.DropTable(
                name: "WELL_PERFORATION");

            migrationBuilder.DropTable(
                name: "WELL_TUBULAR");

            migrationBuilder.DropTable(
                name: "ORG_UNIT");

            migrationBuilder.DropTable(
                name: "R_EQUIPMENT_SUB_TYPE");

            migrationBuilder.DropTable(
                name: "R_FACILITY_TYPE");

            migrationBuilder.DropTable(
                name: "REPORTING_ENTITY");

            migrationBuilder.DropTable(
                name: "R_PERFORATION_METHOD");

            migrationBuilder.DropTable(
                name: "R_PERFORATION_TYPE");

            migrationBuilder.DropTable(
                name: "WELL_COMPLETION");

            migrationBuilder.DropTable(
                name: "R_COUPLING_TYPE");

            migrationBuilder.DropTable(
                name: "R_TUBULAR_TYPE");

            migrationBuilder.DropTable(
                name: "R_ORG_UNIT_CATEGORY");

            migrationBuilder.DropTable(
                name: "R_ORG_UNIT_TYPE");

            migrationBuilder.DropTable(
                name: "R_EQUIPMENT_TYPE");

            migrationBuilder.DropTable(
                name: "R_REPORTING_ENTITY_KIND");

            migrationBuilder.DropTable(
                name: "R_COMPLETION_TYPE");

            migrationBuilder.DropTable(
                name: "WELLBORE");

            migrationBuilder.DropTable(
                name: "ZONE");

            migrationBuilder.DropTable(
                name: "R_EQUIPMENT_CATALOGUE");

            migrationBuilder.DropTable(
                name: "WELL");

            migrationBuilder.DropTable(
                name: "POOL");

            migrationBuilder.DropTable(
                name: "R_PLOT_SYMBOL");

            migrationBuilder.DropTable(
                name: "R_TIMEZONE");

            migrationBuilder.DropTable(
                name: "R_WELL_CLASS");

            migrationBuilder.DropTable(
                name: "R_WELL_DATUM_TYPE");

            migrationBuilder.DropTable(
                name: "R_WELL_STATUS");

            migrationBuilder.DropTable(
                name: "FIELD");

            migrationBuilder.DropTable(
                name: "R_POOL_STATUS");

            migrationBuilder.DropTable(
                name: "R_POOL_TYPE");

            migrationBuilder.DropTable(
                name: "R_WELL_STATUS_TYPE");

            migrationBuilder.DropTable(
                name: "CARTOREFERENCESYSTEM");

            migrationBuilder.DropTable(
                name: "R_DATA_ACCESS_CATEGORY");

            migrationBuilder.DropTable(
                name: "R_FIELD_TYPE");

            migrationBuilder.DropTable(
                name: "R_SOURCE");
        }
    }
}

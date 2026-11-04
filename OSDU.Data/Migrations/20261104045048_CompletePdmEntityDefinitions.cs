using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OSDU.Data.Migrations
{
    /// <inheritdoc />
    public partial class CompletePdmEntityDefinitions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FACILITY_EQUIPMENT",
                columns: table => new
                {
                    FACILITY_EQUIPMENT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FACILITY_ID = table.Column<int>(type: "int", nullable: false),
                    FACILITY_NAME = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    EQUIPMENT_ID = table.Column<int>(type: "int", nullable: false),
                    EQUIPMENT_NAME = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    INSTALL_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    REMOVE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FACILITY_EQUIPMENT", x => x.FACILITY_EQUIPMENT_ID);
                    table.ForeignKey(
                        name: "FK_FACILITY_EQUIPMENT_EQUIPMENT_EQUIPMENT_ID",
                        column: x => x.EQUIPMENT_ID,
                        principalTable: "EQUIPMENT",
                        principalColumn: "EQUIPMENT_ID");
                    table.ForeignKey(
                        name: "FK_FACILITY_EQUIPMENT_FACILITY_FACILITY_ID",
                        column: x => x.FACILITY_ID,
                        principalTable: "FACILITY",
                        principalColumn: "FACILITY_ID");
                });

            migrationBuilder.CreateTable(
                name: "FACILITY_FIELD",
                columns: table => new
                {
                    FACILITY_FIELD_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FACILITY_ID = table.Column<int>(type: "int", nullable: false),
                    FIELD_ID = table.Column<int>(type: "int", nullable: false),
                    EFFECTIVE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EXPIRY_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FACILITY_FIELD", x => x.FACILITY_FIELD_ID);
                    table.ForeignKey(
                        name: "FK_FACILITY_FIELD_FACILITY_FACILITY_ID",
                        column: x => x.FACILITY_ID,
                        principalTable: "FACILITY",
                        principalColumn: "FACILITY_ID");
                    table.ForeignKey(
                        name: "FK_FACILITY_FIELD_FIELD_FIELD_ID",
                        column: x => x.FIELD_ID,
                        principalTable: "FIELD",
                        principalColumn: "FIELD_ID");
                });

            migrationBuilder.CreateTable(
                name: "R_ALARM_COLOR",
                columns: table => new
                {
                    R_ALARM_COLOR_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COLOR_CODE = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_ALARM_COLOR", x => x.R_ALARM_COLOR_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_ALARM_LEVEL",
                columns: table => new
                {
                    R_ALARM_LEVEL_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ALARM_LEVEL = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_ALARM_LEVEL", x => x.R_ALARM_LEVEL_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_ALARM_TYPE",
                columns: table => new
                {
                    R_ALARM_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ALARM_TYPE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_ALARM_TYPE", x => x.R_ALARM_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_DIRECTION_TYPE",
                columns: table => new
                {
                    R_DIRECTION_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DIRECTION_TYPE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_DIRECTION_TYPE", x => x.R_DIRECTION_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_DOWN_TIME_TYPE",
                columns: table => new
                {
                    R_DOWN_TIME_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DOWN_TIME_TYPE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_DOWN_TIME_TYPE", x => x.R_DOWN_TIME_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_ENTITY_TYPE",
                columns: table => new
                {
                    R_ENTITY_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ENTITY_TYPE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    BUSINESS_OBJECT_ATTR_ID = table.Column<int>(type: "int", nullable: true),
                    BO_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DEFAULT_ATTRIBUTE_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_ENTITY_TYPE", x => x.R_ENTITY_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_EQUIPMENT_MEASUREMENT",
                columns: table => new
                {
                    R_EQUIPMENT_MEASUREMENT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EQUIPMENT_MEASUREMENT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DATA_TYPE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    UNIT = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RANGE_FROM = table.Column<int>(type: "int", nullable: true),
                    RANGE_TO = table.Column<int>(type: "int", nullable: true),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_EQUIPMENT_MEASUREMENT", x => x.R_EQUIPMENT_MEASUREMENT_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_EVENT_CATEGORY",
                columns: table => new
                {
                    R_EVENT_CATEGORY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EVENT_CATEGORY = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PARENT_EVENT_CATEGORY_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_EVENT_CATEGORY", x => x.R_EVENT_CATEGORY_ID);
                    table.ForeignKey(
                        name: "FK_R_EVENT_CATEGORY_R_EVENT_CATEGORY_PARENT_EVENT_CATEGORY_ID",
                        column: x => x.PARENT_EVENT_CATEGORY_ID,
                        principalTable: "R_EVENT_CATEGORY",
                        principalColumn: "R_EVENT_CATEGORY_ID");
                });

            migrationBuilder.CreateTable(
                name: "R_EVENT_STATUS",
                columns: table => new
                {
                    R_EVENT_STATUS_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EVENT_STATUS = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_EVENT_STATUS", x => x.R_EVENT_STATUS_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_FLUID_TYPE",
                columns: table => new
                {
                    R_FLUID_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FLUID_TYPE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    table.PrimaryKey("PK_R_FLUID_TYPE", x => x.R_FLUID_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_NORTH_TYPE",
                columns: table => new
                {
                    R_NORTH_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NORTH_TYPE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
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
                    table.PrimaryKey("PK_R_NORTH_TYPE", x => x.R_NORTH_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_PRODUCTION_METHOD",
                columns: table => new
                {
                    R_PRODUCTION_METHOD_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRODUCTION_METHOD = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    table.PrimaryKey("PK_R_PRODUCTION_METHOD", x => x.R_PRODUCTION_METHOD_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_REPORTING_FACILITY_KIND",
                columns: table => new
                {
                    R_REPORTING_FACILITY_KIND_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REPORTING_FACILITY_KIND = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_REPORTING_FACILITY_KIND", x => x.R_REPORTING_FACILITY_KIND_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_SCENARIO_SOURCE",
                columns: table => new
                {
                    R_SCENARIO_SOURCE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SCENARIO_SOURCE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_SCENARIO_SOURCE", x => x.R_SCENARIO_SOURCE_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_SCENARIO_TYPE",
                columns: table => new
                {
                    R_SCENARIO_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SCENARIO_TYPE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_SCENARIO_TYPE", x => x.R_SCENARIO_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_SURVEY_TYPE",
                columns: table => new
                {
                    R_SURVEY_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    SURVEY_TYPE = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_SURVEY_TYPE", x => x.R_SURVEY_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "SPATIAL_DESCRIPTION",
                columns: table => new
                {
                    SPATIAL_DESCRIPTION_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SPATIAL_DESCRIPTION = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    SPATIAL_OBS_NO = table.Column<int>(type: "int", nullable: false),
                    SPATIAL_DESC_TEXT_IND = table.Column<bool>(type: "bit", nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SPATIAL_DESCRIPTION", x => x.SPATIAL_DESCRIPTION_ID);
                });

            migrationBuilder.CreateTable(
                name: "TAGS_INFO",
                columns: table => new
                {
                    TAGS_INFO_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TAGS_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TAG_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DATA_TYPE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    UNIT = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    POOLING_FREQUENCY = table.Column<int>(type: "int", nullable: true),
                    DATA_SOURCE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAGS_INFO", x => x.TAGS_INFO_ID);
                });

            migrationBuilder.CreateTable(
                name: "WELL_EQUIPMENT",
                columns: table => new
                {
                    WELL_EQUIPMENT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WELLBORE_ID = table.Column<int>(type: "int", nullable: false),
                    WELLBORE_UWI = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EQUIPMENT_ID = table.Column<int>(type: "int", nullable: false),
                    EQUIPMENT_NAME = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    INSTALL_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    REMOVE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    INSTALL_TOP_DEPTH = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: true),
                    INSTALL_BASE_DEPTH = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: true),
                    ID_EQUIPMENT = table.Column<decimal>(type: "decimal(8,3)", precision: 8, scale: 3, nullable: true),
                    OD_EQUIPMENT = table.Column<decimal>(type: "decimal(8,3)", precision: 8, scale: 3, nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WELL_EQUIPMENT_NAME = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WELL_EQUIPMENT", x => x.WELL_EQUIPMENT_ID);
                    table.ForeignKey(
                        name: "FK_WELL_EQUIPMENT_EQUIPMENT_EQUIPMENT_ID",
                        column: x => x.EQUIPMENT_ID,
                        principalTable: "EQUIPMENT",
                        principalColumn: "EQUIPMENT_ID");
                    table.ForeignKey(
                        name: "FK_WELL_EQUIPMENT_WELLBORE_WELLBORE_ID",
                        column: x => x.WELLBORE_ID,
                        principalTable: "WELLBORE",
                        principalColumn: "WELLBORE_ID");
                });

            migrationBuilder.CreateTable(
                name: "WELL_POOL",
                columns: table => new
                {
                    WELL_POOL_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WELL_ID = table.Column<int>(type: "int", nullable: false),
                    POOL_ID = table.Column<int>(type: "int", nullable: false),
                    TOP_MD = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    BASE_MD = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    TOP_TVD = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    BASE_TVD = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WELL_POOL", x => x.WELL_POOL_ID);
                    table.ForeignKey(
                        name: "FK_WELL_POOL_POOL_POOL_ID",
                        column: x => x.POOL_ID,
                        principalTable: "POOL",
                        principalColumn: "POOL_ID");
                    table.ForeignKey(
                        name: "FK_WELL_POOL_WELL_WELL_ID",
                        column: x => x.WELL_ID,
                        principalTable: "WELL",
                        principalColumn: "WELL_ID");
                });

            migrationBuilder.CreateTable(
                name: "WELL_STATUS",
                columns: table => new
                {
                    WELL_STATUS_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REPORTING_ENTITY_ID = table.Column<int>(type: "int", nullable: false),
                    R_WELL_STATUS_ID = table.Column<int>(type: "int", nullable: false),
                    R_SOURCE_ID = table.Column<int>(type: "int", nullable: true),
                    EFFECTIVE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EXPIRY_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WELL_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WELL_STATUS", x => x.WELL_STATUS_ID);
                    table.ForeignKey(
                        name: "FK_WELL_STATUS_REPORTING_ENTITY_REPORTING_ENTITY_ID",
                        column: x => x.REPORTING_ENTITY_ID,
                        principalTable: "REPORTING_ENTITY",
                        principalColumn: "REPORTING_ENTITY_ID");
                    table.ForeignKey(
                        name: "FK_WELL_STATUS_R_SOURCE_R_SOURCE_ID",
                        column: x => x.R_SOURCE_ID,
                        principalTable: "R_SOURCE",
                        principalColumn: "R_SOURCE_ID");
                    table.ForeignKey(
                        name: "FK_WELL_STATUS_R_WELL_STATUS_R_WELL_STATUS_ID",
                        column: x => x.R_WELL_STATUS_ID,
                        principalTable: "R_WELL_STATUS",
                        principalColumn: "R_WELL_STATUS_ID");
                    table.ForeignKey(
                        name: "FK_WELL_STATUS_WELL_WELL_ID",
                        column: x => x.WELL_ID,
                        principalTable: "WELL",
                        principalColumn: "WELL_ID");
                });

            migrationBuilder.CreateTable(
                name: "WELL_TUBING_TALLY",
                columns: table => new
                {
                    WELL_TUBING_TALLY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WELL_TUBING_ID = table.Column<int>(type: "int", nullable: false),
                    WELLBORE_UWI = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TUBING_IN_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JOINTS_SEQUENCE = table.Column<int>(type: "int", nullable: true),
                    JOINTS_COUNT = table.Column<int>(type: "int", nullable: true),
                    JOINTS_LENGTH = table.Column<decimal>(type: "decimal(8,3)", precision: 8, scale: 3, nullable: true),
                    CUM_JOINTS_LENGTH = table.Column<decimal>(type: "decimal(8,3)", precision: 8, scale: 3, nullable: true),
                    INSIDE_DIAMETER = table.Column<decimal>(type: "decimal(8,3)", precision: 8, scale: 3, nullable: true),
                    OUTSIDE_DIAMETER = table.Column<decimal>(type: "decimal(8,3)", precision: 8, scale: 3, nullable: true),
                    TUBING_GRADE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    ROUGHNESS = table.Column<decimal>(type: "decimal(8,3)", precision: 8, scale: 3, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WELL_TUBING_TALLY", x => x.WELL_TUBING_TALLY_ID);
                    table.ForeignKey(
                        name: "FK_WELL_TUBING_TALLY_WELL_TUBULAR_WELL_TUBING_ID",
                        column: x => x.WELL_TUBING_ID,
                        principalTable: "WELL_TUBULAR",
                        principalColumn: "WELL_TUBULAR_ID");
                });

            migrationBuilder.CreateTable(
                name: "ALARM_SETTINGS",
                columns: table => new
                {
                    ALARM_SETTINGS_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    R_ENTITY_TYPE_ID = table.Column<int>(type: "int", nullable: true),
                    R_ENTITY_TYPE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    ENTITY_NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    R_EQUIPMENT_MEASUREMENT_ID = table.Column<int>(type: "int", nullable: true),
                    MEASUREMENT_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ALARM_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    R_ALARM_LEVEL_ID = table.Column<int>(type: "int", nullable: true),
                    ALARM_LEVEL = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    R_ALARM_COLOR_ID = table.Column<int>(type: "int", nullable: true),
                    COLOR_CODE = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    R_ALARM_TYPE_ID = table.Column<int>(type: "int", nullable: true),
                    ALARM_TYPE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    BASE_LINE = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    INPUT_VALUE = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: true),
                    DURATION = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: true),
                    MINIMUM_THRESHOLD = table.Column<decimal>(type: "decimal(15,10)", precision: 15, scale: 10, nullable: true),
                    MAXIMUM_THRESHOLD = table.Column<decimal>(type: "decimal(15,10)", precision: 15, scale: 10, nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EQUIPMENT_ID = table.Column<int>(type: "int", nullable: true),
                    EQUIPMENT_NAME = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    ENTITY_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALARM_SETTINGS", x => x.ALARM_SETTINGS_ID);
                    table.ForeignKey(
                        name: "FK_ALARM_SETTINGS_EQUIPMENT_EQUIPMENT_ID",
                        column: x => x.EQUIPMENT_ID,
                        principalTable: "EQUIPMENT",
                        principalColumn: "EQUIPMENT_ID");
                    table.ForeignKey(
                        name: "FK_ALARM_SETTINGS_R_ALARM_COLOR_R_ALARM_COLOR_ID",
                        column: x => x.R_ALARM_COLOR_ID,
                        principalTable: "R_ALARM_COLOR",
                        principalColumn: "R_ALARM_COLOR_ID");
                    table.ForeignKey(
                        name: "FK_ALARM_SETTINGS_R_ALARM_LEVEL_R_ALARM_LEVEL_ID",
                        column: x => x.R_ALARM_LEVEL_ID,
                        principalTable: "R_ALARM_LEVEL",
                        principalColumn: "R_ALARM_LEVEL_ID");
                    table.ForeignKey(
                        name: "FK_ALARM_SETTINGS_R_ALARM_TYPE_R_ALARM_TYPE_ID",
                        column: x => x.R_ALARM_TYPE_ID,
                        principalTable: "R_ALARM_TYPE",
                        principalColumn: "R_ALARM_TYPE_ID");
                    table.ForeignKey(
                        name: "FK_ALARM_SETTINGS_R_ENTITY_TYPE_R_ENTITY_TYPE_ID",
                        column: x => x.R_ENTITY_TYPE_ID,
                        principalTable: "R_ENTITY_TYPE",
                        principalColumn: "R_ENTITY_TYPE_ID");
                    table.ForeignKey(
                        name: "FK_ALARM_SETTINGS_R_EQUIPMENT_MEASUREMENT_R_EQUIPMENT_MEASUREMENT_ID",
                        column: x => x.R_EQUIPMENT_MEASUREMENT_ID,
                        principalTable: "R_EQUIPMENT_MEASUREMENT",
                        principalColumn: "R_EQUIPMENT_MEASUREMENT_ID");
                });

            migrationBuilder.CreateTable(
                name: "R_DOWN_TIME_REASON",
                columns: table => new
                {
                    R_DOWN_TIME_REASON_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DOWN_TIME_REASON = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    R_EVENT_CATEGORY_ID = table.Column<int>(type: "int", nullable: false),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_DOWN_TIME_REASON", x => x.R_DOWN_TIME_REASON_ID);
                    table.ForeignKey(
                        name: "FK_R_DOWN_TIME_REASON_R_EVENT_CATEGORY_R_EVENT_CATEGORY_ID",
                        column: x => x.R_EVENT_CATEGORY_ID,
                        principalTable: "R_EVENT_CATEGORY",
                        principalColumn: "R_EVENT_CATEGORY_ID");
                });

            migrationBuilder.CreateTable(
                name: "WELL_ZONE",
                columns: table => new
                {
                    WELL_ZONE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WELLBORE_ID = table.Column<int>(type: "int", nullable: false),
                    WELLBORE_UWI = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ZONE_ID = table.Column<int>(type: "int", nullable: false),
                    ZONE_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    R_FLUID_TYPE_ID = table.Column<int>(type: "int", nullable: true),
                    FLUID_TYPE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TOP_MD = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    BASE_MD = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    TOP_TVD = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    BASE_TVD = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    GROSS_PAY = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    NET_PAY = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    NTG = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    POROSITY = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    PERMEABILITY = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    INITIAL_O_SAT = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    INITIAL_G_SAT = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    INITIAL_W_SAT = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    ORIGINAL_OIL_IN_PLACE = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: true),
                    ORIGINAL_GAS_IN_PLACE = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: true),
                    INITIAL_FORMATION_PRESS = table.Column<decimal>(type: "decimal(14,4)", precision: 14, scale: 4, nullable: true),
                    INITIAL_FORMATION_TEMP = table.Column<decimal>(type: "decimal(14,4)", precision: 14, scale: 4, nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WELL_ZONE", x => x.WELL_ZONE_ID);
                    table.ForeignKey(
                        name: "FK_WELL_ZONE_R_FLUID_TYPE_R_FLUID_TYPE_ID",
                        column: x => x.R_FLUID_TYPE_ID,
                        principalTable: "R_FLUID_TYPE",
                        principalColumn: "R_FLUID_TYPE_ID");
                    table.ForeignKey(
                        name: "FK_WELL_ZONE_WELLBORE_WELLBORE_ID",
                        column: x => x.WELLBORE_ID,
                        principalTable: "WELLBORE",
                        principalColumn: "WELLBORE_ID");
                    table.ForeignKey(
                        name: "FK_WELL_ZONE_ZONE_ZONE_ID",
                        column: x => x.ZONE_ID,
                        principalTable: "ZONE",
                        principalColumn: "ZONE_ID");
                });

            migrationBuilder.CreateTable(
                name: "WELL_PROD_METHOD_HISTORY",
                columns: table => new
                {
                    WELL_PROD_METHOD_HISTORY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WELL_ID = table.Column<int>(type: "int", nullable: false),
                    UWI = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EFFECTIVE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    R_PRODUCTION_METHOD_ID = table.Column<int>(type: "int", nullable: true),
                    PRODUCTION_METHOD = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EXPIRY_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WELL_PROD_METHOD_HISTORY", x => x.WELL_PROD_METHOD_HISTORY_ID);
                    table.ForeignKey(
                        name: "FK_WELL_PROD_METHOD_HISTORY_R_PRODUCTION_METHOD_R_PRODUCTION_METHOD_ID",
                        column: x => x.R_PRODUCTION_METHOD_ID,
                        principalTable: "R_PRODUCTION_METHOD",
                        principalColumn: "R_PRODUCTION_METHOD_ID");
                    table.ForeignKey(
                        name: "FK_WELL_PROD_METHOD_HISTORY_WELL_WELL_ID",
                        column: x => x.WELL_ID,
                        principalTable: "WELL",
                        principalColumn: "WELL_ID");
                });

            migrationBuilder.CreateTable(
                name: "REPORTING_FACILITY",
                columns: table => new
                {
                    REPORTING_FACILITY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REPORTING_FACILITY_KIND = table.Column<int>(type: "int", nullable: false),
                    ASSOCIATED_OBJECT_ID = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    SITE_KIND = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    NAMING_SYSTEM = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REPORTING_FACILITY", x => x.REPORTING_FACILITY_ID);
                    table.ForeignKey(
                        name: "FK_REPORTING_FACILITY_R_REPORTING_FACILITY_KIND_REPORTING_FACILITY_KIND",
                        column: x => x.REPORTING_FACILITY_KIND,
                        principalTable: "R_REPORTING_FACILITY_KIND",
                        principalColumn: "R_REPORTING_FACILITY_KIND_ID");
                });

            migrationBuilder.CreateTable(
                name: "SCENARIO",
                columns: table => new
                {
                    SCENARIO_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    R_SCENARIO_TYPE_ID = table.Column<int>(type: "int", nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SCENARIO_NAME = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    SCENARIO_TYPE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    R_SCENARIO_SOURCE_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCENARIO", x => x.SCENARIO_ID);
                    table.ForeignKey(
                        name: "FK_SCENARIO_R_SCENARIO_SOURCE_R_SCENARIO_SOURCE_ID",
                        column: x => x.R_SCENARIO_SOURCE_ID,
                        principalTable: "R_SCENARIO_SOURCE",
                        principalColumn: "R_SCENARIO_SOURCE_ID");
                    table.ForeignKey(
                        name: "FK_SCENARIO_R_SCENARIO_TYPE_R_SCENARIO_TYPE_ID",
                        column: x => x.R_SCENARIO_TYPE_ID,
                        principalTable: "R_SCENARIO_TYPE",
                        principalColumn: "R_SCENARIO_TYPE_ID");
                });

            migrationBuilder.CreateTable(
                name: "WELL_DIR_SRVY",
                columns: table => new
                {
                    WELL_DIR_SRVY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WELLBORE_ID = table.Column<int>(type: "int", nullable: false),
                    WELLBORE_UWI = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SURVEY_RUN_NUM = table.Column<int>(type: "int", nullable: false),
                    MD = table.Column<decimal>(type: "decimal(14,4)", precision: 14, scale: 4, nullable: true),
                    TVD = table.Column<decimal>(type: "decimal(14,4)", precision: 14, scale: 4, nullable: true),
                    AZIMUTH = table.Column<decimal>(type: "decimal(14,4)", precision: 14, scale: 4, nullable: true),
                    INCLINATION = table.Column<decimal>(type: "decimal(14,4)", precision: 14, scale: 4, nullable: true),
                    R_NORTH_ID = table.Column<int>(type: "int", nullable: true),
                    AZIMUTH_NORTH_TYPE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SURVEY_START_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SURVEY_END_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    R_SURVEY_TYPE_ID = table.Column<int>(type: "int", nullable: true),
                    SURVEY_TYPE = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    TOP_DEPTH = table.Column<decimal>(type: "decimal(18,9)", precision: 18, scale: 9, nullable: true),
                    BASE_DEPTH = table.Column<decimal>(type: "decimal(18,9)", precision: 18, scale: 9, nullable: true),
                    REPORT_LOG_DATUM_ID = table.Column<int>(type: "int", nullable: true),
                    REPORT_LOG_DATUM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WELL_DIR_SRVY", x => x.WELL_DIR_SRVY_ID);
                    table.ForeignKey(
                        name: "FK_WELL_DIR_SRVY_R_NORTH_TYPE_R_NORTH_ID",
                        column: x => x.R_NORTH_ID,
                        principalTable: "R_NORTH_TYPE",
                        principalColumn: "R_NORTH_ID");
                    table.ForeignKey(
                        name: "FK_WELL_DIR_SRVY_R_SURVEY_TYPE_R_SURVEY_TYPE_ID",
                        column: x => x.R_SURVEY_TYPE_ID,
                        principalTable: "R_SURVEY_TYPE",
                        principalColumn: "R_SURVEY_TYPE_ID");
                    table.ForeignKey(
                        name: "FK_WELL_DIR_SRVY_R_WELL_DATUM_TYPE_REPORT_LOG_DATUM_ID",
                        column: x => x.REPORT_LOG_DATUM_ID,
                        principalTable: "R_WELL_DATUM_TYPE",
                        principalColumn: "WELL_DATUM_TYPE_ID");
                    table.ForeignKey(
                        name: "FK_WELL_DIR_SRVY_WELLBORE_WELLBORE_ID",
                        column: x => x.WELLBORE_ID,
                        principalTable: "WELLBORE",
                        principalColumn: "WELLBORE_ID");
                });

            migrationBuilder.CreateTable(
                name: "FIELD_COMPONENT",
                columns: table => new
                {
                    FIELD_COMPONENT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIELD_ID = table.Column<int>(type: "int", nullable: true),
                    COMPONENT_OBS_NO = table.Column<int>(type: "int", nullable: false),
                    SPATIAL_DESCRIPTION_ID = table.Column<int>(type: "int", nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FIELD_NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SPATIAL_DESCRIPTION = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FIELD_COMPONENT", x => x.FIELD_COMPONENT_ID);
                    table.ForeignKey(
                        name: "FK_FIELD_COMPONENT_FIELD_FIELD_ID",
                        column: x => x.FIELD_ID,
                        principalTable: "FIELD",
                        principalColumn: "FIELD_ID");
                    table.ForeignKey(
                        name: "FK_FIELD_COMPONENT_SPATIAL_DESCRIPTION_SPATIAL_DESCRIPTION_ID",
                        column: x => x.SPATIAL_DESCRIPTION_ID,
                        principalTable: "SPATIAL_DESCRIPTION",
                        principalColumn: "SPATIAL_DESCRIPTION_ID");
                });

            migrationBuilder.CreateTable(
                name: "POOL_COMPONENT",
                columns: table => new
                {
                    POOL_COMPONENT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    POOL_ID = table.Column<int>(type: "int", nullable: true),
                    COMPONENT_OBS_NO = table.Column<int>(type: "int", nullable: false),
                    SPATIAL_DESCRIPTION_ID = table.Column<int>(type: "int", nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    POOL_NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SPATIAL_DESCRIPTION = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POOL_COMPONENT", x => x.POOL_COMPONENT_ID);
                    table.ForeignKey(
                        name: "FK_POOL_COMPONENT_POOL_POOL_ID",
                        column: x => x.POOL_ID,
                        principalTable: "POOL",
                        principalColumn: "POOL_ID");
                    table.ForeignKey(
                        name: "FK_POOL_COMPONENT_SPATIAL_DESCRIPTION_SPATIAL_DESCRIPTION_ID",
                        column: x => x.SPATIAL_DESCRIPTION_ID,
                        principalTable: "SPATIAL_DESCRIPTION",
                        principalColumn: "SPATIAL_DESCRIPTION_ID");
                });

            migrationBuilder.CreateTable(
                name: "EQUIPMENT_MEASUREMENT_TAGS",
                columns: table => new
                {
                    EQUIPMENT_MEASUREMENT_TAGS_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EQUIPMENT_ID = table.Column<int>(type: "int", nullable: false),
                    EQUIPMENT_NAME = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    R_EQUIPMENT_MEASUREMENT_ID = table.Column<int>(type: "int", nullable: false),
                    EQUIPMENT_MEASUREMENT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TAGS_INFO_ID = table.Column<int>(type: "int", nullable: false),
                    TAGS_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EQUIPMENT_MEASUREMENT_TAGS", x => x.EQUIPMENT_MEASUREMENT_TAGS_ID);
                    table.ForeignKey(
                        name: "FK_EQUIPMENT_MEASUREMENT_TAGS_EQUIPMENT_EQUIPMENT_ID",
                        column: x => x.EQUIPMENT_ID,
                        principalTable: "EQUIPMENT",
                        principalColumn: "EQUIPMENT_ID");
                    table.ForeignKey(
                        name: "FK_EQUIPMENT_MEASUREMENT_TAGS_R_EQUIPMENT_MEASUREMENT_R_EQUIPMENT_MEASUREMENT_ID",
                        column: x => x.R_EQUIPMENT_MEASUREMENT_ID,
                        principalTable: "R_EQUIPMENT_MEASUREMENT",
                        principalColumn: "R_EQUIPMENT_MEASUREMENT_ID");
                    table.ForeignKey(
                        name: "FK_EQUIPMENT_MEASUREMENT_TAGS_TAGS_INFO_TAGS_INFO_ID",
                        column: x => x.TAGS_INFO_ID,
                        principalTable: "TAGS_INFO",
                        principalColumn: "TAGS_INFO_ID");
                });

            migrationBuilder.CreateTable(
                name: "PROD_DOWN_TIME_EVENT",
                columns: table => new
                {
                    PROD_DOWN_TIME_EVENT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PROD_ENTITY_ID = table.Column<int>(type: "int", nullable: false),
                    START_TIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    END_TIME = table.Column<DateTime>(type: "datetime2", nullable: true),
                    R_TIMEZONE_ID = table.Column<int>(type: "int", nullable: true),
                    R_EVENT_CATEGORY_ID = table.Column<int>(type: "int", nullable: false),
                    R_DOWN_TIME_REASON_ID = table.Column<int>(type: "int", nullable: true),
                    EQUIPMENT_ID = table.Column<int>(type: "int", nullable: true),
                    PARENT_DOWN_TIME_EVENT_ID = table.Column<int>(type: "int", nullable: true),
                    R_EVENT_STATUS_ID = table.Column<int>(type: "int", nullable: true),
                    R_DOWN_TIME_TYPE_ID = table.Column<int>(type: "int", nullable: true),
                    IS_PLAN = table.Column<bool>(type: "bit", nullable: true),
                    R_SOURCE_ID = table.Column<int>(type: "int", nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(240)", maxLength: 240, nullable: true),
                    EFFECTIVE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EXPIRY_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROD_DOWN_TIME_EVENT", x => x.PROD_DOWN_TIME_EVENT_ID);
                    table.ForeignKey(
                        name: "FK_PROD_DOWN_TIME_EVENT_EQUIPMENT_EQUIPMENT_ID",
                        column: x => x.EQUIPMENT_ID,
                        principalTable: "EQUIPMENT",
                        principalColumn: "EQUIPMENT_ID");
                    table.ForeignKey(
                        name: "FK_PROD_DOWN_TIME_EVENT_PROD_DOWN_TIME_EVENT_PARENT_DOWN_TIME_EVENT_ID",
                        column: x => x.PARENT_DOWN_TIME_EVENT_ID,
                        principalTable: "PROD_DOWN_TIME_EVENT",
                        principalColumn: "PROD_DOWN_TIME_EVENT_ID");
                    table.ForeignKey(
                        name: "FK_PROD_DOWN_TIME_EVENT_REPORTING_ENTITY_PROD_ENTITY_ID",
                        column: x => x.PROD_ENTITY_ID,
                        principalTable: "REPORTING_ENTITY",
                        principalColumn: "REPORTING_ENTITY_ID");
                    table.ForeignKey(
                        name: "FK_PROD_DOWN_TIME_EVENT_R_DOWN_TIME_REASON_R_DOWN_TIME_REASON_ID",
                        column: x => x.R_DOWN_TIME_REASON_ID,
                        principalTable: "R_DOWN_TIME_REASON",
                        principalColumn: "R_DOWN_TIME_REASON_ID");
                    table.ForeignKey(
                        name: "FK_PROD_DOWN_TIME_EVENT_R_DOWN_TIME_TYPE_R_DOWN_TIME_TYPE_ID",
                        column: x => x.R_DOWN_TIME_TYPE_ID,
                        principalTable: "R_DOWN_TIME_TYPE",
                        principalColumn: "R_DOWN_TIME_TYPE_ID");
                    table.ForeignKey(
                        name: "FK_PROD_DOWN_TIME_EVENT_R_EVENT_CATEGORY_R_EVENT_CATEGORY_ID",
                        column: x => x.R_EVENT_CATEGORY_ID,
                        principalTable: "R_EVENT_CATEGORY",
                        principalColumn: "R_EVENT_CATEGORY_ID");
                    table.ForeignKey(
                        name: "FK_PROD_DOWN_TIME_EVENT_R_EVENT_STATUS_R_EVENT_STATUS_ID",
                        column: x => x.R_EVENT_STATUS_ID,
                        principalTable: "R_EVENT_STATUS",
                        principalColumn: "R_EVENT_STATUS_ID");
                    table.ForeignKey(
                        name: "FK_PROD_DOWN_TIME_EVENT_R_SOURCE_R_SOURCE_ID",
                        column: x => x.R_SOURCE_ID,
                        principalTable: "R_SOURCE",
                        principalColumn: "R_SOURCE_ID");
                    table.ForeignKey(
                        name: "FK_PROD_DOWN_TIME_EVENT_R_TIMEZONE_R_TIMEZONE_ID",
                        column: x => x.R_TIMEZONE_ID,
                        principalTable: "R_TIMEZONE",
                        principalColumn: "R_TIMEZONE_ID");
                });

            migrationBuilder.CreateTable(
                name: "FLOW_MODEL_CONTEXT_FACILITY",
                columns: table => new
                {
                    FLOW_MODEL_CONTEXT_FACILITY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FLOW_MODEL_ID = table.Column<int>(type: "int", nullable: false),
                    CONTEXT_FACILITY_ID = table.Column<int>(type: "int", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FLOW_MODEL_CONTEXT_FACILITY", x => x.FLOW_MODEL_CONTEXT_FACILITY_ID);
                    table.ForeignKey(
                        name: "FK_FLOW_MODEL_CONTEXT_FACILITY_FLOW_MODEL_FLOW_MODEL_ID",
                        column: x => x.FLOW_MODEL_ID,
                        principalTable: "FLOW_MODEL",
                        principalColumn: "FLOW_MODEL_ID");
                    table.ForeignKey(
                        name: "FK_FLOW_MODEL_CONTEXT_FACILITY_REPORTING_FACILITY_CONTEXT_FACILITY_ID",
                        column: x => x.CONTEXT_FACILITY_ID,
                        principalTable: "REPORTING_FACILITY",
                        principalColumn: "REPORTING_FACILITY_ID");
                });

            migrationBuilder.CreateTable(
                name: "NETWORK",
                columns: table => new
                {
                    NETWORK_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NETWORK_NAME = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    FLOW_MODEL_ID = table.Column<int>(type: "int", nullable: true),
                    SCENARIO_ID = table.Column<int>(type: "int", nullable: true),
                    PARENT_NETWORK_ID = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_NETWORK", x => x.NETWORK_ID);
                    table.ForeignKey(
                        name: "FK_NETWORK_FLOW_MODEL_FLOW_MODEL_ID",
                        column: x => x.FLOW_MODEL_ID,
                        principalTable: "FLOW_MODEL",
                        principalColumn: "FLOW_MODEL_ID");
                    table.ForeignKey(
                        name: "FK_NETWORK_NETWORK_PARENT_NETWORK_ID",
                        column: x => x.PARENT_NETWORK_ID,
                        principalTable: "NETWORK",
                        principalColumn: "NETWORK_ID");
                    table.ForeignKey(
                        name: "FK_NETWORK_SCENARIO_SCENARIO_ID",
                        column: x => x.SCENARIO_ID,
                        principalTable: "SCENARIO",
                        principalColumn: "SCENARIO_ID");
                });

            migrationBuilder.CreateTable(
                name: "NETWORK_PLAN",
                columns: table => new
                {
                    NETWORK_PLAN_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NETWORK_PLAN_NAME = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    NETWORK_ID = table.Column<int>(type: "int", nullable: false),
                    PLAN_START_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PLAN_PURPOSE = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    UID = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NETWORK_PLAN", x => x.NETWORK_PLAN_ID);
                    table.ForeignKey(
                        name: "FK_NETWORK_PLAN_NETWORK_NETWORK_ID",
                        column: x => x.NETWORK_ID,
                        principalTable: "NETWORK",
                        principalColumn: "NETWORK_ID");
                });

            migrationBuilder.CreateTable(
                name: "FLOW_UNIT",
                columns: table => new
                {
                    FLOW_UNIT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FLOW_UNIT_NAME = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    REPORTING_FACILITY_ID = table.Column<int>(type: "int", nullable: true),
                    NETWORK_ID = table.Column<int>(type: "int", nullable: false),
                    NETWORK_PLAN_ID = table.Column<int>(type: "int", nullable: true),
                    COMMENT = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    REPORTING_FACILITY_PARENT1_ID = table.Column<int>(type: "int", nullable: true),
                    REPORTING_FACILITY_PARENT2_ID = table.Column<int>(type: "int", nullable: true),
                    INTERNAL_NETWORK_ID = table.Column<int>(type: "int", nullable: true),
                    RELATIVE_COORDINATE_X = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    RELATIVE_COORDINATE_Y = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    RELATIVE_COORDINATE_Z = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    IS_VIRTUAL = table.Column<bool>(type: "bit", nullable: false),
                    EFFECTIVE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EXPIRY_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UID = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FLOW_UNIT", x => x.FLOW_UNIT_ID);
                    table.ForeignKey(
                        name: "FK_FLOW_UNIT_NETWORK_INTERNAL_NETWORK_ID",
                        column: x => x.INTERNAL_NETWORK_ID,
                        principalTable: "NETWORK",
                        principalColumn: "NETWORK_ID");
                    table.ForeignKey(
                        name: "FK_FLOW_UNIT_NETWORK_NETWORK_ID",
                        column: x => x.NETWORK_ID,
                        principalTable: "NETWORK",
                        principalColumn: "NETWORK_ID");
                    table.ForeignKey(
                        name: "FK_FLOW_UNIT_NETWORK_PLAN_NETWORK_PLAN_ID",
                        column: x => x.NETWORK_PLAN_ID,
                        principalTable: "NETWORK_PLAN",
                        principalColumn: "NETWORK_PLAN_ID");
                    table.ForeignKey(
                        name: "FK_FLOW_UNIT_REPORTING_FACILITY_REPORTING_FACILITY_ID",
                        column: x => x.REPORTING_FACILITY_ID,
                        principalTable: "REPORTING_FACILITY",
                        principalColumn: "REPORTING_FACILITY_ID");
                    table.ForeignKey(
                        name: "FK_FLOW_UNIT_REPORTING_FACILITY_REPORTING_FACILITY_PARENT1_ID",
                        column: x => x.REPORTING_FACILITY_PARENT1_ID,
                        principalTable: "REPORTING_FACILITY",
                        principalColumn: "REPORTING_FACILITY_ID");
                    table.ForeignKey(
                        name: "FK_FLOW_UNIT_REPORTING_FACILITY_REPORTING_FACILITY_PARENT2_ID",
                        column: x => x.REPORTING_FACILITY_PARENT2_ID,
                        principalTable: "REPORTING_FACILITY",
                        principalColumn: "REPORTING_FACILITY_ID");
                });

            migrationBuilder.CreateTable(
                name: "FLOW_PORT",
                columns: table => new
                {
                    FLOW_PORT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FLOW_PORT_NAME = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    FLOW_UNIT_ID = table.Column<int>(type: "int", nullable: false),
                    R_DIRECTION_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    UID = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    IS_EXPOSED_INTERNAL = table.Column<bool>(type: "bit", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FLOW_PORT", x => x.FLOW_PORT_ID);
                    table.ForeignKey(
                        name: "FK_FLOW_PORT_FLOW_UNIT_FLOW_UNIT_ID",
                        column: x => x.FLOW_UNIT_ID,
                        principalTable: "FLOW_UNIT",
                        principalColumn: "FLOW_UNIT_ID");
                    table.ForeignKey(
                        name: "FK_FLOW_PORT_R_DIRECTION_TYPE_R_DIRECTION_TYPE_ID",
                        column: x => x.R_DIRECTION_TYPE_ID,
                        principalTable: "R_DIRECTION_TYPE",
                        principalColumn: "R_DIRECTION_TYPE_ID");
                });

            migrationBuilder.CreateTable(
                name: "FLOW_CONNECTED_NODE",
                columns: table => new
                {
                    FLOW_CONNECTED_NODE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    INLET_PORT_ID = table.Column<int>(type: "int", nullable: false),
                    OUTLET_PORT_ID = table.Column<int>(type: "int", nullable: false),
                    EXPIRY_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EFFECTIVE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    COMMENT = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FLOW_CONNECTED_NODE", x => x.FLOW_CONNECTED_NODE_ID);
                    table.ForeignKey(
                        name: "FK_FLOW_CONNECTED_NODE_FLOW_PORT_INLET_PORT_ID",
                        column: x => x.INLET_PORT_ID,
                        principalTable: "FLOW_PORT",
                        principalColumn: "FLOW_PORT_ID");
                    table.ForeignKey(
                        name: "FK_FLOW_CONNECTED_NODE_FLOW_PORT_OUTLET_PORT_ID",
                        column: x => x.OUTLET_PORT_ID,
                        principalTable: "FLOW_PORT",
                        principalColumn: "FLOW_PORT_ID");
                });

            migrationBuilder.CreateTable(
                name: "FLOW_MODEL_EXTERNAL_CONNECT",
                columns: table => new
                {
                    FLOW_MODEL_EXTERNAL_CONNECT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FLOW_MODEL_ID = table.Column<int>(type: "int", nullable: false),
                    FLOW_PORT_ID = table.Column<int>(type: "int", nullable: false),
                    CONNECTED_FLOW_PORT_ID = table.Column<int>(type: "int", nullable: false),
                    CONNECTED_FLOW_MODEL_ID = table.Column<int>(type: "int", nullable: false),
                    CONNECTED_INSTALLATION_ID = table.Column<int>(type: "int", nullable: true),
                    UID = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FLOW_MODEL_EXTERNAL_CONNECT", x => x.FLOW_MODEL_EXTERNAL_CONNECT_ID);
                    table.ForeignKey(
                        name: "FK_FLOW_MODEL_EXTERNAL_CONNECT_FLOW_MODEL_CONNECTED_FLOW_MODEL_ID",
                        column: x => x.CONNECTED_FLOW_MODEL_ID,
                        principalTable: "FLOW_MODEL",
                        principalColumn: "FLOW_MODEL_ID");
                    table.ForeignKey(
                        name: "FK_FLOW_MODEL_EXTERNAL_CONNECT_FLOW_MODEL_FLOW_MODEL_ID",
                        column: x => x.FLOW_MODEL_ID,
                        principalTable: "FLOW_MODEL",
                        principalColumn: "FLOW_MODEL_ID");
                    table.ForeignKey(
                        name: "FK_FLOW_MODEL_EXTERNAL_CONNECT_FLOW_PORT_CONNECTED_FLOW_PORT_ID",
                        column: x => x.CONNECTED_FLOW_PORT_ID,
                        principalTable: "FLOW_PORT",
                        principalColumn: "FLOW_PORT_ID");
                    table.ForeignKey(
                        name: "FK_FLOW_MODEL_EXTERNAL_CONNECT_FLOW_PORT_FLOW_PORT_ID",
                        column: x => x.FLOW_PORT_ID,
                        principalTable: "FLOW_PORT",
                        principalColumn: "FLOW_PORT_ID");
                    table.ForeignKey(
                        name: "FK_FLOW_MODEL_EXTERNAL_CONNECT_REPORTING_ENTITY_CONNECTED_INSTALLATION_ID",
                        column: x => x.CONNECTED_INSTALLATION_ID,
                        principalTable: "REPORTING_ENTITY",
                        principalColumn: "REPORTING_ENTITY_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ALARM_SETTINGS_EQUIPMENT_ID",
                table: "ALARM_SETTINGS",
                column: "EQUIPMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ALARM_SETTINGS_R_ALARM_COLOR_ID",
                table: "ALARM_SETTINGS",
                column: "R_ALARM_COLOR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ALARM_SETTINGS_R_ALARM_LEVEL_ID",
                table: "ALARM_SETTINGS",
                column: "R_ALARM_LEVEL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ALARM_SETTINGS_R_ALARM_TYPE_ID",
                table: "ALARM_SETTINGS",
                column: "R_ALARM_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ALARM_SETTINGS_R_ENTITY_TYPE_ID",
                table: "ALARM_SETTINGS",
                column: "R_ENTITY_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ALARM_SETTINGS_R_EQUIPMENT_MEASUREMENT_ID",
                table: "ALARM_SETTINGS",
                column: "R_EQUIPMENT_MEASUREMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EQUIPMENT_MEASUREMENT_TAGS_EQUIPMENT_ID",
                table: "EQUIPMENT_MEASUREMENT_TAGS",
                column: "EQUIPMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EQUIPMENT_MEASUREMENT_TAGS_R_EQUIPMENT_MEASUREMENT_ID",
                table: "EQUIPMENT_MEASUREMENT_TAGS",
                column: "R_EQUIPMENT_MEASUREMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EQUIPMENT_MEASUREMENT_TAGS_TAGS_INFO_ID",
                table: "EQUIPMENT_MEASUREMENT_TAGS",
                column: "TAGS_INFO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FACILITY_EQUIPMENT_EQUIPMENT_ID",
                table: "FACILITY_EQUIPMENT",
                column: "EQUIPMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FACILITY_EQUIPMENT_FACILITY_ID",
                table: "FACILITY_EQUIPMENT",
                column: "FACILITY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FACILITY_FIELD_FACILITY_ID",
                table: "FACILITY_FIELD",
                column: "FACILITY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FACILITY_FIELD_FIELD_ID",
                table: "FACILITY_FIELD",
                column: "FIELD_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FIELD_COMPONENT_FIELD_ID",
                table: "FIELD_COMPONENT",
                column: "FIELD_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FIELD_COMPONENT_SPATIAL_DESCRIPTION_ID",
                table: "FIELD_COMPONENT",
                column: "SPATIAL_DESCRIPTION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLOW_CONNECTED_NODE_INLET_PORT_ID",
                table: "FLOW_CONNECTED_NODE",
                column: "INLET_PORT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLOW_CONNECTED_NODE_OUTLET_PORT_ID",
                table: "FLOW_CONNECTED_NODE",
                column: "OUTLET_PORT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLOW_MODEL_CONTEXT_FACILITY_CONTEXT_FACILITY_ID",
                table: "FLOW_MODEL_CONTEXT_FACILITY",
                column: "CONTEXT_FACILITY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLOW_MODEL_CONTEXT_FACILITY_FLOW_MODEL_ID",
                table: "FLOW_MODEL_CONTEXT_FACILITY",
                column: "FLOW_MODEL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLOW_MODEL_EXTERNAL_CONNECT_CONNECTED_FLOW_MODEL_ID",
                table: "FLOW_MODEL_EXTERNAL_CONNECT",
                column: "CONNECTED_FLOW_MODEL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLOW_MODEL_EXTERNAL_CONNECT_CONNECTED_FLOW_PORT_ID",
                table: "FLOW_MODEL_EXTERNAL_CONNECT",
                column: "CONNECTED_FLOW_PORT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLOW_MODEL_EXTERNAL_CONNECT_CONNECTED_INSTALLATION_ID",
                table: "FLOW_MODEL_EXTERNAL_CONNECT",
                column: "CONNECTED_INSTALLATION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLOW_MODEL_EXTERNAL_CONNECT_FLOW_MODEL_ID",
                table: "FLOW_MODEL_EXTERNAL_CONNECT",
                column: "FLOW_MODEL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLOW_MODEL_EXTERNAL_CONNECT_FLOW_PORT_ID",
                table: "FLOW_MODEL_EXTERNAL_CONNECT",
                column: "FLOW_PORT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLOW_PORT_FLOW_UNIT_ID",
                table: "FLOW_PORT",
                column: "FLOW_UNIT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLOW_PORT_R_DIRECTION_TYPE_ID",
                table: "FLOW_PORT",
                column: "R_DIRECTION_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLOW_UNIT_INTERNAL_NETWORK_ID",
                table: "FLOW_UNIT",
                column: "INTERNAL_NETWORK_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLOW_UNIT_NETWORK_ID",
                table: "FLOW_UNIT",
                column: "NETWORK_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLOW_UNIT_NETWORK_PLAN_ID",
                table: "FLOW_UNIT",
                column: "NETWORK_PLAN_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLOW_UNIT_REPORTING_FACILITY_ID",
                table: "FLOW_UNIT",
                column: "REPORTING_FACILITY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLOW_UNIT_REPORTING_FACILITY_PARENT1_ID",
                table: "FLOW_UNIT",
                column: "REPORTING_FACILITY_PARENT1_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLOW_UNIT_REPORTING_FACILITY_PARENT2_ID",
                table: "FLOW_UNIT",
                column: "REPORTING_FACILITY_PARENT2_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NETWORK_FLOW_MODEL_ID",
                table: "NETWORK",
                column: "FLOW_MODEL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NETWORK_PARENT_NETWORK_ID",
                table: "NETWORK",
                column: "PARENT_NETWORK_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NETWORK_SCENARIO_ID",
                table: "NETWORK",
                column: "SCENARIO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NETWORK_PLAN_NETWORK_ID",
                table: "NETWORK_PLAN",
                column: "NETWORK_ID");

            migrationBuilder.CreateIndex(
                name: "IX_POOL_COMPONENT_POOL_ID",
                table: "POOL_COMPONENT",
                column: "POOL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_POOL_COMPONENT_SPATIAL_DESCRIPTION_ID",
                table: "POOL_COMPONENT",
                column: "SPATIAL_DESCRIPTION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_DOWN_TIME_EVENT_EQUIPMENT_ID",
                table: "PROD_DOWN_TIME_EVENT",
                column: "EQUIPMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_DOWN_TIME_EVENT_PARENT_DOWN_TIME_EVENT_ID",
                table: "PROD_DOWN_TIME_EVENT",
                column: "PARENT_DOWN_TIME_EVENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_DOWN_TIME_EVENT_PROD_ENTITY_ID",
                table: "PROD_DOWN_TIME_EVENT",
                column: "PROD_ENTITY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_DOWN_TIME_EVENT_R_DOWN_TIME_REASON_ID",
                table: "PROD_DOWN_TIME_EVENT",
                column: "R_DOWN_TIME_REASON_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_DOWN_TIME_EVENT_R_DOWN_TIME_TYPE_ID",
                table: "PROD_DOWN_TIME_EVENT",
                column: "R_DOWN_TIME_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_DOWN_TIME_EVENT_R_EVENT_CATEGORY_ID",
                table: "PROD_DOWN_TIME_EVENT",
                column: "R_EVENT_CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_DOWN_TIME_EVENT_R_EVENT_STATUS_ID",
                table: "PROD_DOWN_TIME_EVENT",
                column: "R_EVENT_STATUS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_DOWN_TIME_EVENT_R_SOURCE_ID",
                table: "PROD_DOWN_TIME_EVENT",
                column: "R_SOURCE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_DOWN_TIME_EVENT_R_TIMEZONE_ID",
                table: "PROD_DOWN_TIME_EVENT",
                column: "R_TIMEZONE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_R_DOWN_TIME_REASON_R_EVENT_CATEGORY_ID",
                table: "R_DOWN_TIME_REASON",
                column: "R_EVENT_CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_R_EVENT_CATEGORY_PARENT_EVENT_CATEGORY_ID",
                table: "R_EVENT_CATEGORY",
                column: "PARENT_EVENT_CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_REPORTING_FACILITY_REPORTING_FACILITY_KIND",
                table: "REPORTING_FACILITY",
                column: "REPORTING_FACILITY_KIND");

            migrationBuilder.CreateIndex(
                name: "IX_SCENARIO_R_SCENARIO_SOURCE_ID",
                table: "SCENARIO",
                column: "R_SCENARIO_SOURCE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SCENARIO_R_SCENARIO_TYPE_ID",
                table: "SCENARIO",
                column: "R_SCENARIO_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_DIR_SRVY_R_NORTH_ID",
                table: "WELL_DIR_SRVY",
                column: "R_NORTH_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_DIR_SRVY_R_SURVEY_TYPE_ID",
                table: "WELL_DIR_SRVY",
                column: "R_SURVEY_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_DIR_SRVY_REPORT_LOG_DATUM_ID",
                table: "WELL_DIR_SRVY",
                column: "REPORT_LOG_DATUM_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_DIR_SRVY_WELLBORE_ID",
                table: "WELL_DIR_SRVY",
                column: "WELLBORE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_EQUIPMENT_EQUIPMENT_ID",
                table: "WELL_EQUIPMENT",
                column: "EQUIPMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_EQUIPMENT_WELLBORE_ID",
                table: "WELL_EQUIPMENT",
                column: "WELLBORE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_POOL_POOL_ID",
                table: "WELL_POOL",
                column: "POOL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_POOL_WELL_ID",
                table: "WELL_POOL",
                column: "WELL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_PROD_METHOD_HISTORY_R_PRODUCTION_METHOD_ID",
                table: "WELL_PROD_METHOD_HISTORY",
                column: "R_PRODUCTION_METHOD_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_PROD_METHOD_HISTORY_WELL_ID",
                table: "WELL_PROD_METHOD_HISTORY",
                column: "WELL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_STATUS_R_SOURCE_ID",
                table: "WELL_STATUS",
                column: "R_SOURCE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_STATUS_R_WELL_STATUS_ID",
                table: "WELL_STATUS",
                column: "R_WELL_STATUS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_STATUS_REPORTING_ENTITY_ID",
                table: "WELL_STATUS",
                column: "REPORTING_ENTITY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_STATUS_WELL_ID",
                table: "WELL_STATUS",
                column: "WELL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_TUBING_TALLY_WELL_TUBING_ID",
                table: "WELL_TUBING_TALLY",
                column: "WELL_TUBING_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_ZONE_R_FLUID_TYPE_ID",
                table: "WELL_ZONE",
                column: "R_FLUID_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_ZONE_WELLBORE_ID",
                table: "WELL_ZONE",
                column: "WELLBORE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_ZONE_ZONE_ID",
                table: "WELL_ZONE",
                column: "ZONE_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ALARM_SETTINGS");

            migrationBuilder.DropTable(
                name: "EQUIPMENT_MEASUREMENT_TAGS");

            migrationBuilder.DropTable(
                name: "FACILITY_EQUIPMENT");

            migrationBuilder.DropTable(
                name: "FACILITY_FIELD");

            migrationBuilder.DropTable(
                name: "FIELD_COMPONENT");

            migrationBuilder.DropTable(
                name: "FLOW_CONNECTED_NODE");

            migrationBuilder.DropTable(
                name: "FLOW_MODEL_CONTEXT_FACILITY");

            migrationBuilder.DropTable(
                name: "FLOW_MODEL_EXTERNAL_CONNECT");

            migrationBuilder.DropTable(
                name: "POOL_COMPONENT");

            migrationBuilder.DropTable(
                name: "PROD_DOWN_TIME_EVENT");

            migrationBuilder.DropTable(
                name: "WELL_DIR_SRVY");

            migrationBuilder.DropTable(
                name: "WELL_EQUIPMENT");

            migrationBuilder.DropTable(
                name: "WELL_POOL");

            migrationBuilder.DropTable(
                name: "WELL_PROD_METHOD_HISTORY");

            migrationBuilder.DropTable(
                name: "WELL_STATUS");

            migrationBuilder.DropTable(
                name: "WELL_TUBING_TALLY");

            migrationBuilder.DropTable(
                name: "WELL_ZONE");

            migrationBuilder.DropTable(
                name: "R_ALARM_COLOR");

            migrationBuilder.DropTable(
                name: "R_ALARM_LEVEL");

            migrationBuilder.DropTable(
                name: "R_ALARM_TYPE");

            migrationBuilder.DropTable(
                name: "R_ENTITY_TYPE");

            migrationBuilder.DropTable(
                name: "R_EQUIPMENT_MEASUREMENT");

            migrationBuilder.DropTable(
                name: "TAGS_INFO");

            migrationBuilder.DropTable(
                name: "FLOW_PORT");

            migrationBuilder.DropTable(
                name: "SPATIAL_DESCRIPTION");

            migrationBuilder.DropTable(
                name: "R_DOWN_TIME_REASON");

            migrationBuilder.DropTable(
                name: "R_DOWN_TIME_TYPE");

            migrationBuilder.DropTable(
                name: "R_EVENT_STATUS");

            migrationBuilder.DropTable(
                name: "R_NORTH_TYPE");

            migrationBuilder.DropTable(
                name: "R_SURVEY_TYPE");

            migrationBuilder.DropTable(
                name: "R_PRODUCTION_METHOD");

            migrationBuilder.DropTable(
                name: "R_FLUID_TYPE");

            migrationBuilder.DropTable(
                name: "FLOW_UNIT");

            migrationBuilder.DropTable(
                name: "R_DIRECTION_TYPE");

            migrationBuilder.DropTable(
                name: "R_EVENT_CATEGORY");

            migrationBuilder.DropTable(
                name: "NETWORK_PLAN");

            migrationBuilder.DropTable(
                name: "REPORTING_FACILITY");

            migrationBuilder.DropTable(
                name: "NETWORK");

            migrationBuilder.DropTable(
                name: "R_REPORTING_FACILITY_KIND");

            migrationBuilder.DropTable(
                name: "SCENARIO");

            migrationBuilder.DropTable(
                name: "R_SCENARIO_SOURCE");

            migrationBuilder.DropTable(
                name: "R_SCENARIO_TYPE");
        }
    }
}

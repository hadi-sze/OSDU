using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OSDU.Data.Migrations
{
    /// <inheritdoc />
    public partial class CompletePdmDictionary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EQUIPMENT_TYPE_MEASUREMENT",
                columns: table => new
                {
                    EQUIPMENT_TYPE_MEASUREMENT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    R_EQUIPMENT_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    EQUIPMENT_TYPE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    R_EQUIPMENT_MEASUREMENT_ID = table.Column<int>(type: "int", nullable: false),
                    EQUIPMENT_MEASUREMENT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EQUIPMENT_TYPE_MEASUREMENT", x => x.EQUIPMENT_TYPE_MEASUREMENT_ID);
                    table.ForeignKey(
                        name: "FK_EQUIPMENT_TYPE_MEASUREMENT_R_EQUIPMENT_MEASUREMENT_R_EQUIPMENT_MEASUREMENT_ID",
                        column: x => x.R_EQUIPMENT_MEASUREMENT_ID,
                        principalTable: "R_EQUIPMENT_MEASUREMENT",
                        principalColumn: "R_EQUIPMENT_MEASUREMENT_ID");
                    table.ForeignKey(
                        name: "FK_EQUIPMENT_TYPE_MEASUREMENT_R_EQUIPMENT_TYPE_R_EQUIPMENT_TYPE_ID",
                        column: x => x.R_EQUIPMENT_TYPE_ID,
                        principalTable: "R_EQUIPMENT_TYPE",
                        principalColumn: "R_EQUIPMENT_TYPE_ID");
                });

            migrationBuilder.CreateTable(
                name: "FLOW_PORT_ALIAS",
                columns: table => new
                {
                    FLOW_PORT_ALIAS_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FLOW_PORT_ID = table.Column<int>(type: "int", nullable: false),
                    FLOW_PORT_ALIAS = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FLOW_PORT_ALIAS", x => x.FLOW_PORT_ALIAS_ID);
                    table.ForeignKey(
                        name: "FK_FLOW_PORT_ALIAS_FLOW_PORT_FLOW_PORT_ID",
                        column: x => x.FLOW_PORT_ID,
                        principalTable: "FLOW_PORT",
                        principalColumn: "FLOW_PORT_ID");
                });

            migrationBuilder.CreateTable(
                name: "FLOW_PORT_EXPECTED_PRODUCT",
                columns: table => new
                {
                    FLOW_PORT_EXPECTED_PRODUCT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FLOW_PORT_ID = table.Column<int>(type: "int", nullable: false),
                    R_REPORTING_FLOW_ID = table.Column<int>(type: "int", nullable: false),
                    R_REPORTING_PRODUCT_ID = table.Column<int>(type: "int", nullable: false),
                    UID_REF = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FLOW_PORT_EXPECTED_PRODUCT", x => x.FLOW_PORT_EXPECTED_PRODUCT_ID);
                });

            migrationBuilder.CreateTable(
                name: "FLOW_UNIT_ALIAS",
                columns: table => new
                {
                    FLOW_UNIT_ALIAS_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FLOW_UNIT_ID = table.Column<int>(type: "int", nullable: false),
                    FLOW_UNIT_ALIAS = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FLOW_UNIT_ALIAS", x => x.FLOW_UNIT_ALIAS_ID);
                    table.ForeignKey(
                        name: "FK_FLOW_UNIT_ALIAS_FLOW_UNIT_FLOW_UNIT_ID",
                        column: x => x.FLOW_UNIT_ID,
                        principalTable: "FLOW_UNIT",
                        principalColumn: "FLOW_UNIT_ID");
                });

            migrationBuilder.CreateTable(
                name: "FLOW_UNIT_CONTEXT_FACILITY",
                columns: table => new
                {
                    FLOW_UNIT_CONTEXT_FACILITY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FLOW_UNIT_ID = table.Column<int>(type: "int", nullable: false),
                    REPORTING_FACILITY_ID = table.Column<int>(type: "int", nullable: true),
                    SITE_KIND = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    NAMING_SYSTEM = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    UID_REF = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FLOW_UNIT_CONTEXT_FACILITY", x => x.FLOW_UNIT_CONTEXT_FACILITY_ID);
                    table.ForeignKey(
                        name: "FK_FLOW_UNIT_CONTEXT_FACILITY_FLOW_UNIT_FLOW_UNIT_ID",
                        column: x => x.FLOW_UNIT_ID,
                        principalTable: "FLOW_UNIT",
                        principalColumn: "FLOW_UNIT_ID");
                    table.ForeignKey(
                        name: "FK_FLOW_UNIT_CONTEXT_FACILITY_REPORTING_FACILITY_REPORTING_FACILITY_ID",
                        column: x => x.REPORTING_FACILITY_ID,
                        principalTable: "REPORTING_FACILITY",
                        principalColumn: "REPORTING_FACILITY_ID");
                });

            migrationBuilder.CreateTable(
                name: "FLUID_ANALYSIS",
                columns: table => new
                {
                    FLUID_ANALYSIS_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PROD_ENTITY_ID = table.Column<int>(type: "int", nullable: false),
                    START_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    END_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FLUID_ANALYSIS_PURPOSE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FLUID_ANALYSIS_LABORATORY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ANALYST = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    REPORT_NUMBER = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    REPORTED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FLUID_ANALYSIS", x => x.FLUID_ANALYSIS_ID);
                    table.ForeignKey(
                        name: "FK_FLUID_ANALYSIS_REPORTING_ENTITY_PROD_ENTITY_ID",
                        column: x => x.PROD_ENTITY_ID,
                        principalTable: "REPORTING_ENTITY",
                        principalColumn: "REPORTING_ENTITY_ID");
                });

            migrationBuilder.CreateTable(
                name: "HIERARCHY",
                columns: table => new
                {
                    HIERARCHY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HIERARCHY_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TENANT_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HIERARCHY", x => x.HIERARCHY_ID);
                });

            migrationBuilder.CreateTable(
                name: "HIERARCHY_TEMPLATE",
                columns: table => new
                {
                    HIERARCHY_TEMPLATE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HIERARCHY_TEMPLATE_NAME = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HIERARCHY_TEMPLATE", x => x.HIERARCHY_TEMPLATE_ID);
                });

            migrationBuilder.CreateTable(
                name: "NETWORK_CHANGE_LOG",
                columns: table => new
                {
                    NETWORK_CHANGE_LOG_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NETWORK_ID = table.Column<int>(type: "int", nullable: false),
                    NETWORK_CHANGE_NAME = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    CHANGE_START_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CHANGE_REASON = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
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
                    table.PrimaryKey("PK_NETWORK_CHANGE_LOG", x => x.NETWORK_CHANGE_LOG_ID);
                    table.ForeignKey(
                        name: "FK_NETWORK_CHANGE_LOG_NETWORK_NETWORK_ID",
                        column: x => x.NETWORK_ID,
                        principalTable: "NETWORK",
                        principalColumn: "NETWORK_ID");
                });

            migrationBuilder.CreateTable(
                name: "NETWORK_EXTERNAL_PORT",
                columns: table => new
                {
                    NETWORK_EXTERNAL_PORT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NETWORK_ID = table.Column<int>(type: "int", nullable: false),
                    FLOW_PORT_ID = table.Column<int>(type: "int", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NETWORK_EXTERNAL_PORT", x => x.NETWORK_EXTERNAL_PORT_ID);
                    table.ForeignKey(
                        name: "FK_NETWORK_EXTERNAL_PORT_NETWORK_NETWORK_ID",
                        column: x => x.NETWORK_ID,
                        principalTable: "NETWORK",
                        principalColumn: "NETWORK_ID");
                });

            migrationBuilder.CreateTable(
                name: "NETWORK_PLAN_CHANGE_LOG",
                columns: table => new
                {
                    NETWORK_PLAN_CHANGE_LOG_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NETWORK_PLAN_ID = table.Column<int>(type: "int", nullable: false),
                    NETWORK_PLAN_CHANGE_NAME = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    CHANGE_START_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CHANGE_REASON = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
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
                    table.PrimaryKey("PK_NETWORK_PLAN_CHANGE_LOG", x => x.NETWORK_PLAN_CHANGE_LOG_ID);
                    table.ForeignKey(
                        name: "FK_NETWORK_PLAN_CHANGE_LOG_NETWORK_PLAN_NETWORK_PLAN_ID",
                        column: x => x.NETWORK_PLAN_ID,
                        principalTable: "NETWORK_PLAN",
                        principalColumn: "NETWORK_PLAN_ID");
                });

            migrationBuilder.CreateTable(
                name: "PRESSURE_TEMPERATURE",
                columns: table => new
                {
                    PRESSURE_TEMPERATURE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TEMPERATURE = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: false),
                    PRESSURE = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRESSURE_TEMPERATURE", x => x.PRESSURE_TEMPERATURE_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_ALARM_CATEGORY",
                columns: table => new
                {
                    R_ALARM_CATEGORY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ALARM_CATEGORY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    table.PrimaryKey("PK_R_ALARM_CATEGORY", x => x.R_ALARM_CATEGORY_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_ALARM_STATUS",
                columns: table => new
                {
                    R_ALARM_STATUS_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ALARM_STATUS = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
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
                    table.PrimaryKey("PK_R_ALARM_STATUS", x => x.R_ALARM_STATUS_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_ALLOCATION_TYPE",
                columns: table => new
                {
                    R_ALLOCATION_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ALLOCATION_TYPE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    R_SOURCE_ID = table.Column<int>(type: "int", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_ALLOCATION_TYPE", x => x.R_ALLOCATION_TYPE_ID);
                    table.ForeignKey(
                        name: "FK_R_ALLOCATION_TYPE_R_SOURCE_R_SOURCE_ID",
                        column: x => x.R_SOURCE_ID,
                        principalTable: "R_SOURCE",
                        principalColumn: "R_SOURCE_ID");
                });

            migrationBuilder.CreateTable(
                name: "R_AMEND_REASON",
                columns: table => new
                {
                    R_AMEND_REASON_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AMEND_REASON = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_AMEND_REASON", x => x.R_AMEND_REASON_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_DECLINE_CURVE_TYPE",
                columns: table => new
                {
                    R_DECLINE_CURVE_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DECLINE_CURVE_TYPE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
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
                    table.PrimaryKey("PK_R_DECLINE_CURVE_TYPE", x => x.R_DECLINE_CURVE_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_DECLINE_METHOD",
                columns: table => new
                {
                    R_DECLINE_METHOD_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DECLINE_METHOD = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
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
                    table.PrimaryKey("PK_R_DECLINE_METHOD", x => x.R_DECLINE_METHOD_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_DECLINE_PARM",
                columns: table => new
                {
                    R_DECLINE_PARM_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DECLINE_PARM = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
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
                    table.PrimaryKey("PK_R_DECLINE_PARM", x => x.R_DECLINE_PARM_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_DECLINE_TYPE",
                columns: table => new
                {
                    R_DECLINE_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DECLINE_TYPE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
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
                    table.PrimaryKey("PK_R_DECLINE_TYPE", x => x.R_DECLINE_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_DISPOSITION_CATEGORY",
                columns: table => new
                {
                    R_DISPOSITION_CATEGORY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DISPOSITION_CATEGORY = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
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
                    table.PrimaryKey("PK_R_DISPOSITION_CATEGORY", x => x.R_DISPOSITION_CATEGORY_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_DOWNTIME_TYPE",
                columns: table => new
                {
                    R_DOWNTIME_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DOWNTIME_TYPE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
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
                    table.PrimaryKey("PK_R_DOWNTIME_TYPE", x => x.R_DOWNTIME_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_EQUIPMENT_SPEC",
                columns: table => new
                {
                    R_EQUIPMENT_SPEC_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DATA_TYPE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    EQUIPMENT_SPEC = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UNIT = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_EQUIPMENT_SPEC", x => x.R_EQUIPMENT_SPEC_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_ESTIMATION_METHOD",
                columns: table => new
                {
                    R_ESTIMATION_METHOD_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ESTIMATION_METHOD = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
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
                    table.PrimaryKey("PK_R_ESTIMATION_METHOD", x => x.R_ESTIMATION_METHOD_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_EVENT_SUB_CATEGORY",
                columns: table => new
                {
                    R_EVENT_SUB_CATEGORY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EVENT_SUB_CATEGORY = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    R_EVENT_CATEGORY_ID = table.Column<int>(type: "int", nullable: true),
                    EVENT_CATEGORY = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
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
                    table.PrimaryKey("PK_R_EVENT_SUB_CATEGORY", x => x.R_EVENT_SUB_CATEGORY_ID);
                    table.ForeignKey(
                        name: "FK_R_EVENT_SUB_CATEGORY_R_EVENT_CATEGORY_R_EVENT_CATEGORY_ID",
                        column: x => x.R_EVENT_CATEGORY_ID,
                        principalTable: "R_EVENT_CATEGORY",
                        principalColumn: "R_EVENT_CATEGORY_ID");
                });

            migrationBuilder.CreateTable(
                name: "R_FACILITY_PARAMETER",
                columns: table => new
                {
                    R_FACILITY_PARAMETER_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FACILITY_PARAMETER = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
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
                    table.PrimaryKey("PK_R_FACILITY_PARAMETER", x => x.R_FACILITY_PARAMETER_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_FLOW_PART",
                columns: table => new
                {
                    R_FLOW_PART_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FLOW_PART = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
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
                    table.PrimaryKey("PK_R_FLOW_PART", x => x.R_FLOW_PART_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_FLOW_QUALIFIER",
                columns: table => new
                {
                    R_FLOW_QUALIFIER_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FLOW_QUALIFIER = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
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
                    table.PrimaryKey("PK_R_FLOW_QUALIFIER", x => x.R_FLOW_QUALIFIER_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_FLUID_ANALYSIS_METHOD",
                columns: table => new
                {
                    R_FLUID_ANALYSIS_METHOD_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FLUID_ANALYSIS_METHOD = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
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
                    table.PrimaryKey("PK_R_FLUID_ANALYSIS_METHOD", x => x.R_FLUID_ANALYSIS_METHOD_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_FLUID_COMPONENT",
                columns: table => new
                {
                    R_FLUID_COMPONENT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FLUID_COMPONENT = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
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
                    table.PrimaryKey("PK_R_FLUID_COMPONENT", x => x.R_FLUID_COMPONENT_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_FLUID_PROPERTY",
                columns: table => new
                {
                    R_FLUID_PROPERTY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FLUID_PROPERTY = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
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
                    table.PrimaryKey("PK_R_FLUID_PROPERTY", x => x.R_FLUID_PROPERTY_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_FLUID_SAMPLE_METHOD",
                columns: table => new
                {
                    R_FLUID_SAMPLE_METHOD_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FLUID_SAMPLE_METHOD = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
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
                    table.PrimaryKey("PK_R_FLUID_SAMPLE_METHOD", x => x.R_FLUID_SAMPLE_METHOD_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_FORECAST_CLASS_TYPE",
                columns: table => new
                {
                    R_FORECAST_CLASS_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FORECAST_CLASS_TYPE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
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
                    table.PrimaryKey("PK_R_FORECAST_CLASS_TYPE", x => x.R_FORECAST_CLASS_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_HAUL_EVENT_TYPE",
                columns: table => new
                {
                    R_HAUL_EVENT_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HAUL_EVENT_TYPE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
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
                    table.PrimaryKey("PK_R_HAUL_EVENT_TYPE", x => x.R_HAUL_EVENT_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_MEASUREMENT",
                columns: table => new
                {
                    R_MEASUREMENT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MEASUREMENT = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    INCLUDE_ON_WELL_TEST = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_R_MEASUREMENT", x => x.R_MEASUREMENT_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_NET_VOLUME_METHOD",
                columns: table => new
                {
                    R_NET_VOLUME_METHOD_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NET_VOLUME_METHOD = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
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
                    table.PrimaryKey("PK_R_NET_VOLUME_METHOD", x => x.R_NET_VOLUME_METHOD_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_PERIOD_KIND",
                columns: table => new
                {
                    R_PERIOD_KIND_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PERIOD_KIND = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
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
                    table.PrimaryKey("PK_R_PERIOD_KIND", x => x.R_PERIOD_KIND_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_PRODUCT_CATEGORY",
                columns: table => new
                {
                    R_PRODUCT_CATEGORY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRODUCT_CATEGORY = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
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
                    table.PrimaryKey("PK_R_PRODUCT_CATEGORY", x => x.R_PRODUCT_CATEGORY_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_QUANTITY_METHOD",
                columns: table => new
                {
                    R_QUANTITY_METHOD_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QUANTITY_METHOD = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_QUANTITY_METHOD", x => x.R_QUANTITY_METHOD_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_RATIO_CURVE_TYPE",
                columns: table => new
                {
                    R_RATIO_CURVE_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RATIO_CURVE_TYPE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
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
                    table.PrimaryKey("PK_R_RATIO_CURVE_TYPE", x => x.R_RATIO_CURVE_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_RATIO_FLUID_TYPE",
                columns: table => new
                {
                    R_RATIO_FLUID_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RATIO_FLUID_TYPE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
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
                    table.PrimaryKey("PK_R_RATIO_FLUID_TYPE", x => x.R_RATIO_FLUID_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_SATURATION_POINT_TYPE",
                columns: table => new
                {
                    R_SATURATION_POINT_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SATURATION_POINT_TYPE = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_SATURATION_POINT_TYPE", x => x.R_SATURATION_POINT_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_TRIGGER_TYPE",
                columns: table => new
                {
                    R_TRIGGER_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TRIGGER_TYPE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_TRIGGER_TYPE", x => x.R_TRIGGER_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_VALIDATE_RESULT",
                columns: table => new
                {
                    R_VALIDATE_RESULT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VALIDATE_RESULT = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
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
                    table.PrimaryKey("PK_R_VALIDATE_RESULT", x => x.R_VALIDATE_RESULT_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_VOLUME_METHOD",
                columns: table => new
                {
                    R_VOLUME_METHOD_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VOLUME_METHOD = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    LONG_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SHORT_NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_VOLUME_METHOD", x => x.R_VOLUME_METHOD_ID);
                });

            migrationBuilder.CreateTable(
                name: "R_WELL_TEST_TYPE",
                columns: table => new
                {
                    R_WELL_TEST_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WELL_TEST_TYPE = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
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
                    table.PrimaryKey("PK_R_WELL_TEST_TYPE", x => x.R_WELL_TEST_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "SP_DESC_TEXT",
                columns: table => new
                {
                    SP_DESC_TEXT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SPATIAL_DESCRIPTION_ID = table.Column<int>(type: "int", nullable: false),
                    TEXT_ID = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SP_DESC_TEXT", x => x.SP_DESC_TEXT_ID);
                    table.ForeignKey(
                        name: "FK_SP_DESC_TEXT_SPATIAL_DESCRIPTION_SPATIAL_DESCRIPTION_ID",
                        column: x => x.SPATIAL_DESCRIPTION_ID,
                        principalTable: "SPATIAL_DESCRIPTION",
                        principalColumn: "SPATIAL_DESCRIPTION_ID");
                });

            migrationBuilder.CreateTable(
                name: "SP_POLYGON",
                columns: table => new
                {
                    POLYGON_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    POLYGON_NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BOUNDARY_DIRECTION = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CRS_ID = table.Column<int>(type: "int", nullable: true),
                    DATUM_ELEV = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    MAX_PLOT_SCALE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MIN_PLOT_SCALE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    REFERENCE_DATUM = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    SPATIAL_DESCRIPTION_ID = table.Column<int>(type: "int", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SP_POLYGON", x => x.POLYGON_ID);
                    table.ForeignKey(
                        name: "FK_SP_POLYGON_CARTOREFERENCESYSTEM_CRS_ID",
                        column: x => x.CRS_ID,
                        principalTable: "CARTOREFERENCESYSTEM",
                        principalColumn: "CRS_ID");
                    table.ForeignKey(
                        name: "FK_SP_POLYGON_SPATIAL_DESCRIPTION_SPATIAL_DESCRIPTION_ID",
                        column: x => x.SPATIAL_DESCRIPTION_ID,
                        principalTable: "SPATIAL_DESCRIPTION",
                        principalColumn: "SPATIAL_DESCRIPTION_ID");
                });

            migrationBuilder.CreateTable(
                name: "VERSION",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VERSION = table.Column<long>(type: "bigint", nullable: false),
                    FILENAME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    BUILDURL = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CREATEDATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VERSION", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WELL_STATUS_HISTORY",
                columns: table => new
                {
                    WELL_STATUS_HISTORY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WELL_ID = table.Column<int>(type: "int", nullable: false),
                    UWI = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EFFECTIVE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    R_WELL_STATUS_ID = table.Column<int>(type: "int", nullable: true),
                    DISPLAY_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
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
                    table.PrimaryKey("PK_WELL_STATUS_HISTORY", x => x.WELL_STATUS_HISTORY_ID);
                    table.ForeignKey(
                        name: "FK_WELL_STATUS_HISTORY_R_WELL_STATUS_R_WELL_STATUS_ID",
                        column: x => x.R_WELL_STATUS_ID,
                        principalTable: "R_WELL_STATUS",
                        principalColumn: "R_WELL_STATUS_ID");
                    table.ForeignKey(
                        name: "FK_WELL_STATUS_HISTORY_WELL_WELL_ID",
                        column: x => x.WELL_ID,
                        principalTable: "WELL",
                        principalColumn: "WELL_ID");
                });

            migrationBuilder.CreateTable(
                name: "WELL_VOL_DAILY",
                columns: table => new
                {
                    WELL_VOLUME_DAILY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WELL_ID = table.Column<int>(type: "int", nullable: false),
                    UWI = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VOLUME_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    HOURS_ON = table.Column<decimal>(type: "decimal(14,4)", precision: 14, scale: 4, nullable: true),
                    OIL_VOLUME = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    OIL_QUALITY = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: true),
                    GAS_VOLUME = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    GAS_QUALITY = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: true),
                    GAS_ENERGY = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    BOE_VOLUME = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    WATER_VOLUME = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    LIQUID_VOLUME = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    CONDENSATE_VOLUME = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    CO2_VOLUME = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    NITROGEN_VOLUME = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    NGL_VOLUME = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    SULPHUR_VOLUME = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    INJECTION_CYCLE = table.Column<int>(type: "int", nullable: true),
                    INJ_WATER_VOLUME = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    INJ_OIL_VOLUME = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    INJ_GAS_VOLUME = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    INJ_CO2_VOLUME = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    INJ_STEAM_VOLUME = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    INJ_POLYMER_VOLUME = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    TUBING_PRESS = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    CASING_PRESS = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    BH_PRESS = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    FL_PRESS = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    SEP_PRESS = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    INJECTION_PRESS = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    WH_TEMP = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    BH_TEMP = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    FL_TEMP = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    SEP_TEMP = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    INJ_WH_STEAM_PRESS = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    INJ_WH_STEAM_TEMP = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    INJ_WH_STEAM_DRY = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    WATER_CUT_PERCENT = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    GAS_OIL_RATIO = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CUM_OIL_VOLUME = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    CUM_GAS_VOLUME = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    CUM_BOE_VOLUME = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    CUM_WATER_VOLUME = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    CUM_LIQUID_VOLUME = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    CUM_CONDENSATE_VOLUME = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    CUM_CO2_VOLUME = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    CUM_NITROGEN_VOLUME = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    CUM_SULPHUR_VOLUME = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    CUM_INJ_WATER_VOLUME = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    CUM_INJ_OIL_VOLUME = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    CUM_INJ_GAS_VOLUME = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    CUM_INJ_CO2_VOLUME = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    CUM_INJ_STEAM_VOLUME = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    CUM_INJ_POLYMER_VOLUME = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    CUM_NGL_VOLUME = table.Column<decimal>(type: "decimal(14,4)", precision: 14, scale: 4, nullable: true),
                    R_VOLUME_METHOD_ID = table.Column<int>(type: "int", nullable: true),
                    VOLUME_METHOD = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WELL_VOL_DAILY", x => x.WELL_VOLUME_DAILY_ID);
                    table.ForeignKey(
                        name: "FK_WELL_VOL_DAILY_WELL_WELL_ID",
                        column: x => x.WELL_ID,
                        principalTable: "WELL",
                        principalColumn: "WELL_ID");
                });

            migrationBuilder.CreateTable(
                name: "WELL_VOL_MONTHLY",
                columns: table => new
                {
                    WELL_VOLUME_MONTHLY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WELL_ID = table.Column<int>(type: "int", nullable: false),
                    UWI = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VOLUME_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    YEAR_MONTH = table.Column<int>(type: "int", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    DAYS_ON = table.Column<decimal>(type: "decimal(14,4)", precision: 14, scale: 4, nullable: true),
                    MONTHLY_OIL = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    AVG_OIL = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    AVG_OIL_QUALITY = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: true),
                    MONTHLY_GAS = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    AVG_GAS = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    AVG_GAS_QUALITY = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: true),
                    AVG_GAS_ENERGY = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MONTHLY_BOE = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    AVG_BOE = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MONTHLY_WATER = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    AVG_WATER = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MONTHLY_LIQUID = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    AVG_LIQUID = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MONTHLY_CONDENSATE = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    AVG_CONDENSATE = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MONTHLY_CO2 = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    AVG_CO2 = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MONTHLY_NITROGEN = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    AVG_NITROGEN = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MONTHLY_NGL = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    AVG_NGL = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MONTHLY_SULPHUR = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    AVG_SULPHUR = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MONTHLY_INJ_WATER = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    AVG_INJ_WATER = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MONTHLY_INJ_OIL = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    AVG_INJ_OIL = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MONTHLY_INJ_GAS = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    AVG_INJ_GAS = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MONTHLY_INJ_CO2 = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    AVG_INJ_CO2 = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MONTHLY_INJ_STEAM = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    AVG_INJ_STEAM = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MONTHLY_INJ_POLYMER = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    AVG_INJ_POLYMER = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    AVG_TUBING_PRESS = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MAX_TUBING_PRESS = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MIN_TUBING_PRESS = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    AVG_CASING_PRESS = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MAX_CASING_PRESS = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MIN_CASING_PRESS = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    AVG_BH_PRESS = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MAX_BH_PRESS = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MIN_BH_PRESS = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    AVG_FL_PRESS = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MAX_FL_PRESS = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MIN_FL_PRESS = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    AVG_SEP_PRESS = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MAX_SEP_PRESS = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MIN_SEP_PRESS = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    AVG_INJECTION_PRESS = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MAX_INJECTION_PRESS = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MIN_INJECTION_PRESS = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    AVG_WH_TEMP = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MAX_WH_TEMP = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MIN_WH_TEMP = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    AVG_BH_TEMP = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MAX_BH_TEMP = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MIN_BH_TEMP = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    AVG_FL_TEMP = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MAX_FL_TEMP = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MIN_FL_TEMP = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    AVG_SEP_TEMP = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MAX_SEP_TEMP = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MIN_SEP_TEMP = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    AVG_INJ_WH_STEAM_PRESS = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MAX_INJ_WH_STEAM_PRESS = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MIN_INJ_WH_STEAM_PRESS = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    AVG_INJ_WH_STEAM_TEMP = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MAX_INJ_WH_STEAM_TEMP = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MIN_INJ_WH_STEAM_TEMP = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    AVG_INJ_WH_STEAM_DRY = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MAX_INJ_WH_STEAM_DRY = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MIN_INJ_WH_STEAM_DRY = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MONTH_WATER_CUT_PERCENT = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    MONTH_GAS_OIL_RATIO = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CUM_OIL = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    CUM_GAS = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    CUM_BOE = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    CUM_WATER = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    CUM_LIQUID = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    CUM_CONDENSATE = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    CUM_CO2 = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    CUM_NITROGEN = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    CUM_SULPHUR = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    CUM_INJ_WATER = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    CUM_INJ_OIL = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    CUM_INJ_GAS = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    CUM_INJ_CO2 = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    CUM_INJ_STEAM = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    CUM_INJ_POLYMER = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    CUM_NGL = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WELL_VOL_MONTHLY", x => x.WELL_VOLUME_MONTHLY_ID);
                    table.ForeignKey(
                        name: "FK_WELL_VOL_MONTHLY_WELL_WELL_ID",
                        column: x => x.WELL_ID,
                        principalTable: "WELL",
                        principalColumn: "WELL_ID");
                });

            migrationBuilder.CreateTable(
                name: "HIERARCHY_DESC",
                columns: table => new
                {
                    HIERARCHY_DESC_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HIERARCHY_ID = table.Column<int>(type: "int", nullable: false),
                    R_ORG_UNIT_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    PARENT_HIERARCHY_DESC_ID = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_HIERARCHY_DESC", x => x.HIERARCHY_DESC_ID);
                    table.ForeignKey(
                        name: "FK_HIERARCHY_DESC_HIERARCHY_DESC_PARENT_HIERARCHY_DESC_ID",
                        column: x => x.PARENT_HIERARCHY_DESC_ID,
                        principalTable: "HIERARCHY_DESC",
                        principalColumn: "HIERARCHY_DESC_ID");
                    table.ForeignKey(
                        name: "FK_HIERARCHY_DESC_HIERARCHY_HIERARCHY_ID",
                        column: x => x.HIERARCHY_ID,
                        principalTable: "HIERARCHY",
                        principalColumn: "HIERARCHY_ID");
                    table.ForeignKey(
                        name: "FK_HIERARCHY_DESC_R_ORG_UNIT_TYPE_R_ORG_UNIT_TYPE_ID",
                        column: x => x.R_ORG_UNIT_TYPE_ID,
                        principalTable: "R_ORG_UNIT_TYPE",
                        principalColumn: "R_ORG_UNIT_TYPE_ID");
                });

            migrationBuilder.CreateTable(
                name: "HIERARCHY_TEMPLATE_DESC",
                columns: table => new
                {
                    HIERARCHY_TEMPLATE_DESC_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HIERARCHY_TEMPLATE_ID = table.Column<int>(type: "int", nullable: false),
                    R_ORG_UNIT_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    PARENT_HIERARCHY_TEMPLATE_DESC_ID = table.Column<int>(type: "int", nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HIERARCHY_TEMPLATE_DESC", x => x.HIERARCHY_TEMPLATE_DESC_ID);
                    table.ForeignKey(
                        name: "FK_HIERARCHY_TEMPLATE_DESC_HIERARCHY_TEMPLATE_DESC_PARENT_HIERARCHY_TEMPLATE_DESC_ID",
                        column: x => x.PARENT_HIERARCHY_TEMPLATE_DESC_ID,
                        principalTable: "HIERARCHY_TEMPLATE_DESC",
                        principalColumn: "HIERARCHY_TEMPLATE_DESC_ID");
                    table.ForeignKey(
                        name: "FK_HIERARCHY_TEMPLATE_DESC_HIERARCHY_TEMPLATE_HIERARCHY_TEMPLATE_ID",
                        column: x => x.HIERARCHY_TEMPLATE_ID,
                        principalTable: "HIERARCHY_TEMPLATE",
                        principalColumn: "HIERARCHY_TEMPLATE_ID");
                    table.ForeignKey(
                        name: "FK_HIERARCHY_TEMPLATE_DESC_R_ORG_UNIT_TYPE_R_ORG_UNIT_TYPE_ID",
                        column: x => x.R_ORG_UNIT_TYPE_ID,
                        principalTable: "R_ORG_UNIT_TYPE",
                        principalColumn: "R_ORG_UNIT_TYPE_ID");
                });

            migrationBuilder.CreateTable(
                name: "EMAIL_CONFIG",
                columns: table => new
                {
                    EMAIL_CONFIG_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ALARM_CATEGORY_ID = table.Column<int>(type: "int", nullable: false),
                    EMAIL_SUBJECT = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    HELLO_WORDS = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    INTRODUCTION = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    BODY = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    DETAIL_LINK = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IS_AUTO_SEND = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMAIL_CONFIG", x => x.EMAIL_CONFIG_ID);
                    table.ForeignKey(
                        name: "FK_EMAIL_CONFIG_R_ALARM_CATEGORY_ALARM_CATEGORY_ID",
                        column: x => x.ALARM_CATEGORY_ID,
                        principalTable: "R_ALARM_CATEGORY",
                        principalColumn: "R_ALARM_CATEGORY_ID");
                });

            migrationBuilder.CreateTable(
                name: "R_ALARM_SUB_CATEGORY",
                columns: table => new
                {
                    R_ALARM_SUB_CATEGORY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ALARM_SUB_CATEGORY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    R_ALARM_CATEGORY_ID = table.Column<int>(type: "int", nullable: true),
                    ALARM_CATEGORY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
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
                    table.PrimaryKey("PK_R_ALARM_SUB_CATEGORY", x => x.R_ALARM_SUB_CATEGORY_ID);
                    table.ForeignKey(
                        name: "FK_R_ALARM_SUB_CATEGORY_R_ALARM_CATEGORY_R_ALARM_CATEGORY_ID",
                        column: x => x.R_ALARM_CATEGORY_ID,
                        principalTable: "R_ALARM_CATEGORY",
                        principalColumn: "R_ALARM_CATEGORY_ID");
                });

            migrationBuilder.CreateTable(
                name: "PROD_DECLINE_FORECAST",
                columns: table => new
                {
                    PROD_DECLINE_FORECAST_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PROD_ENTITY_ID = table.Column<int>(type: "int", nullable: false),
                    SCENARIO_ID = table.Column<int>(type: "int", nullable: false),
                    R_DECLINE_METHOD_ID = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_PROD_DECLINE_FORECAST", x => x.PROD_DECLINE_FORECAST_ID);
                    table.ForeignKey(
                        name: "FK_PROD_DECLINE_FORECAST_REPORTING_ENTITY_PROD_ENTITY_ID",
                        column: x => x.PROD_ENTITY_ID,
                        principalTable: "REPORTING_ENTITY",
                        principalColumn: "REPORTING_ENTITY_ID");
                    table.ForeignKey(
                        name: "FK_PROD_DECLINE_FORECAST_R_DECLINE_METHOD_R_DECLINE_METHOD_ID",
                        column: x => x.R_DECLINE_METHOD_ID,
                        principalTable: "R_DECLINE_METHOD",
                        principalColumn: "R_DECLINE_METHOD_ID");
                    table.ForeignKey(
                        name: "FK_PROD_DECLINE_FORECAST_SCENARIO_SCENARIO_ID",
                        column: x => x.SCENARIO_ID,
                        principalTable: "SCENARIO",
                        principalColumn: "SCENARIO_ID");
                });

            migrationBuilder.CreateTable(
                name: "R_REPORTING_FLOW",
                columns: table => new
                {
                    R_REPORTING_FLOW_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REPORTING_FLOW = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    PARENT_FLOW_KIND_ID = table.Column<int>(type: "int", nullable: true),
                    R_DISPOSITION_CATEGORY_ID = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_R_REPORTING_FLOW", x => x.R_REPORTING_FLOW_ID);
                    table.ForeignKey(
                        name: "FK_R_REPORTING_FLOW_R_DISPOSITION_CATEGORY_R_DISPOSITION_CATEGORY_ID",
                        column: x => x.R_DISPOSITION_CATEGORY_ID,
                        principalTable: "R_DISPOSITION_CATEGORY",
                        principalColumn: "R_DISPOSITION_CATEGORY_ID");
                    table.ForeignKey(
                        name: "FK_R_REPORTING_FLOW_R_REPORTING_FLOW_PARENT_FLOW_KIND_ID",
                        column: x => x.PARENT_FLOW_KIND_ID,
                        principalTable: "R_REPORTING_FLOW",
                        principalColumn: "R_REPORTING_FLOW_ID");
                });

            migrationBuilder.CreateTable(
                name: "EQUIPMENT_SUBTYPE_SPEC",
                columns: table => new
                {
                    EQUIPMENT_SUBTYPE_SPEC_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    R_EQUIPMENT_SUB_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    EQUIPMENT_SUB_TYPE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    R_EQUIPMENT_SPEC_ID = table.Column<int>(type: "int", nullable: false),
                    EQUIPMENT_SPEC = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EQUIPMENT_SUBTYPE_SPEC", x => x.EQUIPMENT_SUBTYPE_SPEC_ID);
                    table.ForeignKey(
                        name: "FK_EQUIPMENT_SUBTYPE_SPEC_R_EQUIPMENT_SPEC_R_EQUIPMENT_SPEC_ID",
                        column: x => x.R_EQUIPMENT_SPEC_ID,
                        principalTable: "R_EQUIPMENT_SPEC",
                        principalColumn: "R_EQUIPMENT_SPEC_ID");
                    table.ForeignKey(
                        name: "FK_EQUIPMENT_SUBTYPE_SPEC_R_EQUIPMENT_SUB_TYPE_R_EQUIPMENT_SUB_TYPE_ID",
                        column: x => x.R_EQUIPMENT_SUB_TYPE_ID,
                        principalTable: "R_EQUIPMENT_SUB_TYPE",
                        principalColumn: "R_EQUIPMENT_SUB_TYPE_ID");
                });

            migrationBuilder.CreateTable(
                name: "EQUIPMENT_TYPE_SPECIFICATION",
                columns: table => new
                {
                    EQUIPMENT_TYPE_SPEC_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    R_EQUIPMENT_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    EQUIPMENT_TYPE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    R_EQUIPMENT_SPEC_ID = table.Column<int>(type: "int", nullable: false),
                    EQUIPMENT_SPEC = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EQUIPMENT_TYPE_SPECIFICATION", x => x.EQUIPMENT_TYPE_SPEC_ID);
                    table.ForeignKey(
                        name: "FK_EQUIPMENT_TYPE_SPECIFICATION_R_EQUIPMENT_SPEC_R_EQUIPMENT_SPEC_ID",
                        column: x => x.R_EQUIPMENT_SPEC_ID,
                        principalTable: "R_EQUIPMENT_SPEC",
                        principalColumn: "R_EQUIPMENT_SPEC_ID");
                    table.ForeignKey(
                        name: "FK_EQUIPMENT_TYPE_SPECIFICATION_R_EQUIPMENT_TYPE_R_EQUIPMENT_TYPE_ID",
                        column: x => x.R_EQUIPMENT_TYPE_ID,
                        principalTable: "R_EQUIPMENT_TYPE",
                        principalColumn: "R_EQUIPMENT_TYPE_ID");
                });

            migrationBuilder.CreateTable(
                name: "WELL_EVENT",
                columns: table => new
                {
                    WELL_EVENT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WELL_ID = table.Column<int>(type: "int", nullable: false),
                    UWI = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EVENT_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    R_EVENT_SUB_CATEGORY_ID = table.Column<int>(type: "int", nullable: false),
                    EVENT_SUB_CATEGORY = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    EVENT_DURATION = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    R_DOWNTIME_TYPE_ID = table.Column<int>(type: "int", nullable: true),
                    DOWNTIME_TYPE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    BASE_DEPTH = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: true),
                    TOP_DEPTH = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: true),
                    LOST_VOLUME_OIL = table.Column<decimal>(type: "decimal(14,4)", precision: 14, scale: 4, nullable: true),
                    LOST_VOLUME_GAS = table.Column<decimal>(type: "decimal(14,4)", precision: 14, scale: 4, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    R_SOURCE_ID = table.Column<int>(type: "int", nullable: true),
                    SOURCE = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WELL_EVENT", x => x.WELL_EVENT_ID);
                    table.ForeignKey(
                        name: "FK_WELL_EVENT_R_DOWNTIME_TYPE_R_DOWNTIME_TYPE_ID",
                        column: x => x.R_DOWNTIME_TYPE_ID,
                        principalTable: "R_DOWNTIME_TYPE",
                        principalColumn: "R_DOWNTIME_TYPE_ID");
                    table.ForeignKey(
                        name: "FK_WELL_EVENT_R_EVENT_SUB_CATEGORY_R_EVENT_SUB_CATEGORY_ID",
                        column: x => x.R_EVENT_SUB_CATEGORY_ID,
                        principalTable: "R_EVENT_SUB_CATEGORY",
                        principalColumn: "R_EVENT_SUB_CATEGORY_ID");
                    table.ForeignKey(
                        name: "FK_WELL_EVENT_R_SOURCE_R_SOURCE_ID",
                        column: x => x.R_SOURCE_ID,
                        principalTable: "R_SOURCE",
                        principalColumn: "R_SOURCE_ID");
                    table.ForeignKey(
                        name: "FK_WELL_EVENT_WELL_WELL_ID",
                        column: x => x.WELL_ID,
                        principalTable: "WELL",
                        principalColumn: "WELL_ID");
                });

            migrationBuilder.CreateTable(
                name: "WELL_EVENT_PLAN",
                columns: table => new
                {
                    WELL_EVENT_PLAN_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WELL_ID = table.Column<int>(type: "int", nullable: false),
                    UWI = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PLANNED_START_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PLANNED_END_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    R_EVENT_SUB_CATEGORY_ID = table.Column<int>(type: "int", nullable: false),
                    EVENT_SUB_CATEGORY = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    PLAN_OWNER = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    R_SOURCE_ID = table.Column<int>(type: "int", nullable: true),
                    SOURCE = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WELL_EVENT_PLAN", x => x.WELL_EVENT_PLAN_ID);
                    table.ForeignKey(
                        name: "FK_WELL_EVENT_PLAN_R_EVENT_SUB_CATEGORY_R_EVENT_SUB_CATEGORY_ID",
                        column: x => x.R_EVENT_SUB_CATEGORY_ID,
                        principalTable: "R_EVENT_SUB_CATEGORY",
                        principalColumn: "R_EVENT_SUB_CATEGORY_ID");
                    table.ForeignKey(
                        name: "FK_WELL_EVENT_PLAN_R_SOURCE_R_SOURCE_ID",
                        column: x => x.R_SOURCE_ID,
                        principalTable: "R_SOURCE",
                        principalColumn: "R_SOURCE_ID");
                    table.ForeignKey(
                        name: "FK_WELL_EVENT_PLAN_WELL_WELL_ID",
                        column: x => x.WELL_ID,
                        principalTable: "WELL",
                        principalColumn: "WELL_ID");
                });

            migrationBuilder.CreateTable(
                name: "FLOW_PORT_EXPECTED_PROPERTY",
                columns: table => new
                {
                    FLOW_PORT_EXPECTED_PROPERTY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FLOW_PORT_ID = table.Column<int>(type: "int", nullable: false),
                    R_FACILITY_PARAMETER_ID = table.Column<int>(type: "int", nullable: false),
                    DEAD_BAND = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    MAXIMUM_FREQUENCY = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
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
                    table.PrimaryKey("PK_FLOW_PORT_EXPECTED_PROPERTY", x => x.FLOW_PORT_EXPECTED_PROPERTY_ID);
                    table.ForeignKey(
                        name: "FK_FLOW_PORT_EXPECTED_PROPERTY_FLOW_PORT_FLOW_PORT_ID",
                        column: x => x.FLOW_PORT_ID,
                        principalTable: "FLOW_PORT",
                        principalColumn: "FLOW_PORT_ID");
                    table.ForeignKey(
                        name: "FK_FLOW_PORT_EXPECTED_PROPERTY_R_FACILITY_PARAMETER_R_FACILITY_PARAMETER_ID",
                        column: x => x.R_FACILITY_PARAMETER_ID,
                        principalTable: "R_FACILITY_PARAMETER",
                        principalColumn: "R_FACILITY_PARAMETER_ID");
                });

            migrationBuilder.CreateTable(
                name: "FLOW_UNIT_EXPECTED_PROPERTY",
                columns: table => new
                {
                    FLOW_UNIT_EXPECTED_PROPERTY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FLOW_UNIT_ID = table.Column<int>(type: "int", nullable: false),
                    R_FACILITY_PARAMETER_ID = table.Column<int>(type: "int", nullable: false),
                    DEAD_BAND = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    MAXIMUM_FREQUENCY = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    CHILD_FACILITY_ID = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_FLOW_UNIT_EXPECTED_PROPERTY", x => x.FLOW_UNIT_EXPECTED_PROPERTY_ID);
                    table.ForeignKey(
                        name: "FK_FLOW_UNIT_EXPECTED_PROPERTY_FLOW_UNIT_FLOW_UNIT_ID",
                        column: x => x.FLOW_UNIT_ID,
                        principalTable: "FLOW_UNIT",
                        principalColumn: "FLOW_UNIT_ID");
                    table.ForeignKey(
                        name: "FK_FLOW_UNIT_EXPECTED_PROPERTY_REPORTING_FACILITY_CHILD_FACILITY_ID",
                        column: x => x.CHILD_FACILITY_ID,
                        principalTable: "REPORTING_FACILITY",
                        principalColumn: "REPORTING_FACILITY_ID");
                    table.ForeignKey(
                        name: "FK_FLOW_UNIT_EXPECTED_PROPERTY_R_FACILITY_PARAMETER_R_FACILITY_PARAMETER_ID",
                        column: x => x.R_FACILITY_PARAMETER_ID,
                        principalTable: "R_FACILITY_PARAMETER",
                        principalColumn: "R_FACILITY_PARAMETER_ID");
                });

            migrationBuilder.CreateTable(
                name: "FLUID_ANALYSIS_STEP",
                columns: table => new
                {
                    FLUID_ANALYSIS_STEP_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FLUID_ANALYSIS_ID = table.Column<int>(type: "int", nullable: false),
                    R_FLUID_ANALYSIS_METHOD_ID = table.Column<int>(type: "int", nullable: false),
                    STEP_SEQUENCE = table.Column<int>(type: "int", nullable: false),
                    STEP_PRESSURE = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: true),
                    STEP_TEMPERATURE = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FLUID_ANALYSIS_STEP", x => x.FLUID_ANALYSIS_STEP_ID);
                    table.ForeignKey(
                        name: "FK_FLUID_ANALYSIS_STEP_FLUID_ANALYSIS_FLUID_ANALYSIS_ID",
                        column: x => x.FLUID_ANALYSIS_ID,
                        principalTable: "FLUID_ANALYSIS",
                        principalColumn: "FLUID_ANALYSIS_ID");
                    table.ForeignKey(
                        name: "FK_FLUID_ANALYSIS_STEP_R_FLUID_ANALYSIS_METHOD_R_FLUID_ANALYSIS_METHOD_ID",
                        column: x => x.R_FLUID_ANALYSIS_METHOD_ID,
                        principalTable: "R_FLUID_ANALYSIS_METHOD",
                        principalColumn: "R_FLUID_ANALYSIS_METHOD_ID");
                });

            migrationBuilder.CreateTable(
                name: "R_FORECAST_CLASS",
                columns: table => new
                {
                    R_FORECAST_CLASS_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FORECAST_CLASS = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    R_FORECAST_CLASS_TYPE_ID = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_R_FORECAST_CLASS", x => x.R_FORECAST_CLASS_ID);
                    table.ForeignKey(
                        name: "FK_R_FORECAST_CLASS_R_FORECAST_CLASS_TYPE_R_FORECAST_CLASS_TYPE_ID",
                        column: x => x.R_FORECAST_CLASS_TYPE_ID,
                        principalTable: "R_FORECAST_CLASS_TYPE",
                        principalColumn: "R_FORECAST_CLASS_TYPE_ID");
                });

            migrationBuilder.CreateTable(
                name: "R_REPORTING_PRODUCT",
                columns: table => new
                {
                    R_REPORTING_PRODUCT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRODUCT = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    R_PRODUCT_CATEGORY_ID = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_R_REPORTING_PRODUCT", x => x.R_REPORTING_PRODUCT_ID);
                    table.ForeignKey(
                        name: "FK_R_REPORTING_PRODUCT_R_PRODUCT_CATEGORY_R_PRODUCT_CATEGORY_ID",
                        column: x => x.R_PRODUCT_CATEGORY_ID,
                        principalTable: "R_PRODUCT_CATEGORY",
                        principalColumn: "R_PRODUCT_CATEGORY_ID");
                });

            migrationBuilder.CreateTable(
                name: "WELL_TEST",
                columns: table => new
                {
                    WELL_TEST_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REPORTING_ENTITY_ID = table.Column<int>(type: "int", nullable: false),
                    START_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    END_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TEST_DURATION = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    R_TIMEZONE_ID = table.Column<int>(type: "int", nullable: true),
                    R_WELL_TEST_TYPE_ID = table.Column<int>(type: "int", nullable: true),
                    PRESSURE_TEMPERATURE_ID = table.Column<int>(type: "int", nullable: true),
                    TEST_DEVICE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    TEST_BY = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IS_VALIDATED = table.Column<bool>(type: "bit", nullable: true),
                    R_VALIDATE_RESULT_ID = table.Column<int>(type: "int", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TEMPERATURE = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    PRESSURE = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    TIMEZONE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    VALIDATE_RESULT = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    WELL_TEST_TYPE = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ASSOCIATED_OBJECT_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WELL_TEST", x => x.WELL_TEST_ID);
                    table.ForeignKey(
                        name: "FK_WELL_TEST_PRESSURE_TEMPERATURE_PRESSURE_TEMPERATURE_ID",
                        column: x => x.PRESSURE_TEMPERATURE_ID,
                        principalTable: "PRESSURE_TEMPERATURE",
                        principalColumn: "PRESSURE_TEMPERATURE_ID");
                    table.ForeignKey(
                        name: "FK_WELL_TEST_REPORTING_ENTITY_REPORTING_ENTITY_ID",
                        column: x => x.REPORTING_ENTITY_ID,
                        principalTable: "REPORTING_ENTITY",
                        principalColumn: "REPORTING_ENTITY_ID");
                    table.ForeignKey(
                        name: "FK_WELL_TEST_R_TIMEZONE_R_TIMEZONE_ID",
                        column: x => x.R_TIMEZONE_ID,
                        principalTable: "R_TIMEZONE",
                        principalColumn: "R_TIMEZONE_ID");
                    table.ForeignKey(
                        name: "FK_WELL_TEST_R_VALIDATE_RESULT_R_VALIDATE_RESULT_ID",
                        column: x => x.R_VALIDATE_RESULT_ID,
                        principalTable: "R_VALIDATE_RESULT",
                        principalColumn: "R_VALIDATE_RESULT_ID");
                    table.ForeignKey(
                        name: "FK_WELL_TEST_R_WELL_TEST_TYPE_R_WELL_TEST_TYPE_ID",
                        column: x => x.R_WELL_TEST_TYPE_ID,
                        principalTable: "R_WELL_TEST_TYPE",
                        principalColumn: "R_WELL_TEST_TYPE_ID");
                });

            migrationBuilder.CreateTable(
                name: "SP_BOUNDARY",
                columns: table => new
                {
                    SP_BOUNDARY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    POLYGON_ID = table.Column<int>(type: "int", nullable: true),
                    POINT_SEQ_NO = table.Column<int>(type: "int", nullable: true),
                    DEPTH = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: true),
                    ELEVATION = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    LATITUDE = table.Column<decimal>(type: "decimal(14,9)", precision: 14, scale: 9, nullable: true),
                    LONGITUDE = table.Column<decimal>(type: "decimal(14,9)", precision: 14, scale: 9, nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SP_BOUNDARY", x => x.SP_BOUNDARY_ID);
                    table.ForeignKey(
                        name: "FK_SP_BOUNDARY_SP_POLYGON_POLYGON_ID",
                        column: x => x.POLYGON_ID,
                        principalTable: "SP_POLYGON",
                        principalColumn: "POLYGON_ID");
                });

            migrationBuilder.CreateTable(
                name: "HIERARCHY_LEVEL",
                columns: table => new
                {
                    HIERARCHY_LEVEL_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HIERARCHY_DESC_ID = table.Column<int>(type: "int", nullable: false),
                    ORG_UNIT_ID = table.Column<int>(type: "int", nullable: false),
                    PARENT_HIERARCHY_LEVEL_ID = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_HIERARCHY_LEVEL", x => x.HIERARCHY_LEVEL_ID);
                    table.ForeignKey(
                        name: "FK_HIERARCHY_LEVEL_HIERARCHY_DESC_HIERARCHY_DESC_ID",
                        column: x => x.HIERARCHY_DESC_ID,
                        principalTable: "HIERARCHY_DESC",
                        principalColumn: "HIERARCHY_DESC_ID");
                    table.ForeignKey(
                        name: "FK_HIERARCHY_LEVEL_HIERARCHY_LEVEL_PARENT_HIERARCHY_LEVEL_ID",
                        column: x => x.PARENT_HIERARCHY_LEVEL_ID,
                        principalTable: "HIERARCHY_LEVEL",
                        principalColumn: "HIERARCHY_LEVEL_ID");
                    table.ForeignKey(
                        name: "FK_HIERARCHY_LEVEL_ORG_UNIT_ORG_UNIT_ID",
                        column: x => x.ORG_UNIT_ID,
                        principalTable: "ORG_UNIT",
                        principalColumn: "ORG_UNIT_ID");
                });

            migrationBuilder.CreateTable(
                name: "ALARM",
                columns: table => new
                {
                    ALARM_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ALARM_SETTINGS_ID = table.Column<int>(type: "int", nullable: false),
                    COUNTER = table.Column<int>(type: "int", nullable: true),
                    IS_ACKNOWLEDGED = table.Column<bool>(type: "bit", nullable: true),
                    ACKNOWLEDGED_COMMENTS = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ACKNOWLEDGED_BY = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    R_EVENT_CATEGORY_ID = table.Column<int>(type: "int", nullable: true),
                    EVENT_CATEGORY = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    R_EVENT_SUB_CATEGORY_ID = table.Column<int>(type: "int", nullable: true),
                    EVENT_SUB_CATEGORY = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IS_NOTIFICATION_SUCCESS = table.Column<bool>(type: "bit", nullable: true),
                    STATUS_ID = table.Column<int>(type: "int", nullable: true),
                    STATUS = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TRIGGER_TYPE_ID = table.Column<int>(type: "int", nullable: true),
                    TRIGGER_TYPE = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    EVENT_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    R_ALARM_SUB_CATEGORY_ID = table.Column<int>(type: "int", nullable: true),
                    ALARM_SUB_CATEGORY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALARM", x => x.ALARM_ID);
                    table.ForeignKey(
                        name: "FK_ALARM_ALARM_SETTINGS_ALARM_SETTINGS_ID",
                        column: x => x.ALARM_SETTINGS_ID,
                        principalTable: "ALARM_SETTINGS",
                        principalColumn: "ALARM_SETTINGS_ID");
                    table.ForeignKey(
                        name: "FK_ALARM_R_ALARM_STATUS_STATUS_ID",
                        column: x => x.STATUS_ID,
                        principalTable: "R_ALARM_STATUS",
                        principalColumn: "R_ALARM_STATUS_ID");
                    table.ForeignKey(
                        name: "FK_ALARM_R_ALARM_SUB_CATEGORY_R_ALARM_SUB_CATEGORY_ID",
                        column: x => x.R_ALARM_SUB_CATEGORY_ID,
                        principalTable: "R_ALARM_SUB_CATEGORY",
                        principalColumn: "R_ALARM_SUB_CATEGORY_ID");
                    table.ForeignKey(
                        name: "FK_ALARM_R_EVENT_CATEGORY_R_EVENT_CATEGORY_ID",
                        column: x => x.R_EVENT_CATEGORY_ID,
                        principalTable: "R_EVENT_CATEGORY",
                        principalColumn: "R_EVENT_CATEGORY_ID");
                    table.ForeignKey(
                        name: "FK_ALARM_R_EVENT_SUB_CATEGORY_R_EVENT_SUB_CATEGORY_ID",
                        column: x => x.R_EVENT_SUB_CATEGORY_ID,
                        principalTable: "R_EVENT_SUB_CATEGORY",
                        principalColumn: "R_EVENT_SUB_CATEGORY_ID");
                });

            migrationBuilder.CreateTable(
                name: "ALARM_NOTIFICATION",
                columns: table => new
                {
                    ALARM_NOTIFICATION_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    R_ALARM_SUB_CATEGORY_ID = table.Column<int>(type: "int", nullable: false),
                    USER_GROUP = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    EMAIL_CONFIG_ID = table.Column<int>(type: "int", nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALARM_NOTIFICATION", x => x.ALARM_NOTIFICATION_ID);
                    table.ForeignKey(
                        name: "FK_ALARM_NOTIFICATION_EMAIL_CONFIG_EMAIL_CONFIG_ID",
                        column: x => x.EMAIL_CONFIG_ID,
                        principalTable: "EMAIL_CONFIG",
                        principalColumn: "EMAIL_CONFIG_ID");
                    table.ForeignKey(
                        name: "FK_ALARM_NOTIFICATION_R_ALARM_SUB_CATEGORY_R_ALARM_SUB_CATEGORY_ID",
                        column: x => x.R_ALARM_SUB_CATEGORY_ID,
                        principalTable: "R_ALARM_SUB_CATEGORY",
                        principalColumn: "R_ALARM_SUB_CATEGORY_ID");
                });

            migrationBuilder.CreateTable(
                name: "FLOW_PORT_NFP_TAG_ALIAS",
                columns: table => new
                {
                    FLOW_PORT_NFP_TAG_ALIAS_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FLOW_PORT_EXPECTED_PROPERTY_ID = table.Column<int>(type: "int", nullable: false),
                    TAG_ALIAS = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FLOW_PORT_NFP_TAG_ALIAS", x => x.FLOW_PORT_NFP_TAG_ALIAS_ID);
                    table.ForeignKey(
                        name: "FK_FLOW_PORT_NFP_TAG_ALIAS_FLOW_PORT_EXPECTED_PROPERTY_FLOW_PORT_EXPECTED_PROPERTY_ID",
                        column: x => x.FLOW_PORT_EXPECTED_PROPERTY_ID,
                        principalTable: "FLOW_PORT_EXPECTED_PROPERTY",
                        principalColumn: "FLOW_PORT_EXPECTED_PROPERTY_ID");
                });

            migrationBuilder.CreateTable(
                name: "FLOW_UNIT_NFP_TAG_ALIAS",
                columns: table => new
                {
                    FLOW_UNIT_NFP_TAG_ALIAS_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FLOW_UNIT_EXPECTED_PROPERTY_ID = table.Column<int>(type: "int", nullable: false),
                    TAG_ALIAS = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FLOW_UNIT_NFP_TAG_ALIAS", x => x.FLOW_UNIT_NFP_TAG_ALIAS_ID);
                    table.ForeignKey(
                        name: "FK_FLOW_UNIT_NFP_TAG_ALIAS_FLOW_UNIT_EXPECTED_PROPERTY_FLOW_UNIT_EXPECTED_PROPERTY_ID",
                        column: x => x.FLOW_UNIT_EXPECTED_PROPERTY_ID,
                        principalTable: "FLOW_UNIT_EXPECTED_PROPERTY",
                        principalColumn: "FLOW_UNIT_EXPECTED_PROPERTY_ID");
                });

            migrationBuilder.CreateTable(
                name: "FLUID_RES_SURF_VOL_RELATION",
                columns: table => new
                {
                    FLUID_RES_SURF_VOL_RELATION_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FLUID_ANALYSIS_STEP_ID = table.Column<int>(type: "int", nullable: false),
                    OIL_FVF = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    GAS_FVF = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    TOTAL_FVF = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    SOLUTION_GOR = table.Column<decimal>(type: "decimal(15,6)", precision: 15, scale: 6, nullable: true),
                    Z_FACTOR = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    OIL_VISCOSITY = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    GAS_VISCOSITY = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    LIQUID_VISCOSITY = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    OIL_GRAVITY = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    GAS_GRAVITY = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    LIQUID_DENSITY = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FLUID_RES_SURF_VOL_RELATION", x => x.FLUID_RES_SURF_VOL_RELATION_ID);
                    table.ForeignKey(
                        name: "FK_FLUID_RES_SURF_VOL_RELATION_FLUID_ANALYSIS_STEP_FLUID_ANALYSIS_STEP_ID",
                        column: x => x.FLUID_ANALYSIS_STEP_ID,
                        principalTable: "FLUID_ANALYSIS_STEP",
                        principalColumn: "FLUID_ANALYSIS_STEP_ID");
                });

            migrationBuilder.CreateTable(
                name: "FLUID_SATURATION_PRESSURE",
                columns: table => new
                {
                    FLUID_SATURATION_PRESSURE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FLUID_ANALYSIS_STEP_ID = table.Column<int>(type: "int", nullable: false),
                    VOLUME = table.Column<decimal>(type: "decimal(14,4)", precision: 14, scale: 4, nullable: true),
                    PRESSURE = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    OPTIC = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: true),
                    R_SATURATION_POINT_TYPE_ID = table.Column<int>(type: "int", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FLUID_SATURATION_PRESSURE", x => x.FLUID_SATURATION_PRESSURE_ID);
                    table.ForeignKey(
                        name: "FK_FLUID_SATURATION_PRESSURE_FLUID_ANALYSIS_STEP_FLUID_ANALYSIS_STEP_ID",
                        column: x => x.FLUID_ANALYSIS_STEP_ID,
                        principalTable: "FLUID_ANALYSIS_STEP",
                        principalColumn: "FLUID_ANALYSIS_STEP_ID");
                    table.ForeignKey(
                        name: "FK_FLUID_SATURATION_PRESSURE_R_SATURATION_POINT_TYPE_R_SATURATION_POINT_TYPE_ID",
                        column: x => x.R_SATURATION_POINT_TYPE_ID,
                        principalTable: "R_SATURATION_POINT_TYPE",
                        principalColumn: "R_SATURATION_POINT_TYPE_ID");
                });

            migrationBuilder.CreateTable(
                name: "PROD_DECLINE_FORECAST_CLASS",
                columns: table => new
                {
                    PROD_DECLINE_FORECAST_CLASS_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PROD_DECLINE_FORECAST_ID = table.Column<int>(type: "int", nullable: false),
                    R_FORECAST_CLASS_ID = table.Column<int>(type: "int", nullable: false),
                    R_FORECAST_CLASS_TYPE_ID = table.Column<int>(type: "int", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROD_DECLINE_FORECAST_CLASS", x => x.PROD_DECLINE_FORECAST_CLASS_ID);
                    table.ForeignKey(
                        name: "FK_PROD_DECLINE_FORECAST_CLASS_PROD_DECLINE_FORECAST_PROD_DECLINE_FORECAST_ID",
                        column: x => x.PROD_DECLINE_FORECAST_ID,
                        principalTable: "PROD_DECLINE_FORECAST",
                        principalColumn: "PROD_DECLINE_FORECAST_ID");
                    table.ForeignKey(
                        name: "FK_PROD_DECLINE_FORECAST_CLASS_R_FORECAST_CLASS_R_FORECAST_CLASS_ID",
                        column: x => x.R_FORECAST_CLASS_ID,
                        principalTable: "R_FORECAST_CLASS",
                        principalColumn: "R_FORECAST_CLASS_ID");
                });

            migrationBuilder.CreateTable(
                name: "FLOW_PORT_PROPERTY_EXPECTED_FLOW_PRODUCT",
                columns: table => new
                {
                    FLOW_PORT_PROPERTY_EXPECTED_FLOW_PRODUCT_ID = table.Column<int>(name: "FLOW_PORT_PROPERTY_ EXPECTED_FLOW_PRODUCT_ID", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FLOW_PORT_EXPECTED_PROPERTY_ID = table.Column<int>(type: "int", nullable: false),
                    R_REPORTING_FLOW_ID = table.Column<int>(type: "int", nullable: false),
                    R_REPORTING_PRODUCT_ID = table.Column<int>(type: "int", nullable: false),
                    R_FLOW_QUALIFIER_ID = table.Column<int>(type: "int", nullable: false),
                    UID = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FLOW_PORT_PROPERTY_EXPECTED_FLOW_PRODUCT", x => x.FLOW_PORT_PROPERTY_EXPECTED_FLOW_PRODUCT_ID);
                    table.ForeignKey(
                        name: "FK_FLOW_PORT_PROPERTY_EXPECTED_FLOW_PRODUCT_FLOW_PORT_EXPECTED_PROPERTY_FLOW_PORT_EXPECTED_PROPERTY_ID",
                        column: x => x.FLOW_PORT_EXPECTED_PROPERTY_ID,
                        principalTable: "FLOW_PORT_EXPECTED_PROPERTY",
                        principalColumn: "FLOW_PORT_EXPECTED_PROPERTY_ID");
                    table.ForeignKey(
                        name: "FK_FLOW_PORT_PROPERTY_EXPECTED_FLOW_PRODUCT_R_FLOW_QUALIFIER_R_FLOW_QUALIFIER_ID",
                        column: x => x.R_FLOW_QUALIFIER_ID,
                        principalTable: "R_FLOW_QUALIFIER",
                        principalColumn: "R_FLOW_QUALIFIER_ID");
                    table.ForeignKey(
                        name: "FK_FLOW_PORT_PROPERTY_EXPECTED_FLOW_PRODUCT_R_REPORTING_FLOW_R_REPORTING_FLOW_ID",
                        column: x => x.R_REPORTING_FLOW_ID,
                        principalTable: "R_REPORTING_FLOW",
                        principalColumn: "R_REPORTING_FLOW_ID");
                    table.ForeignKey(
                        name: "FK_FLOW_PORT_PROPERTY_EXPECTED_FLOW_PRODUCT_R_REPORTING_PRODUCT_R_REPORTING_PRODUCT_ID",
                        column: x => x.R_REPORTING_PRODUCT_ID,
                        principalTable: "R_REPORTING_PRODUCT",
                        principalColumn: "R_REPORTING_PRODUCT_ID");
                });

            migrationBuilder.CreateTable(
                name: "FLOW_UNIT_EXPECTED_FLOW_PRODUCT",
                columns: table => new
                {
                    FLOW_UNIT_EXPECTED_FLOW_PRODUCT_ID = table.Column<int>(name: "FLOW_UNIT_EXPECTED _FLOW_PRODUCT_ID", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FLOW_UNIT_EXPECTED_PROPERTY_ID = table.Column<int>(type: "int", nullable: false),
                    R_REPORTING_FLOW_ID = table.Column<int>(type: "int", nullable: false),
                    R_REPORTING_PRODUCT_ID = table.Column<int>(type: "int", nullable: false),
                    R_FLOW_QUALIFIER_ID = table.Column<int>(type: "int", nullable: false),
                    UID = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
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
                    table.PrimaryKey("PK_FLOW_UNIT_EXPECTED_FLOW_PRODUCT", x => x.FLOW_UNIT_EXPECTED_FLOW_PRODUCT_ID);
                    table.ForeignKey(
                        name: "FK_FLOW_UNIT_EXPECTED_FLOW_PRODUCT_FLOW_UNIT_EXPECTED_PROPERTY_FLOW_UNIT_EXPECTED_PROPERTY_ID",
                        column: x => x.FLOW_UNIT_EXPECTED_PROPERTY_ID,
                        principalTable: "FLOW_UNIT_EXPECTED_PROPERTY",
                        principalColumn: "FLOW_UNIT_EXPECTED_PROPERTY_ID");
                    table.ForeignKey(
                        name: "FK_FLOW_UNIT_EXPECTED_FLOW_PRODUCT_R_FLOW_QUALIFIER_R_FLOW_QUALIFIER_ID",
                        column: x => x.R_FLOW_QUALIFIER_ID,
                        principalTable: "R_FLOW_QUALIFIER",
                        principalColumn: "R_FLOW_QUALIFIER_ID");
                    table.ForeignKey(
                        name: "FK_FLOW_UNIT_EXPECTED_FLOW_PRODUCT_R_REPORTING_FLOW_R_REPORTING_FLOW_ID",
                        column: x => x.R_REPORTING_FLOW_ID,
                        principalTable: "R_REPORTING_FLOW",
                        principalColumn: "R_REPORTING_FLOW_ID");
                    table.ForeignKey(
                        name: "FK_FLOW_UNIT_EXPECTED_FLOW_PRODUCT_R_REPORTING_PRODUCT_R_REPORTING_PRODUCT_ID",
                        column: x => x.R_REPORTING_PRODUCT_ID,
                        principalTable: "R_REPORTING_PRODUCT",
                        principalColumn: "R_REPORTING_PRODUCT_ID");
                });

            migrationBuilder.CreateTable(
                name: "FLUID_ANALYSIS_PROPERTY_SUMMARY",
                columns: table => new
                {
                    FLUID_ANALYSIS_PROPERTY_SUMMARY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FLUID_ANALYSIS_ID = table.Column<int>(type: "int", nullable: false),
                    REF_PRESSURE = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: true),
                    REF_TEMPERATURE = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    R_PRODUCT_ID = table.Column<int>(type: "int", nullable: false),
                    R_FLUID_PROPERTY_ID = table.Column<int>(type: "int", nullable: false),
                    VALUE = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: true),
                    VALUE_UOM = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FLUID_ANALYSIS_PROPERTY_SUMMARY", x => x.FLUID_ANALYSIS_PROPERTY_SUMMARY_ID);
                    table.ForeignKey(
                        name: "FK_FLUID_ANALYSIS_PROPERTY_SUMMARY_FLUID_ANALYSIS_FLUID_ANALYSIS_ID",
                        column: x => x.FLUID_ANALYSIS_ID,
                        principalTable: "FLUID_ANALYSIS",
                        principalColumn: "FLUID_ANALYSIS_ID");
                    table.ForeignKey(
                        name: "FK_FLUID_ANALYSIS_PROPERTY_SUMMARY_R_FLUID_PROPERTY_R_FLUID_PROPERTY_ID",
                        column: x => x.R_FLUID_PROPERTY_ID,
                        principalTable: "R_FLUID_PROPERTY",
                        principalColumn: "R_FLUID_PROPERTY_ID");
                    table.ForeignKey(
                        name: "FK_FLUID_ANALYSIS_PROPERTY_SUMMARY_R_REPORTING_PRODUCT_R_PRODUCT_ID",
                        column: x => x.R_PRODUCT_ID,
                        principalTable: "R_REPORTING_PRODUCT",
                        principalColumn: "R_REPORTING_PRODUCT_ID");
                });

            migrationBuilder.CreateTable(
                name: "FLUID_COMPOSITION_ANALYSIS",
                columns: table => new
                {
                    FLUID_COMPOSITION_ANALYSIS_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FLUID_ANALYSIS_STEP_ID = table.Column<int>(type: "int", nullable: false),
                    R_PRODUCT_ID = table.Column<int>(type: "int", nullable: false),
                    R_FLUID_COMPONENT_ID = table.Column<int>(type: "int", nullable: false),
                    MOLECULAR_WEIGHT = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    WEIGHT_FRACTION = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    MOLE_FRACTION = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    VOLUME_FRACTION = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FLUID_COMPOSITION_ANALYSIS", x => x.FLUID_COMPOSITION_ANALYSIS_ID);
                    table.ForeignKey(
                        name: "FK_FLUID_COMPOSITION_ANALYSIS_FLUID_ANALYSIS_STEP_FLUID_ANALYSIS_STEP_ID",
                        column: x => x.FLUID_ANALYSIS_STEP_ID,
                        principalTable: "FLUID_ANALYSIS_STEP",
                        principalColumn: "FLUID_ANALYSIS_STEP_ID");
                    table.ForeignKey(
                        name: "FK_FLUID_COMPOSITION_ANALYSIS_R_FLUID_COMPONENT_R_FLUID_COMPONENT_ID",
                        column: x => x.R_FLUID_COMPONENT_ID,
                        principalTable: "R_FLUID_COMPONENT",
                        principalColumn: "R_FLUID_COMPONENT_ID");
                    table.ForeignKey(
                        name: "FK_FLUID_COMPOSITION_ANALYSIS_R_REPORTING_PRODUCT_R_PRODUCT_ID",
                        column: x => x.R_PRODUCT_ID,
                        principalTable: "R_REPORTING_PRODUCT",
                        principalColumn: "R_REPORTING_PRODUCT_ID");
                });

            migrationBuilder.CreateTable(
                name: "FLUID_SAMPLE",
                columns: table => new
                {
                    FLUID_SAMPLE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SAMPLE_NUMBER = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SAMPLE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PROD_ENTITY_ID = table.Column<int>(type: "int", nullable: false),
                    R_FLUID_SAMPLE_METHOD_ID = table.Column<int>(type: "int", nullable: true),
                    R_PRODUCT_ID = table.Column<int>(type: "int", nullable: true),
                    ACQUISITION_DEPTH = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: true),
                    ACQUISITION_PRESSURE = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: true),
                    ACQUISITION_TEMPERATURE = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    ACQUISITION_VOLUME = table.Column<decimal>(type: "decimal(14,4)", precision: 14, scale: 4, nullable: true),
                    SERVICE_COMPANY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IS_REPRESENTATIVE = table.Column<bool>(type: "bit", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FLUID_SAMPLE", x => x.FLUID_SAMPLE_ID);
                    table.ForeignKey(
                        name: "FK_FLUID_SAMPLE_REPORTING_ENTITY_PROD_ENTITY_ID",
                        column: x => x.PROD_ENTITY_ID,
                        principalTable: "REPORTING_ENTITY",
                        principalColumn: "REPORTING_ENTITY_ID");
                    table.ForeignKey(
                        name: "FK_FLUID_SAMPLE_R_FLUID_SAMPLE_METHOD_R_FLUID_SAMPLE_METHOD_ID",
                        column: x => x.R_FLUID_SAMPLE_METHOD_ID,
                        principalTable: "R_FLUID_SAMPLE_METHOD",
                        principalColumn: "R_FLUID_SAMPLE_METHOD_ID");
                    table.ForeignKey(
                        name: "FK_FLUID_SAMPLE_R_REPORTING_PRODUCT_R_PRODUCT_ID",
                        column: x => x.R_PRODUCT_ID,
                        principalTable: "R_REPORTING_PRODUCT",
                        principalColumn: "R_REPORTING_PRODUCT_ID");
                });

            migrationBuilder.CreateTable(
                name: "PROD_DECLINE_SEGMENT",
                columns: table => new
                {
                    PROD_DECLINE_SEGMENT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PROD_DECLINE_FORECAST_ID = table.Column<int>(type: "int", nullable: false),
                    SEGMENT_SEQUENCE = table.Column<int>(type: "int", nullable: false),
                    R_PRODUCT_ID = table.Column<int>(type: "int", nullable: false),
                    START_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    END_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    R_DECLINE_CURVE_TYPE_ID = table.Column<int>(type: "int", nullable: true),
                    R_DECLINE_TYPE_ID = table.Column<int>(type: "int", nullable: true),
                    R_RATIO_FLUID_TYPE_ID = table.Column<int>(type: "int", nullable: true),
                    R_RATIO_CURVE_TYPE_ID = table.Column<int>(type: "int", nullable: true),
                    PARENT_PROD_DECLINE_SEGMENT_ID = table.Column<int>(type: "int", nullable: true),
                    VOLUME = table.Column<decimal>(type: "decimal(14,4)", precision: 14, scale: 4, nullable: true),
                    VOLUME_UOM = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROD_DECLINE_SEGMENT", x => x.PROD_DECLINE_SEGMENT_ID);
                    table.ForeignKey(
                        name: "FK_PROD_DECLINE_SEGMENT_PROD_DECLINE_FORECAST_PROD_DECLINE_FORECAST_ID",
                        column: x => x.PROD_DECLINE_FORECAST_ID,
                        principalTable: "PROD_DECLINE_FORECAST",
                        principalColumn: "PROD_DECLINE_FORECAST_ID");
                    table.ForeignKey(
                        name: "FK_PROD_DECLINE_SEGMENT_PROD_DECLINE_SEGMENT_PARENT_PROD_DECLINE_SEGMENT_ID",
                        column: x => x.PARENT_PROD_DECLINE_SEGMENT_ID,
                        principalTable: "PROD_DECLINE_SEGMENT",
                        principalColumn: "PROD_DECLINE_SEGMENT_ID");
                    table.ForeignKey(
                        name: "FK_PROD_DECLINE_SEGMENT_R_DECLINE_CURVE_TYPE_R_DECLINE_CURVE_TYPE_ID",
                        column: x => x.R_DECLINE_CURVE_TYPE_ID,
                        principalTable: "R_DECLINE_CURVE_TYPE",
                        principalColumn: "R_DECLINE_CURVE_TYPE_ID");
                    table.ForeignKey(
                        name: "FK_PROD_DECLINE_SEGMENT_R_DECLINE_TYPE_R_DECLINE_TYPE_ID",
                        column: x => x.R_DECLINE_TYPE_ID,
                        principalTable: "R_DECLINE_TYPE",
                        principalColumn: "R_DECLINE_TYPE_ID");
                    table.ForeignKey(
                        name: "FK_PROD_DECLINE_SEGMENT_R_RATIO_CURVE_TYPE_R_RATIO_CURVE_TYPE_ID",
                        column: x => x.R_RATIO_CURVE_TYPE_ID,
                        principalTable: "R_RATIO_CURVE_TYPE",
                        principalColumn: "R_RATIO_CURVE_TYPE_ID");
                    table.ForeignKey(
                        name: "FK_PROD_DECLINE_SEGMENT_R_RATIO_FLUID_TYPE_R_RATIO_FLUID_TYPE_ID",
                        column: x => x.R_RATIO_FLUID_TYPE_ID,
                        principalTable: "R_RATIO_FLUID_TYPE",
                        principalColumn: "R_RATIO_FLUID_TYPE_ID");
                    table.ForeignKey(
                        name: "FK_PROD_DECLINE_SEGMENT_R_REPORTING_PRODUCT_R_PRODUCT_ID",
                        column: x => x.R_PRODUCT_ID,
                        principalTable: "R_REPORTING_PRODUCT",
                        principalColumn: "R_REPORTING_PRODUCT_ID");
                });

            migrationBuilder.CreateTable(
                name: "PROD_DOWN_TIME_VOLUME_LOSS",
                columns: table => new
                {
                    PROD_DOWN_TIME_VOLUME_LOSS_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PROD_DOWN_TIME_EVENT_ID = table.Column<int>(type: "int", nullable: false),
                    R_FLOW_KIND_ID = table.Column<int>(type: "int", nullable: true),
                    R_PRODUCT_ID = table.Column<int>(type: "int", nullable: false),
                    LOST_VOLUME = table.Column<decimal>(type: "decimal(14,4)", precision: 14, scale: 4, nullable: true),
                    LOST_VOLUME_UOM = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    R_ESTIMATION_METHOD_ID = table.Column<int>(type: "int", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROD_DOWN_TIME_VOLUME_LOSS", x => x.PROD_DOWN_TIME_VOLUME_LOSS_ID);
                    table.ForeignKey(
                        name: "FK_PROD_DOWN_TIME_VOLUME_LOSS_PROD_DOWN_TIME_EVENT_PROD_DOWN_TIME_EVENT_ID",
                        column: x => x.PROD_DOWN_TIME_EVENT_ID,
                        principalTable: "PROD_DOWN_TIME_EVENT",
                        principalColumn: "PROD_DOWN_TIME_EVENT_ID");
                    table.ForeignKey(
                        name: "FK_PROD_DOWN_TIME_VOLUME_LOSS_R_ESTIMATION_METHOD_R_ESTIMATION_METHOD_ID",
                        column: x => x.R_ESTIMATION_METHOD_ID,
                        principalTable: "R_ESTIMATION_METHOD",
                        principalColumn: "R_ESTIMATION_METHOD_ID");
                    table.ForeignKey(
                        name: "FK_PROD_DOWN_TIME_VOLUME_LOSS_R_REPORTING_FLOW_R_FLOW_KIND_ID",
                        column: x => x.R_FLOW_KIND_ID,
                        principalTable: "R_REPORTING_FLOW",
                        principalColumn: "R_REPORTING_FLOW_ID");
                    table.ForeignKey(
                        name: "FK_PROD_DOWN_TIME_VOLUME_LOSS_R_REPORTING_PRODUCT_R_PRODUCT_ID",
                        column: x => x.R_PRODUCT_ID,
                        principalTable: "R_REPORTING_PRODUCT",
                        principalColumn: "R_REPORTING_PRODUCT_ID");
                });

            migrationBuilder.CreateTable(
                name: "PROD_HAUL_EVENT",
                columns: table => new
                {
                    PROD_HAUL_EVENT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EVENT_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    REPORTING_ENTITY_ID = table.Column<int>(type: "int", nullable: false),
                    R_PRODUCT_ID = table.Column<int>(type: "int", nullable: false),
                    R_HAUL_EVENT_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    CARGO_NUMBER = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FROM_OR_TO_ENTITY_ID = table.Column<int>(type: "int", nullable: true),
                    IS_DOWN_STREAM = table.Column<bool>(type: "bit", nullable: true),
                    FROM_OR_TO_ORG_UNIT_ID = table.Column<int>(type: "int", nullable: true),
                    R_FLOW_PART_ID = table.Column<int>(type: "int", nullable: true),
                    R_REPORTING_FLOW_ID = table.Column<int>(type: "int", nullable: true),
                    REPORTED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SHIPPER_ID = table.Column<int>(type: "int", nullable: true),
                    CARRIER_ID = table.Column<int>(type: "int", nullable: true),
                    SEAL_ON = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SEAL_OFF = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GROSS_VOLUME = table.Column<decimal>(type: "decimal(14,4)", precision: 14, scale: 4, nullable: true),
                    GROSS_VOLUME_UOM = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    R_NET_VOLUME_METHOD_ID = table.Column<int>(type: "int", nullable: true),
                    NET_VOLUME = table.Column<decimal>(type: "decimal(14,4)", precision: 14, scale: 4, nullable: true),
                    NET_VOLUME_UOM = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROD_HAUL_EVENT", x => x.PROD_HAUL_EVENT_ID);
                    table.ForeignKey(
                        name: "FK_PROD_HAUL_EVENT_ORG_UNIT_CARRIER_ID",
                        column: x => x.CARRIER_ID,
                        principalTable: "ORG_UNIT",
                        principalColumn: "ORG_UNIT_ID");
                    table.ForeignKey(
                        name: "FK_PROD_HAUL_EVENT_ORG_UNIT_FROM_OR_TO_ORG_UNIT_ID",
                        column: x => x.FROM_OR_TO_ORG_UNIT_ID,
                        principalTable: "ORG_UNIT",
                        principalColumn: "ORG_UNIT_ID");
                    table.ForeignKey(
                        name: "FK_PROD_HAUL_EVENT_ORG_UNIT_SHIPPER_ID",
                        column: x => x.SHIPPER_ID,
                        principalTable: "ORG_UNIT",
                        principalColumn: "ORG_UNIT_ID");
                    table.ForeignKey(
                        name: "FK_PROD_HAUL_EVENT_REPORTING_ENTITY_FROM_OR_TO_ENTITY_ID",
                        column: x => x.FROM_OR_TO_ENTITY_ID,
                        principalTable: "REPORTING_ENTITY",
                        principalColumn: "REPORTING_ENTITY_ID");
                    table.ForeignKey(
                        name: "FK_PROD_HAUL_EVENT_REPORTING_ENTITY_REPORTING_ENTITY_ID",
                        column: x => x.REPORTING_ENTITY_ID,
                        principalTable: "REPORTING_ENTITY",
                        principalColumn: "REPORTING_ENTITY_ID");
                    table.ForeignKey(
                        name: "FK_PROD_HAUL_EVENT_R_FLOW_PART_R_FLOW_PART_ID",
                        column: x => x.R_FLOW_PART_ID,
                        principalTable: "R_FLOW_PART",
                        principalColumn: "R_FLOW_PART_ID");
                    table.ForeignKey(
                        name: "FK_PROD_HAUL_EVENT_R_HAUL_EVENT_TYPE_R_HAUL_EVENT_TYPE_ID",
                        column: x => x.R_HAUL_EVENT_TYPE_ID,
                        principalTable: "R_HAUL_EVENT_TYPE",
                        principalColumn: "R_HAUL_EVENT_TYPE_ID");
                    table.ForeignKey(
                        name: "FK_PROD_HAUL_EVENT_R_NET_VOLUME_METHOD_R_NET_VOLUME_METHOD_ID",
                        column: x => x.R_NET_VOLUME_METHOD_ID,
                        principalTable: "R_NET_VOLUME_METHOD",
                        principalColumn: "R_NET_VOLUME_METHOD_ID");
                    table.ForeignKey(
                        name: "FK_PROD_HAUL_EVENT_R_REPORTING_FLOW_R_REPORTING_FLOW_ID",
                        column: x => x.R_REPORTING_FLOW_ID,
                        principalTable: "R_REPORTING_FLOW",
                        principalColumn: "R_REPORTING_FLOW_ID");
                    table.ForeignKey(
                        name: "FK_PROD_HAUL_EVENT_R_REPORTING_PRODUCT_R_PRODUCT_ID",
                        column: x => x.R_PRODUCT_ID,
                        principalTable: "R_REPORTING_PRODUCT",
                        principalColumn: "R_REPORTING_PRODUCT_ID");
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT_VOLUME_SUMMARY",
                columns: table => new
                {
                    PRODUCT_VOLUME_SUMMARY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REPORTING_ENTITY_ID = table.Column<int>(type: "int", nullable: false),
                    REPORTING_ENTITY_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    START_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    END_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    R_PERIOD_KIND_ID = table.Column<int>(type: "int", nullable: false),
                    PERIOD_KIND = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    R_REPORTING_FLOW_ID = table.Column<int>(type: "int", nullable: false),
                    REPORTING_FLOW = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    R_REPORTING_PRODUCT_ID = table.Column<int>(type: "int", nullable: false),
                    PRODUCT = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    R_QUANTITY_METHOD_ID = table.Column<int>(type: "int", nullable: false),
                    QUANTITY_METHOD = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    AMENDMENT_SEQ_NO = table.Column<int>(type: "int", nullable: false),
                    SCENARIO_ID = table.Column<int>(type: "int", nullable: true),
                    VOLUME = table.Column<decimal>(type: "decimal(14,4)", precision: 14, scale: 4, nullable: true),
                    VOLUME_UOM = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    PRESSURE_TEMPERATURE_ID = table.Column<int>(type: "int", nullable: false),
                    TEMPERATURE = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: false),
                    PRESSURE = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: false),
                    MASS = table.Column<decimal>(type: "decimal(14,4)", precision: 14, scale: 4, nullable: true),
                    MASS_UOM = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    ENERGY = table.Column<decimal>(type: "decimal(14,4)", precision: 14, scale: 4, nullable: true),
                    ENERGY_UOM = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    R_AMEND_REASON_ID = table.Column<int>(type: "int", nullable: true),
                    AMEND_REASON = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MOLES = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    MOLSE_UOM = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARKS = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT_VOLUME_SUMMARY", x => x.PRODUCT_VOLUME_SUMMARY_ID);
                    table.ForeignKey(
                        name: "FK_PRODUCT_VOLUME_SUMMARY_PRESSURE_TEMPERATURE_PRESSURE_TEMPERATURE_ID",
                        column: x => x.PRESSURE_TEMPERATURE_ID,
                        principalTable: "PRESSURE_TEMPERATURE",
                        principalColumn: "PRESSURE_TEMPERATURE_ID");
                    table.ForeignKey(
                        name: "FK_PRODUCT_VOLUME_SUMMARY_REPORTING_ENTITY_REPORTING_ENTITY_ID",
                        column: x => x.REPORTING_ENTITY_ID,
                        principalTable: "REPORTING_ENTITY",
                        principalColumn: "REPORTING_ENTITY_ID");
                    table.ForeignKey(
                        name: "FK_PRODUCT_VOLUME_SUMMARY_R_AMEND_REASON_R_AMEND_REASON_ID",
                        column: x => x.R_AMEND_REASON_ID,
                        principalTable: "R_AMEND_REASON",
                        principalColumn: "R_AMEND_REASON_ID");
                    table.ForeignKey(
                        name: "FK_PRODUCT_VOLUME_SUMMARY_R_PERIOD_KIND_R_PERIOD_KIND_ID",
                        column: x => x.R_PERIOD_KIND_ID,
                        principalTable: "R_PERIOD_KIND",
                        principalColumn: "R_PERIOD_KIND_ID");
                    table.ForeignKey(
                        name: "FK_PRODUCT_VOLUME_SUMMARY_R_QUANTITY_METHOD_R_QUANTITY_METHOD_ID",
                        column: x => x.R_QUANTITY_METHOD_ID,
                        principalTable: "R_QUANTITY_METHOD",
                        principalColumn: "R_QUANTITY_METHOD_ID");
                    table.ForeignKey(
                        name: "FK_PRODUCT_VOLUME_SUMMARY_R_REPORTING_FLOW_R_REPORTING_FLOW_ID",
                        column: x => x.R_REPORTING_FLOW_ID,
                        principalTable: "R_REPORTING_FLOW",
                        principalColumn: "R_REPORTING_FLOW_ID");
                    table.ForeignKey(
                        name: "FK_PRODUCT_VOLUME_SUMMARY_R_REPORTING_PRODUCT_R_REPORTING_PRODUCT_ID",
                        column: x => x.R_REPORTING_PRODUCT_ID,
                        principalTable: "R_REPORTING_PRODUCT",
                        principalColumn: "R_REPORTING_PRODUCT_ID");
                    table.ForeignKey(
                        name: "FK_PRODUCT_VOLUME_SUMMARY_SCENARIO_SCENARIO_ID",
                        column: x => x.SCENARIO_ID,
                        principalTable: "SCENARIO",
                        principalColumn: "SCENARIO_ID");
                });

            migrationBuilder.CreateTable(
                name: "RPEN_ALLOCATION_FACTOR",
                columns: table => new
                {
                    RPEN_ALLOCATION_FACTOR_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TO_REPORTING_ENTITY_ID = table.Column<int>(type: "int", nullable: false),
                    FROM_REPORTING_ENTITY_ID = table.Column<int>(type: "int", nullable: false),
                    R_REPORTING_PRODUCT_ID = table.Column<int>(type: "int", nullable: false),
                    R_REPORTING_FLOW_ID = table.Column<int>(type: "int", nullable: true),
                    ALLOCATION_FACTOR = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    R_ALLOCATION_TYPE_ID = table.Column<int>(type: "int", nullable: true),
                    CALCULATED_FROM = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    EFFECTIVE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_RPEN_ALLOCATION_FACTOR", x => x.RPEN_ALLOCATION_FACTOR_ID);
                    table.ForeignKey(
                        name: "FK_RPEN_ALLOCATION_FACTOR_REPORTING_ENTITY_FROM_REPORTING_ENTITY_ID",
                        column: x => x.FROM_REPORTING_ENTITY_ID,
                        principalTable: "REPORTING_ENTITY",
                        principalColumn: "REPORTING_ENTITY_ID");
                    table.ForeignKey(
                        name: "FK_RPEN_ALLOCATION_FACTOR_REPORTING_ENTITY_TO_REPORTING_ENTITY_ID",
                        column: x => x.TO_REPORTING_ENTITY_ID,
                        principalTable: "REPORTING_ENTITY",
                        principalColumn: "REPORTING_ENTITY_ID");
                    table.ForeignKey(
                        name: "FK_RPEN_ALLOCATION_FACTOR_R_ALLOCATION_TYPE_R_ALLOCATION_TYPE_ID",
                        column: x => x.R_ALLOCATION_TYPE_ID,
                        principalTable: "R_ALLOCATION_TYPE",
                        principalColumn: "R_ALLOCATION_TYPE_ID");
                    table.ForeignKey(
                        name: "FK_RPEN_ALLOCATION_FACTOR_R_REPORTING_FLOW_R_REPORTING_FLOW_ID",
                        column: x => x.R_REPORTING_FLOW_ID,
                        principalTable: "R_REPORTING_FLOW",
                        principalColumn: "R_REPORTING_FLOW_ID");
                    table.ForeignKey(
                        name: "FK_RPEN_ALLOCATION_FACTOR_R_REPORTING_PRODUCT_R_REPORTING_PRODUCT_ID",
                        column: x => x.R_REPORTING_PRODUCT_ID,
                        principalTable: "R_REPORTING_PRODUCT",
                        principalColumn: "R_REPORTING_PRODUCT_ID");
                });

            migrationBuilder.CreateTable(
                name: "WELL_TEST_ALLOCATION_FACTOR",
                columns: table => new
                {
                    WELL_TEST_ALLOCATION_FACTOR_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WELL_TEST_ID = table.Column<int>(type: "int", nullable: false),
                    TO_ENTITY_ID = table.Column<int>(type: "int", nullable: false),
                    ALLOCATION_FACTOR = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    EFFECTIVE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EXPIRY_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    R_REPORTING_PRODUCT_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WELL_TEST_ALLOCATION_FACTOR", x => x.WELL_TEST_ALLOCATION_FACTOR_ID);
                    table.ForeignKey(
                        name: "FK_WELL_TEST_ALLOCATION_FACTOR_REPORTING_ENTITY_TO_ENTITY_ID",
                        column: x => x.TO_ENTITY_ID,
                        principalTable: "REPORTING_ENTITY",
                        principalColumn: "REPORTING_ENTITY_ID");
                    table.ForeignKey(
                        name: "FK_WELL_TEST_ALLOCATION_FACTOR_R_REPORTING_PRODUCT_R_REPORTING_PRODUCT_ID",
                        column: x => x.R_REPORTING_PRODUCT_ID,
                        principalTable: "R_REPORTING_PRODUCT",
                        principalColumn: "R_REPORTING_PRODUCT_ID");
                    table.ForeignKey(
                        name: "FK_WELL_TEST_ALLOCATION_FACTOR_WELL_TEST_WELL_TEST_ID",
                        column: x => x.WELL_TEST_ID,
                        principalTable: "WELL_TEST",
                        principalColumn: "WELL_TEST_ID");
                });

            migrationBuilder.CreateTable(
                name: "WELL_TEST_FLOW_PERIOD",
                columns: table => new
                {
                    WELL_TEST_FLOW_PERIOD_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WELL_TEST_ID = table.Column<int>(type: "int", nullable: false),
                    FLOW_PERIOD = table.Column<int>(type: "int", nullable: false),
                    START_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    END_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TEST_DURATION = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WELL_TEST_FLOW_PERIOD", x => x.WELL_TEST_FLOW_PERIOD_ID);
                    table.ForeignKey(
                        name: "FK_WELL_TEST_FLOW_PERIOD_WELL_TEST_WELL_TEST_ID",
                        column: x => x.WELL_TEST_ID,
                        principalTable: "WELL_TEST",
                        principalColumn: "WELL_TEST_ID");
                });

            migrationBuilder.CreateTable(
                name: "ALARM_DETAIL",
                columns: table => new
                {
                    ALARM_DETAIL_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ALARM_ID = table.Column<int>(type: "int", nullable: false),
                    ALARM_DESCRIPTION = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TAGS_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALARM_DETAIL", x => x.ALARM_DETAIL_ID);
                    table.ForeignKey(
                        name: "FK_ALARM_DETAIL_ALARM_ALARM_ID",
                        column: x => x.ALARM_ID,
                        principalTable: "ALARM",
                        principalColumn: "ALARM_ID");
                });

            migrationBuilder.CreateTable(
                name: "FLUID_ANALYSIS_SAMPLE",
                columns: table => new
                {
                    FLUID_ANALYSIS_SAMPLE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FLUID_SAMPLE_ID = table.Column<int>(type: "int", nullable: false),
                    FLUID_ANALYSIS_ID = table.Column<int>(type: "int", nullable: false),
                    FROM_CYLINDER_NUMBER = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TO_CYLINDER_NUMBER = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TRANSFER_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TRANSFER_PRESSURE = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: true),
                    TRANSFER_TEMPERATURE = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    TRANSFER_VOLUME = table.Column<decimal>(type: "decimal(14,4)", precision: 14, scale: 4, nullable: true),
                    REMAINING_VOLUME = table.Column<decimal>(type: "decimal(14,4)", precision: 14, scale: 4, nullable: true),
                    LAB_BUBBLE_POINT_PRESSURE = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: true),
                    LAB_BUBBLE_POINT_TEMPERATURE = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    OPENING_PRESSURE = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: true),
                    OPENING_TEMPERATURE = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    IS_VALID = table.Column<bool>(type: "bit", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FLUID_ANALYSIS_SAMPLE", x => x.FLUID_ANALYSIS_SAMPLE_ID);
                    table.ForeignKey(
                        name: "FK_FLUID_ANALYSIS_SAMPLE_FLUID_ANALYSIS_FLUID_ANALYSIS_ID",
                        column: x => x.FLUID_ANALYSIS_ID,
                        principalTable: "FLUID_ANALYSIS",
                        principalColumn: "FLUID_ANALYSIS_ID");
                    table.ForeignKey(
                        name: "FK_FLUID_ANALYSIS_SAMPLE_FLUID_SAMPLE_FLUID_SAMPLE_ID",
                        column: x => x.FLUID_SAMPLE_ID,
                        principalTable: "FLUID_SAMPLE",
                        principalColumn: "FLUID_SAMPLE_ID");
                });

            migrationBuilder.CreateTable(
                name: "FLUID_SAMPLE_DETAIL",
                columns: table => new
                {
                    FLUID_SAMPLE_DETAIL_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FLUID_SAMPLE_ID = table.Column<int>(type: "int", nullable: false),
                    R_MEASUREMENT_ID = table.Column<int>(type: "int", nullable: false),
                    VALUE = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: true),
                    VALUE_UOM = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FLUID_SAMPLE_DETAIL", x => x.FLUID_SAMPLE_DETAIL_ID);
                    table.ForeignKey(
                        name: "FK_FLUID_SAMPLE_DETAIL_FLUID_SAMPLE_FLUID_SAMPLE_ID",
                        column: x => x.FLUID_SAMPLE_ID,
                        principalTable: "FLUID_SAMPLE",
                        principalColumn: "FLUID_SAMPLE_ID");
                    table.ForeignKey(
                        name: "FK_FLUID_SAMPLE_DETAIL_R_MEASUREMENT_R_MEASUREMENT_ID",
                        column: x => x.R_MEASUREMENT_ID,
                        principalTable: "R_MEASUREMENT",
                        principalColumn: "R_MEASUREMENT_ID");
                });

            migrationBuilder.CreateTable(
                name: "PROD_DECLINE_METHOD_PARM",
                columns: table => new
                {
                    PROD_DECLINE_METHOD_PARM_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PROD_DECLINE_SEGMENT_ID = table.Column<int>(type: "int", nullable: false),
                    R_DECLINE_PARM_ID = table.Column<int>(type: "int", nullable: false),
                    VALUE = table.Column<decimal>(type: "decimal(14,4)", precision: 14, scale: 4, nullable: true),
                    VALUE_UOM = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROD_DECLINE_METHOD_PARM", x => x.PROD_DECLINE_METHOD_PARM_ID);
                    table.ForeignKey(
                        name: "FK_PROD_DECLINE_METHOD_PARM_PROD_DECLINE_SEGMENT_PROD_DECLINE_SEGMENT_ID",
                        column: x => x.PROD_DECLINE_SEGMENT_ID,
                        principalTable: "PROD_DECLINE_SEGMENT",
                        principalColumn: "PROD_DECLINE_SEGMENT_ID");
                    table.ForeignKey(
                        name: "FK_PROD_DECLINE_METHOD_PARM_R_DECLINE_PARM_R_DECLINE_PARM_ID",
                        column: x => x.R_DECLINE_PARM_ID,
                        principalTable: "R_DECLINE_PARM",
                        principalColumn: "R_DECLINE_PARM_ID");
                });

            migrationBuilder.CreateTable(
                name: "PROD_HAUL_VOLUME_DETAIL",
                columns: table => new
                {
                    PROD_HAUL_VOLUME_DETAIL_ID = table.Column<int>(name: "PROD_HAUL_VOLUME _DETAIL_ID", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PROD_HAUL_EVENT_ID = table.Column<int>(type: "int", nullable: false),
                    BEGINNING_HEIGHT = table.Column<decimal>(type: "decimal(14,4)", precision: 14, scale: 4, nullable: true),
                    ENDING_HEIGHT = table.Column<decimal>(type: "decimal(14,4)", precision: 14, scale: 4, nullable: true),
                    BEGINNING_INVENTORY = table.Column<decimal>(type: "decimal(14,4)", precision: 14, scale: 4, nullable: true),
                    ENDING_INVENTORY = table.Column<decimal>(type: "decimal(14,4)", precision: 14, scale: 4, nullable: true),
                    BEGINNING_TEMP = table.Column<decimal>(type: "decimal(14,4)", precision: 14, scale: 4, nullable: true),
                    ENDING_TEMP = table.Column<decimal>(type: "decimal(14,4)", precision: 14, scale: 4, nullable: true),
                    OBSERVED_TEMP = table.Column<decimal>(type: "decimal(14,4)", precision: 14, scale: 4, nullable: true),
                    DENSITY = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    FREE_WATER_PERCENT = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    FREE_EMULSION_PERCENT = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    SEDIMENT_WATER_CONTENT = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROD_HAUL_VOLUME_DETAIL", x => x.PROD_HAUL_VOLUME_DETAIL_ID);
                    table.ForeignKey(
                        name: "FK_PROD_HAUL_VOLUME_DETAIL_PROD_HAUL_EVENT_PROD_HAUL_EVENT_ID",
                        column: x => x.PROD_HAUL_EVENT_ID,
                        principalTable: "PROD_HAUL_EVENT",
                        principalColumn: "PROD_HAUL_EVENT_ID");
                });

            migrationBuilder.CreateTable(
                name: "PROD_SALE_STATEMENT",
                columns: table => new
                {
                    PROD_SALE_STATEMENT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    START_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    END_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    REPORTING_ENTITY_ID = table.Column<int>(type: "int", nullable: false),
                    R_PRODUCT_ID = table.Column<int>(type: "int", nullable: false),
                    SALE_GROSS_VOLUME = table.Column<decimal>(type: "decimal(14,4)", precision: 14, scale: 4, nullable: true),
                    SALE_GROSS_VOLUME_UOM = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    SALE_NET_VOLUME = table.Column<decimal>(type: "decimal(14,4)", precision: 14, scale: 4, nullable: true),
                    SALE_NET_VOLUME_UOM = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    PROD_HAUL_EVENT_ID = table.Column<int>(type: "int", nullable: true),
                    SELLER_ID = table.Column<int>(type: "int", nullable: true),
                    PURCHASER_ID = table.Column<int>(type: "int", nullable: true),
                    SALES_ADMINISTRATOR_ID = table.Column<int>(type: "int", nullable: true),
                    PRESSURE_TEMPERATURE_ID = table.Column<int>(type: "int", nullable: true),
                    WET_BASIS = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    HEAT_CONTENT = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    PRICE_PER_UNIT = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROD_SALE_STATEMENT", x => x.PROD_SALE_STATEMENT_ID);
                    table.ForeignKey(
                        name: "FK_PROD_SALE_STATEMENT_ORG_UNIT_PURCHASER_ID",
                        column: x => x.PURCHASER_ID,
                        principalTable: "ORG_UNIT",
                        principalColumn: "ORG_UNIT_ID");
                    table.ForeignKey(
                        name: "FK_PROD_SALE_STATEMENT_ORG_UNIT_SALES_ADMINISTRATOR_ID",
                        column: x => x.SALES_ADMINISTRATOR_ID,
                        principalTable: "ORG_UNIT",
                        principalColumn: "ORG_UNIT_ID");
                    table.ForeignKey(
                        name: "FK_PROD_SALE_STATEMENT_ORG_UNIT_SELLER_ID",
                        column: x => x.SELLER_ID,
                        principalTable: "ORG_UNIT",
                        principalColumn: "ORG_UNIT_ID");
                    table.ForeignKey(
                        name: "FK_PROD_SALE_STATEMENT_PRESSURE_TEMPERATURE_PRESSURE_TEMPERATURE_ID",
                        column: x => x.PRESSURE_TEMPERATURE_ID,
                        principalTable: "PRESSURE_TEMPERATURE",
                        principalColumn: "PRESSURE_TEMPERATURE_ID");
                    table.ForeignKey(
                        name: "FK_PROD_SALE_STATEMENT_PROD_HAUL_EVENT_PROD_HAUL_EVENT_ID",
                        column: x => x.PROD_HAUL_EVENT_ID,
                        principalTable: "PROD_HAUL_EVENT",
                        principalColumn: "PROD_HAUL_EVENT_ID");
                    table.ForeignKey(
                        name: "FK_PROD_SALE_STATEMENT_REPORTING_ENTITY_REPORTING_ENTITY_ID",
                        column: x => x.REPORTING_ENTITY_ID,
                        principalTable: "REPORTING_ENTITY",
                        principalColumn: "REPORTING_ENTITY_ID");
                    table.ForeignKey(
                        name: "FK_PROD_SALE_STATEMENT_R_REPORTING_PRODUCT_R_PRODUCT_ID",
                        column: x => x.R_PRODUCT_ID,
                        principalTable: "R_REPORTING_PRODUCT",
                        principalColumn: "R_REPORTING_PRODUCT_ID");
                });

            migrationBuilder.CreateTable(
                name: "WELL_TEST_FLOW_MEASUREMENT",
                columns: table => new
                {
                    WELL_TEST_FLOW_MEASUREMENT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WELL_TEST_FLOW_PERIOD_ID = table.Column<int>(type: "int", nullable: false),
                    R_FLOW_KIND_ID = table.Column<int>(type: "int", nullable: false),
                    RATE = table.Column<decimal>(type: "decimal(14,4)", precision: 14, scale: 4, nullable: true),
                    RATE_UOM = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    VOLUME = table.Column<decimal>(type: "decimal(14,4)", precision: 14, scale: 4, nullable: true),
                    VOLUME_UOM = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    REPORTING_FLOW = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    TEST_PRODUCT = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    WELL_TEST_ID = table.Column<int>(type: "int", nullable: false),
                    FLOW_PERIOD = table.Column<int>(type: "int", nullable: false),
                    R_REPORTING_PRODUCT_ID = table.Column<int>(type: "int", nullable: false),
                    PRODUCT = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WELL_TEST_FLOW_MEASUREMENT", x => x.WELL_TEST_FLOW_MEASUREMENT_ID);
                    table.ForeignKey(
                        name: "FK_WELL_TEST_FLOW_MEASUREMENT_R_REPORTING_FLOW_R_FLOW_KIND_ID",
                        column: x => x.R_FLOW_KIND_ID,
                        principalTable: "R_REPORTING_FLOW",
                        principalColumn: "R_REPORTING_FLOW_ID");
                    table.ForeignKey(
                        name: "FK_WELL_TEST_FLOW_MEASUREMENT_R_REPORTING_PRODUCT_R_REPORTING_PRODUCT_ID",
                        column: x => x.R_REPORTING_PRODUCT_ID,
                        principalTable: "R_REPORTING_PRODUCT",
                        principalColumn: "R_REPORTING_PRODUCT_ID");
                    table.ForeignKey(
                        name: "FK_WELL_TEST_FLOW_MEASUREMENT_WELL_TEST_FLOW_PERIOD_FLOW_PERIOD",
                        column: x => x.FLOW_PERIOD,
                        principalTable: "WELL_TEST_FLOW_PERIOD",
                        principalColumn: "WELL_TEST_FLOW_PERIOD_ID");
                    table.ForeignKey(
                        name: "FK_WELL_TEST_FLOW_MEASUREMENT_WELL_TEST_FLOW_PERIOD_WELL_TEST_FLOW_PERIOD_ID",
                        column: x => x.WELL_TEST_FLOW_PERIOD_ID,
                        principalTable: "WELL_TEST_FLOW_PERIOD",
                        principalColumn: "WELL_TEST_FLOW_PERIOD_ID");
                    table.ForeignKey(
                        name: "FK_WELL_TEST_FLOW_MEASUREMENT_WELL_TEST_FLOW_PERIOD_WELL_TEST_ID",
                        column: x => x.WELL_TEST_ID,
                        principalTable: "WELL_TEST_FLOW_PERIOD",
                        principalColumn: "WELL_TEST_FLOW_PERIOD_ID");
                });

            migrationBuilder.CreateTable(
                name: "WELL_TEST_MEASUREMENT",
                columns: table => new
                {
                    WELL_TEST_MEASUREMENT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WELL_TEST_FLOW_PERIOD_ID = table.Column<int>(type: "int", nullable: false),
                    R_MEASUREMENT_ID = table.Column<int>(type: "int", nullable: false),
                    VALUE = table.Column<decimal>(type: "decimal(14,4)", precision: 14, scale: 4, nullable: true),
                    VALUE_OUM = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    REMARK = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ROW_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CREATED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ROW_CHANGED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ROW_CHANGED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MEASUREMENT = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    WELL_TEST_ID = table.Column<int>(type: "int", nullable: false),
                    FLOW_PERIOD = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WELL_TEST_MEASUREMENT", x => x.WELL_TEST_MEASUREMENT_ID);
                    table.ForeignKey(
                        name: "FK_WELL_TEST_MEASUREMENT_R_MEASUREMENT_R_MEASUREMENT_ID",
                        column: x => x.R_MEASUREMENT_ID,
                        principalTable: "R_MEASUREMENT",
                        principalColumn: "R_MEASUREMENT_ID");
                    table.ForeignKey(
                        name: "FK_WELL_TEST_MEASUREMENT_WELL_TEST_FLOW_PERIOD_FLOW_PERIOD",
                        column: x => x.FLOW_PERIOD,
                        principalTable: "WELL_TEST_FLOW_PERIOD",
                        principalColumn: "WELL_TEST_FLOW_PERIOD_ID");
                    table.ForeignKey(
                        name: "FK_WELL_TEST_MEASUREMENT_WELL_TEST_FLOW_PERIOD_WELL_TEST_FLOW_PERIOD_ID",
                        column: x => x.WELL_TEST_FLOW_PERIOD_ID,
                        principalTable: "WELL_TEST_FLOW_PERIOD",
                        principalColumn: "WELL_TEST_FLOW_PERIOD_ID");
                    table.ForeignKey(
                        name: "FK_WELL_TEST_MEASUREMENT_WELL_TEST_FLOW_PERIOD_WELL_TEST_ID",
                        column: x => x.WELL_TEST_ID,
                        principalTable: "WELL_TEST_FLOW_PERIOD",
                        principalColumn: "WELL_TEST_FLOW_PERIOD_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ALARM_ALARM_SETTINGS_ID",
                table: "ALARM",
                column: "ALARM_SETTINGS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ALARM_R_ALARM_SUB_CATEGORY_ID",
                table: "ALARM",
                column: "R_ALARM_SUB_CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ALARM_R_EVENT_CATEGORY_ID",
                table: "ALARM",
                column: "R_EVENT_CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ALARM_R_EVENT_SUB_CATEGORY_ID",
                table: "ALARM",
                column: "R_EVENT_SUB_CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ALARM_STATUS_ID",
                table: "ALARM",
                column: "STATUS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ALARM_DETAIL_ALARM_ID",
                table: "ALARM_DETAIL",
                column: "ALARM_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ALARM_NOTIFICATION_EMAIL_CONFIG_ID",
                table: "ALARM_NOTIFICATION",
                column: "EMAIL_CONFIG_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ALARM_NOTIFICATION_R_ALARM_SUB_CATEGORY_ID",
                table: "ALARM_NOTIFICATION",
                column: "R_ALARM_SUB_CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EMAIL_CONFIG_ALARM_CATEGORY_ID",
                table: "EMAIL_CONFIG",
                column: "ALARM_CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EQUIPMENT_SUBTYPE_SPEC_R_EQUIPMENT_SPEC_ID",
                table: "EQUIPMENT_SUBTYPE_SPEC",
                column: "R_EQUIPMENT_SPEC_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EQUIPMENT_SUBTYPE_SPEC_R_EQUIPMENT_SUB_TYPE_ID",
                table: "EQUIPMENT_SUBTYPE_SPEC",
                column: "R_EQUIPMENT_SUB_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EQUIPMENT_TYPE_MEASUREMENT_R_EQUIPMENT_MEASUREMENT_ID",
                table: "EQUIPMENT_TYPE_MEASUREMENT",
                column: "R_EQUIPMENT_MEASUREMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EQUIPMENT_TYPE_MEASUREMENT_R_EQUIPMENT_TYPE_ID",
                table: "EQUIPMENT_TYPE_MEASUREMENT",
                column: "R_EQUIPMENT_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EQUIPMENT_TYPE_SPECIFICATION_R_EQUIPMENT_SPEC_ID",
                table: "EQUIPMENT_TYPE_SPECIFICATION",
                column: "R_EQUIPMENT_SPEC_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EQUIPMENT_TYPE_SPECIFICATION_R_EQUIPMENT_TYPE_ID",
                table: "EQUIPMENT_TYPE_SPECIFICATION",
                column: "R_EQUIPMENT_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLOW_PORT_ALIAS_FLOW_PORT_ID",
                table: "FLOW_PORT_ALIAS",
                column: "FLOW_PORT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLOW_PORT_EXPECTED_PROPERTY_FLOW_PORT_ID",
                table: "FLOW_PORT_EXPECTED_PROPERTY",
                column: "FLOW_PORT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLOW_PORT_EXPECTED_PROPERTY_R_FACILITY_PARAMETER_ID",
                table: "FLOW_PORT_EXPECTED_PROPERTY",
                column: "R_FACILITY_PARAMETER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLOW_PORT_NFP_TAG_ALIAS_FLOW_PORT_EXPECTED_PROPERTY_ID",
                table: "FLOW_PORT_NFP_TAG_ALIAS",
                column: "FLOW_PORT_EXPECTED_PROPERTY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLOW_PORT_PROPERTY_EXPECTED_FLOW_PRODUCT_FLOW_PORT_EXPECTED_PROPERTY_ID",
                table: "FLOW_PORT_PROPERTY_EXPECTED_FLOW_PRODUCT",
                column: "FLOW_PORT_EXPECTED_PROPERTY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLOW_PORT_PROPERTY_EXPECTED_FLOW_PRODUCT_R_FLOW_QUALIFIER_ID",
                table: "FLOW_PORT_PROPERTY_EXPECTED_FLOW_PRODUCT",
                column: "R_FLOW_QUALIFIER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLOW_PORT_PROPERTY_EXPECTED_FLOW_PRODUCT_R_REPORTING_FLOW_ID",
                table: "FLOW_PORT_PROPERTY_EXPECTED_FLOW_PRODUCT",
                column: "R_REPORTING_FLOW_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLOW_PORT_PROPERTY_EXPECTED_FLOW_PRODUCT_R_REPORTING_PRODUCT_ID",
                table: "FLOW_PORT_PROPERTY_EXPECTED_FLOW_PRODUCT",
                column: "R_REPORTING_PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLOW_UNIT_ALIAS_FLOW_UNIT_ID",
                table: "FLOW_UNIT_ALIAS",
                column: "FLOW_UNIT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLOW_UNIT_CONTEXT_FACILITY_FLOW_UNIT_ID",
                table: "FLOW_UNIT_CONTEXT_FACILITY",
                column: "FLOW_UNIT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLOW_UNIT_CONTEXT_FACILITY_REPORTING_FACILITY_ID",
                table: "FLOW_UNIT_CONTEXT_FACILITY",
                column: "REPORTING_FACILITY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLOW_UNIT_EXPECTED_FLOW_PRODUCT_FLOW_UNIT_EXPECTED_PROPERTY_ID",
                table: "FLOW_UNIT_EXPECTED_FLOW_PRODUCT",
                column: "FLOW_UNIT_EXPECTED_PROPERTY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLOW_UNIT_EXPECTED_FLOW_PRODUCT_R_FLOW_QUALIFIER_ID",
                table: "FLOW_UNIT_EXPECTED_FLOW_PRODUCT",
                column: "R_FLOW_QUALIFIER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLOW_UNIT_EXPECTED_FLOW_PRODUCT_R_REPORTING_FLOW_ID",
                table: "FLOW_UNIT_EXPECTED_FLOW_PRODUCT",
                column: "R_REPORTING_FLOW_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLOW_UNIT_EXPECTED_FLOW_PRODUCT_R_REPORTING_PRODUCT_ID",
                table: "FLOW_UNIT_EXPECTED_FLOW_PRODUCT",
                column: "R_REPORTING_PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLOW_UNIT_EXPECTED_PROPERTY_CHILD_FACILITY_ID",
                table: "FLOW_UNIT_EXPECTED_PROPERTY",
                column: "CHILD_FACILITY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLOW_UNIT_EXPECTED_PROPERTY_FLOW_UNIT_ID",
                table: "FLOW_UNIT_EXPECTED_PROPERTY",
                column: "FLOW_UNIT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLOW_UNIT_EXPECTED_PROPERTY_R_FACILITY_PARAMETER_ID",
                table: "FLOW_UNIT_EXPECTED_PROPERTY",
                column: "R_FACILITY_PARAMETER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLOW_UNIT_NFP_TAG_ALIAS_FLOW_UNIT_EXPECTED_PROPERTY_ID",
                table: "FLOW_UNIT_NFP_TAG_ALIAS",
                column: "FLOW_UNIT_EXPECTED_PROPERTY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLUID_ANALYSIS_PROD_ENTITY_ID",
                table: "FLUID_ANALYSIS",
                column: "PROD_ENTITY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLUID_ANALYSIS_PROPERTY_SUMMARY_FLUID_ANALYSIS_ID",
                table: "FLUID_ANALYSIS_PROPERTY_SUMMARY",
                column: "FLUID_ANALYSIS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLUID_ANALYSIS_PROPERTY_SUMMARY_R_FLUID_PROPERTY_ID",
                table: "FLUID_ANALYSIS_PROPERTY_SUMMARY",
                column: "R_FLUID_PROPERTY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLUID_ANALYSIS_PROPERTY_SUMMARY_R_PRODUCT_ID",
                table: "FLUID_ANALYSIS_PROPERTY_SUMMARY",
                column: "R_PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLUID_ANALYSIS_SAMPLE_FLUID_ANALYSIS_ID",
                table: "FLUID_ANALYSIS_SAMPLE",
                column: "FLUID_ANALYSIS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLUID_ANALYSIS_SAMPLE_FLUID_SAMPLE_ID",
                table: "FLUID_ANALYSIS_SAMPLE",
                column: "FLUID_SAMPLE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLUID_ANALYSIS_STEP_FLUID_ANALYSIS_ID",
                table: "FLUID_ANALYSIS_STEP",
                column: "FLUID_ANALYSIS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLUID_ANALYSIS_STEP_R_FLUID_ANALYSIS_METHOD_ID",
                table: "FLUID_ANALYSIS_STEP",
                column: "R_FLUID_ANALYSIS_METHOD_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLUID_COMPOSITION_ANALYSIS_FLUID_ANALYSIS_STEP_ID",
                table: "FLUID_COMPOSITION_ANALYSIS",
                column: "FLUID_ANALYSIS_STEP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLUID_COMPOSITION_ANALYSIS_R_FLUID_COMPONENT_ID",
                table: "FLUID_COMPOSITION_ANALYSIS",
                column: "R_FLUID_COMPONENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLUID_COMPOSITION_ANALYSIS_R_PRODUCT_ID",
                table: "FLUID_COMPOSITION_ANALYSIS",
                column: "R_PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLUID_RES_SURF_VOL_RELATION_FLUID_ANALYSIS_STEP_ID",
                table: "FLUID_RES_SURF_VOL_RELATION",
                column: "FLUID_ANALYSIS_STEP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLUID_SAMPLE_PROD_ENTITY_ID",
                table: "FLUID_SAMPLE",
                column: "PROD_ENTITY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLUID_SAMPLE_R_FLUID_SAMPLE_METHOD_ID",
                table: "FLUID_SAMPLE",
                column: "R_FLUID_SAMPLE_METHOD_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLUID_SAMPLE_R_PRODUCT_ID",
                table: "FLUID_SAMPLE",
                column: "R_PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLUID_SAMPLE_DETAIL_FLUID_SAMPLE_ID",
                table: "FLUID_SAMPLE_DETAIL",
                column: "FLUID_SAMPLE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLUID_SAMPLE_DETAIL_R_MEASUREMENT_ID",
                table: "FLUID_SAMPLE_DETAIL",
                column: "R_MEASUREMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLUID_SATURATION_PRESSURE_FLUID_ANALYSIS_STEP_ID",
                table: "FLUID_SATURATION_PRESSURE",
                column: "FLUID_ANALYSIS_STEP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLUID_SATURATION_PRESSURE_R_SATURATION_POINT_TYPE_ID",
                table: "FLUID_SATURATION_PRESSURE",
                column: "R_SATURATION_POINT_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_HIERARCHY_DESC_HIERARCHY_ID",
                table: "HIERARCHY_DESC",
                column: "HIERARCHY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_HIERARCHY_DESC_PARENT_HIERARCHY_DESC_ID",
                table: "HIERARCHY_DESC",
                column: "PARENT_HIERARCHY_DESC_ID");

            migrationBuilder.CreateIndex(
                name: "IX_HIERARCHY_DESC_R_ORG_UNIT_TYPE_ID",
                table: "HIERARCHY_DESC",
                column: "R_ORG_UNIT_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_HIERARCHY_LEVEL_HIERARCHY_DESC_ID",
                table: "HIERARCHY_LEVEL",
                column: "HIERARCHY_DESC_ID");

            migrationBuilder.CreateIndex(
                name: "IX_HIERARCHY_LEVEL_ORG_UNIT_ID",
                table: "HIERARCHY_LEVEL",
                column: "ORG_UNIT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_HIERARCHY_LEVEL_PARENT_HIERARCHY_LEVEL_ID",
                table: "HIERARCHY_LEVEL",
                column: "PARENT_HIERARCHY_LEVEL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_HIERARCHY_TEMPLATE_DESC_HIERARCHY_TEMPLATE_ID",
                table: "HIERARCHY_TEMPLATE_DESC",
                column: "HIERARCHY_TEMPLATE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_HIERARCHY_TEMPLATE_DESC_PARENT_HIERARCHY_TEMPLATE_DESC_ID",
                table: "HIERARCHY_TEMPLATE_DESC",
                column: "PARENT_HIERARCHY_TEMPLATE_DESC_ID");

            migrationBuilder.CreateIndex(
                name: "IX_HIERARCHY_TEMPLATE_DESC_R_ORG_UNIT_TYPE_ID",
                table: "HIERARCHY_TEMPLATE_DESC",
                column: "R_ORG_UNIT_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NETWORK_CHANGE_LOG_NETWORK_ID",
                table: "NETWORK_CHANGE_LOG",
                column: "NETWORK_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NETWORK_EXTERNAL_PORT_NETWORK_ID",
                table: "NETWORK_EXTERNAL_PORT",
                column: "NETWORK_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NETWORK_PLAN_CHANGE_LOG_NETWORK_PLAN_ID",
                table: "NETWORK_PLAN_CHANGE_LOG",
                column: "NETWORK_PLAN_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_DECLINE_FORECAST_PROD_ENTITY_ID",
                table: "PROD_DECLINE_FORECAST",
                column: "PROD_ENTITY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_DECLINE_FORECAST_R_DECLINE_METHOD_ID",
                table: "PROD_DECLINE_FORECAST",
                column: "R_DECLINE_METHOD_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_DECLINE_FORECAST_SCENARIO_ID",
                table: "PROD_DECLINE_FORECAST",
                column: "SCENARIO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_DECLINE_FORECAST_CLASS_PROD_DECLINE_FORECAST_ID",
                table: "PROD_DECLINE_FORECAST_CLASS",
                column: "PROD_DECLINE_FORECAST_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_DECLINE_FORECAST_CLASS_R_FORECAST_CLASS_ID",
                table: "PROD_DECLINE_FORECAST_CLASS",
                column: "R_FORECAST_CLASS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_DECLINE_METHOD_PARM_PROD_DECLINE_SEGMENT_ID",
                table: "PROD_DECLINE_METHOD_PARM",
                column: "PROD_DECLINE_SEGMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_DECLINE_METHOD_PARM_R_DECLINE_PARM_ID",
                table: "PROD_DECLINE_METHOD_PARM",
                column: "R_DECLINE_PARM_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_DECLINE_SEGMENT_PARENT_PROD_DECLINE_SEGMENT_ID",
                table: "PROD_DECLINE_SEGMENT",
                column: "PARENT_PROD_DECLINE_SEGMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_DECLINE_SEGMENT_PROD_DECLINE_FORECAST_ID",
                table: "PROD_DECLINE_SEGMENT",
                column: "PROD_DECLINE_FORECAST_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_DECLINE_SEGMENT_R_DECLINE_CURVE_TYPE_ID",
                table: "PROD_DECLINE_SEGMENT",
                column: "R_DECLINE_CURVE_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_DECLINE_SEGMENT_R_DECLINE_TYPE_ID",
                table: "PROD_DECLINE_SEGMENT",
                column: "R_DECLINE_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_DECLINE_SEGMENT_R_PRODUCT_ID",
                table: "PROD_DECLINE_SEGMENT",
                column: "R_PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_DECLINE_SEGMENT_R_RATIO_CURVE_TYPE_ID",
                table: "PROD_DECLINE_SEGMENT",
                column: "R_RATIO_CURVE_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_DECLINE_SEGMENT_R_RATIO_FLUID_TYPE_ID",
                table: "PROD_DECLINE_SEGMENT",
                column: "R_RATIO_FLUID_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_DOWN_TIME_VOLUME_LOSS_PROD_DOWN_TIME_EVENT_ID",
                table: "PROD_DOWN_TIME_VOLUME_LOSS",
                column: "PROD_DOWN_TIME_EVENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_DOWN_TIME_VOLUME_LOSS_R_ESTIMATION_METHOD_ID",
                table: "PROD_DOWN_TIME_VOLUME_LOSS",
                column: "R_ESTIMATION_METHOD_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_DOWN_TIME_VOLUME_LOSS_R_FLOW_KIND_ID",
                table: "PROD_DOWN_TIME_VOLUME_LOSS",
                column: "R_FLOW_KIND_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_DOWN_TIME_VOLUME_LOSS_R_PRODUCT_ID",
                table: "PROD_DOWN_TIME_VOLUME_LOSS",
                column: "R_PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_HAUL_EVENT_CARRIER_ID",
                table: "PROD_HAUL_EVENT",
                column: "CARRIER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_HAUL_EVENT_FROM_OR_TO_ENTITY_ID",
                table: "PROD_HAUL_EVENT",
                column: "FROM_OR_TO_ENTITY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_HAUL_EVENT_FROM_OR_TO_ORG_UNIT_ID",
                table: "PROD_HAUL_EVENT",
                column: "FROM_OR_TO_ORG_UNIT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_HAUL_EVENT_R_FLOW_PART_ID",
                table: "PROD_HAUL_EVENT",
                column: "R_FLOW_PART_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_HAUL_EVENT_R_HAUL_EVENT_TYPE_ID",
                table: "PROD_HAUL_EVENT",
                column: "R_HAUL_EVENT_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_HAUL_EVENT_R_NET_VOLUME_METHOD_ID",
                table: "PROD_HAUL_EVENT",
                column: "R_NET_VOLUME_METHOD_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_HAUL_EVENT_R_PRODUCT_ID",
                table: "PROD_HAUL_EVENT",
                column: "R_PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_HAUL_EVENT_R_REPORTING_FLOW_ID",
                table: "PROD_HAUL_EVENT",
                column: "R_REPORTING_FLOW_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_HAUL_EVENT_REPORTING_ENTITY_ID",
                table: "PROD_HAUL_EVENT",
                column: "REPORTING_ENTITY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_HAUL_EVENT_SHIPPER_ID",
                table: "PROD_HAUL_EVENT",
                column: "SHIPPER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_HAUL_VOLUME_DETAIL_PROD_HAUL_EVENT_ID",
                table: "PROD_HAUL_VOLUME_DETAIL",
                column: "PROD_HAUL_EVENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_SALE_STATEMENT_PRESSURE_TEMPERATURE_ID",
                table: "PROD_SALE_STATEMENT",
                column: "PRESSURE_TEMPERATURE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_SALE_STATEMENT_PROD_HAUL_EVENT_ID",
                table: "PROD_SALE_STATEMENT",
                column: "PROD_HAUL_EVENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_SALE_STATEMENT_PURCHASER_ID",
                table: "PROD_SALE_STATEMENT",
                column: "PURCHASER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_SALE_STATEMENT_R_PRODUCT_ID",
                table: "PROD_SALE_STATEMENT",
                column: "R_PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_SALE_STATEMENT_REPORTING_ENTITY_ID",
                table: "PROD_SALE_STATEMENT",
                column: "REPORTING_ENTITY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_SALE_STATEMENT_SALES_ADMINISTRATOR_ID",
                table: "PROD_SALE_STATEMENT",
                column: "SALES_ADMINISTRATOR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PROD_SALE_STATEMENT_SELLER_ID",
                table: "PROD_SALE_STATEMENT",
                column: "SELLER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_VOLUME_SUMMARY_PRESSURE_TEMPERATURE_ID",
                table: "PRODUCT_VOLUME_SUMMARY",
                column: "PRESSURE_TEMPERATURE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_VOLUME_SUMMARY_R_AMEND_REASON_ID",
                table: "PRODUCT_VOLUME_SUMMARY",
                column: "R_AMEND_REASON_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_VOLUME_SUMMARY_R_PERIOD_KIND_ID",
                table: "PRODUCT_VOLUME_SUMMARY",
                column: "R_PERIOD_KIND_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_VOLUME_SUMMARY_R_QUANTITY_METHOD_ID",
                table: "PRODUCT_VOLUME_SUMMARY",
                column: "R_QUANTITY_METHOD_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_VOLUME_SUMMARY_R_REPORTING_FLOW_ID",
                table: "PRODUCT_VOLUME_SUMMARY",
                column: "R_REPORTING_FLOW_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_VOLUME_SUMMARY_R_REPORTING_PRODUCT_ID",
                table: "PRODUCT_VOLUME_SUMMARY",
                column: "R_REPORTING_PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_VOLUME_SUMMARY_REPORTING_ENTITY_ID",
                table: "PRODUCT_VOLUME_SUMMARY",
                column: "REPORTING_ENTITY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_VOLUME_SUMMARY_SCENARIO_ID",
                table: "PRODUCT_VOLUME_SUMMARY",
                column: "SCENARIO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_R_ALARM_SUB_CATEGORY_R_ALARM_CATEGORY_ID",
                table: "R_ALARM_SUB_CATEGORY",
                column: "R_ALARM_CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_R_ALLOCATION_TYPE_R_SOURCE_ID",
                table: "R_ALLOCATION_TYPE",
                column: "R_SOURCE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_R_EVENT_SUB_CATEGORY_R_EVENT_CATEGORY_ID",
                table: "R_EVENT_SUB_CATEGORY",
                column: "R_EVENT_CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_R_FORECAST_CLASS_R_FORECAST_CLASS_TYPE_ID",
                table: "R_FORECAST_CLASS",
                column: "R_FORECAST_CLASS_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_R_REPORTING_FLOW_PARENT_FLOW_KIND_ID",
                table: "R_REPORTING_FLOW",
                column: "PARENT_FLOW_KIND_ID");

            migrationBuilder.CreateIndex(
                name: "IX_R_REPORTING_FLOW_R_DISPOSITION_CATEGORY_ID",
                table: "R_REPORTING_FLOW",
                column: "R_DISPOSITION_CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_R_REPORTING_PRODUCT_R_PRODUCT_CATEGORY_ID",
                table: "R_REPORTING_PRODUCT",
                column: "R_PRODUCT_CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RPEN_ALLOCATION_FACTOR_FROM_REPORTING_ENTITY_ID",
                table: "RPEN_ALLOCATION_FACTOR",
                column: "FROM_REPORTING_ENTITY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RPEN_ALLOCATION_FACTOR_R_ALLOCATION_TYPE_ID",
                table: "RPEN_ALLOCATION_FACTOR",
                column: "R_ALLOCATION_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RPEN_ALLOCATION_FACTOR_R_REPORTING_FLOW_ID",
                table: "RPEN_ALLOCATION_FACTOR",
                column: "R_REPORTING_FLOW_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RPEN_ALLOCATION_FACTOR_R_REPORTING_PRODUCT_ID",
                table: "RPEN_ALLOCATION_FACTOR",
                column: "R_REPORTING_PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RPEN_ALLOCATION_FACTOR_TO_REPORTING_ENTITY_ID",
                table: "RPEN_ALLOCATION_FACTOR",
                column: "TO_REPORTING_ENTITY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SP_BOUNDARY_POLYGON_ID",
                table: "SP_BOUNDARY",
                column: "POLYGON_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SP_DESC_TEXT_SPATIAL_DESCRIPTION_ID",
                table: "SP_DESC_TEXT",
                column: "SPATIAL_DESCRIPTION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SP_POLYGON_CRS_ID",
                table: "SP_POLYGON",
                column: "CRS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SP_POLYGON_SPATIAL_DESCRIPTION_ID",
                table: "SP_POLYGON",
                column: "SPATIAL_DESCRIPTION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_EVENT_R_DOWNTIME_TYPE_ID",
                table: "WELL_EVENT",
                column: "R_DOWNTIME_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_EVENT_R_EVENT_SUB_CATEGORY_ID",
                table: "WELL_EVENT",
                column: "R_EVENT_SUB_CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_EVENT_R_SOURCE_ID",
                table: "WELL_EVENT",
                column: "R_SOURCE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_EVENT_WELL_ID",
                table: "WELL_EVENT",
                column: "WELL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_EVENT_PLAN_R_EVENT_SUB_CATEGORY_ID",
                table: "WELL_EVENT_PLAN",
                column: "R_EVENT_SUB_CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_EVENT_PLAN_R_SOURCE_ID",
                table: "WELL_EVENT_PLAN",
                column: "R_SOURCE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_EVENT_PLAN_WELL_ID",
                table: "WELL_EVENT_PLAN",
                column: "WELL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_STATUS_HISTORY_R_WELL_STATUS_ID",
                table: "WELL_STATUS_HISTORY",
                column: "R_WELL_STATUS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_STATUS_HISTORY_WELL_ID",
                table: "WELL_STATUS_HISTORY",
                column: "WELL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_TEST_PRESSURE_TEMPERATURE_ID",
                table: "WELL_TEST",
                column: "PRESSURE_TEMPERATURE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_TEST_R_TIMEZONE_ID",
                table: "WELL_TEST",
                column: "R_TIMEZONE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_TEST_R_VALIDATE_RESULT_ID",
                table: "WELL_TEST",
                column: "R_VALIDATE_RESULT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_TEST_R_WELL_TEST_TYPE_ID",
                table: "WELL_TEST",
                column: "R_WELL_TEST_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_TEST_REPORTING_ENTITY_ID",
                table: "WELL_TEST",
                column: "REPORTING_ENTITY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_TEST_ALLOCATION_FACTOR_R_REPORTING_PRODUCT_ID",
                table: "WELL_TEST_ALLOCATION_FACTOR",
                column: "R_REPORTING_PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_TEST_ALLOCATION_FACTOR_TO_ENTITY_ID",
                table: "WELL_TEST_ALLOCATION_FACTOR",
                column: "TO_ENTITY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_TEST_ALLOCATION_FACTOR_WELL_TEST_ID",
                table: "WELL_TEST_ALLOCATION_FACTOR",
                column: "WELL_TEST_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_TEST_FLOW_MEASUREMENT_FLOW_PERIOD",
                table: "WELL_TEST_FLOW_MEASUREMENT",
                column: "FLOW_PERIOD");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_TEST_FLOW_MEASUREMENT_R_FLOW_KIND_ID",
                table: "WELL_TEST_FLOW_MEASUREMENT",
                column: "R_FLOW_KIND_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_TEST_FLOW_MEASUREMENT_R_REPORTING_PRODUCT_ID",
                table: "WELL_TEST_FLOW_MEASUREMENT",
                column: "R_REPORTING_PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_TEST_FLOW_MEASUREMENT_WELL_TEST_FLOW_PERIOD_ID",
                table: "WELL_TEST_FLOW_MEASUREMENT",
                column: "WELL_TEST_FLOW_PERIOD_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_TEST_FLOW_MEASUREMENT_WELL_TEST_ID",
                table: "WELL_TEST_FLOW_MEASUREMENT",
                column: "WELL_TEST_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_TEST_FLOW_PERIOD_WELL_TEST_ID",
                table: "WELL_TEST_FLOW_PERIOD",
                column: "WELL_TEST_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_TEST_MEASUREMENT_FLOW_PERIOD",
                table: "WELL_TEST_MEASUREMENT",
                column: "FLOW_PERIOD");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_TEST_MEASUREMENT_R_MEASUREMENT_ID",
                table: "WELL_TEST_MEASUREMENT",
                column: "R_MEASUREMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_TEST_MEASUREMENT_WELL_TEST_FLOW_PERIOD_ID",
                table: "WELL_TEST_MEASUREMENT",
                column: "WELL_TEST_FLOW_PERIOD_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_TEST_MEASUREMENT_WELL_TEST_ID",
                table: "WELL_TEST_MEASUREMENT",
                column: "WELL_TEST_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_VOL_DAILY_WELL_ID",
                table: "WELL_VOL_DAILY",
                column: "WELL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WELL_VOL_MONTHLY_WELL_ID",
                table: "WELL_VOL_MONTHLY",
                column: "WELL_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ALARM_DETAIL");

            migrationBuilder.DropTable(
                name: "ALARM_NOTIFICATION");

            migrationBuilder.DropTable(
                name: "EQUIPMENT_SUBTYPE_SPEC");

            migrationBuilder.DropTable(
                name: "EQUIPMENT_TYPE_MEASUREMENT");

            migrationBuilder.DropTable(
                name: "EQUIPMENT_TYPE_SPECIFICATION");

            migrationBuilder.DropTable(
                name: "FLOW_PORT_ALIAS");

            migrationBuilder.DropTable(
                name: "FLOW_PORT_EXPECTED_PRODUCT");

            migrationBuilder.DropTable(
                name: "FLOW_PORT_NFP_TAG_ALIAS");

            migrationBuilder.DropTable(
                name: "FLOW_PORT_PROPERTY_EXPECTED_FLOW_PRODUCT");

            migrationBuilder.DropTable(
                name: "FLOW_UNIT_ALIAS");

            migrationBuilder.DropTable(
                name: "FLOW_UNIT_CONTEXT_FACILITY");

            migrationBuilder.DropTable(
                name: "FLOW_UNIT_EXPECTED_FLOW_PRODUCT");

            migrationBuilder.DropTable(
                name: "FLOW_UNIT_NFP_TAG_ALIAS");

            migrationBuilder.DropTable(
                name: "FLUID_ANALYSIS_PROPERTY_SUMMARY");

            migrationBuilder.DropTable(
                name: "FLUID_ANALYSIS_SAMPLE");

            migrationBuilder.DropTable(
                name: "FLUID_COMPOSITION_ANALYSIS");

            migrationBuilder.DropTable(
                name: "FLUID_RES_SURF_VOL_RELATION");

            migrationBuilder.DropTable(
                name: "FLUID_SAMPLE_DETAIL");

            migrationBuilder.DropTable(
                name: "FLUID_SATURATION_PRESSURE");

            migrationBuilder.DropTable(
                name: "HIERARCHY_LEVEL");

            migrationBuilder.DropTable(
                name: "HIERARCHY_TEMPLATE_DESC");

            migrationBuilder.DropTable(
                name: "NETWORK_CHANGE_LOG");

            migrationBuilder.DropTable(
                name: "NETWORK_EXTERNAL_PORT");

            migrationBuilder.DropTable(
                name: "NETWORK_PLAN_CHANGE_LOG");

            migrationBuilder.DropTable(
                name: "PROD_DECLINE_FORECAST_CLASS");

            migrationBuilder.DropTable(
                name: "PROD_DECLINE_METHOD_PARM");

            migrationBuilder.DropTable(
                name: "PROD_DOWN_TIME_VOLUME_LOSS");

            migrationBuilder.DropTable(
                name: "PROD_HAUL_VOLUME_DETAIL");

            migrationBuilder.DropTable(
                name: "PROD_SALE_STATEMENT");

            migrationBuilder.DropTable(
                name: "PRODUCT_VOLUME_SUMMARY");

            migrationBuilder.DropTable(
                name: "R_TRIGGER_TYPE");

            migrationBuilder.DropTable(
                name: "R_VOLUME_METHOD");

            migrationBuilder.DropTable(
                name: "RPEN_ALLOCATION_FACTOR");

            migrationBuilder.DropTable(
                name: "SP_BOUNDARY");

            migrationBuilder.DropTable(
                name: "SP_DESC_TEXT");

            migrationBuilder.DropTable(
                name: "VERSION");

            migrationBuilder.DropTable(
                name: "WELL_EVENT");

            migrationBuilder.DropTable(
                name: "WELL_EVENT_PLAN");

            migrationBuilder.DropTable(
                name: "WELL_STATUS_HISTORY");

            migrationBuilder.DropTable(
                name: "WELL_TEST_ALLOCATION_FACTOR");

            migrationBuilder.DropTable(
                name: "WELL_TEST_FLOW_MEASUREMENT");

            migrationBuilder.DropTable(
                name: "WELL_TEST_MEASUREMENT");

            migrationBuilder.DropTable(
                name: "WELL_VOL_DAILY");

            migrationBuilder.DropTable(
                name: "WELL_VOL_MONTHLY");

            migrationBuilder.DropTable(
                name: "ALARM");

            migrationBuilder.DropTable(
                name: "EMAIL_CONFIG");

            migrationBuilder.DropTable(
                name: "R_EQUIPMENT_SPEC");

            migrationBuilder.DropTable(
                name: "FLOW_PORT_EXPECTED_PROPERTY");

            migrationBuilder.DropTable(
                name: "R_FLOW_QUALIFIER");

            migrationBuilder.DropTable(
                name: "FLOW_UNIT_EXPECTED_PROPERTY");

            migrationBuilder.DropTable(
                name: "R_FLUID_PROPERTY");

            migrationBuilder.DropTable(
                name: "R_FLUID_COMPONENT");

            migrationBuilder.DropTable(
                name: "FLUID_SAMPLE");

            migrationBuilder.DropTable(
                name: "FLUID_ANALYSIS_STEP");

            migrationBuilder.DropTable(
                name: "R_SATURATION_POINT_TYPE");

            migrationBuilder.DropTable(
                name: "HIERARCHY_DESC");

            migrationBuilder.DropTable(
                name: "HIERARCHY_TEMPLATE");

            migrationBuilder.DropTable(
                name: "R_FORECAST_CLASS");

            migrationBuilder.DropTable(
                name: "PROD_DECLINE_SEGMENT");

            migrationBuilder.DropTable(
                name: "R_DECLINE_PARM");

            migrationBuilder.DropTable(
                name: "R_ESTIMATION_METHOD");

            migrationBuilder.DropTable(
                name: "PROD_HAUL_EVENT");

            migrationBuilder.DropTable(
                name: "R_AMEND_REASON");

            migrationBuilder.DropTable(
                name: "R_PERIOD_KIND");

            migrationBuilder.DropTable(
                name: "R_QUANTITY_METHOD");

            migrationBuilder.DropTable(
                name: "R_ALLOCATION_TYPE");

            migrationBuilder.DropTable(
                name: "SP_POLYGON");

            migrationBuilder.DropTable(
                name: "R_DOWNTIME_TYPE");

            migrationBuilder.DropTable(
                name: "R_MEASUREMENT");

            migrationBuilder.DropTable(
                name: "WELL_TEST_FLOW_PERIOD");

            migrationBuilder.DropTable(
                name: "R_ALARM_STATUS");

            migrationBuilder.DropTable(
                name: "R_ALARM_SUB_CATEGORY");

            migrationBuilder.DropTable(
                name: "R_EVENT_SUB_CATEGORY");

            migrationBuilder.DropTable(
                name: "R_FACILITY_PARAMETER");

            migrationBuilder.DropTable(
                name: "R_FLUID_SAMPLE_METHOD");

            migrationBuilder.DropTable(
                name: "FLUID_ANALYSIS");

            migrationBuilder.DropTable(
                name: "R_FLUID_ANALYSIS_METHOD");

            migrationBuilder.DropTable(
                name: "HIERARCHY");

            migrationBuilder.DropTable(
                name: "R_FORECAST_CLASS_TYPE");

            migrationBuilder.DropTable(
                name: "PROD_DECLINE_FORECAST");

            migrationBuilder.DropTable(
                name: "R_DECLINE_CURVE_TYPE");

            migrationBuilder.DropTable(
                name: "R_DECLINE_TYPE");

            migrationBuilder.DropTable(
                name: "R_RATIO_CURVE_TYPE");

            migrationBuilder.DropTable(
                name: "R_RATIO_FLUID_TYPE");

            migrationBuilder.DropTable(
                name: "R_FLOW_PART");

            migrationBuilder.DropTable(
                name: "R_HAUL_EVENT_TYPE");

            migrationBuilder.DropTable(
                name: "R_NET_VOLUME_METHOD");

            migrationBuilder.DropTable(
                name: "R_REPORTING_FLOW");

            migrationBuilder.DropTable(
                name: "R_REPORTING_PRODUCT");

            migrationBuilder.DropTable(
                name: "WELL_TEST");

            migrationBuilder.DropTable(
                name: "R_ALARM_CATEGORY");

            migrationBuilder.DropTable(
                name: "R_DECLINE_METHOD");

            migrationBuilder.DropTable(
                name: "R_DISPOSITION_CATEGORY");

            migrationBuilder.DropTable(
                name: "R_PRODUCT_CATEGORY");

            migrationBuilder.DropTable(
                name: "PRESSURE_TEMPERATURE");

            migrationBuilder.DropTable(
                name: "R_VALIDATE_RESULT");

            migrationBuilder.DropTable(
                name: "R_WELL_TEST_TYPE");
        }
    }
}

export const masterDataGroups = [
  {
    "id": "organization",
    "label": "Organization & associations",
    "items": [
      {
        "label": "Facility Org Unit",
        "table": "FACILITY_ORG_UNIT",
        "form": false
      },
      {
        "label": "Field Org Unit",
        "table": "FIELD_ORG_UNIT",
        "form": true
      },
      {
        "label": "Organization Unit",
        "table": "ORG_UNIT",
        "form": true
      },
      {
        "label": "Well Org Unit",
        "table": "WELL_ORG_UNIT",
        "form": false
      }
    ]
  },
  {
    "id": "geography",
    "label": "Fields & subsurface",
    "items": [
      {
        "label": "Coordinate Reference Systems",
        "table": "CARTOREFERENCESYSTEM",
        "form": true
      },
      {
        "label": "Field",
        "table": "FIELD",
        "form": true
      },
      {
        "label": "Field Component",
        "table": "FIELD_COMPONENT",
        "form": false
      },
      {
        "label": "Formation",
        "table": "FORMATION",
        "form": false
      },
      {
        "label": "Pool / Reservoir",
        "table": "POOL",
        "form": true
      },
      {
        "label": "Pool Component",
        "table": "POOL_COMPONENT",
        "form": false
      },
      {
        "label": "Spatial Description",
        "table": "SPATIAL_DESCRIPTION",
        "form": false
      },
      {
        "label": "Zone",
        "table": "ZONE",
        "form": false
      }
    ]
  },
  {
    "id": "wells",
    "label": "Wells & completions",
    "items": [
      {
        "label": "Well",
        "table": "WELL",
        "form": true
      },
      {
        "label": "Wellbore",
        "table": "WELLBORE",
        "form": true
      },
      {
        "label": "Well Completion",
        "table": "WELL_COMPLETION",
        "form": true
      },
      {
        "label": "Well Dir Srvy",
        "table": "WELL_DIR_SRVY",
        "form": true
      },
      {
        "label": "Well Equipment",
        "table": "WELL_EQUIPMENT",
        "form": true
      },
      {
        "label": "Perforation",
        "table": "WELL_PERFORATION",
        "form": true
      },
      {
        "label": "Well Pool",
        "table": "WELL_POOL",
        "form": true
      },
      {
        "label": "Well Prod Method History",
        "table": "WELL_PROD_METHOD_HISTORY",
        "form": true
      },
      {
        "label": "Well Status",
        "table": "WELL_STATUS",
        "form": true
      },
      {
        "label": "Well Tubing Tally",
        "table": "WELL_TUBING_TALLY",
        "form": true
      },
      {
        "label": "Well Tubular",
        "table": "WELL_TUBULAR",
        "form": true
      },
      {
        "label": "Well Zone",
        "table": "WELL_ZONE",
        "form": true
      }
    ]
  },
  {
    "id": "infrastructure",
    "label": "Facilities & equipment",
    "items": [
      {
        "label": "Equipment",
        "table": "EQUIPMENT",
        "form": true
      },
      {
        "label": "Equipment Measurement Tags",
        "table": "EQUIPMENT_MEASUREMENT_TAGS",
        "form": false
      },
      {
        "label": "Facilities",
        "table": "FACILITY",
        "form": true
      },
      {
        "label": "Facility Equipment",
        "table": "FACILITY_EQUIPMENT",
        "form": false
      },
      {
        "label": "Facility Field",
        "table": "FACILITY_FIELD",
        "form": true
      }
    ]
  },
  {
    "id": "flow",
    "label": "Flow models & networks",
    "items": [
      {
        "label": "Flow Connected Node",
        "table": "FLOW_CONNECTED_NODE",
        "form": false
      },
      {
        "label": "Flow Model",
        "table": "FLOW_MODEL",
        "form": false
      },
      {
        "label": "Flow Model Context Facility",
        "table": "FLOW_MODEL_CONTEXT_FACILITY",
        "form": false
      },
      {
        "label": "Flow Model External Connect",
        "table": "FLOW_MODEL_EXTERNAL_CONNECT",
        "form": false
      },
      {
        "label": "Flow Port",
        "table": "FLOW_PORT",
        "form": false
      },
      {
        "label": "Flow Unit",
        "table": "FLOW_UNIT",
        "form": false
      },
      {
        "label": "Network",
        "table": "NETWORK",
        "form": false
      },
      {
        "label": "Network Plan",
        "table": "NETWORK_PLAN",
        "form": false
      },
      {
        "label": "Reporting Entity",
        "table": "REPORTING_ENTITY",
        "form": false
      },
      {
        "label": "Reporting Facility",
        "table": "REPORTING_FACILITY",
        "form": false
      },
      {
        "label": "Scenario",
        "table": "SCENARIO",
        "form": false
      }
    ]
  },
  {
    "id": "monitoring",
    "label": "Monitoring & operations",
    "items": [
      {
        "label": "Alarm Settings",
        "table": "ALARM_SETTINGS",
        "form": false
      },
      {
        "label": "Prod Down Time Event",
        "table": "PROD_DOWN_TIME_EVENT",
        "form": false
      },
      {
        "label": "Tags Info",
        "table": "TAGS_INFO",
        "form": false
      }
    ]
  },
  {
    "id": "reference",
    "label": "Reference data",
    "items": [
      {
        "label": "Reference \u00b7 Alarm Color",
        "table": "R_ALARM_COLOR",
        "form": false
      },
      {
        "label": "Reference \u00b7 Alarm Level",
        "table": "R_ALARM_LEVEL",
        "form": false
      },
      {
        "label": "Reference \u00b7 Alarm Type",
        "table": "R_ALARM_TYPE",
        "form": false
      },
      {
        "label": "Reference \u00b7 Completion Type",
        "table": "R_COMPLETION_TYPE",
        "form": false
      },
      {
        "label": "Reference \u00b7 Coupling Type",
        "table": "R_COUPLING_TYPE",
        "form": false
      },
      {
        "label": "Reference \u00b7 Data Access Category",
        "table": "R_DATA_ACCESS_CATEGORY",
        "form": false
      },
      {
        "label": "Reference \u00b7 Direction Type",
        "table": "R_DIRECTION_TYPE",
        "form": false
      },
      {
        "label": "Reference \u00b7 Down Time Reason",
        "table": "R_DOWN_TIME_REASON",
        "form": false
      },
      {
        "label": "Reference \u00b7 Down Time Type",
        "table": "R_DOWN_TIME_TYPE",
        "form": false
      },
      {
        "label": "Reference \u00b7 Entity Type",
        "table": "R_ENTITY_TYPE",
        "form": false
      },
      {
        "label": "Reference \u00b7 Equipment Catalogue",
        "table": "R_EQUIPMENT_CATALOGUE",
        "form": false
      },
      {
        "label": "Reference \u00b7 Equipment Measurement",
        "table": "R_EQUIPMENT_MEASUREMENT",
        "form": false
      },
      {
        "label": "Reference \u00b7 Equipment Sub Type",
        "table": "R_EQUIPMENT_SUB_TYPE",
        "form": false
      },
      {
        "label": "Reference \u00b7 Equipment Type",
        "table": "R_EQUIPMENT_TYPE",
        "form": false
      },
      {
        "label": "Reference \u00b7 Event Category",
        "table": "R_EVENT_CATEGORY",
        "form": false
      },
      {
        "label": "Reference \u00b7 Event Status",
        "table": "R_EVENT_STATUS",
        "form": false
      },
      {
        "label": "Reference \u00b7 Facility Type",
        "table": "R_FACILITY_TYPE",
        "form": false
      },
      {
        "label": "Reference \u00b7 Field Type",
        "table": "R_FIELD_TYPE",
        "form": true
      },
      {
        "label": "Reference \u00b7 Fluid Type",
        "table": "R_FLUID_TYPE",
        "form": false
      },
      {
        "label": "Reference \u00b7 North Type",
        "table": "R_NORTH_TYPE",
        "form": false
      },
      {
        "label": "Reference \u00b7 Org Unit Category",
        "table": "R_ORG_UNIT_CATEGORY",
        "form": false
      },
      {
        "label": "Reference \u00b7 Org Unit Type",
        "table": "R_ORG_UNIT_TYPE",
        "form": true
      },
      {
        "label": "Reference \u00b7 Perforation Method",
        "table": "R_PERFORATION_METHOD",
        "form": false
      },
      {
        "label": "Reference \u00b7 Perforation Type",
        "table": "R_PERFORATION_TYPE",
        "form": false
      },
      {
        "label": "Reference \u00b7 Plot Symbol",
        "table": "R_PLOT_SYMBOL",
        "form": false
      },
      {
        "label": "Reference \u00b7 Pool Status",
        "table": "R_POOL_STATUS",
        "form": true
      },
      {
        "label": "Reference \u00b7 Pool Type",
        "table": "R_POOL_TYPE",
        "form": true
      },
      {
        "label": "Reference \u00b7 Production Method",
        "table": "R_PRODUCTION_METHOD",
        "form": false
      },
      {
        "label": "Reference \u00b7 Reporting Entity Kind",
        "table": "R_REPORTING_ENTITY_KIND",
        "form": false
      },
      {
        "label": "Reference \u00b7 Reporting Facility Kind",
        "table": "R_REPORTING_FACILITY_KIND",
        "form": false
      },
      {
        "label": "Reference \u00b7 Scenario Source",
        "table": "R_SCENARIO_SOURCE",
        "form": false
      },
      {
        "label": "Reference \u00b7 Scenario Type",
        "table": "R_SCENARIO_TYPE",
        "form": false
      },
      {
        "label": "Reference \u00b7 Source",
        "table": "R_SOURCE",
        "form": false
      },
      {
        "label": "Reference \u00b7 Survey Type",
        "table": "R_SURVEY_TYPE",
        "form": false
      },
      {
        "label": "Reference \u00b7 Timezone",
        "table": "R_TIMEZONE",
        "form": false
      },
      {
        "label": "Reference \u00b7 Tubular Type",
        "table": "R_TUBULAR_TYPE",
        "form": false
      },
      {
        "label": "Reference \u00b7 Well Class",
        "table": "R_WELL_CLASS",
        "form": false
      },
      {
        "label": "Reference \u00b7 Well Datum Type",
        "table": "R_WELL_DATUM_TYPE",
        "form": false
      },
      {
        "label": "Reference \u00b7 Well Status",
        "table": "R_WELL_STATUS",
        "form": true
      },
      {
        "label": "Reference \u00b7 Well Status Type",
        "table": "R_WELL_STATUS_TYPE",
        "form": true
      }
    ]
  }
] as const
export const masterDataItems = masterDataGroups.flatMap(group=>[...group.items])

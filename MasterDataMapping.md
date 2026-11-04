# Master data mapping

Requested tables: ORG_UNIT, FIELD, POOL, FORMATION, ZONE, WELL, WELLBORE, WELL_COMPLETION, WELL_PERFORATION, WELL_TUBULAR, FLOW_MODEL, FACILITY, EQUIPMENT

Supporting tables: CARTOREFERENCESYSTEM, REPORTING_ENTITY, R_COMPLETION_TYPE, R_COUPLING_TYPE, R_DATA_ACCESS_CATEGORY, R_EQUIPMENT_CATALOGUE, R_EQUIPMENT_SUB_TYPE, R_EQUIPMENT_TYPE, R_FACILITY_TYPE, R_FIELD_TYPE, R_ORG_UNIT_CATEGORY, R_ORG_UNIT_TYPE, R_PERFORATION_METHOD, R_PERFORATION_TYPE, R_PLOT_SYMBOL, R_POOL_STATUS, R_POOL_TYPE, R_REPORTING_ENTITY_KIND, R_SOURCE, R_TIMEZONE, R_TUBULAR_TYPE, R_WELL_CLASS, R_WELL_DATUM_TYPE, R_WELL_STATUS, R_WELL_STATUS_TYPE

Source: https://osdu.pages.opengroup.org/platform/domain-data-mgmt-services/production/core/dspdm-services/PDM/1.0/data-model-usage-guide/Data-Dictionary.html

The published Nullable column appears inverted: Y marks primary keys and mandatory names throughout. This mapping treats Y as required and N as optional, with all primary keys required. C# uses PascalCase; SQL preserves published column names including spelling and embedded spaces. Numeric precision is preserved; timestamps map to datetime2, booleans to bit, BYTEA to varbinary(max). Foreign keys are configured for integer columns with explicit referenced tables. Text copies of referenced names are retained as scalar fields. No cascade deletes. No reference values are seeded.

## Organization unit associations
ORG_UNIT, R_ORG_UNIT_TYPE and R_ORG_UNIT_CATEGORY are mapped by MasterDataModels.cs.
OrganizationAssociationModels.cs adds FIELD_ORG_UNIT, FACILITY_ORG_UNIT and WELL_ORG_UNIT from the PDM 1.0 dictionary.
Each association has a generated integer key, required parent and organization-unit foreign keys, optional effective/expiry dates, active status, remarks and audit fields.
Deletes do not cascade. Database check constraints reject expiry dates before effective dates. The same documented Y/N interpretation as the existing master models is retained.
Migration: AddOrganizationUnitAssociations. No reference records are seeded.

## Entities Definition coverage
Added the following missing tables and dependencies:
ALARM_SETTINGS, EQUIPMENT_MEASUREMENT_TAGS, FACILITY_EQUIPMENT, FACILITY_FIELD, FIELD_COMPONENT, FLOW_CONNECTED_NODE, FLOW_MODEL_CONTEXT_FACILITY, FLOW_MODEL_EXTERNAL_CONNECT, FLOW_PORT, FLOW_UNIT, NETWORK, NETWORK_PLAN, POOL_COMPONENT, PROD_DOWN_TIME_EVENT, REPORTING_FACILITY, R_ALARM_COLOR, R_ALARM_LEVEL, R_ALARM_TYPE, R_DIRECTION_TYPE, R_DOWN_TIME_REASON, R_DOWN_TIME_TYPE, R_ENTITY_TYPE, R_EQUIPMENT_MEASUREMENT, R_EVENT_CATEGORY, R_EVENT_STATUS, R_FLUID_TYPE, R_NORTH_TYPE, R_PRODUCTION_METHOD, R_REPORTING_FACILITY_KIND, R_SCENARIO_SOURCE, R_SCENARIO_TYPE, R_SURVEY_TYPE, SCENARIO, SPATIAL_DESCRIPTION, TAGS_INFO, WELL_DIR_SRVY, WELL_EQUIPMENT, WELL_POOL, WELL_PROD_METHOD_HISTORY, WELL_STATUS, WELL_TUBING_TALLY, WELL_ZONE

Relationship corrections based on field meanings:
FLOW_MODEL_EXTERNAL_CONNECT.CONNECTED_FLOW_PORT_ID: FLOW_MODEL -> FLOW_PORT
FLOW_MODEL_EXTERNAL_CONNECT.CONNECTED_FLOW_MODEL_ID: FLOW_PORT -> FLOW_MODEL
FLOW_PORT.FLOW_UNIT_ID: (unspecified) -> FLOW_UNIT

All deletes are non-cascading. Required flags follow the existing documented mapping. Existing models and records are preserved. New tables contain no seeded data.
SpatialDescription.Description maps to SPATIAL_DESCRIPTION because C# forbids a property with the same name as its containing class.

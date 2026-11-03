# Master data mapping

Requested tables: ORG_UNIT, FIELD, POOL, FORMATION, ZONE, WELL, WELLBORE, WELL_COMPLETION, WELL_PERFORATION, WELL_TUBULAR, FLOW_MODEL, FACILITY, EQUIPMENT

Supporting tables: CARTOREFERENCESYSTEM, REPORTING_ENTITY, R_COMPLETION_TYPE, R_COUPLING_TYPE, R_DATA_ACCESS_CATEGORY, R_EQUIPMENT_CATALOGUE, R_EQUIPMENT_SUB_TYPE, R_EQUIPMENT_TYPE, R_FACILITY_TYPE, R_FIELD_TYPE, R_ORG_UNIT_CATEGORY, R_ORG_UNIT_TYPE, R_PERFORATION_METHOD, R_PERFORATION_TYPE, R_PLOT_SYMBOL, R_POOL_STATUS, R_POOL_TYPE, R_REPORTING_ENTITY_KIND, R_SOURCE, R_TIMEZONE, R_TUBULAR_TYPE, R_WELL_CLASS, R_WELL_DATUM_TYPE, R_WELL_STATUS, R_WELL_STATUS_TYPE

Source: https://osdu.pages.opengroup.org/platform/domain-data-mgmt-services/production/core/dspdm-services/PDM/1.0/data-model-usage-guide/Data-Dictionary.html

The published Nullable column appears inverted: Y marks primary keys and mandatory names throughout. This mapping treats Y as required and N as optional, with all primary keys required. C# uses PascalCase; SQL preserves published column names including spelling and embedded spaces. Numeric precision is preserved; timestamps map to datetime2, booleans to bit, BYTEA to varbinary(max). Foreign keys are configured for integer columns with explicit referenced tables. Text copies of referenced names are retained as scalar fields. No cascade deletes. No reference values are seeded.

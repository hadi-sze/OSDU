# Reference data seeding

UseSeeding and UseAsyncSeeding share an idempotent implementation. Run dotnet ef database update --project OSDU.Data --startup-project OSDU.Api from the solution directory. Migration locking protects execution. Existing values and IDs are preserved; no business records or users are seeded. SQL scripts alone do not invoke the seeder. Missing tables are skipped during downgrades.

These are editable application starter values, not a certified OSDU reference dataset. Domain-specific codes, measurement definitions, equipment taxonomy, alarm colors, downtime reasons, well statuses, plot symbols and CRS definitions require approved project configuration.

- RFacilityType: Pipeline, Tank, Battery, Separator, Processing Plant, Terminal, Metering Station
- ROrgUnitType: Country, Province, District, Area, Company, Partner
- ROrgUnitCategory: Area Unit, Business Unit
- RDataAccessCategory: Public, Private, Confidential
- REquipmentCatalogue: Production Equipment, Measurement Equipment, Processing Equipment
- RDirectionType: Inlet, Outlet, Unknown
- RCompletionType: Perforated, Open Hole, Gravel Pack, Combination
- RTubularType: Conductor, Surface Casing, Intermediate Casing, Production Casing, Tubing, Liner
- RCouplingType: Threaded, Premium
- RPoolStatus: Active, Inactive, Abandoned
- RPoolType: Conventional, Oil Sands, Administrative
- RFieldType: Regulatory, Locally Assigned
- RFluidType: Oil, Gas, Water, Condensate, Mud
- RProductionMethod: Flowing, Pumping, Gas Lift, Swabbing
- RNorthType: True North, Grid North, Magnetic North
- RWellDatumType: Kelly Bushing, Ground Level, Mean Sea Level, Derrick Floor
- RWellClass: New Field Wildcat, Deeper Pool Test, Outpost, Development
- RPerforationType: Bullet, Jet, Combination
- RPerforationMethod: Perforation, Open Hole, Combination
- REventCategory: Maintenance, Workover, Stimulation, Equipment Failure
- REventStatus: Open, Closed
- RDownTimeType: Planned, Unplanned, External
- RReportingEntityKind: Well, Wellbore, Completion, Facility, Field, Pool
- RReportingFacilityKind: Well, Facility
- RScenarioType: Base, Alternate
- RScenarioSource: Manual, Imported, Calculated
- RSource: Manual Entry, Import
- RSurveyType: Gyroscopic, Magnetic, MWD, Totco, Acid Bottle
- RTimezone: UTC
- RWellStatusType: Construction, Operating, Producing, Abandonment
- RAlarmLevel: Low, Medium, High, Critical
- RAlarmType: Threshold, Rate of Change
For a dedicated async initialization process run: dotnet run --project OSDU.Api -- --seed-data=true. This applies migrations, seeds reference data and exits without starting the web server.

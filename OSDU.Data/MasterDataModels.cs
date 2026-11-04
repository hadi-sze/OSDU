// PDM 1.0 dictionary mapping. See MasterDataMapping.md.
namespace OSDU.Data.MasterData;

public class Cartoreferencesystem {
 public int CrsId { get; set; }
 public string CrsName { get; set; } = "";
 public string? CrsType { get; set; }
 public string? GeodeticSource { get; set; }
 public string? ProjectionType { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public bool IsActive { get; set; }
 public string? LongName { get; set; }
 public string? ShortName { get; set; }
 public string? Remark { get; set; }
}

public class Equipment {
 public DateTime? CommissionDate { get; set; }
 public DateTime? DecommissionDate { get; set; }
 public int EquipmentId { get; set; }
 public string EquipmentName { get; set; } = "";
 public string? EquipmentSubType { get; set; }
 public string? EquipmentType { get; set; }
 public bool IsActive { get; set; }
 public int? REquipmentSubTypeId { get; set; }
 public int? REquipmentTypeId { get; set; }
 public string? Remark { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public string? EquipmentAliasName { get; set; }
 public int? SerialNum { get; set; }
 public int? ManufacturerBaId { get; set; }
 public int? RDataAccessCategoryId { get; set; }
}

public class Facility {
 public string? DepthUom { get; set; }
 public string? ElevationUom { get; set; }
 public string? FacilityDiameterUom { get; set; }
 public int FacilityId { get; set; }
 public string FacilityName { get; set; } = "";
 public int? FacilityTypeId { get; set; }
 public string? FacilityType { get; set; }
 public bool IsActive { get; set; }
 public DateTime? ConstructedDate { get; set; }
 public DateTime? ActiveDate { get; set; }
 public DateTime? AbandonedDate { get; set; }
 public bool OffshoreInd { get; set; }
 public int? REquipmentCatalogueId { get; set; }
 public string? EquipmentCatalogue { get; set; }
 public decimal? XCoordinate { get; set; }
 public decimal? YCoordinate { get; set; }
 public int? CrsId { get; set; }
 public string? CrsName { get; set; }
 public string? CurrentOperator { get; set; }
 public decimal? Depth { get; set; }
 public decimal? Elevation { get; set; }
 public decimal? FacilityDiameter { get; set; }
 public string? FacilityFunction { get; set; }
 public int? FacilityNo { get; set; }
 public string? FacilityShortName { get; set; }
 public string? FacilityLongName { get; set; }
 public DateTime? LastInjectionDate { get; set; }
 public DateTime? LastProductionDate { get; set; }
 public DateTime? LastReportedDate { get; set; }
 public DateTime? OnInjectionDate { get; set; }
 public DateTime? OnProductionDate { get; set; }
 public string? Remark { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public bool? IsVirtual { get; set; }
 public string? Uidref { get; set; }
 public int? RDataAccessCategoryId { get; set; }
}

public class Field {
 public int FieldId { get; set; }
 public string FieldName { get; set; } = "";
 public string? FieldTypeName { get; set; }
 public string? FieldAbbreviation { get; set; }
 public decimal? XCoordinate { get; set; }
 public decimal? YCoordinate { get; set; }
 public int? CrsId { get; set; }
 public string? CrsName { get; set; }
 public string? Remark { get; set; }
 public bool IsActive { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public string? SourceName { get; set; }
 public int? RFieldTypeId { get; set; }
 public string? Uidref { get; set; }
 public int? RDataAccessCategoryId { get; set; }
}

public class FlowModel {
 public int FlowModelId { get; set; }
 public string FlowModelName { get; set; } = "";
 public int? InstallationId { get; set; }
 public DateTime? ExpiryDate { get; set; }
 public DateTime? EffectiveDate { get; set; }
 public string? Comment { get; set; }
 public bool IsActive { get; set; }
 public string? Remark { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
}

public class Formation {
 public int FormationId { get; set; }
 public string FormationName { get; set; } = "";
 public string? LongName { get; set; }
 public string? ShortName { get; set; }
 public bool IsActive { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public bool? TestBit { get; set; }
 public short? AttrSmallint { get; set; }
 public int? AttrInt { get; set; }
 public long? AttrBigint { get; set; }
}

public class OrgUnit {
 public int OrgUnitId { get; set; }
 public string OrgUnitName { get; set; } = "";
 public int ROrgUnitTypeId { get; set; }
 public int? ROrgUnitCategoryId { get; set; }
 public string? Remark { get; set; }
 public bool IsActive { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowChangedBy { get; set; }
 public string? OrgUnitShortName { get; set; }
 public string? OrgUnitAbberivation { get; set; }
}

public class Pool {
 public int PoolId { get; set; }
 public string PoolName { get; set; } = "";
 public bool IsActive { get; set; }
 public DateTime? DiscoveryDate { get; set; }
 public DateTime? EffectiveDate { get; set; }
 public DateTime? ExpiryDate { get; set; }
 public int? FieldId { get; set; }
 public string? FieldName { get; set; }
 public string? PoolCode { get; set; }
 public string? PoolNameAbbreviation { get; set; }
 public int? RPoolStatusId { get; set; }
 public string? PoolStatus { get; set; }
 public int? RPoolTypeId { get; set; }
 public string? PoolType { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public int? RDataAccessCategoryId { get; set; }
}

public class ReportingEntity {
 public int ReportingEntityId { get; set; }
 public int RReportingEntityKindId { get; set; }
 public int AssociatedObjectId { get; set; }
 public string AssociatedObjectName { get; set; } = "";
 public bool IsActive { get; set; }
 public string? Remark { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowChangedBy { get; set; }
}

public class RCompletionType {
 public int RCompletionTypeId { get; set; }
 public string CompletionType { get; set; } = "";
 public bool IsActive { get; set; }
 public string? LongName { get; set; }
 public string? ShortName { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public string? Remark { get; set; }
}

public class RCouplingType {
 public int RCouplingTypeId { get; set; }
 public string CouplingType { get; set; } = "";
 public bool IsActive { get; set; }
 public string? LongName { get; set; }
 public string? ShortName { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public string? Remark { get; set; }
}

public class RDataAccessCategory {
 public int RDataAccessCategoryId { get; set; }
 public string DataAccessCategory { get; set; } = "";
 public bool IsActive { get; set; }
 public string? Remark { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowChangedBy { get; set; }
 public string? LongName { get; set; }
 public string? ShortName { get; set; }
}

public class REquipmentCatalogue {
 public string EquipmentCatalogue { get; set; } = "";
 public bool IsActive { get; set; }
 public string? LongName { get; set; }
 public int REquipmentCatalogueId { get; set; }
 public string? Remark { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public string? ShortName { get; set; }
}

public class REquipmentSubType {
 public string EquipmentSubType { get; set; } = "";
 public bool IsActive { get; set; }
 public string? LongName { get; set; }
 public int REquipmentSubTypeId { get; set; }
 public string? Remark { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public string? ShortName { get; set; }
 public int? REquipmentTypeId { get; set; }
 public string? EquipmentType { get; set; }
 public bool? BarrierElement { get; set; }
}

public class REquipmentType {
 public string? EquipmentCatalogue { get; set; }
 public string EquipmentType { get; set; } = "";
 public bool IsActive { get; set; }
 public string? LongName { get; set; }
 public int? REquipmentCatalogueId { get; set; }
 public int REquipmentTypeId { get; set; }
 public string? Remark { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public string? ShortName { get; set; }
}

public class RFacilityType {
 public int RFacilityTypeId { get; set; }
 public string FacilityType { get; set; } = "";
 public string? LongName { get; set; }
 public string? ShortName { get; set; }
 public string? Remark { get; set; }
 public bool IsActive { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
}

public class RFieldType {
 public int RFieldTypeId { get; set; }
 public string? DisplayName { get; set; }
 public string? LongName { get; set; }
 public string? ShortName { get; set; }
 public string? Abbreviation { get; set; }
 public string? ColorCode { get; set; }
 public string? Remark { get; set; }
 public bool IsActive { get; set; }
 public DateTime? EffectiveDate { get; set; }
 public DateTime? ExpiryDate { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public string? SourceName { get; set; }
 public string FieldTypeName { get; set; } = "";
}

public class ROrgUnitCategory {
 public int ROrgUnitCategoryId { get; set; }
 public string OrgUnitCategory { get; set; } = "";
 public string? Remark { get; set; }
 public bool IsActive { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowChangedBy { get; set; }
 public string? LongName { get; set; }
 public string? ShortName { get; set; }
}

public class ROrgUnitType {
 public int ROrgUnitTypeId { get; set; }
 public string OrgUnitType { get; set; } = "";
 public string? Remark { get; set; }
 public bool IsActive { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowChangedBy { get; set; }
 public string? LongName { get; set; }
 public string? ShortName { get; set; }
}

public class RPerforationMethod {
 public int RPerforationMethodId { get; set; }
 public string PerforationMethod { get; set; } = "";
 public bool IsActive { get; set; }
 public string? LongName { get; set; }
 public string? ShortName { get; set; }
 public string? Remark { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
}

public class RPerforationType {
 public int RPerforationTypeId { get; set; }
 public string PerforationType { get; set; } = "";
 public bool IsActive { get; set; }
 public string? LongName { get; set; }
 public string? ShortName { get; set; }
 public string? Remark { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
}

public class RPlotSymbol {
 public string? ColorCode { get; set; }
 public bool? IsActive { get; set; }
 public byte[]? PlotSymbol { get; set; }
 public string PlotSymbolType { get; set; } = "";
 public int RPlotSymbolId { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public string? LongName { get; set; }
 public string? ShortName { get; set; }
 public string? Remark { get; set; }
}

public class RPoolStatus {
 public int RPoolStatusId { get; set; }
 public string PoolStatus { get; set; } = "";
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public bool IsActive { get; set; }
 public string? LongName { get; set; }
 public string? ShortName { get; set; }
 public string? Remark { get; set; }
}

public class RPoolType {
 public int RPoolTypeId { get; set; }
 public string PoolType { get; set; } = "";
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public bool IsActive { get; set; }
 public string? LongName { get; set; }
 public string? ShortName { get; set; }
 public string? Remark { get; set; }
}

public class RReportingEntityKind {
 public int RReportingEntityKindId { get; set; }
 public string ReportingEntityKind { get; set; } = "";
 public bool IsActive { get; set; }
 public string? Remark { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowChangedBy { get; set; }
 public string? LongName { get; set; }
 public string? ShortName { get; set; }
}

public class RSource {
 public int RSourceId { get; set; }
 public string? DisplayName { get; set; }
 public string? LongName { get; set; }
 public string? ShortName { get; set; }
 public string? Abbreviation { get; set; }
 public string? ColorCode { get; set; }
 public string? Remark { get; set; }
 public bool IsActive { get; set; }
 public DateTime? EffectiveDate { get; set; }
 public DateTime? ExpiryDate { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public string SourceName { get; set; } = "";
}

public class RTimezone {
 public int RTimezoneId { get; set; }
 public string Timezone { get; set; } = "";
 public bool IsActive { get; set; }
 public string? LongName { get; set; }
 public string? ShortName { get; set; }
 public string? Remark { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
}

public class RTubularType {
 public int RTubularTypeId { get; set; }
 public string TubularType { get; set; } = "";
 public bool IsActive { get; set; }
 public string? LongName { get; set; }
 public string? ShortName { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public string? Remark { get; set; }
}

public class RWellClass {
 public int RWellClassId { get; set; }
 public string WellClass { get; set; } = "";
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public bool IsActive { get; set; }
 public string? LongName { get; set; }
 public string? ShortName { get; set; }
 public string? Remark { get; set; }
}

public class RWellDatumType {
 public int WellDatumTypeId { get; set; }
 public string WellDatumType { get; set; } = "";
 public string? Abbreviation { get; set; }
 public string? LongName { get; set; }
 public string? ShortName { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public bool IsActive { get; set; }
 public string? Remark { get; set; }
}

public class RWellStatus {
 public int RWellStatusId { get; set; }
 public string WellStatus { get; set; } = "";
 public int RWellStatusTypeId { get; set; }
 public int? RSourceId { get; set; }
 public string? Remark { get; set; }
 public bool IsActive { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowChangedBy { get; set; }
 public string? LongName { get; set; }
 public string? ShortName { get; set; }
}

public class RWellStatusType {
 public int RWellStatusTypeId { get; set; }
 public string WellStatusType { get; set; } = "";
 public int? RSourceId { get; set; }
 public string? Remark { get; set; }
 public bool IsActive { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowChangedBy { get; set; }
 public string? LongName { get; set; }
 public string? ShortName { get; set; }
}

public class Well {
 public int WellId { get; set; }
 public string Uwi { get; set; } = "";
 public string WellName { get; set; } = "";
 public string? WellAliasName { get; set; }
 public int? FieldId { get; set; }
 public string? FieldName { get; set; }
 public bool OffshoreInd { get; set; }
 public bool IsActive { get; set; }
 public string? WellOwner { get; set; }
 public DateTime? SpudDate { get; set; }
 public string? SpudDateTz { get; set; }
 public int? RTimezoneId { get; set; }
 public DateTime? CompletionDate { get; set; }
 public DateTime? ProductionStartDate { get; set; }
 public decimal? XCoordinate { get; set; }
 public decimal? YCoordinate { get; set; }
 public int? CrsId { get; set; }
 public string? CrsName { get; set; }
 public int? CurrentClassId { get; set; }
 public string? WellClass { get; set; }
 public decimal? DeepestDepth { get; set; }
 public decimal? MaxTvd { get; set; }
 public int? DepthDatumId { get; set; }
 public string? DepthDatum { get; set; }
 public decimal? DepthDatumElev { get; set; }
 public decimal? GroundElev { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public decimal? BottomHoleXLon { get; set; }
 public decimal? BottomHoleYLat { get; set; }
 public DateTime? AbandonmentDate { get; set; }
 public DateTime? ExpiryDate { get; set; }
 public bool? FaultedInd { get; set; }
 public DateTime? FinalDrillDate { get; set; }
 public decimal? LogTd { get; set; }
 public decimal? NetPay { get; set; }
 public string? Operator { get; set; }
 public string? PlotName { get; set; }
 public decimal? PlugbackDepth { get; set; }
 public int? RWellProfileId { get; set; }
 public string? WellProfile { get; set; }
 public decimal? WaterAcousticVel { get; set; }
 public decimal? WaterDepth { get; set; }
 public string? WaterDepthDatum { get; set; }
 public bool? IsVirtual { get; set; }
 public int? RPlotSymbolId { get; set; }
 public string? Uidref { get; set; }
 public int? RDataAccessCategoryId { get; set; }
}

public class Wellbore {
 public int WellboreId { get; set; }
 public int WellId { get; set; }
 public string WellUwi { get; set; } = "";
 public string WellboreUwi { get; set; } = "";
 public string? WellboreName { get; set; }
 public string? WellboreNumber { get; set; }
 public decimal? XCoordinate { get; set; }
 public decimal? YCoordinate { get; set; }
 public int? CrsId { get; set; }
 public string? CrsName { get; set; }
 public decimal? BhXCoordinate { get; set; }
 public decimal? BhYCoordinate { get; set; }
 public int? BhCrsId { get; set; }
 public string? BhCrsName { get; set; }
 public int? FieldId { get; set; }
 public string? FieldName { get; set; }
 public decimal? KbElev { get; set; }
 public decimal? GroundElev { get; set; }
 public decimal? DerrickFloorElev { get; set; }
 public int? DepthDatumId { get; set; }
 public string? DepthDatum { get; set; }
 public decimal? DepthDatumElev { get; set; }
 public DateTime? SpudDate { get; set; }
 public string? SpudDateTz { get; set; }
 public int? RTimezoneId { get; set; }
 public DateTime? CompletionDate { get; set; }
 public decimal? DrillTd { get; set; }
 public decimal? PlugbackDepth { get; set; }
 public decimal? KickOffDepth { get; set; }
 public decimal? WaterDepth { get; set; }
 public int? ParentWellboreId { get; set; }
 public string? ParentWellboreUwi { get; set; }
 public string? FormationAtTd { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public bool IsActive { get; set; }
 public string? Uidref { get; set; }
 public int? RPlotSymbolId { get; set; }
}

public class WellCompletion {
 public int WellCompletionId { get; set; }
 public int? WellboreId { get; set; }
 public string WellboreUwi { get; set; } = "";
 public DateTime? CompletionDate { get; set; }
 public int? CompletionObsNo { get; set; }
 public int? CompletionTypeId { get; set; }
 public string? CompletionType { get; set; }
 public bool IsActive { get; set; }
 public DateTime? ExpiryDate { get; set; }
 public decimal? TopDepth { get; set; }
 public decimal? BaseDepth { get; set; }
 public int? ZoneId { get; set; }
 public string? ZoneName { get; set; }
 public string? Remark { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public string WellCompletionName { get; set; } = "";
 public string? Uidref { get; set; }
}

public class WellPerforation {
 public int WellPerforationId { get; set; }
 public int WellCompletionId { get; set; }
 public int PerforationObsNo { get; set; }
 public int? PerforationTypeId { get; set; }
 public string? PerforationType { get; set; }
 public int? PerforationMethodId { get; set; }
 public string? PerforationMethod { get; set; }
 public DateTime? ExpiryDate { get; set; }
 public decimal? TopDepth { get; set; }
 public int? TopZoneId { get; set; }
 public string? TopZoneName { get; set; }
 public decimal? BaseDepth { get; set; }
 public int? BaseZoneId { get; set; }
 public string? BaseZoneName { get; set; }
 public decimal? PerforationAngle { get; set; }
 public int? PerforationCount { get; set; }
 public decimal? PerforationDensity { get; set; }
 public decimal? PerforationDiameter { get; set; }
 public string? PerforationPhase { get; set; }
 public bool IsActive { get; set; }
 public string? Remark { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public string WellCompletionName { get; set; } = "";
}

public class WellTubular {
 public int WellTubularId { get; set; }
 public int WellboreId { get; set; }
 public string WellboreUwi { get; set; } = "";
 public int? RTubularTypeId { get; set; }
 public string TubularType { get; set; } = "";
 public int? RCouplingTypeId { get; set; }
 public string? CouplingType { get; set; }
 public DateTime TubularInDate { get; set; }
 public DateTime? TubularOutDate { get; set; }
 public decimal? TopDepth { get; set; }
 public decimal? BaseDepth { get; set; }
 public decimal? InsideDiameter { get; set; }
 public decimal? OutsideDiameter { get; set; }
 public decimal? TubularThickness { get; set; }
 public int? JointCount { get; set; }
 public decimal? JointLength { get; set; }
 public decimal? Roughness { get; set; }
 public decimal? TubularDensity { get; set; }
 public string? TubularGrade { get; set; }
 public decimal? TubularStrength { get; set; }
 public decimal? TubularWeight { get; set; }
 public decimal? PackerSetDepth { get; set; }
 public bool IsActive { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
}

public class Zone {
 public int ZoneId { get; set; }
 public string ZoneName { get; set; } = "";
 public string? LongName { get; set; }
 public string? ShortName { get; set; }
 public bool IsActive { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public int? PoolId { get; set; }
 public string? PoolName { get; set; }
 public int? RDataAccessCategoryId { get; set; }
}
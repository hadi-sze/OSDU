// Additional entities referenced by PDM Entities Definition and their dependencies.
namespace OSDU.Data.MasterData;

public class AlarmSettings {
 public int AlarmSettingsId { get; set; }
 public int? REntityTypeId { get; set; }
 public string? REntityType { get; set; }
 public string EntityName { get; set; } = "";
 public int? REquipmentMeasurementId { get; set; }
 public string MeasurementName { get; set; } = "";
 public string AlarmName { get; set; } = "";
 public DateTime Date { get; set; }
 public int? RAlarmLevelId { get; set; }
 public string? AlarmLevel { get; set; }
 public int? RAlarmColorId { get; set; }
 public string? ColorCode { get; set; }
 public int? RAlarmTypeId { get; set; }
 public string AlarmType { get; set; } = "";
 public string? BaseLine { get; set; }
 public decimal? InputValue { get; set; }
 public decimal? Duration { get; set; }
 public decimal? MinimumThreshold { get; set; }
 public decimal? MaximumThreshold { get; set; }
 public string? Remark { get; set; }
 public bool IsActive { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public int? EquipmentId { get; set; }
 public string? EquipmentName { get; set; }
 public int? EntityId { get; set; }
}

public class EquipmentMeasurementTags {
 public int EquipmentMeasurementTagsId { get; set; }
 public int EquipmentId { get; set; }
 public string EquipmentName { get; set; } = "";
 public int REquipmentMeasurementId { get; set; }
 public string EquipmentMeasurement { get; set; } = "";
 public int TagsInfoId { get; set; }
 public string TagsId { get; set; } = "";
 public bool? IsActive { get; set; }
 public string? Remark { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowChangedBy { get; set; }
}

public class FacilityEquipment {
 public int FacilityEquipmentId { get; set; }
 public int FacilityId { get; set; }
 public string FacilityName { get; set; } = "";
 public int EquipmentId { get; set; }
 public string EquipmentName { get; set; } = "";
 public DateTime? InstallDate { get; set; }
 public DateTime? RemoveDate { get; set; }
 public bool IsActive { get; set; }
 public string? Remark { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
}

public class FacilityField {
 public int FacilityFieldId { get; set; }
 public int FacilityId { get; set; }
 public int FieldId { get; set; }
 public DateTime? EffectiveDate { get; set; }
 public DateTime? ExpiryDate { get; set; }
 public string? Remark { get; set; }
 public bool IsActive { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowChangedBy { get; set; }
}

public class FieldComponent {
 public int FieldComponentId { get; set; }
 public int? FieldId { get; set; }
 public int ComponentObsNo { get; set; }
 public int? SpatialDescriptionId { get; set; }
 public string? Remark { get; set; }
 public bool? IsActive { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowChangedBy { get; set; }
 public string FieldName { get; set; } = "";
 public string? SpatialDescription { get; set; }
}

public class FlowConnectedNode {
 public int FlowConnectedNodeId { get; set; }
 public int InletPortId { get; set; }
 public int OutletPortId { get; set; }
 public DateTime? ExpiryDate { get; set; }
 public DateTime? EffectiveDate { get; set; }
 public string? Comment { get; set; }
 public bool IsActive { get; set; }
 public string? Remark { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowChangedBy { get; set; }
}

public class FlowModelContextFacility {
 public int FlowModelContextFacilityId { get; set; }
 public int FlowModelId { get; set; }
 public int ContextFacilityId { get; set; }
 public bool IsActive { get; set; }
 public string? Remark { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
}

public class FlowModelExternalConnect {
 public int FlowModelExternalConnectId { get; set; }
 public int FlowModelId { get; set; }
 public int FlowPortId { get; set; }
 public int ConnectedFlowPortId { get; set; }
 public int ConnectedFlowModelId { get; set; }
 public int? ConnectedInstallationId { get; set; }
 public string? Uid { get; set; }
 public bool IsActive { get; set; }
 public string? Remark { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowChangedBy { get; set; }
}

public class FlowPort {
 public int FlowPortId { get; set; }
 public string FlowPortName { get; set; } = "";
 public int FlowUnitId { get; set; }
 public int RDirectionTypeId { get; set; }
 public string? Uid { get; set; }
 public bool IsExposedInternal { get; set; }
 public bool IsActive { get; set; }
 public string? Remark { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowChangedBy { get; set; }
}

public class FlowUnit {
 public int FlowUnitId { get; set; }
 public string FlowUnitName { get; set; } = "";
 public int? ReportingFacilityId { get; set; }
 public int NetworkId { get; set; }
 public int? NetworkPlanId { get; set; }
 public string? Comment { get; set; }
 public int? ReportingFacilityParent1Id { get; set; }
 public int? ReportingFacilityParent2Id { get; set; }
 public int? InternalNetworkId { get; set; }
 public decimal? RelativeCoordinateX { get; set; }
 public decimal? RelativeCoordinateY { get; set; }
 public decimal? RelativeCoordinateZ { get; set; }
 public bool IsVirtual { get; set; }
 public DateTime? EffectiveDate { get; set; }
 public DateTime? ExpiryDate { get; set; }
 public string? Uid { get; set; }
 public bool IsActive { get; set; }
 public string? Remark { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowChangedBy { get; set; }
}

public class Network {
 public int NetworkId { get; set; }
 public string NetworkName { get; set; } = "";
 public int? FlowModelId { get; set; }
 public int? ScenarioId { get; set; }
 public int? ParentNetworkId { get; set; }
 public string? Comment { get; set; }
 public bool IsActive { get; set; }
 public string? Remark { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
}

public class NetworkPlan {
 public int NetworkPlanId { get; set; }
 public string NetworkPlanName { get; set; } = "";
 public int NetworkId { get; set; }
 public DateTime PlanStartDate { get; set; }
 public string? PlanPurpose { get; set; }
 public string Uid { get; set; } = "";
 public bool IsActive { get; set; }
 public string? Remark { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
}

public class PoolComponent {
 public int PoolComponentId { get; set; }
 public int? PoolId { get; set; }
 public int ComponentObsNo { get; set; }
 public int? SpatialDescriptionId { get; set; }
 public string? Remark { get; set; }
 public bool? IsActive { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowChangedBy { get; set; }
 public string PoolName { get; set; } = "";
 public string? SpatialDescription { get; set; }
}

public class ProdDownTimeEvent {
 public int ProdDownTimeEventId { get; set; }
 public int ProdEntityId { get; set; }
 public DateTime StartTime { get; set; }
 public DateTime? EndTime { get; set; }
 public int? RTimezoneId { get; set; }
 public int REventCategoryId { get; set; }
 public int? RDownTimeReasonId { get; set; }
 public int? EquipmentId { get; set; }
 public int? ParentDownTimeEventId { get; set; }
 public int? REventStatusId { get; set; }
 public int? RDownTimeTypeId { get; set; }
 public bool? IsPlan { get; set; }
 public int? RSourceId { get; set; }
 public string? Description { get; set; }
 public DateTime? EffectiveDate { get; set; }
 public DateTime? ExpiryDate { get; set; }
 public bool IsActive { get; set; }
 public string? Remark { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowChangedBy { get; set; }
}

public class ReportingFacility {
 public int ReportingFacilityId { get; set; }
 public int ReportingFacilityKind { get; set; }
 public string AssociatedObjectId { get; set; } = "";
 public string? SiteKind { get; set; }
 public string? NamingSystem { get; set; }
 public bool IsActive { get; set; }
 public string? Remark { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowChangedBy { get; set; }
}

public class RAlarmColor {
 public int RAlarmColorId { get; set; }
 public string? ColorCode { get; set; }
 public string? Remark { get; set; }
 public bool IsActive { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public string? LongName { get; set; }
 public string? ShortName { get; set; }
}

public class RAlarmLevel {
 public int RAlarmLevelId { get; set; }
 public string AlarmLevel { get; set; } = "";
 public string? Remark { get; set; }
 public bool IsActive { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public string? LongName { get; set; }
 public string? ShortName { get; set; }
}

public class RAlarmType {
 public int RAlarmTypeId { get; set; }
 public string AlarmType { get; set; } = "";
 public string? Remark { get; set; }
 public bool IsActive { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public string? LongName { get; set; }
 public string? ShortName { get; set; }
}

public class RDirectionType {
 public int RDirectionTypeId { get; set; }
 public string DirectionType { get; set; } = "";
 public string? LongName { get; set; }
 public string? ShortName { get; set; }
 public bool IsActive { get; set; }
 public string? Remark { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowChangedBy { get; set; }
}

public class RDownTimeReason {
 public int RDownTimeReasonId { get; set; }
 public string DownTimeReason { get; set; } = "";
 public int REventCategoryId { get; set; }
 public string? LongName { get; set; }
 public string? ShortName { get; set; }
 public bool IsActive { get; set; }
 public string? Remark { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowChangedBy { get; set; }
}

public class RDownTimeType {
 public int RDownTimeTypeId { get; set; }
 public string DownTimeType { get; set; } = "";
 public string? LongName { get; set; }
 public string? ShortName { get; set; }
 public bool IsActive { get; set; }
 public string? Remark { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowChangedBy { get; set; }
}

public class REntityType {
 public string EntityType { get; set; } = "";
 public bool? IsActive { get; set; }
 public string? LongName { get; set; }
 public int REntityTypeId { get; set; }
 public string? Remark { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public string? ShortName { get; set; }
 public int? BusinessObjectAttrId { get; set; }
 public string? BoName { get; set; }
 public string? DefaultAttributeName { get; set; }
}

public class REquipmentMeasurement {
 public int REquipmentMeasurementId { get; set; }
 public string EquipmentMeasurement { get; set; } = "";
 public string DataType { get; set; } = "";
 public string? Unit { get; set; }
 public bool IsActive { get; set; }
 public string? Remark { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public int? RangeFrom { get; set; }
 public int? RangeTo { get; set; }
 public string? LongName { get; set; }
 public string? ShortName { get; set; }
}

public class REventCategory {
 public int REventCategoryId { get; set; }
 public string EventCategory { get; set; } = "";
 public bool IsActive { get; set; }
 public string? LongName { get; set; }
 public string? ShortName { get; set; }
 public string? Remark { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public int? ParentEventCategoryId { get; set; }
}

public class REventStatus {
 public int REventStatusId { get; set; }
 public string EventStatus { get; set; } = "";
 public string? LongName { get; set; }
 public string? ShortName { get; set; }
 public bool IsActive { get; set; }
 public string? Remark { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowChangedBy { get; set; }
}

public class RFluidType {
 public int RFluidTypeId { get; set; }
 public string FluidType { get; set; } = "";
 public string? LongName { get; set; }
 public string? ShortName { get; set; }
 public string? Remark { get; set; }
 public bool IsActive { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
}

public class RNorthType {
 public int RNorthId { get; set; }
 public string NorthType { get; set; } = "";
 public bool IsActive { get; set; }
 public string? LongName { get; set; }
 public string? ShortName { get; set; }
 public string? Remark { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
}

public class RProductionMethod {
 public int RProductionMethodId { get; set; }
 public string ProductionMethod { get; set; } = "";
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public bool IsActive { get; set; }
 public string? LongName { get; set; }
 public string? ShortName { get; set; }
 public string? Remark { get; set; }
}

public class RReportingFacilityKind {
 public int RReportingFacilityKindId { get; set; }
 public string ReportingFacilityKind { get; set; } = "";
 public string? LongName { get; set; }
 public string? ShortName { get; set; }
 public bool IsActive { get; set; }
 public string? Remark { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowChangedBy { get; set; }
}

public class RScenarioSource {
 public int RScenarioSourceId { get; set; }
 public string ScenarioSource { get; set; } = "";
 public string? LongName { get; set; }
 public string? ShortName { get; set; }
 public bool IsActive { get; set; }
 public string? Remark { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowChangedBy { get; set; }
}

public class RScenarioType {
 public bool? IsActive { get; set; }
 public string? LongName { get; set; }
 public int RScenarioTypeId { get; set; }
 public string? Remark { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public string ScenarioType { get; set; } = "";
 public string? ShortName { get; set; }
}

public class RSurveyType {
 public bool IsActive { get; set; }
 public string? LongName { get; set; }
 public int RSurveyTypeId { get; set; }
 public string? Remark { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public string? ShortName { get; set; }
 public string SurveyType { get; set; } = "";
}

public class Scenario {
 public bool? IsActive { get; set; }
 public int? RScenarioTypeId { get; set; }
 public string? Remark { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public int ScenarioId { get; set; }
 public string ScenarioName { get; set; } = "";
 public string? ScenarioType { get; set; }
 public int? RScenarioSourceId { get; set; }
}

public class SpatialDescription {
 public int SpatialDescriptionId { get; set; }
 public string Description { get; set; } = "";
 public int SpatialObsNo { get; set; }
 public bool? SpatialDescTextInd { get; set; }
 public string? Remark { get; set; }
 public bool? IsActive { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowChangedBy { get; set; }
}

public class TagsInfo {
 public int TagsInfoId { get; set; }
 public string TagsId { get; set; } = "";
 public string? TagName { get; set; }
 public string? DataType { get; set; }
 public string? Unit { get; set; }
 public int? PoolingFrequency { get; set; }
 public string? DataSource { get; set; }
 public bool IsActive { get; set; }
 public string? Remark { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public string? LongName { get; set; }
 public string? ShortName { get; set; }
}

public class WellDirSrvy {
 public int WellDirSrvyId { get; set; }
 public int WellboreId { get; set; }
 public string WellboreUwi { get; set; } = "";
 public int SurveyRunNum { get; set; }
 public decimal? Md { get; set; }
 public decimal? Tvd { get; set; }
 public decimal? Azimuth { get; set; }
 public decimal? Inclination { get; set; }
 public int? RNorthId { get; set; }
 public string? AzimuthNorthType { get; set; }
 public bool IsActive { get; set; }
 public string? Remark { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public DateTime? SurveyStartDate { get; set; }
 public DateTime? SurveyEndDate { get; set; }
 public int? RSurveyTypeId { get; set; }
 public string? SurveyType { get; set; }
 public decimal? TopDepth { get; set; }
 public decimal? BaseDepth { get; set; }
 public int? ReportLogDatumId { get; set; }
 public string? ReportLogDatum { get; set; }
}

public class WellEquipment {
 public int WellEquipmentId { get; set; }
 public int WellboreId { get; set; }
 public string WellboreUwi { get; set; } = "";
 public int EquipmentId { get; set; }
 public string? EquipmentName { get; set; }
 public bool IsActive { get; set; }
 public DateTime? InstallDate { get; set; }
 public DateTime? RemoveDate { get; set; }
 public decimal? InstallTopDepth { get; set; }
 public decimal? InstallBaseDepth { get; set; }
 public decimal? IdEquipment { get; set; }
 public decimal? OdEquipment { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public string? WellEquipmentName { get; set; }
}

public class WellPool {
 public int WellPoolId { get; set; }
 public int WellId { get; set; }
 public int PoolId { get; set; }
 public decimal? TopMd { get; set; }
 public decimal? BaseMd { get; set; }
 public decimal? TopTvd { get; set; }
 public decimal? BaseTvd { get; set; }
 public bool IsActive { get; set; }
 public string? Remark { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowChangedBy { get; set; }
}

public class WellProdMethodHistory {
 public int WellProdMethodHistoryId { get; set; }
 public int WellId { get; set; }
 public string Uwi { get; set; } = "";
 public DateTime EffectiveDate { get; set; }
 public int? RProductionMethodId { get; set; }
 public string? ProductionMethod { get; set; }
 public DateTime? ExpiryDate { get; set; }
 public bool IsActive { get; set; }
 public string? Remark { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
}

public class WellStatus {
 public int WellStatusId { get; set; }
 public int ReportingEntityId { get; set; }
 public int RWellStatusId { get; set; }
 public int? RSourceId { get; set; }
 public DateTime? EffectiveDate { get; set; }
 public DateTime? ExpiryDate { get; set; }
 public string? Remark { get; set; }
 public bool IsActive { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowChangedBy { get; set; }
 public int? WellId { get; set; }
}

public class WellTubingTally {
 public int WellTubingTallyId { get; set; }
 public int WellTubingId { get; set; }
 public string WellboreUwi { get; set; } = "";
 public DateTime TubingInDate { get; set; }
 public int? JointsSequence { get; set; }
 public int? JointsCount { get; set; }
 public decimal? JointsLength { get; set; }
 public decimal? CumJointsLength { get; set; }
 public decimal? InsideDiameter { get; set; }
 public decimal? OutsideDiameter { get; set; }
 public string? TubingGrade { get; set; }
 public decimal? Roughness { get; set; }
 public bool IsActive { get; set; }
 public string? Remark { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
}

public class WellZone {
 public int WellZoneId { get; set; }
 public int WellboreId { get; set; }
 public string WellboreUwi { get; set; } = "";
 public int ZoneId { get; set; }
 public string ZoneName { get; set; } = "";
 public int? RFluidTypeId { get; set; }
 public string? FluidType { get; set; }
 public decimal? TopMd { get; set; }
 public decimal? BaseMd { get; set; }
 public decimal? TopTvd { get; set; }
 public decimal? BaseTvd { get; set; }
 public decimal? GrossPay { get; set; }
 public decimal? NetPay { get; set; }
 public decimal? Ntg { get; set; }
 public decimal? Porosity { get; set; }
 public decimal? Permeability { get; set; }
 public decimal? InitialOSat { get; set; }
 public decimal? InitialGSat { get; set; }
 public decimal? InitialWSat { get; set; }
 public decimal? OriginalOilInPlace { get; set; }
 public decimal? OriginalGasInPlace { get; set; }
 public decimal? InitialFormationPress { get; set; }
 public decimal? InitialFormationTemp { get; set; }
 public string? Remark { get; set; }
 public bool IsActive { get; set; }
 public string? RowChangedBy { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
}

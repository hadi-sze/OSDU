// OSDU PDM 1.0 dictionary entities.
namespace OSDU.Data.MasterData;

public class Alarm
{
    public int AlarmId { get; set; }
    public int AlarmSettingsId { get; set; }
    public int? Counter { get; set; }
    public bool? IsAcknowledged { get; set; }
    public string? AcknowledgedComments { get; set; }
    public string? AcknowledgedBy { get; set; }
    public int? REventCategoryId { get; set; }
    public string? EventCategory { get; set; }
    public int? REventSubCategoryId { get; set; }
    public string? EventSubCategory { get; set; }
    public bool? IsNotificationSuccess { get; set; }
    public int? StatusId { get; set; }
    public string? Status { get; set; }
    public string? Remark { get; set; }
    public bool IsActive { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
    public int? TriggerTypeId { get; set; }
    public string? TriggerType { get; set; }
    public DateTime? EventDate { get; set; }
    public int? RAlarmSubCategoryId { get; set; }
    public string? AlarmSubCategory { get; set; }
}

public class AlarmDetail
{
    public int AlarmDetailId { get; set; }
    public int AlarmId { get; set; }
    public string? AlarmDescription { get; set; }
    public DateTime Date { get; set; }
    public string? Remark { get; set; }
    public bool IsActive { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
    public string TagsId { get; set; } = "";
}

public class AlarmNotification
{
    public int AlarmNotificationId { get; set; }
    public int RAlarmSubCategoryId { get; set; }
    public string UserGroup { get; set; } = "";
    public int? EmailConfigId { get; set; }
    public string? Remark { get; set; }
    public bool IsActive { get; set; }
    public string? RowChangedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
}

public class EmailConfig
{
    public int EmailConfigId { get; set; }
    public int AlarmCategoryId { get; set; }
    public string? EmailSubject { get; set; }
    public string? HelloWords { get; set; }
    public string? Introduction { get; set; }
    public string? Body { get; set; }
    public string? DetailLink { get; set; }
    public bool IsAutoSend { get; set; }
    public string? Remark { get; set; }
    public bool IsActive { get; set; }
    public string? RowChangedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
}

public class EquipmentSubtypeSpec
{
    public int EquipmentSubtypeSpecId { get; set; }
    public int REquipmentSubTypeId { get; set; }
    public string EquipmentSubType { get; set; } = "";
    public int REquipmentSpecId { get; set; }
    public string EquipmentSpec { get; set; } = "";
    public bool? IsActive { get; set; }
    public string? Remark { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class EquipmentTypeMeasurement
{
    public int EquipmentTypeMeasurementId { get; set; }
    public int REquipmentTypeId { get; set; }
    public string EquipmentType { get; set; } = "";
    public int REquipmentMeasurementId { get; set; }
    public string EquipmentMeasurement { get; set; } = "";
    public bool? IsActive { get; set; }
    public string? Remark { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class EquipmentTypeSpecification
{
    public int EquipmentTypeSpecId { get; set; }
    public int REquipmentTypeId { get; set; }
    public string EquipmentType { get; set; } = "";
    public int REquipmentSpecId { get; set; }
    public string EquipmentSpec { get; set; } = "";
    public bool? IsActive { get; set; }
    public string? Remark { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class FlowPortAlias
{
    public int FlowPortAliasId { get; set; }
    public int FlowPortId { get; set; }
    public string FlowPortAliasValue { get; set; } = "";
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class FlowPortExpectedProduct
{
    public int FlowPortExpectedProductId { get; set; }
    public int FlowPortId { get; set; }
    public int RReportingFlowId { get; set; }
    public int RReportingProductId { get; set; }
    public string? UidRef { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class FlowPortExpectedProperty
{
    public int FlowPortExpectedPropertyId { get; set; }
    public int FlowPortId { get; set; }
    public int RFacilityParameterId { get; set; }
    public decimal? DeadBand { get; set; }
    public decimal? MaximumFrequency { get; set; }
    public string? Comment { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class FlowPortNfpTagAlias
{
    public int FlowPortNfpTagAliasId { get; set; }
    public int FlowPortExpectedPropertyId { get; set; }
    public string TagAlias { get; set; } = "";
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class FlowPortPropertyExpectedFlowProduct
{
    public int FlowPortPropertyExpectedFlowProductId { get; set; }
    public int FlowPortExpectedPropertyId { get; set; }
    public int RReportingFlowId { get; set; }
    public int RReportingProductId { get; set; }
    public int RFlowQualifierId { get; set; }
    public string Uid { get; set; } = "";
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class FlowUnitAlias
{
    public int FlowUnitAliasId { get; set; }
    public int FlowUnitId { get; set; }
    public string FlowUnitAliasValue { get; set; } = "";
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class FlowUnitContextFacility
{
    public int FlowUnitContextFacilityId { get; set; }
    public int FlowUnitId { get; set; }
    public int? ReportingFacilityId { get; set; }
    public string? SiteKind { get; set; }
    public string? NamingSystem { get; set; }
    public string? UidRef { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class FlowUnitExpectedFlowProduct
{
    public int FlowUnitExpectedFlowProductId { get; set; }
    public int FlowUnitExpectedPropertyId { get; set; }
    public int RReportingFlowId { get; set; }
    public int RReportingProductId { get; set; }
    public int RFlowQualifierId { get; set; }
    public string? Uid { get; set; }
    public string? Comment { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class FlowUnitExpectedProperty
{
    public int FlowUnitExpectedPropertyId { get; set; }
    public int FlowUnitId { get; set; }
    public int RFacilityParameterId { get; set; }
    public decimal? DeadBand { get; set; }
    public decimal? MaximumFrequency { get; set; }
    public int? ChildFacilityId { get; set; }
    public string? Comment { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class FlowUnitNfpTagAlias
{
    public int FlowUnitNfpTagAliasId { get; set; }
    public int FlowUnitExpectedPropertyId { get; set; }
    public string TagAlias { get; set; } = "";
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class FluidAnalysis
{
    public int FluidAnalysisId { get; set; }
    public int ProdEntityId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? FluidAnalysisPurpose { get; set; }
    public string? FluidAnalysisLaboratory { get; set; }
    public string? Analyst { get; set; }
    public string? ReportNumber { get; set; }
    public DateTime? ReportedDate { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class FluidAnalysisPropertySummary
{
    public int FluidAnalysisPropertySummaryId { get; set; }
    public int FluidAnalysisId { get; set; }
    public decimal? RefPressure { get; set; }
    public decimal? RefTemperature { get; set; }
    public int RProductId { get; set; }
    public int RFluidPropertyId { get; set; }
    public decimal? Value { get; set; }
    public string? ValueUom { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class FluidAnalysisSample
{
    public int FluidAnalysisSampleId { get; set; }
    public int FluidSampleId { get; set; }
    public int FluidAnalysisId { get; set; }
    public string? FromCylinderNumber { get; set; }
    public string? ToCylinderNumber { get; set; }
    public DateTime? TransferDate { get; set; }
    public decimal? TransferPressure { get; set; }
    public decimal? TransferTemperature { get; set; }
    public decimal? TransferVolume { get; set; }
    public decimal? RemainingVolume { get; set; }
    public decimal? LabBubblePointPressure { get; set; }
    public decimal? LabBubblePointTemperature { get; set; }
    public decimal? OpeningPressure { get; set; }
    public decimal? OpeningTemperature { get; set; }
    public bool? IsValid { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class FluidAnalysisStep
{
    public int FluidAnalysisStepId { get; set; }
    public int FluidAnalysisId { get; set; }
    public int RFluidAnalysisMethodId { get; set; }
    public int StepSequence { get; set; }
    public decimal? StepPressure { get; set; }
    public decimal? StepTemperature { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class FluidCompositionAnalysis
{
    public int FluidCompositionAnalysisId { get; set; }
    public int FluidAnalysisStepId { get; set; }
    public int RProductId { get; set; }
    public int RFluidComponentId { get; set; }
    public decimal? MolecularWeight { get; set; }
    public decimal? WeightFraction { get; set; }
    public decimal? MoleFraction { get; set; }
    public decimal? VolumeFraction { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class FluidResSurfVolRelation
{
    public int FluidResSurfVolRelationId { get; set; }
    public int FluidAnalysisStepId { get; set; }
    public decimal? OilFvf { get; set; }
    public decimal? GasFvf { get; set; }
    public decimal? TotalFvf { get; set; }
    public decimal? SolutionGor { get; set; }
    public decimal? ZFactor { get; set; }
    public decimal? OilViscosity { get; set; }
    public decimal? GasViscosity { get; set; }
    public decimal? LiquidViscosity { get; set; }
    public decimal? OilGravity { get; set; }
    public decimal? GasGravity { get; set; }
    public decimal? LiquidDensity { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class FluidSample
{
    public int FluidSampleId { get; set; }
    public string SampleNumber { get; set; } = "";
    public DateTime? SampleDate { get; set; }
    public int ProdEntityId { get; set; }
    public int? RFluidSampleMethodId { get; set; }
    public int? RProductId { get; set; }
    public decimal? AcquisitionDepth { get; set; }
    public decimal? AcquisitionPressure { get; set; }
    public decimal? AcquisitionTemperature { get; set; }
    public decimal? AcquisitionVolume { get; set; }
    public string? ServiceCompany { get; set; }
    public bool? IsRepresentative { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class FluidSampleDetail
{
    public int FluidSampleDetailId { get; set; }
    public int FluidSampleId { get; set; }
    public int RMeasurementId { get; set; }
    public decimal? Value { get; set; }
    public string? ValueUom { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class FluidSaturationPressure
{
    public int FluidSaturationPressureId { get; set; }
    public int FluidAnalysisStepId { get; set; }
    public decimal? Volume { get; set; }
    public decimal Pressure { get; set; }
    public decimal? Optic { get; set; }
    public int? RSaturationPointTypeId { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class Hierarchy
{
    public int HierarchyId { get; set; }
    public string HierarchyName { get; set; } = "";
    public string? TenantId { get; set; }
    public string? Remark { get; set; }
    public bool IsActive { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class HierarchyDesc
{
    public int HierarchyDescId { get; set; }
    public int HierarchyId { get; set; }
    public int ROrgUnitTypeId { get; set; }
    public int? ParentHierarchyDescId { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public string? Remark { get; set; }
    public bool IsActive { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class HierarchyLevel
{
    public int HierarchyLevelId { get; set; }
    public int HierarchyDescId { get; set; }
    public int OrgUnitId { get; set; }
    public int? ParentHierarchyLevelId { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public string? Remark { get; set; }
    public bool IsActive { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class HierarchyTemplate
{
    public int HierarchyTemplateId { get; set; }
    public string HierarchyTemplateName { get; set; } = "";
    public string? Remark { get; set; }
    public bool IsActive { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class HierarchyTemplateDesc
{
    public int HierarchyTemplateDescId { get; set; }
    public int HierarchyTemplateId { get; set; }
    public int ROrgUnitTypeId { get; set; }
    public int? ParentHierarchyTemplateDescId { get; set; }
    public string? Remark { get; set; }
    public bool IsActive { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class NetworkChangeLog
{
    public int NetworkChangeLogId { get; set; }
    public int NetworkId { get; set; }
    public string NetworkChangeName { get; set; } = "";
    public DateTime ChangeStartDate { get; set; }
    public string? ChangeReason { get; set; }
    public string Uid { get; set; } = "";
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public string? RowChangedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
}

public class NetworkExternalPort
{
    public int NetworkExternalPortId { get; set; }
    public int NetworkId { get; set; }
    public int FlowPortId { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class NetworkPlanChangeLog
{
    public int NetworkPlanChangeLogId { get; set; }
    public int NetworkPlanId { get; set; }
    public string NetworkPlanChangeName { get; set; } = "";
    public DateTime ChangeStartDate { get; set; }
    public string? ChangeReason { get; set; }
    public string Uid { get; set; } = "";
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public string? RowChangedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
}

public class PressureTemperature
{
    public int PressureTemperatureId { get; set; }
    public decimal Temperature { get; set; }
    public decimal Pressure { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class ProductVolumeSummary
{
    public int ProductVolumeSummaryId { get; set; }
    public int ReportingEntityId { get; set; }
    public string ReportingEntityName { get; set; } = "";
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int RPeriodKindId { get; set; }
    public string PeriodKind { get; set; } = "";
    public int RReportingFlowId { get; set; }
    public string ReportingFlow { get; set; } = "";
    public int RReportingProductId { get; set; }
    public string Product { get; set; } = "";
    public int RQuantityMethodId { get; set; }
    public string QuantityMethod { get; set; } = "";
    public int AmendmentSeqNo { get; set; }
    public int? ScenarioId { get; set; }
    public decimal? Volume { get; set; }
    public string? VolumeUom { get; set; }
    public int PressureTemperatureId { get; set; }
    public decimal Temperature { get; set; }
    public decimal Pressure { get; set; }
    public decimal? Mass { get; set; }
    public string? MassUom { get; set; }
    public decimal? Energy { get; set; }
    public string? EnergyUom { get; set; }
    public int? RAmendReasonId { get; set; }
    public string? AmendReason { get; set; }
    public decimal? Moles { get; set; }
    public string? MolseUom { get; set; }
    public bool IsActive { get; set; }
    public string? Remarks { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class ProdDeclineForecast
{
    public int ProdDeclineForecastId { get; set; }
    public int ProdEntityId { get; set; }
    public int ScenarioId { get; set; }
    public int RDeclineMethodId { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public string? Remark { get; set; }
    public bool IsActive { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class ProdDeclineForecastClass
{
    public int ProdDeclineForecastClassId { get; set; }
    public int ProdDeclineForecastId { get; set; }
    public int RForecastClassId { get; set; }
    public int? RForecastClassTypeId { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class ProdDeclineMethodParm
{
    public int ProdDeclineMethodParmId { get; set; }
    public int ProdDeclineSegmentId { get; set; }
    public int RDeclineParmId { get; set; }
    public decimal? Value { get; set; }
    public string? ValueUom { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class ProdDeclineSegment
{
    public int ProdDeclineSegmentId { get; set; }
    public int ProdDeclineForecastId { get; set; }
    public int SegmentSequence { get; set; }
    public int RProductId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? RDeclineCurveTypeId { get; set; }
    public int? RDeclineTypeId { get; set; }
    public int? RRatioFluidTypeId { get; set; }
    public int? RRatioCurveTypeId { get; set; }
    public int? ParentProdDeclineSegmentId { get; set; }
    public decimal? Volume { get; set; }
    public string? VolumeUom { get; set; }
    public string? Remark { get; set; }
    public bool IsActive { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class ProdDownTimeVolumeLoss
{
    public int ProdDownTimeVolumeLossId { get; set; }
    public int ProdDownTimeEventId { get; set; }
    public int? RFlowKindId { get; set; }
    public int RProductId { get; set; }
    public decimal? LostVolume { get; set; }
    public string? LostVolumeUom { get; set; }
    public int? REstimationMethodId { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class ProdHaulEvent
{
    public int ProdHaulEventId { get; set; }
    public DateTime EventDate { get; set; }
    public int ReportingEntityId { get; set; }
    public int RProductId { get; set; }
    public int RHaulEventTypeId { get; set; }
    public string CargoNumber { get; set; } = "";
    public int? FromOrToEntityId { get; set; }
    public bool? IsDownStream { get; set; }
    public int? FromOrToOrgUnitId { get; set; }
    public int? RFlowPartId { get; set; }
    public int? RReportingFlowId { get; set; }
    public DateTime? ReportedDate { get; set; }
    public int? ShipperId { get; set; }
    public int? CarrierId { get; set; }
    public string? SealOn { get; set; }
    public string? SealOff { get; set; }
    public decimal? GrossVolume { get; set; }
    public string? GrossVolumeUom { get; set; }
    public int? RNetVolumeMethodId { get; set; }
    public decimal? NetVolume { get; set; }
    public string? NetVolumeUom { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class ProdHaulVolumeDetail
{
    public int ProdHaulVolumeDetailId { get; set; }
    public int ProdHaulEventId { get; set; }
    public decimal? BeginningHeight { get; set; }
    public decimal? EndingHeight { get; set; }
    public decimal? BeginningInventory { get; set; }
    public decimal? EndingInventory { get; set; }
    public decimal? BeginningTemp { get; set; }
    public decimal? EndingTemp { get; set; }
    public decimal? ObservedTemp { get; set; }
    public decimal? Density { get; set; }
    public decimal? FreeWaterPercent { get; set; }
    public decimal? FreeEmulsionPercent { get; set; }
    public decimal? SedimentWaterContent { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class ProdSaleStatement
{
    public int ProdSaleStatementId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int ReportingEntityId { get; set; }
    public int RProductId { get; set; }
    public decimal? SaleGrossVolume { get; set; }
    public string? SaleGrossVolumeUom { get; set; }
    public decimal? SaleNetVolume { get; set; }
    public string? SaleNetVolumeUom { get; set; }
    public int? ProdHaulEventId { get; set; }
    public int? SellerId { get; set; }
    public int? PurchaserId { get; set; }
    public int? SalesAdministratorId { get; set; }
    public int? PressureTemperatureId { get; set; }
    public decimal? WetBasis { get; set; }
    public decimal? HeatContent { get; set; }
    public decimal? PricePerUnit { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class RpenAllocationFactor
{
    public int RpenAllocationFactorId { get; set; }
    public int ToReportingEntityId { get; set; }
    public int FromReportingEntityId { get; set; }
    public int RReportingProductId { get; set; }
    public int? RReportingFlowId { get; set; }
    public decimal? AllocationFactor { get; set; }
    public int? RAllocationTypeId { get; set; }
    public string? CalculatedFrom { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public string? RowChangedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
}

public class RAlarmCategory
{
    public int RAlarmCategoryId { get; set; }
    public string AlarmCategory { get; set; } = "";
    public string? Remark { get; set; }
    public bool IsActive { get; set; }
    public string? RowChangedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public string? LongName { get; set; }
    public string? ShortName { get; set; }
}

public class RAlarmStatus
{
    public int RAlarmStatusId { get; set; }
    public string AlarmStatus { get; set; } = "";
    public string? Remark { get; set; }
    public bool IsActive { get; set; }
    public string? RowChangedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public string? LongName { get; set; }
    public string? ShortName { get; set; }
}

public class RAlarmSubCategory
{
    public int RAlarmSubCategoryId { get; set; }
    public string AlarmSubCategory { get; set; } = "";
    public int? RAlarmCategoryId { get; set; }
    public string? AlarmCategory { get; set; }
    public string? Remark { get; set; }
    public bool IsActive { get; set; }
    public string? RowChangedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public string? LongName { get; set; }
    public string? ShortName { get; set; }
}

public class RAllocationType
{
    public int RAllocationTypeId { get; set; }
    public string AllocationType { get; set; } = "";
    public string? LongName { get; set; }
    public string? ShortName { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public int? RSourceId { get; set; }
    public string? RowChangedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
}

public class RAmendReason
{
    public int RAmendReasonId { get; set; }
    public string AmendReason { get; set; } = "";
    public string? LongName { get; set; }
    public string? ShortName { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public string? RowChangedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
}

public class RDeclineCurveType
{
    public int RDeclineCurveTypeId { get; set; }
    public string DeclineCurveType { get; set; } = "";
    public string? LongName { get; set; }
    public string? ShortName { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class RDeclineMethod
{
    public int RDeclineMethodId { get; set; }
    public string DeclineMethod { get; set; } = "";
    public string? LongName { get; set; }
    public string? ShortName { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class RDeclineParm
{
    public int RDeclineParmId { get; set; }
    public string DeclineParm { get; set; } = "";
    public string? Description { get; set; }
    public string? LongName { get; set; }
    public string? ShortName { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class RDeclineType
{
    public int RDeclineTypeId { get; set; }
    public string DeclineType { get; set; } = "";
    public string? LongName { get; set; }
    public string? ShortName { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class RDispositionCategory
{
    public int RDispositionCategoryId { get; set; }
    public string DispositionCategory { get; set; } = "";
    public string? LongName { get; set; }
    public string? ShortName { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class RDowntimeType
{
    public int RDowntimeTypeId { get; set; }
    public string DowntimeType { get; set; } = "";
    public bool IsActive { get; set; }
    public string? LongName { get; set; }
    public string? ShortName { get; set; }
    public string? Remark { get; set; }
    public string? RowChangedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
}

public class REquipmentSpec
{
    public string DataType { get; set; } = "";
    public string EquipmentSpec { get; set; } = "";
    public bool IsActive { get; set; }
    public string? LongName { get; set; }
    public int REquipmentSpecId { get; set; }
    public string? Remark { get; set; }
    public string? RowChangedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public string? ShortName { get; set; }
    public string? Unit { get; set; }
}

public class REstimationMethod
{
    public int REstimationMethodId { get; set; }
    public string EstimationMethod { get; set; } = "";
    public string? LongName { get; set; }
    public string? ShortName { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class REventSubCategory
{
    public int REventSubCategoryId { get; set; }
    public string EventSubCategory { get; set; } = "";
    public bool IsActive { get; set; }
    public int? REventCategoryId { get; set; }
    public string? EventCategory { get; set; }
    public string? LongName { get; set; }
    public string? ShortName { get; set; }
    public string? Remark { get; set; }
    public string? RowChangedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
}

public class RFacilityParameter
{
    public int RFacilityParameterId { get; set; }
    public string FacilityParameter { get; set; } = "";
    public string? LongName { get; set; }
    public string? ShortName { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class RFlowPart
{
    public int RFlowPartId { get; set; }
    public string FlowPart { get; set; } = "";
    public string? LongName { get; set; }
    public string? ShortName { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class RFlowQualifier
{
    public int RFlowQualifierId { get; set; }
    public string FlowQualifier { get; set; } = "";
    public string? LongName { get; set; }
    public string? ShortName { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class RFluidAnalysisMethod
{
    public int RFluidAnalysisMethodId { get; set; }
    public string FluidAnalysisMethod { get; set; } = "";
    public string? LongName { get; set; }
    public string? ShortName { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class RFluidComponent
{
    public int RFluidComponentId { get; set; }
    public string FluidComponent { get; set; } = "";
    public string? LongName { get; set; }
    public string? ShortName { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class RFluidProperty
{
    public int RFluidPropertyId { get; set; }
    public string FluidProperty { get; set; } = "";
    public string? LongName { get; set; }
    public string? ShortName { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class RFluidSampleMethod
{
    public int RFluidSampleMethodId { get; set; }
    public string FluidSampleMethod { get; set; } = "";
    public string? LongName { get; set; }
    public string? ShortName { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class RForecastClass
{
    public int RForecastClassId { get; set; }
    public string ForecastClass { get; set; } = "";
    public int? RForecastClassTypeId { get; set; }
    public string? LongName { get; set; }
    public string? ShortName { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class RForecastClassType
{
    public int RForecastClassTypeId { get; set; }
    public string ForecastClassType { get; set; } = "";
    public string? LongName { get; set; }
    public string? ShortName { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class RHaulEventType
{
    public int RHaulEventTypeId { get; set; }
    public string HaulEventType { get; set; } = "";
    public string? LongName { get; set; }
    public string? ShortName { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class RMeasurement
{
    public int RMeasurementId { get; set; }
    public string Measurement { get; set; } = "";
    public bool? IncludeOnWellTest { get; set; }
    public string? LongName { get; set; }
    public string? ShortName { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class RNetVolumeMethod
{
    public int RNetVolumeMethodId { get; set; }
    public string NetVolumeMethod { get; set; } = "";
    public string? LongName { get; set; }
    public string? ShortName { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class RPeriodKind
{
    public int RPeriodKindId { get; set; }
    public string PeriodKind { get; set; } = "";
    public string? LongName { get; set; }
    public string? ShortName { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class RProductCategory
{
    public int RProductCategoryId { get; set; }
    public string ProductCategory { get; set; } = "";
    public string? LongName { get; set; }
    public string? ShortName { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class RQuantityMethod
{
    public int RQuantityMethodId { get; set; }
    public string QuantityMethod { get; set; } = "";
    public bool IsActive { get; set; }
    public string? LongName { get; set; }
    public string? ShortName { get; set; }
    public string? Remark { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class RRatioCurveType
{
    public int RRatioCurveTypeId { get; set; }
    public string RatioCurveType { get; set; } = "";
    public string? LongName { get; set; }
    public string? ShortName { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class RRatioFluidType
{
    public int RRatioFluidTypeId { get; set; }
    public string RatioFluidType { get; set; } = "";
    public string? LongName { get; set; }
    public string? ShortName { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class RReportingFlow
{
    public int RReportingFlowId { get; set; }
    public string ReportingFlow { get; set; } = "";
    public int? ParentFlowKindId { get; set; }
    public int? RDispositionCategoryId { get; set; }
    public string? LongName { get; set; }
    public string? ShortName { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class RReportingProduct
{
    public int RReportingProductId { get; set; }
    public string Product { get; set; } = "";
    public int? RProductCategoryId { get; set; }
    public string? LongName { get; set; }
    public string? ShortName { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class RSaturationPointType
{
    public int RSaturationPointTypeId { get; set; }
    public string SaturationPointType { get; set; } = "";
    public string? LongName { get; set; }
    public string? ShortName { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class RTriggerType
{
    public bool IsActive { get; set; }
    public int RTriggerTypeId { get; set; }
    public string? Remark { get; set; }
    public string? RowChangedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public string? TriggerType { get; set; }
    public string? LongName { get; set; }
    public string? ShortName { get; set; }
}

public class RValidateResult
{
    public int RValidateResultId { get; set; }
    public string ValidateResult { get; set; } = "";
    public string? LongName { get; set; }
    public string? ShortName { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class RVolumeMethod
{
    public bool IsActive { get; set; }
    public int RVolumeMethodId { get; set; }
    public string? Remark { get; set; }
    public string? RowChangedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public string? VolumeMethod { get; set; }
    public string? LongName { get; set; }
    public string? ShortName { get; set; }
}

public class RWellTestType
{
    public int RWellTestTypeId { get; set; }
    public string WellTestType { get; set; } = "";
    public bool IsActive { get; set; }
    public string? LongName { get; set; }
    public string? ShortName { get; set; }
    public string? Remark { get; set; }
    public string? RowChangedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
}

public class SpBoundary
{
    public int SpBoundaryId { get; set; }
    public int? PolygonId { get; set; }
    public int? PointSeqNo { get; set; }
    public decimal? Depth { get; set; }
    public decimal? Elevation { get; set; }
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }
    public string? Remark { get; set; }
    public bool? IsActive { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class SpDescText
{
    public int SpDescTextId { get; set; }
    public int SpatialDescriptionId { get; set; }
    public string? TextId { get; set; }
    public string? Description { get; set; }
    public string? Remark { get; set; }
    public bool? IsActive { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class SpPolygon
{
    public int PolygonId { get; set; }
    public string PolygonName { get; set; } = "";
    public string? BoundaryDirection { get; set; }
    public int? CrsId { get; set; }
    public decimal? DatumElev { get; set; }
    public string? MaxPlotScale { get; set; }
    public string? MinPlotScale { get; set; }
    public string? ReferenceDatum { get; set; }
    public int SpatialDescriptionId { get; set; }
    public string? Remark { get; set; }
    public bool? IsActive { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class PdmVersion
{
    public int Id { get; set; }
    public long VersionValue { get; set; }
    public string Filename { get; set; } = "";
    public string Buildurl { get; set; } = "";
    public DateTime Createdate { get; set; }
}

public class WellEvent
{
    public int WellEventId { get; set; }
    public int WellId { get; set; }
    public string Uwi { get; set; } = "";
    public DateTime EventDate { get; set; }
    public int REventSubCategoryId { get; set; }
    public string EventSubCategory { get; set; } = "";
    public decimal? EventDuration { get; set; }
    public int? RDowntimeTypeId { get; set; }
    public string? DowntimeType { get; set; }
    public decimal? BaseDepth { get; set; }
    public decimal? TopDepth { get; set; }
    public decimal? LostVolumeOil { get; set; }
    public decimal? LostVolumeGas { get; set; }
    public string? Description { get; set; }
    public int? RSourceId { get; set; }
    public string? Source { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public string? RowChangedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
}

public class WellEventPlan
{
    public int WellEventPlanId { get; set; }
    public int WellId { get; set; }
    public string Uwi { get; set; } = "";
    public DateTime PlannedStartDate { get; set; }
    public DateTime? PlannedEndDate { get; set; }
    public int REventSubCategoryId { get; set; }
    public string EventSubCategory { get; set; } = "";
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public string? PlanOwner { get; set; }
    public int? RSourceId { get; set; }
    public string? Source { get; set; }
    public string? RowChangedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
}

public class WellStatusHistory
{
    public int WellStatusHistoryId { get; set; }
    public int WellId { get; set; }
    public string Uwi { get; set; } = "";
    public DateTime EffectiveDate { get; set; }
    public int? RWellStatusId { get; set; }
    public string? DisplayName { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public string? RowChangedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
}

public class WellTest
{
    public int WellTestId { get; set; }
    public int ReportingEntityId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public decimal? TestDuration { get; set; }
    public int? RTimezoneId { get; set; }
    public int? RWellTestTypeId { get; set; }
    public int? PressureTemperatureId { get; set; }
    public string? TestDevice { get; set; }
    public string? TestBy { get; set; }
    public bool? IsValidated { get; set; }
    public int? RValidateResultId { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
    public decimal? Temperature { get; set; }
    public decimal? Pressure { get; set; }
    public string? Timezone { get; set; }
    public string? ValidateResult { get; set; }
    public string? WellTestType { get; set; }
    public string AssociatedObjectName { get; set; } = "";
}

public class WellTestAllocationFactor
{
    public int WellTestAllocationFactorId { get; set; }
    public int WellTestId { get; set; }
    public int ToEntityId { get; set; }
    public decimal? AllocationFactor { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
    public int RReportingProductId { get; set; }
}

public class WellTestFlowMeasurement
{
    public int WellTestFlowMeasurementId { get; set; }
    public int WellTestFlowPeriodId { get; set; }
    public int RFlowKindId { get; set; }
    public decimal? Rate { get; set; }
    public string? RateUom { get; set; }
    public decimal? Volume { get; set; }
    public string? VolumeUom { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
    public string ReportingFlow { get; set; } = "";
    public string TestProduct { get; set; } = "";
    public int WellTestId { get; set; }
    public int FlowPeriod { get; set; }
    public int RReportingProductId { get; set; }
    public string Product { get; set; } = "";
}

public class WellTestFlowPeriod
{
    public int WellTestFlowPeriodId { get; set; }
    public int WellTestId { get; set; }
    public int FlowPeriod { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public decimal? TestDuration { get; set; }
    public bool? IsActive { get; set; }
    public string? Remark { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
}

public class WellTestMeasurement
{
    public int WellTestMeasurementId { get; set; }
    public int WellTestFlowPeriodId { get; set; }
    public int RMeasurementId { get; set; }
    public decimal? Value { get; set; }
    public string? ValueOum { get; set; }
    public bool IsActive { get; set; }
    public string? Remark { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowChangedBy { get; set; }
    public string Measurement { get; set; } = "";
    public int WellTestId { get; set; }
    public int FlowPeriod { get; set; }
}

public class WellVolDaily
{
    public int WellVolumeDailyId { get; set; }
    public int WellId { get; set; }
    public string Uwi { get; set; } = "";
    public DateTime VolumeDate { get; set; }
    public bool IsActive { get; set; }
    public decimal? HoursOn { get; set; }
    public decimal? OilVolume { get; set; }
    public decimal? OilQuality { get; set; }
    public decimal? GasVolume { get; set; }
    public decimal? GasQuality { get; set; }
    public decimal? GasEnergy { get; set; }
    public decimal? BoeVolume { get; set; }
    public decimal? WaterVolume { get; set; }
    public decimal? LiquidVolume { get; set; }
    public decimal? CondensateVolume { get; set; }
    public decimal? Co2Volume { get; set; }
    public decimal? NitrogenVolume { get; set; }
    public decimal? NglVolume { get; set; }
    public decimal? SulphurVolume { get; set; }
    public int? InjectionCycle { get; set; }
    public decimal? InjWaterVolume { get; set; }
    public decimal? InjOilVolume { get; set; }
    public decimal? InjGasVolume { get; set; }
    public decimal? InjCo2Volume { get; set; }
    public decimal? InjSteamVolume { get; set; }
    public decimal? InjPolymerVolume { get; set; }
    public decimal? TubingPress { get; set; }
    public decimal? CasingPress { get; set; }
    public decimal? BhPress { get; set; }
    public decimal? FlPress { get; set; }
    public decimal? SepPress { get; set; }
    public decimal? InjectionPress { get; set; }
    public decimal? WhTemp { get; set; }
    public decimal? BhTemp { get; set; }
    public decimal? FlTemp { get; set; }
    public decimal? SepTemp { get; set; }
    public decimal? InjWhSteamPress { get; set; }
    public decimal? InjWhSteamTemp { get; set; }
    public decimal? InjWhSteamDry { get; set; }
    public decimal? WaterCutPercent { get; set; }
    public decimal? GasOilRatio { get; set; }
    public string? RowChangedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public decimal? CumOilVolume { get; set; }
    public decimal? CumGasVolume { get; set; }
    public decimal? CumBoeVolume { get; set; }
    public decimal? CumWaterVolume { get; set; }
    public decimal? CumLiquidVolume { get; set; }
    public decimal? CumCondensateVolume { get; set; }
    public decimal? CumCo2Volume { get; set; }
    public decimal? CumNitrogenVolume { get; set; }
    public decimal? CumSulphurVolume { get; set; }
    public decimal? CumInjWaterVolume { get; set; }
    public decimal? CumInjOilVolume { get; set; }
    public decimal? CumInjGasVolume { get; set; }
    public decimal? CumInjCo2Volume { get; set; }
    public decimal? CumInjSteamVolume { get; set; }
    public decimal? CumInjPolymerVolume { get; set; }
    public decimal? CumNglVolume { get; set; }
    public int? RVolumeMethodId { get; set; }
    public string? VolumeMethod { get; set; }
}

public class WellVolMonthly
{
    public int WellVolumeMonthlyId { get; set; }
    public int WellId { get; set; }
    public string Uwi { get; set; } = "";
    public DateTime VolumeDate { get; set; }
    public int? YearMonth { get; set; }
    public bool IsActive { get; set; }
    public decimal? DaysOn { get; set; }
    public decimal? MonthlyOil { get; set; }
    public decimal? AvgOil { get; set; }
    public decimal? AvgOilQuality { get; set; }
    public decimal? MonthlyGas { get; set; }
    public decimal? AvgGas { get; set; }
    public decimal? AvgGasQuality { get; set; }
    public decimal? AvgGasEnergy { get; set; }
    public decimal? MonthlyBoe { get; set; }
    public decimal? AvgBoe { get; set; }
    public decimal? MonthlyWater { get; set; }
    public decimal? AvgWater { get; set; }
    public decimal? MonthlyLiquid { get; set; }
    public decimal? AvgLiquid { get; set; }
    public decimal? MonthlyCondensate { get; set; }
    public decimal? AvgCondensate { get; set; }
    public decimal? MonthlyCo2 { get; set; }
    public decimal? AvgCo2 { get; set; }
    public decimal? MonthlyNitrogen { get; set; }
    public decimal? AvgNitrogen { get; set; }
    public decimal? MonthlyNgl { get; set; }
    public decimal? AvgNgl { get; set; }
    public decimal? MonthlySulphur { get; set; }
    public decimal? AvgSulphur { get; set; }
    public decimal? MonthlyInjWater { get; set; }
    public decimal? AvgInjWater { get; set; }
    public decimal? MonthlyInjOil { get; set; }
    public decimal? AvgInjOil { get; set; }
    public decimal? MonthlyInjGas { get; set; }
    public decimal? AvgInjGas { get; set; }
    public decimal? MonthlyInjCo2 { get; set; }
    public decimal? AvgInjCo2 { get; set; }
    public decimal? MonthlyInjSteam { get; set; }
    public decimal? AvgInjSteam { get; set; }
    public decimal? MonthlyInjPolymer { get; set; }
    public decimal? AvgInjPolymer { get; set; }
    public decimal? AvgTubingPress { get; set; }
    public decimal? MaxTubingPress { get; set; }
    public decimal? MinTubingPress { get; set; }
    public decimal? AvgCasingPress { get; set; }
    public decimal? MaxCasingPress { get; set; }
    public decimal? MinCasingPress { get; set; }
    public decimal? AvgBhPress { get; set; }
    public decimal? MaxBhPress { get; set; }
    public decimal? MinBhPress { get; set; }
    public decimal? AvgFlPress { get; set; }
    public decimal? MaxFlPress { get; set; }
    public decimal? MinFlPress { get; set; }
    public decimal? AvgSepPress { get; set; }
    public decimal? MaxSepPress { get; set; }
    public decimal? MinSepPress { get; set; }
    public decimal? AvgInjectionPress { get; set; }
    public decimal? MaxInjectionPress { get; set; }
    public decimal? MinInjectionPress { get; set; }
    public decimal? AvgWhTemp { get; set; }
    public decimal? MaxWhTemp { get; set; }
    public decimal? MinWhTemp { get; set; }
    public decimal? AvgBhTemp { get; set; }
    public decimal? MaxBhTemp { get; set; }
    public decimal? MinBhTemp { get; set; }
    public decimal? AvgFlTemp { get; set; }
    public decimal? MaxFlTemp { get; set; }
    public decimal? MinFlTemp { get; set; }
    public decimal? AvgSepTemp { get; set; }
    public decimal? MaxSepTemp { get; set; }
    public decimal? MinSepTemp { get; set; }
    public decimal? AvgInjWhSteamPress { get; set; }
    public decimal? MaxInjWhSteamPress { get; set; }
    public decimal? MinInjWhSteamPress { get; set; }
    public decimal? AvgInjWhSteamTemp { get; set; }
    public decimal? MaxInjWhSteamTemp { get; set; }
    public decimal? MinInjWhSteamTemp { get; set; }
    public decimal? AvgInjWhSteamDry { get; set; }
    public decimal? MaxInjWhSteamDry { get; set; }
    public decimal? MinInjWhSteamDry { get; set; }
    public decimal? MonthWaterCutPercent { get; set; }
    public decimal? MonthGasOilRatio { get; set; }
    public string? RowChangedBy { get; set; }
    public DateTime? RowChangedDate { get; set; }
    public string? RowCreatedBy { get; set; }
    public DateTime? RowCreatedDate { get; set; }
    public decimal? CumOil { get; set; }
    public decimal? CumGas { get; set; }
    public decimal? CumBoe { get; set; }
    public decimal? CumWater { get; set; }
    public decimal? CumLiquid { get; set; }
    public decimal? CumCondensate { get; set; }
    public decimal? CumCo2 { get; set; }
    public decimal? CumNitrogen { get; set; }
    public decimal? CumSulphur { get; set; }
    public decimal? CumInjWater { get; set; }
    public decimal? CumInjOil { get; set; }
    public decimal? CumInjGas { get; set; }
    public decimal? CumInjCo2 { get; set; }
    public decimal? CumInjSteam { get; set; }
    public decimal? CumInjPolymer { get; set; }
    public decimal? CumNgl { get; set; }
}


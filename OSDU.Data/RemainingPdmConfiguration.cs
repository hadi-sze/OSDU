using Microsoft.EntityFrameworkCore;
using OSDU.Data.MasterData;

namespace OSDU.Data;

internal static class RemainingPdmConfiguration
{
    internal static void Configure(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Alarm>(entity =>
        {
            entity.ToTable("ALARM");
            entity.HasKey(x => x.AlarmId);
            entity.Property(x => x.AlarmId).HasColumnName("ALARM_ID");
            entity.Property(x => x.AlarmSettingsId).HasColumnName("ALARM_SETTINGS_ID");
            entity.HasOne<AlarmSettings>().WithMany().HasForeignKey(x => x.AlarmSettingsId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.Counter).HasColumnName("COUNTER");
            entity.Property(x => x.IsAcknowledged).HasColumnName("IS_ACKNOWLEDGED");
            entity.Property(x => x.AcknowledgedComments).HasColumnName("ACKNOWLEDGED_COMMENTS").HasMaxLength(255);
            entity.Property(x => x.AcknowledgedBy).HasColumnName("ACKNOWLEDGED_BY").HasMaxLength(50);
            entity.Property(x => x.REventCategoryId).HasColumnName("R_EVENT_CATEGORY_ID");
            entity.HasOne<REventCategory>().WithMany().HasForeignKey(x => x.REventCategoryId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.EventCategory).HasColumnName("EVENT_CATEGORY").HasMaxLength(40);
            entity.Property(x => x.REventSubCategoryId).HasColumnName("R_EVENT_SUB_CATEGORY_ID");
            entity.HasOne<REventSubCategory>().WithMany().HasForeignKey(x => x.REventSubCategoryId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.EventSubCategory).HasColumnName("EVENT_SUB_CATEGORY").HasMaxLength(40);
            entity.Property(x => x.IsNotificationSuccess).HasColumnName("IS_NOTIFICATION_SUCCESS");
            entity.Property(x => x.StatusId).HasColumnName("STATUS_ID");
            entity.HasOne<RAlarmStatus>().WithMany().HasForeignKey(x => x.StatusId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.Status).HasColumnName("STATUS").HasMaxLength(40);
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
            entity.Property(x => x.TriggerTypeId).HasColumnName("TRIGGER_TYPE_ID");
            entity.Property(x => x.TriggerType).HasColumnName("TRIGGER_TYPE").HasMaxLength(40);
            entity.Property(x => x.EventDate).HasColumnName("EVENT_DATE");
            entity.Property(x => x.RAlarmSubCategoryId).HasColumnName("R_ALARM_SUB_CATEGORY_ID");
            entity.HasOne<RAlarmSubCategory>().WithMany().HasForeignKey(x => x.RAlarmSubCategoryId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.AlarmSubCategory).HasColumnName("ALARM_SUB_CATEGORY").HasMaxLength(100);
        });

        modelBuilder.Entity<AlarmDetail>(entity =>
        {
            entity.ToTable("ALARM_DETAIL");
            entity.HasKey(x => x.AlarmDetailId);
            entity.Property(x => x.AlarmDetailId).HasColumnName("ALARM_DETAIL_ID");
            entity.Property(x => x.AlarmId).HasColumnName("ALARM_ID");
            entity.HasOne<Alarm>().WithMany().HasForeignKey(x => x.AlarmId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.AlarmDescription).HasColumnName("ALARM_DESCRIPTION").HasMaxLength(255);
            entity.Property(x => x.Date).HasColumnName("DATE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
            entity.Property(x => x.TagsId).HasColumnName("TAGS_ID").HasMaxLength(50);
        });

        modelBuilder.Entity<AlarmNotification>(entity =>
        {
            entity.ToTable("ALARM_NOTIFICATION");
            entity.HasKey(x => x.AlarmNotificationId);
            entity.Property(x => x.AlarmNotificationId).HasColumnName("ALARM_NOTIFICATION_ID");
            entity.Property(x => x.RAlarmSubCategoryId).HasColumnName("R_ALARM_SUB_CATEGORY_ID");
            entity.HasOne<RAlarmSubCategory>().WithMany().HasForeignKey(x => x.RAlarmSubCategoryId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.UserGroup).HasColumnName("USER_GROUP").HasMaxLength(2000);
            entity.Property(x => x.EmailConfigId).HasColumnName("EMAIL_CONFIG_ID");
            entity.HasOne<EmailConfig>().WithMany().HasForeignKey(x => x.EmailConfigId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
        });

        modelBuilder.Entity<EmailConfig>(entity =>
        {
            entity.ToTable("EMAIL_CONFIG");
            entity.HasKey(x => x.EmailConfigId);
            entity.Property(x => x.EmailConfigId).HasColumnName("EMAIL_CONFIG_ID");
            entity.Property(x => x.AlarmCategoryId).HasColumnName("ALARM_CATEGORY_ID");
            entity.HasOne<RAlarmCategory>().WithMany().HasForeignKey(x => x.AlarmCategoryId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.EmailSubject).HasColumnName("EMAIL_SUBJECT").HasMaxLength(255);
            entity.Property(x => x.HelloWords).HasColumnName("HELLO_WORDS").HasMaxLength(255);
            entity.Property(x => x.Introduction).HasColumnName("INTRODUCTION").HasMaxLength(2000);
            entity.Property(x => x.Body).HasColumnName("BODY").HasMaxLength(2000);
            entity.Property(x => x.DetailLink).HasColumnName("DETAIL_LINK").HasMaxLength(255);
            entity.Property(x => x.IsAutoSend).HasColumnName("IS_AUTO_SEND");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
        });

        modelBuilder.Entity<EquipmentSubtypeSpec>(entity =>
        {
            entity.ToTable("EQUIPMENT_SUBTYPE_SPEC");
            entity.HasKey(x => x.EquipmentSubtypeSpecId);
            entity.Property(x => x.EquipmentSubtypeSpecId).HasColumnName("EQUIPMENT_SUBTYPE_SPEC_ID");
            entity.Property(x => x.REquipmentSubTypeId).HasColumnName("R_EQUIPMENT_SUB_TYPE_ID");
            entity.HasOne<REquipmentSubType>().WithMany().HasForeignKey(x => x.REquipmentSubTypeId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.EquipmentSubType).HasColumnName("EQUIPMENT_SUB_TYPE").HasMaxLength(40);
            entity.Property(x => x.REquipmentSpecId).HasColumnName("R_EQUIPMENT_SPEC_ID");
            entity.HasOne<REquipmentSpec>().WithMany().HasForeignKey(x => x.REquipmentSpecId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.EquipmentSpec).HasColumnName("EQUIPMENT_SPEC").HasMaxLength(100);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<EquipmentTypeMeasurement>(entity =>
        {
            entity.ToTable("EQUIPMENT_TYPE_MEASUREMENT");
            entity.HasKey(x => x.EquipmentTypeMeasurementId);
            entity.Property(x => x.EquipmentTypeMeasurementId).HasColumnName("EQUIPMENT_TYPE_MEASUREMENT_ID");
            entity.Property(x => x.REquipmentTypeId).HasColumnName("R_EQUIPMENT_TYPE_ID");
            entity.HasOne<REquipmentType>().WithMany().HasForeignKey(x => x.REquipmentTypeId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.EquipmentType).HasColumnName("EQUIPMENT_TYPE").HasMaxLength(40);
            entity.Property(x => x.REquipmentMeasurementId).HasColumnName("R_EQUIPMENT_MEASUREMENT_ID");
            entity.HasOne<REquipmentMeasurement>().WithMany().HasForeignKey(x => x.REquipmentMeasurementId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.EquipmentMeasurement).HasColumnName("EQUIPMENT_MEASUREMENT").HasMaxLength(50);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<EquipmentTypeSpecification>(entity =>
        {
            entity.ToTable("EQUIPMENT_TYPE_SPECIFICATION");
            entity.HasKey(x => x.EquipmentTypeSpecId);
            entity.Property(x => x.EquipmentTypeSpecId).HasColumnName("EQUIPMENT_TYPE_SPEC_ID");
            entity.Property(x => x.REquipmentTypeId).HasColumnName("R_EQUIPMENT_TYPE_ID");
            entity.HasOne<REquipmentType>().WithMany().HasForeignKey(x => x.REquipmentTypeId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.EquipmentType).HasColumnName("EQUIPMENT_TYPE").HasMaxLength(40);
            entity.Property(x => x.REquipmentSpecId).HasColumnName("R_EQUIPMENT_SPEC_ID");
            entity.HasOne<REquipmentSpec>().WithMany().HasForeignKey(x => x.REquipmentSpecId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.EquipmentSpec).HasColumnName("EQUIPMENT_SPEC").HasMaxLength(100);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<FlowPortAlias>(entity =>
        {
            entity.ToTable("FLOW_PORT_ALIAS");
            entity.HasKey(x => x.FlowPortAliasId);
            entity.Property(x => x.FlowPortAliasId).HasColumnName("FLOW_PORT_ALIAS_ID");
            entity.Property(x => x.FlowPortId).HasColumnName("FLOW_PORT_ID");
            entity.HasOne<FlowPort>().WithMany().HasForeignKey(x => x.FlowPortId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.FlowPortAliasValue).HasColumnName("FLOW_PORT_ALIAS").HasMaxLength(64);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<FlowPortExpectedProduct>(entity =>
        {
            entity.ToTable("FLOW_PORT_EXPECTED_PRODUCT");
            entity.HasKey(x => x.FlowPortExpectedProductId);
            entity.Property(x => x.FlowPortExpectedProductId).HasColumnName("FLOW_PORT_EXPECTED_PRODUCT_ID");
            entity.Property(x => x.FlowPortId).HasColumnName("FLOW_PORT_ID");
            entity.Property(x => x.RReportingFlowId).HasColumnName("R_REPORTING_FLOW_ID");
            entity.Property(x => x.RReportingProductId).HasColumnName("R_REPORTING_PRODUCT_ID");
            entity.Property(x => x.UidRef).HasColumnName("UID_REF").HasMaxLength(64);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<FlowPortExpectedProperty>(entity =>
        {
            entity.ToTable("FLOW_PORT_EXPECTED_PROPERTY");
            entity.HasKey(x => x.FlowPortExpectedPropertyId);
            entity.Property(x => x.FlowPortExpectedPropertyId).HasColumnName("FLOW_PORT_EXPECTED_PROPERTY_ID");
            entity.Property(x => x.FlowPortId).HasColumnName("FLOW_PORT_ID");
            entity.HasOne<FlowPort>().WithMany().HasForeignKey(x => x.FlowPortId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.RFacilityParameterId).HasColumnName("R_FACILITY_PARAMETER_ID");
            entity.HasOne<RFacilityParameter>().WithMany().HasForeignKey(x => x.RFacilityParameterId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.DeadBand).HasColumnName("DEAD_BAND").HasPrecision(10, 5);
            entity.Property(x => x.MaximumFrequency).HasColumnName("MAXIMUM_FREQUENCY").HasPrecision(10, 5);
            entity.Property(x => x.Comment).HasColumnName("COMMENT").HasMaxLength(2000);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<FlowPortNfpTagAlias>(entity =>
        {
            entity.ToTable("FLOW_PORT_NFP_TAG_ALIAS");
            entity.HasKey(x => x.FlowPortNfpTagAliasId);
            entity.Property(x => x.FlowPortNfpTagAliasId).HasColumnName("FLOW_PORT_NFP_TAG_ALIAS_ID");
            entity.Property(x => x.FlowPortExpectedPropertyId).HasColumnName("FLOW_PORT_EXPECTED_PROPERTY_ID");
            entity.HasOne<FlowPortExpectedProperty>().WithMany().HasForeignKey(x => x.FlowPortExpectedPropertyId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.TagAlias).HasColumnName("TAG_ALIAS").HasMaxLength(64);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<FlowPortPropertyExpectedFlowProduct>(entity =>
        {
            entity.ToTable("FLOW_PORT_PROPERTY_EXPECTED_FLOW_PRODUCT");
            entity.HasKey(x => x.FlowPortPropertyExpectedFlowProductId);
            entity.Property(x => x.FlowPortPropertyExpectedFlowProductId).HasColumnName("FLOW_PORT_PROPERTY_ EXPECTED_FLOW_PRODUCT_ID");
            entity.Property(x => x.FlowPortExpectedPropertyId).HasColumnName("FLOW_PORT_EXPECTED_PROPERTY_ID");
            entity.HasOne<FlowPortExpectedProperty>().WithMany().HasForeignKey(x => x.FlowPortExpectedPropertyId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.RReportingFlowId).HasColumnName("R_REPORTING_FLOW_ID");
            entity.HasOne<RReportingFlow>().WithMany().HasForeignKey(x => x.RReportingFlowId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.RReportingProductId).HasColumnName("R_REPORTING_PRODUCT_ID");
            entity.HasOne<RReportingProduct>().WithMany().HasForeignKey(x => x.RReportingProductId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.RFlowQualifierId).HasColumnName("R_FLOW_QUALIFIER_ID");
            entity.HasOne<RFlowQualifier>().WithMany().HasForeignKey(x => x.RFlowQualifierId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.Uid).HasColumnName("UID").HasMaxLength(64);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<FlowUnitAlias>(entity =>
        {
            entity.ToTable("FLOW_UNIT_ALIAS");
            entity.HasKey(x => x.FlowUnitAliasId);
            entity.Property(x => x.FlowUnitAliasId).HasColumnName("FLOW_UNIT_ALIAS_ID");
            entity.Property(x => x.FlowUnitId).HasColumnName("FLOW_UNIT_ID");
            entity.HasOne<FlowUnit>().WithMany().HasForeignKey(x => x.FlowUnitId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.FlowUnitAliasValue).HasColumnName("FLOW_UNIT_ALIAS").HasMaxLength(64);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<FlowUnitContextFacility>(entity =>
        {
            entity.ToTable("FLOW_UNIT_CONTEXT_FACILITY");
            entity.HasKey(x => x.FlowUnitContextFacilityId);
            entity.Property(x => x.FlowUnitContextFacilityId).HasColumnName("FLOW_UNIT_CONTEXT_FACILITY_ID");
            entity.Property(x => x.FlowUnitId).HasColumnName("FLOW_UNIT_ID");
            entity.HasOne<FlowUnit>().WithMany().HasForeignKey(x => x.FlowUnitId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.ReportingFacilityId).HasColumnName("REPORTING_FACILITY_ID");
            entity.HasOne<ReportingFacility>().WithMany().HasForeignKey(x => x.ReportingFacilityId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.SiteKind).HasColumnName("SITE_KIND").HasMaxLength(64);
            entity.Property(x => x.NamingSystem).HasColumnName("NAMING_SYSTEM").HasMaxLength(64);
            entity.Property(x => x.UidRef).HasColumnName("UID_REF").HasMaxLength(64);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<FlowUnitExpectedFlowProduct>(entity =>
        {
            entity.ToTable("FLOW_UNIT_EXPECTED_FLOW_PRODUCT");
            entity.HasKey(x => x.FlowUnitExpectedFlowProductId);
            entity.Property(x => x.FlowUnitExpectedFlowProductId).HasColumnName("FLOW_UNIT_EXPECTED _FLOW_PRODUCT_ID");
            entity.Property(x => x.FlowUnitExpectedPropertyId).HasColumnName("FLOW_UNIT_EXPECTED_PROPERTY_ID");
            entity.HasOne<FlowUnitExpectedProperty>().WithMany().HasForeignKey(x => x.FlowUnitExpectedPropertyId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.RReportingFlowId).HasColumnName("R_REPORTING_FLOW_ID");
            entity.HasOne<RReportingFlow>().WithMany().HasForeignKey(x => x.RReportingFlowId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.RReportingProductId).HasColumnName("R_REPORTING_PRODUCT_ID");
            entity.HasOne<RReportingProduct>().WithMany().HasForeignKey(x => x.RReportingProductId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.RFlowQualifierId).HasColumnName("R_FLOW_QUALIFIER_ID");
            entity.HasOne<RFlowQualifier>().WithMany().HasForeignKey(x => x.RFlowQualifierId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.Uid).HasColumnName("UID").HasMaxLength(64);
            entity.Property(x => x.Comment).HasColumnName("COMMENT").HasMaxLength(2000);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<FlowUnitExpectedProperty>(entity =>
        {
            entity.ToTable("FLOW_UNIT_EXPECTED_PROPERTY");
            entity.HasKey(x => x.FlowUnitExpectedPropertyId);
            entity.Property(x => x.FlowUnitExpectedPropertyId).HasColumnName("FLOW_UNIT_EXPECTED_PROPERTY_ID");
            entity.Property(x => x.FlowUnitId).HasColumnName("FLOW_UNIT_ID");
            entity.HasOne<FlowUnit>().WithMany().HasForeignKey(x => x.FlowUnitId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.RFacilityParameterId).HasColumnName("R_FACILITY_PARAMETER_ID");
            entity.HasOne<RFacilityParameter>().WithMany().HasForeignKey(x => x.RFacilityParameterId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.DeadBand).HasColumnName("DEAD_BAND").HasPrecision(10, 5);
            entity.Property(x => x.MaximumFrequency).HasColumnName("MAXIMUM_FREQUENCY").HasPrecision(10, 5);
            entity.Property(x => x.ChildFacilityId).HasColumnName("CHILD_FACILITY_ID");
            entity.HasOne<ReportingFacility>().WithMany().HasForeignKey(x => x.ChildFacilityId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.Comment).HasColumnName("COMMENT").HasMaxLength(2000);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<FlowUnitNfpTagAlias>(entity =>
        {
            entity.ToTable("FLOW_UNIT_NFP_TAG_ALIAS");
            entity.HasKey(x => x.FlowUnitNfpTagAliasId);
            entity.Property(x => x.FlowUnitNfpTagAliasId).HasColumnName("FLOW_UNIT_NFP_TAG_ALIAS_ID");
            entity.Property(x => x.FlowUnitExpectedPropertyId).HasColumnName("FLOW_UNIT_EXPECTED_PROPERTY_ID");
            entity.HasOne<FlowUnitExpectedProperty>().WithMany().HasForeignKey(x => x.FlowUnitExpectedPropertyId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.TagAlias).HasColumnName("TAG_ALIAS").HasMaxLength(64);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<FluidAnalysis>(entity =>
        {
            entity.ToTable("FLUID_ANALYSIS");
            entity.HasKey(x => x.FluidAnalysisId);
            entity.Property(x => x.FluidAnalysisId).HasColumnName("FLUID_ANALYSIS_ID");
            entity.Property(x => x.ProdEntityId).HasColumnName("PROD_ENTITY_ID");
            entity.HasOne<ReportingEntity>().WithMany().HasForeignKey(x => x.ProdEntityId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.StartDate).HasColumnName("START_DATE");
            entity.Property(x => x.EndDate).HasColumnName("END_DATE");
            entity.Property(x => x.FluidAnalysisPurpose).HasColumnName("FLUID_ANALYSIS_PURPOSE").HasMaxLength(100);
            entity.Property(x => x.FluidAnalysisLaboratory).HasColumnName("FLUID_ANALYSIS_LABORATORY").HasMaxLength(100);
            entity.Property(x => x.Analyst).HasColumnName("ANALYST").HasMaxLength(100);
            entity.Property(x => x.ReportNumber).HasColumnName("REPORT_NUMBER").HasMaxLength(40);
            entity.Property(x => x.ReportedDate).HasColumnName("REPORTED_DATE");
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<FluidAnalysisPropertySummary>(entity =>
        {
            entity.ToTable("FLUID_ANALYSIS_PROPERTY_SUMMARY");
            entity.HasKey(x => x.FluidAnalysisPropertySummaryId);
            entity.Property(x => x.FluidAnalysisPropertySummaryId).HasColumnName("FLUID_ANALYSIS_PROPERTY_SUMMARY_ID");
            entity.Property(x => x.FluidAnalysisId).HasColumnName("FLUID_ANALYSIS_ID");
            entity.HasOne<FluidAnalysis>().WithMany().HasForeignKey(x => x.FluidAnalysisId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.RefPressure).HasColumnName("REF_PRESSURE").HasPrecision(8, 2);
            entity.Property(x => x.RefTemperature).HasColumnName("REF_TEMPERATURE").HasPrecision(10, 5);
            entity.Property(x => x.RProductId).HasColumnName("R_PRODUCT_ID");
            entity.HasOne<RReportingProduct>().WithMany().HasForeignKey(x => x.RProductId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.RFluidPropertyId).HasColumnName("R_FLUID_PROPERTY_ID");
            entity.HasOne<RFluidProperty>().WithMany().HasForeignKey(x => x.RFluidPropertyId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.Value).HasColumnName("VALUE").HasPrecision(15, 5);
            entity.Property(x => x.ValueUom).HasColumnName("VALUE_UOM").HasMaxLength(40);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<FluidAnalysisSample>(entity =>
        {
            entity.ToTable("FLUID_ANALYSIS_SAMPLE");
            entity.HasKey(x => x.FluidAnalysisSampleId);
            entity.Property(x => x.FluidAnalysisSampleId).HasColumnName("FLUID_ANALYSIS_SAMPLE_ID");
            entity.Property(x => x.FluidSampleId).HasColumnName("FLUID_SAMPLE_ID");
            entity.HasOne<FluidSample>().WithMany().HasForeignKey(x => x.FluidSampleId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.FluidAnalysisId).HasColumnName("FLUID_ANALYSIS_ID");
            entity.HasOne<FluidAnalysis>().WithMany().HasForeignKey(x => x.FluidAnalysisId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.FromCylinderNumber).HasColumnName("FROM_CYLINDER_NUMBER").HasMaxLength(100);
            entity.Property(x => x.ToCylinderNumber).HasColumnName("TO_CYLINDER_NUMBER").HasMaxLength(100);
            entity.Property(x => x.TransferDate).HasColumnName("TRANSFER_DATE");
            entity.Property(x => x.TransferPressure).HasColumnName("TRANSFER_PRESSURE").HasPrecision(8, 2);
            entity.Property(x => x.TransferTemperature).HasColumnName("TRANSFER_TEMPERATURE").HasPrecision(10, 5);
            entity.Property(x => x.TransferVolume).HasColumnName("TRANSFER_VOLUME").HasPrecision(14, 4);
            entity.Property(x => x.RemainingVolume).HasColumnName("REMAINING_VOLUME").HasPrecision(14, 4);
            entity.Property(x => x.LabBubblePointPressure).HasColumnName("LAB_BUBBLE_POINT_PRESSURE").HasPrecision(8, 2);
            entity.Property(x => x.LabBubblePointTemperature).HasColumnName("LAB_BUBBLE_POINT_TEMPERATURE").HasPrecision(10, 5);
            entity.Property(x => x.OpeningPressure).HasColumnName("OPENING_PRESSURE").HasPrecision(8, 2);
            entity.Property(x => x.OpeningTemperature).HasColumnName("OPENING_TEMPERATURE").HasPrecision(10, 5);
            entity.Property(x => x.IsValid).HasColumnName("IS_VALID");
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<FluidAnalysisStep>(entity =>
        {
            entity.ToTable("FLUID_ANALYSIS_STEP");
            entity.HasKey(x => x.FluidAnalysisStepId);
            entity.Property(x => x.FluidAnalysisStepId).HasColumnName("FLUID_ANALYSIS_STEP_ID");
            entity.Property(x => x.FluidAnalysisId).HasColumnName("FLUID_ANALYSIS_ID");
            entity.HasOne<FluidAnalysis>().WithMany().HasForeignKey(x => x.FluidAnalysisId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.RFluidAnalysisMethodId).HasColumnName("R_FLUID_ANALYSIS_METHOD_ID");
            entity.HasOne<RFluidAnalysisMethod>().WithMany().HasForeignKey(x => x.RFluidAnalysisMethodId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.StepSequence).HasColumnName("STEP_SEQUENCE");
            entity.Property(x => x.StepPressure).HasColumnName("STEP_PRESSURE").HasPrecision(8, 2);
            entity.Property(x => x.StepTemperature).HasColumnName("STEP_TEMPERATURE").HasPrecision(10, 5);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<FluidCompositionAnalysis>(entity =>
        {
            entity.ToTable("FLUID_COMPOSITION_ANALYSIS");
            entity.HasKey(x => x.FluidCompositionAnalysisId);
            entity.Property(x => x.FluidCompositionAnalysisId).HasColumnName("FLUID_COMPOSITION_ANALYSIS_ID");
            entity.Property(x => x.FluidAnalysisStepId).HasColumnName("FLUID_ANALYSIS_STEP_ID");
            entity.HasOne<FluidAnalysisStep>().WithMany().HasForeignKey(x => x.FluidAnalysisStepId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.RProductId).HasColumnName("R_PRODUCT_ID");
            entity.HasOne<RReportingProduct>().WithMany().HasForeignKey(x => x.RProductId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.RFluidComponentId).HasColumnName("R_FLUID_COMPONENT_ID");
            entity.HasOne<RFluidComponent>().WithMany().HasForeignKey(x => x.RFluidComponentId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.MolecularWeight).HasColumnName("MOLECULAR_WEIGHT").HasPrecision(10, 5);
            entity.Property(x => x.WeightFraction).HasColumnName("WEIGHT_FRACTION").HasPrecision(10, 5);
            entity.Property(x => x.MoleFraction).HasColumnName("MOLE_FRACTION").HasPrecision(10, 5);
            entity.Property(x => x.VolumeFraction).HasColumnName("VOLUME_FRACTION").HasPrecision(10, 5);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<FluidResSurfVolRelation>(entity =>
        {
            entity.ToTable("FLUID_RES_SURF_VOL_RELATION");
            entity.HasKey(x => x.FluidResSurfVolRelationId);
            entity.Property(x => x.FluidResSurfVolRelationId).HasColumnName("FLUID_RES_SURF_VOL_RELATION_ID");
            entity.Property(x => x.FluidAnalysisStepId).HasColumnName("FLUID_ANALYSIS_STEP_ID");
            entity.HasOne<FluidAnalysisStep>().WithMany().HasForeignKey(x => x.FluidAnalysisStepId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.OilFvf).HasColumnName("OIL_FVF").HasPrecision(10, 5);
            entity.Property(x => x.GasFvf).HasColumnName("GAS_FVF").HasPrecision(10, 5);
            entity.Property(x => x.TotalFvf).HasColumnName("TOTAL_FVF").HasPrecision(10, 5);
            entity.Property(x => x.SolutionGor).HasColumnName("SOLUTION_GOR").HasPrecision(15, 6);
            entity.Property(x => x.ZFactor).HasColumnName("Z_FACTOR").HasPrecision(10, 5);
            entity.Property(x => x.OilViscosity).HasColumnName("OIL_VISCOSITY").HasPrecision(10, 5);
            entity.Property(x => x.GasViscosity).HasColumnName("GAS_VISCOSITY").HasPrecision(10, 5);
            entity.Property(x => x.LiquidViscosity).HasColumnName("LIQUID_VISCOSITY").HasPrecision(10, 5);
            entity.Property(x => x.OilGravity).HasColumnName("OIL_GRAVITY").HasPrecision(10, 5);
            entity.Property(x => x.GasGravity).HasColumnName("GAS_GRAVITY").HasPrecision(10, 5);
            entity.Property(x => x.LiquidDensity).HasColumnName("LIQUID_DENSITY").HasPrecision(10, 5);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<FluidSample>(entity =>
        {
            entity.ToTable("FLUID_SAMPLE");
            entity.HasKey(x => x.FluidSampleId);
            entity.Property(x => x.FluidSampleId).HasColumnName("FLUID_SAMPLE_ID");
            entity.Property(x => x.SampleNumber).HasColumnName("SAMPLE_NUMBER").HasMaxLength(100);
            entity.Property(x => x.SampleDate).HasColumnName("SAMPLE_DATE");
            entity.Property(x => x.ProdEntityId).HasColumnName("PROD_ENTITY_ID");
            entity.HasOne<ReportingEntity>().WithMany().HasForeignKey(x => x.ProdEntityId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.RFluidSampleMethodId).HasColumnName("R_FLUID_SAMPLE_METHOD_ID");
            entity.HasOne<RFluidSampleMethod>().WithMany().HasForeignKey(x => x.RFluidSampleMethodId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.RProductId).HasColumnName("R_PRODUCT_ID");
            entity.HasOne<RReportingProduct>().WithMany().HasForeignKey(x => x.RProductId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.AcquisitionDepth).HasColumnName("ACQUISITION_DEPTH").HasPrecision(15, 5);
            entity.Property(x => x.AcquisitionPressure).HasColumnName("ACQUISITION_PRESSURE").HasPrecision(8, 2);
            entity.Property(x => x.AcquisitionTemperature).HasColumnName("ACQUISITION_TEMPERATURE").HasPrecision(10, 5);
            entity.Property(x => x.AcquisitionVolume).HasColumnName("ACQUISITION_VOLUME").HasPrecision(14, 4);
            entity.Property(x => x.ServiceCompany).HasColumnName("SERVICE_COMPANY").HasMaxLength(100);
            entity.Property(x => x.IsRepresentative).HasColumnName("IS_REPRESENTATIVE");
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<FluidSampleDetail>(entity =>
        {
            entity.ToTable("FLUID_SAMPLE_DETAIL");
            entity.HasKey(x => x.FluidSampleDetailId);
            entity.Property(x => x.FluidSampleDetailId).HasColumnName("FLUID_SAMPLE_DETAIL_ID");
            entity.Property(x => x.FluidSampleId).HasColumnName("FLUID_SAMPLE_ID");
            entity.HasOne<FluidSample>().WithMany().HasForeignKey(x => x.FluidSampleId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.RMeasurementId).HasColumnName("R_MEASUREMENT_ID");
            entity.HasOne<RMeasurement>().WithMany().HasForeignKey(x => x.RMeasurementId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.Value).HasColumnName("VALUE").HasPrecision(15, 5);
            entity.Property(x => x.ValueUom).HasColumnName("VALUE_UOM").HasMaxLength(40);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<FluidSaturationPressure>(entity =>
        {
            entity.ToTable("FLUID_SATURATION_PRESSURE");
            entity.HasKey(x => x.FluidSaturationPressureId);
            entity.Property(x => x.FluidSaturationPressureId).HasColumnName("FLUID_SATURATION_PRESSURE_ID");
            entity.Property(x => x.FluidAnalysisStepId).HasColumnName("FLUID_ANALYSIS_STEP_ID");
            entity.HasOne<FluidAnalysisStep>().WithMany().HasForeignKey(x => x.FluidAnalysisStepId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.Volume).HasColumnName("VOLUME").HasPrecision(14, 4);
            entity.Property(x => x.Pressure).HasColumnName("PRESSURE").HasPrecision(8, 2);
            entity.Property(x => x.Optic).HasColumnName("OPTIC").HasPrecision(8, 2);
            entity.Property(x => x.RSaturationPointTypeId).HasColumnName("R_SATURATION_POINT_TYPE_ID");
            entity.HasOne<RSaturationPointType>().WithMany().HasForeignKey(x => x.RSaturationPointTypeId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<Hierarchy>(entity =>
        {
            entity.ToTable("HIERARCHY");
            entity.HasKey(x => x.HierarchyId);
            entity.Property(x => x.HierarchyId).HasColumnName("HIERARCHY_ID");
            entity.Property(x => x.HierarchyName).HasColumnName("HIERARCHY_NAME").HasMaxLength(50);
            entity.Property(x => x.TenantId).HasColumnName("TENANT_ID").HasMaxLength(100);
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<HierarchyDesc>(entity =>
        {
            entity.ToTable("HIERARCHY_DESC");
            entity.HasKey(x => x.HierarchyDescId);
            entity.Property(x => x.HierarchyDescId).HasColumnName("HIERARCHY_DESC_ID");
            entity.Property(x => x.HierarchyId).HasColumnName("HIERARCHY_ID");
            entity.HasOne<Hierarchy>().WithMany().HasForeignKey(x => x.HierarchyId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.ROrgUnitTypeId).HasColumnName("R_ORG_UNIT_TYPE_ID");
            entity.HasOne<ROrgUnitType>().WithMany().HasForeignKey(x => x.ROrgUnitTypeId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.ParentHierarchyDescId).HasColumnName("PARENT_HIERARCHY_DESC_ID");
            entity.HasOne<HierarchyDesc>().WithMany().HasForeignKey(x => x.ParentHierarchyDescId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.EffectiveDate).HasColumnName("EFFECTIVE_DATE");
            entity.Property(x => x.ExpiryDate).HasColumnName("EXPIRY_DATE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<HierarchyLevel>(entity =>
        {
            entity.ToTable("HIERARCHY_LEVEL");
            entity.HasKey(x => x.HierarchyLevelId);
            entity.Property(x => x.HierarchyLevelId).HasColumnName("HIERARCHY_LEVEL_ID");
            entity.Property(x => x.HierarchyDescId).HasColumnName("HIERARCHY_DESC_ID");
            entity.HasOne<HierarchyDesc>().WithMany().HasForeignKey(x => x.HierarchyDescId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.OrgUnitId).HasColumnName("ORG_UNIT_ID");
            entity.HasOne<OrgUnit>().WithMany().HasForeignKey(x => x.OrgUnitId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.ParentHierarchyLevelId).HasColumnName("PARENT_HIERARCHY_LEVEL_ID");
            entity.HasOne<HierarchyLevel>().WithMany().HasForeignKey(x => x.ParentHierarchyLevelId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.EffectiveDate).HasColumnName("EFFECTIVE_DATE");
            entity.Property(x => x.ExpiryDate).HasColumnName("EXPIRY_DATE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<HierarchyTemplate>(entity =>
        {
            entity.ToTable("HIERARCHY_TEMPLATE");
            entity.HasKey(x => x.HierarchyTemplateId);
            entity.Property(x => x.HierarchyTemplateId).HasColumnName("HIERARCHY_TEMPLATE_ID");
            entity.Property(x => x.HierarchyTemplateName).HasColumnName("HIERARCHY_TEMPLATE_NAME").HasMaxLength(200);
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<HierarchyTemplateDesc>(entity =>
        {
            entity.ToTable("HIERARCHY_TEMPLATE_DESC");
            entity.HasKey(x => x.HierarchyTemplateDescId);
            entity.Property(x => x.HierarchyTemplateDescId).HasColumnName("HIERARCHY_TEMPLATE_DESC_ID");
            entity.Property(x => x.HierarchyTemplateId).HasColumnName("HIERARCHY_TEMPLATE_ID");
            entity.HasOne<HierarchyTemplate>().WithMany().HasForeignKey(x => x.HierarchyTemplateId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.ROrgUnitTypeId).HasColumnName("R_ORG_UNIT_TYPE_ID");
            entity.HasOne<ROrgUnitType>().WithMany().HasForeignKey(x => x.ROrgUnitTypeId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.ParentHierarchyTemplateDescId).HasColumnName("PARENT_HIERARCHY_TEMPLATE_DESC_ID");
            entity.HasOne<HierarchyTemplateDesc>().WithMany().HasForeignKey(x => x.ParentHierarchyTemplateDescId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<NetworkChangeLog>(entity =>
        {
            entity.ToTable("NETWORK_CHANGE_LOG");
            entity.HasKey(x => x.NetworkChangeLogId);
            entity.Property(x => x.NetworkChangeLogId).HasColumnName("NETWORK_CHANGE_LOG_ID");
            entity.Property(x => x.NetworkId).HasColumnName("NETWORK_ID");
            entity.HasOne<Network>().WithMany().HasForeignKey(x => x.NetworkId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.NetworkChangeName).HasColumnName("NETWORK_CHANGE_NAME").HasMaxLength(64);
            entity.Property(x => x.ChangeStartDate).HasColumnName("CHANGE_START_DATE");
            entity.Property(x => x.ChangeReason).HasColumnName("CHANGE_REASON").HasMaxLength(2000);
            entity.Property(x => x.Uid).HasColumnName("UID").HasMaxLength(64);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
        });

        modelBuilder.Entity<NetworkExternalPort>(entity =>
        {
            entity.ToTable("NETWORK_EXTERNAL_PORT");
            entity.HasKey(x => x.NetworkExternalPortId);
            entity.Property(x => x.NetworkExternalPortId).HasColumnName("NETWORK_EXTERNAL_PORT_ID");
            entity.Property(x => x.NetworkId).HasColumnName("NETWORK_ID");
            entity.HasOne<Network>().WithMany().HasForeignKey(x => x.NetworkId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.FlowPortId).HasColumnName("FLOW_PORT_ID");
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<NetworkPlanChangeLog>(entity =>
        {
            entity.ToTable("NETWORK_PLAN_CHANGE_LOG");
            entity.HasKey(x => x.NetworkPlanChangeLogId);
            entity.Property(x => x.NetworkPlanChangeLogId).HasColumnName("NETWORK_PLAN_CHANGE_LOG_ID");
            entity.Property(x => x.NetworkPlanId).HasColumnName("NETWORK_PLAN_ID");
            entity.HasOne<NetworkPlan>().WithMany().HasForeignKey(x => x.NetworkPlanId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.NetworkPlanChangeName).HasColumnName("NETWORK_PLAN_CHANGE_NAME").HasMaxLength(64);
            entity.Property(x => x.ChangeStartDate).HasColumnName("CHANGE_START_DATE");
            entity.Property(x => x.ChangeReason).HasColumnName("CHANGE_REASON").HasMaxLength(2000);
            entity.Property(x => x.Uid).HasColumnName("UID").HasMaxLength(64);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
        });

        modelBuilder.Entity<PressureTemperature>(entity =>
        {
            entity.ToTable("PRESSURE_TEMPERATURE");
            entity.HasKey(x => x.PressureTemperatureId);
            entity.Property(x => x.PressureTemperatureId).HasColumnName("PRESSURE_TEMPERATURE_ID");
            entity.Property(x => x.Temperature).HasColumnName("TEMPERATURE").HasPrecision(10, 5);
            entity.Property(x => x.Pressure).HasColumnName("PRESSURE").HasPrecision(10, 5);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<ProductVolumeSummary>(entity =>
        {
            entity.ToTable("PRODUCT_VOLUME_SUMMARY");
            entity.HasKey(x => x.ProductVolumeSummaryId);
            entity.Property(x => x.ProductVolumeSummaryId).HasColumnName("PRODUCT_VOLUME_SUMMARY_ID");
            entity.Property(x => x.ReportingEntityId).HasColumnName("REPORTING_ENTITY_ID");
            entity.HasOne<ReportingEntity>().WithMany().HasForeignKey(x => x.ReportingEntityId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.ReportingEntityName).HasColumnName("REPORTING_ENTITY_NAME").HasMaxLength(50);
            entity.Property(x => x.StartDate).HasColumnName("START_DATE");
            entity.Property(x => x.EndDate).HasColumnName("END_DATE");
            entity.Property(x => x.RPeriodKindId).HasColumnName("R_PERIOD_KIND_ID");
            entity.HasOne<RPeriodKind>().WithMany().HasForeignKey(x => x.RPeriodKindId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.PeriodKind).HasColumnName("PERIOD_KIND").HasMaxLength(40);
            entity.Property(x => x.RReportingFlowId).HasColumnName("R_REPORTING_FLOW_ID");
            entity.HasOne<RReportingFlow>().WithMany().HasForeignKey(x => x.RReportingFlowId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.ReportingFlow).HasColumnName("REPORTING_FLOW").HasMaxLength(40);
            entity.Property(x => x.RReportingProductId).HasColumnName("R_REPORTING_PRODUCT_ID");
            entity.HasOne<RReportingProduct>().WithMany().HasForeignKey(x => x.RReportingProductId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.Product).HasColumnName("PRODUCT").HasMaxLength(40);
            entity.Property(x => x.RQuantityMethodId).HasColumnName("R_QUANTITY_METHOD_ID");
            entity.HasOne<RQuantityMethod>().WithMany().HasForeignKey(x => x.RQuantityMethodId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.QuantityMethod).HasColumnName("QUANTITY_METHOD").HasMaxLength(40);
            entity.Property(x => x.AmendmentSeqNo).HasColumnName("AMENDMENT_SEQ_NO");
            entity.Property(x => x.ScenarioId).HasColumnName("SCENARIO_ID");
            entity.HasOne<Scenario>().WithMany().HasForeignKey(x => x.ScenarioId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.Volume).HasColumnName("VOLUME").HasPrecision(14, 4);
            entity.Property(x => x.VolumeUom).HasColumnName("VOLUME_UOM").HasMaxLength(40);
            entity.Property(x => x.PressureTemperatureId).HasColumnName("PRESSURE_TEMPERATURE_ID");
            entity.HasOne<PressureTemperature>().WithMany().HasForeignKey(x => x.PressureTemperatureId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.Temperature).HasColumnName("TEMPERATURE").HasPrecision(10, 5);
            entity.Property(x => x.Pressure).HasColumnName("PRESSURE").HasPrecision(10, 5);
            entity.Property(x => x.Mass).HasColumnName("MASS").HasPrecision(14, 4);
            entity.Property(x => x.MassUom).HasColumnName("MASS_UOM").HasMaxLength(40);
            entity.Property(x => x.Energy).HasColumnName("ENERGY").HasPrecision(14, 4);
            entity.Property(x => x.EnergyUom).HasColumnName("ENERGY_UOM").HasMaxLength(40);
            entity.Property(x => x.RAmendReasonId).HasColumnName("R_AMEND_REASON_ID");
            entity.HasOne<RAmendReason>().WithMany().HasForeignKey(x => x.RAmendReasonId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.AmendReason).HasColumnName("AMEND_REASON").HasMaxLength(255);
            entity.Property(x => x.Moles).HasColumnName("MOLES").HasPrecision(10, 5);
            entity.Property(x => x.MolseUom).HasColumnName("MOLSE_UOM").HasMaxLength(40);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remarks).HasColumnName("REMARKS").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<ProdDeclineForecast>(entity =>
        {
            entity.ToTable("PROD_DECLINE_FORECAST");
            entity.HasKey(x => x.ProdDeclineForecastId);
            entity.Property(x => x.ProdDeclineForecastId).HasColumnName("PROD_DECLINE_FORECAST_ID");
            entity.Property(x => x.ProdEntityId).HasColumnName("PROD_ENTITY_ID");
            entity.HasOne<ReportingEntity>().WithMany().HasForeignKey(x => x.ProdEntityId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.ScenarioId).HasColumnName("SCENARIO_ID");
            entity.HasOne<Scenario>().WithMany().HasForeignKey(x => x.ScenarioId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.RDeclineMethodId).HasColumnName("R_DECLINE_METHOD_ID");
            entity.HasOne<RDeclineMethod>().WithMany().HasForeignKey(x => x.RDeclineMethodId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.EffectiveDate).HasColumnName("EFFECTIVE_DATE");
            entity.Property(x => x.ExpiryDate).HasColumnName("EXPIRY_DATE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<ProdDeclineForecastClass>(entity =>
        {
            entity.ToTable("PROD_DECLINE_FORECAST_CLASS");
            entity.HasKey(x => x.ProdDeclineForecastClassId);
            entity.Property(x => x.ProdDeclineForecastClassId).HasColumnName("PROD_DECLINE_FORECAST_CLASS_ID");
            entity.Property(x => x.ProdDeclineForecastId).HasColumnName("PROD_DECLINE_FORECAST_ID");
            entity.HasOne<ProdDeclineForecast>().WithMany().HasForeignKey(x => x.ProdDeclineForecastId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.RForecastClassId).HasColumnName("R_FORECAST_CLASS_ID");
            entity.HasOne<RForecastClass>().WithMany().HasForeignKey(x => x.RForecastClassId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.RForecastClassTypeId).HasColumnName("R_FORECAST_CLASS_TYPE_ID");
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<ProdDeclineMethodParm>(entity =>
        {
            entity.ToTable("PROD_DECLINE_METHOD_PARM");
            entity.HasKey(x => x.ProdDeclineMethodParmId);
            entity.Property(x => x.ProdDeclineMethodParmId).HasColumnName("PROD_DECLINE_METHOD_PARM_ID");
            entity.Property(x => x.ProdDeclineSegmentId).HasColumnName("PROD_DECLINE_SEGMENT_ID");
            entity.HasOne<ProdDeclineSegment>().WithMany().HasForeignKey(x => x.ProdDeclineSegmentId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.RDeclineParmId).HasColumnName("R_DECLINE_PARM_ID");
            entity.HasOne<RDeclineParm>().WithMany().HasForeignKey(x => x.RDeclineParmId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.Value).HasColumnName("VALUE").HasPrecision(14, 4);
            entity.Property(x => x.ValueUom).HasColumnName("VALUE_UOM").HasMaxLength(40);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<ProdDeclineSegment>(entity =>
        {
            entity.ToTable("PROD_DECLINE_SEGMENT");
            entity.HasKey(x => x.ProdDeclineSegmentId);
            entity.Property(x => x.ProdDeclineSegmentId).HasColumnName("PROD_DECLINE_SEGMENT_ID");
            entity.Property(x => x.ProdDeclineForecastId).HasColumnName("PROD_DECLINE_FORECAST_ID");
            entity.HasOne<ProdDeclineForecast>().WithMany().HasForeignKey(x => x.ProdDeclineForecastId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.SegmentSequence).HasColumnName("SEGMENT_SEQUENCE");
            entity.Property(x => x.RProductId).HasColumnName("R_PRODUCT_ID");
            entity.HasOne<RReportingProduct>().WithMany().HasForeignKey(x => x.RProductId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.StartDate).HasColumnName("START_DATE");
            entity.Property(x => x.EndDate).HasColumnName("END_DATE");
            entity.Property(x => x.RDeclineCurveTypeId).HasColumnName("R_DECLINE_CURVE_TYPE_ID");
            entity.HasOne<RDeclineCurveType>().WithMany().HasForeignKey(x => x.RDeclineCurveTypeId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.RDeclineTypeId).HasColumnName("R_DECLINE_TYPE_ID");
            entity.HasOne<RDeclineType>().WithMany().HasForeignKey(x => x.RDeclineTypeId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.RRatioFluidTypeId).HasColumnName("R_RATIO_FLUID_TYPE_ID");
            entity.HasOne<RRatioFluidType>().WithMany().HasForeignKey(x => x.RRatioFluidTypeId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.RRatioCurveTypeId).HasColumnName("R_RATIO_CURVE_TYPE_ID");
            entity.HasOne<RRatioCurveType>().WithMany().HasForeignKey(x => x.RRatioCurveTypeId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.ParentProdDeclineSegmentId).HasColumnName("PARENT_PROD_DECLINE_SEGMENT_ID");
            entity.HasOne<ProdDeclineSegment>().WithMany().HasForeignKey(x => x.ParentProdDeclineSegmentId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.Volume).HasColumnName("VOLUME").HasPrecision(14, 4);
            entity.Property(x => x.VolumeUom).HasColumnName("VOLUME_UOM").HasMaxLength(40);
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<ProdDownTimeVolumeLoss>(entity =>
        {
            entity.ToTable("PROD_DOWN_TIME_VOLUME_LOSS");
            entity.HasKey(x => x.ProdDownTimeVolumeLossId);
            entity.Property(x => x.ProdDownTimeVolumeLossId).HasColumnName("PROD_DOWN_TIME_VOLUME_LOSS_ID");
            entity.Property(x => x.ProdDownTimeEventId).HasColumnName("PROD_DOWN_TIME_EVENT_ID");
            entity.HasOne<ProdDownTimeEvent>().WithMany().HasForeignKey(x => x.ProdDownTimeEventId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.RFlowKindId).HasColumnName("R_FLOW_KIND_ID");
            entity.HasOne<RReportingFlow>().WithMany().HasForeignKey(x => x.RFlowKindId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.RProductId).HasColumnName("R_PRODUCT_ID");
            entity.HasOne<RReportingProduct>().WithMany().HasForeignKey(x => x.RProductId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.LostVolume).HasColumnName("LOST_VOLUME").HasPrecision(14, 4);
            entity.Property(x => x.LostVolumeUom).HasColumnName("LOST_VOLUME_UOM").HasMaxLength(40);
            entity.Property(x => x.REstimationMethodId).HasColumnName("R_ESTIMATION_METHOD_ID");
            entity.HasOne<REstimationMethod>().WithMany().HasForeignKey(x => x.REstimationMethodId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<ProdHaulEvent>(entity =>
        {
            entity.ToTable("PROD_HAUL_EVENT");
            entity.HasKey(x => x.ProdHaulEventId);
            entity.Property(x => x.ProdHaulEventId).HasColumnName("PROD_HAUL_EVENT_ID");
            entity.Property(x => x.EventDate).HasColumnName("EVENT_DATE");
            entity.Property(x => x.ReportingEntityId).HasColumnName("REPORTING_ENTITY_ID");
            entity.HasOne<ReportingEntity>().WithMany().HasForeignKey(x => x.ReportingEntityId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.RProductId).HasColumnName("R_PRODUCT_ID");
            entity.HasOne<RReportingProduct>().WithMany().HasForeignKey(x => x.RProductId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.RHaulEventTypeId).HasColumnName("R_HAUL_EVENT_TYPE_ID");
            entity.HasOne<RHaulEventType>().WithMany().HasForeignKey(x => x.RHaulEventTypeId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.CargoNumber).HasColumnName("CARGO_NUMBER").HasMaxLength(100);
            entity.Property(x => x.FromOrToEntityId).HasColumnName("FROM_OR_TO_ENTITY_ID");
            entity.HasOne<ReportingEntity>().WithMany().HasForeignKey(x => x.FromOrToEntityId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.IsDownStream).HasColumnName("IS_DOWN_STREAM");
            entity.Property(x => x.FromOrToOrgUnitId).HasColumnName("FROM_OR_TO_ORG_UNIT_ID");
            entity.HasOne<OrgUnit>().WithMany().HasForeignKey(x => x.FromOrToOrgUnitId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.RFlowPartId).HasColumnName("R_FLOW_PART_ID");
            entity.HasOne<RFlowPart>().WithMany().HasForeignKey(x => x.RFlowPartId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.RReportingFlowId).HasColumnName("R_REPORTING_FLOW_ID");
            entity.HasOne<RReportingFlow>().WithMany().HasForeignKey(x => x.RReportingFlowId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.ReportedDate).HasColumnName("REPORTED_DATE");
            entity.Property(x => x.ShipperId).HasColumnName("SHIPPER_ID");
            entity.HasOne<OrgUnit>().WithMany().HasForeignKey(x => x.ShipperId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.CarrierId).HasColumnName("CARRIER_ID");
            entity.HasOne<OrgUnit>().WithMany().HasForeignKey(x => x.CarrierId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.SealOn).HasColumnName("SEAL_ON").HasMaxLength(100);
            entity.Property(x => x.SealOff).HasColumnName("SEAL_OFF").HasMaxLength(100);
            entity.Property(x => x.GrossVolume).HasColumnName("GROSS_VOLUME").HasPrecision(14, 4);
            entity.Property(x => x.GrossVolumeUom).HasColumnName("GROSS_VOLUME_UOM").HasMaxLength(40);
            entity.Property(x => x.RNetVolumeMethodId).HasColumnName("R_NET_VOLUME_METHOD_ID");
            entity.HasOne<RNetVolumeMethod>().WithMany().HasForeignKey(x => x.RNetVolumeMethodId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.NetVolume).HasColumnName("NET_VOLUME").HasPrecision(14, 4);
            entity.Property(x => x.NetVolumeUom).HasColumnName("NET_VOLUME_UOM").HasMaxLength(40);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<ProdHaulVolumeDetail>(entity =>
        {
            entity.ToTable("PROD_HAUL_VOLUME_DETAIL");
            entity.HasKey(x => x.ProdHaulVolumeDetailId);
            entity.Property(x => x.ProdHaulVolumeDetailId).HasColumnName("PROD_HAUL_VOLUME _DETAIL_ID");
            entity.Property(x => x.ProdHaulEventId).HasColumnName("PROD_HAUL_EVENT_ID");
            entity.HasOne<ProdHaulEvent>().WithMany().HasForeignKey(x => x.ProdHaulEventId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.BeginningHeight).HasColumnName("BEGINNING_HEIGHT").HasPrecision(14, 4);
            entity.Property(x => x.EndingHeight).HasColumnName("ENDING_HEIGHT").HasPrecision(14, 4);
            entity.Property(x => x.BeginningInventory).HasColumnName("BEGINNING_INVENTORY").HasPrecision(14, 4);
            entity.Property(x => x.EndingInventory).HasColumnName("ENDING_INVENTORY").HasPrecision(14, 4);
            entity.Property(x => x.BeginningTemp).HasColumnName("BEGINNING_TEMP").HasPrecision(14, 4);
            entity.Property(x => x.EndingTemp).HasColumnName("ENDING_TEMP").HasPrecision(14, 4);
            entity.Property(x => x.ObservedTemp).HasColumnName("OBSERVED_TEMP").HasPrecision(14, 4);
            entity.Property(x => x.Density).HasColumnName("DENSITY").HasPrecision(10, 5);
            entity.Property(x => x.FreeWaterPercent).HasColumnName("FREE_WATER_PERCENT").HasPrecision(10, 5);
            entity.Property(x => x.FreeEmulsionPercent).HasColumnName("FREE_EMULSION_PERCENT").HasPrecision(10, 5);
            entity.Property(x => x.SedimentWaterContent).HasColumnName("SEDIMENT_WATER_CONTENT").HasPrecision(10, 5);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<ProdSaleStatement>(entity =>
        {
            entity.ToTable("PROD_SALE_STATEMENT");
            entity.HasKey(x => x.ProdSaleStatementId);
            entity.Property(x => x.ProdSaleStatementId).HasColumnName("PROD_SALE_STATEMENT_ID");
            entity.Property(x => x.StartDate).HasColumnName("START_DATE");
            entity.Property(x => x.EndDate).HasColumnName("END_DATE");
            entity.Property(x => x.ReportingEntityId).HasColumnName("REPORTING_ENTITY_ID");
            entity.HasOne<ReportingEntity>().WithMany().HasForeignKey(x => x.ReportingEntityId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.RProductId).HasColumnName("R_PRODUCT_ID");
            entity.HasOne<RReportingProduct>().WithMany().HasForeignKey(x => x.RProductId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.SaleGrossVolume).HasColumnName("SALE_GROSS_VOLUME").HasPrecision(14, 4);
            entity.Property(x => x.SaleGrossVolumeUom).HasColumnName("SALE_GROSS_VOLUME_UOM").HasMaxLength(40);
            entity.Property(x => x.SaleNetVolume).HasColumnName("SALE_NET_VOLUME").HasPrecision(14, 4);
            entity.Property(x => x.SaleNetVolumeUom).HasColumnName("SALE_NET_VOLUME_UOM").HasMaxLength(40);
            entity.Property(x => x.ProdHaulEventId).HasColumnName("PROD_HAUL_EVENT_ID");
            entity.HasOne<ProdHaulEvent>().WithMany().HasForeignKey(x => x.ProdHaulEventId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.SellerId).HasColumnName("SELLER_ID");
            entity.HasOne<OrgUnit>().WithMany().HasForeignKey(x => x.SellerId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.PurchaserId).HasColumnName("PURCHASER_ID");
            entity.HasOne<OrgUnit>().WithMany().HasForeignKey(x => x.PurchaserId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.SalesAdministratorId).HasColumnName("SALES_ADMINISTRATOR_ID");
            entity.HasOne<OrgUnit>().WithMany().HasForeignKey(x => x.SalesAdministratorId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.PressureTemperatureId).HasColumnName("PRESSURE_TEMPERATURE_ID");
            entity.HasOne<PressureTemperature>().WithMany().HasForeignKey(x => x.PressureTemperatureId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.WetBasis).HasColumnName("WET_BASIS").HasPrecision(10, 5);
            entity.Property(x => x.HeatContent).HasColumnName("HEAT_CONTENT").HasPrecision(10, 5);
            entity.Property(x => x.PricePerUnit).HasColumnName("PRICE_PER_UNIT").HasPrecision(10, 5);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<RpenAllocationFactor>(entity =>
        {
            entity.ToTable("RPEN_ALLOCATION_FACTOR");
            entity.HasKey(x => x.RpenAllocationFactorId);
            entity.Property(x => x.RpenAllocationFactorId).HasColumnName("RPEN_ALLOCATION_FACTOR_ID");
            entity.Property(x => x.ToReportingEntityId).HasColumnName("TO_REPORTING_ENTITY_ID");
            entity.HasOne<ReportingEntity>().WithMany().HasForeignKey(x => x.ToReportingEntityId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.FromReportingEntityId).HasColumnName("FROM_REPORTING_ENTITY_ID");
            entity.HasOne<ReportingEntity>().WithMany().HasForeignKey(x => x.FromReportingEntityId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.RReportingProductId).HasColumnName("R_REPORTING_PRODUCT_ID");
            entity.HasOne<RReportingProduct>().WithMany().HasForeignKey(x => x.RReportingProductId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.RReportingFlowId).HasColumnName("R_REPORTING_FLOW_ID");
            entity.HasOne<RReportingFlow>().WithMany().HasForeignKey(x => x.RReportingFlowId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.AllocationFactor).HasColumnName("ALLOCATION_FACTOR").HasPrecision(10, 5);
            entity.Property(x => x.RAllocationTypeId).HasColumnName("R_ALLOCATION_TYPE_ID");
            entity.HasOne<RAllocationType>().WithMany().HasForeignKey(x => x.RAllocationTypeId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.CalculatedFrom).HasColumnName("CALCULATED_FROM").HasMaxLength(40);
            entity.Property(x => x.EffectiveDate).HasColumnName("EFFECTIVE_DATE");
            entity.Property(x => x.ExpiryDate).HasColumnName("EXPIRY_DATE");
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
        });

        modelBuilder.Entity<RAlarmCategory>(entity =>
        {
            entity.ToTable("R_ALARM_CATEGORY");
            entity.HasKey(x => x.RAlarmCategoryId);
            entity.Property(x => x.RAlarmCategoryId).HasColumnName("R_ALARM_CATEGORY_ID");
            entity.Property(x => x.AlarmCategory).HasColumnName("ALARM_CATEGORY").HasMaxLength(100);
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.LongName).HasColumnName("LONG_NAME").HasMaxLength(255);
            entity.Property(x => x.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(30);
        });

        modelBuilder.Entity<RAlarmStatus>(entity =>
        {
            entity.ToTable("R_ALARM_STATUS");
            entity.HasKey(x => x.RAlarmStatusId);
            entity.Property(x => x.RAlarmStatusId).HasColumnName("R_ALARM_STATUS_ID");
            entity.Property(x => x.AlarmStatus).HasColumnName("ALARM_STATUS").HasMaxLength(40);
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.LongName).HasColumnName("LONG_NAME").HasMaxLength(255);
            entity.Property(x => x.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(30);
        });

        modelBuilder.Entity<RAlarmSubCategory>(entity =>
        {
            entity.ToTable("R_ALARM_SUB_CATEGORY");
            entity.HasKey(x => x.RAlarmSubCategoryId);
            entity.Property(x => x.RAlarmSubCategoryId).HasColumnName("R_ALARM_SUB_CATEGORY_ID");
            entity.Property(x => x.AlarmSubCategory).HasColumnName("ALARM_SUB_CATEGORY").HasMaxLength(100);
            entity.Property(x => x.RAlarmCategoryId).HasColumnName("R_ALARM_CATEGORY_ID");
            entity.HasOne<RAlarmCategory>().WithMany().HasForeignKey(x => x.RAlarmCategoryId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.AlarmCategory).HasColumnName("ALARM_CATEGORY").HasMaxLength(100);
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.LongName).HasColumnName("LONG_NAME").HasMaxLength(255);
            entity.Property(x => x.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(30);
        });

        modelBuilder.Entity<RAllocationType>(entity =>
        {
            entity.ToTable("R_ALLOCATION_TYPE");
            entity.HasKey(x => x.RAllocationTypeId);
            entity.Property(x => x.RAllocationTypeId).HasColumnName("R_ALLOCATION_TYPE_ID");
            entity.Property(x => x.AllocationType).HasColumnName("ALLOCATION_TYPE").HasMaxLength(40);
            entity.Property(x => x.LongName).HasColumnName("LONG_NAME").HasMaxLength(255);
            entity.Property(x => x.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(30);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RSourceId).HasColumnName("R_SOURCE_ID");
            entity.HasOne<RSource>().WithMany().HasForeignKey(x => x.RSourceId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
        });

        modelBuilder.Entity<RAmendReason>(entity =>
        {
            entity.ToTable("R_AMEND_REASON");
            entity.HasKey(x => x.RAmendReasonId);
            entity.Property(x => x.RAmendReasonId).HasColumnName("R_AMEND_REASON_ID");
            entity.Property(x => x.AmendReason).HasColumnName("AMEND_REASON").HasMaxLength(255);
            entity.Property(x => x.LongName).HasColumnName("LONG_NAME").HasMaxLength(255);
            entity.Property(x => x.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(30);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
        });

        modelBuilder.Entity<RDeclineCurveType>(entity =>
        {
            entity.ToTable("R_DECLINE_CURVE_TYPE");
            entity.HasKey(x => x.RDeclineCurveTypeId);
            entity.Property(x => x.RDeclineCurveTypeId).HasColumnName("R_DECLINE_CURVE_TYPE_ID");
            entity.Property(x => x.DeclineCurveType).HasColumnName("DECLINE_CURVE_TYPE").HasMaxLength(40);
            entity.Property(x => x.LongName).HasColumnName("LONG_NAME").HasMaxLength(255);
            entity.Property(x => x.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(30);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<RDeclineMethod>(entity =>
        {
            entity.ToTable("R_DECLINE_METHOD");
            entity.HasKey(x => x.RDeclineMethodId);
            entity.Property(x => x.RDeclineMethodId).HasColumnName("R_DECLINE_METHOD_ID");
            entity.Property(x => x.DeclineMethod).HasColumnName("DECLINE_METHOD").HasMaxLength(40);
            entity.Property(x => x.LongName).HasColumnName("LONG_NAME").HasMaxLength(255);
            entity.Property(x => x.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(30);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<RDeclineParm>(entity =>
        {
            entity.ToTable("R_DECLINE_PARM");
            entity.HasKey(x => x.RDeclineParmId);
            entity.Property(x => x.RDeclineParmId).HasColumnName("R_DECLINE_PARM_ID");
            entity.Property(x => x.DeclineParm).HasColumnName("DECLINE_PARM").HasMaxLength(40);
            entity.Property(x => x.Description).HasColumnName("DESCRIPTION").HasMaxLength(60);
            entity.Property(x => x.LongName).HasColumnName("LONG_NAME").HasMaxLength(255);
            entity.Property(x => x.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(30);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<RDeclineType>(entity =>
        {
            entity.ToTable("R_DECLINE_TYPE");
            entity.HasKey(x => x.RDeclineTypeId);
            entity.Property(x => x.RDeclineTypeId).HasColumnName("R_DECLINE_TYPE_ID");
            entity.Property(x => x.DeclineType).HasColumnName("DECLINE_TYPE").HasMaxLength(40);
            entity.Property(x => x.LongName).HasColumnName("LONG_NAME").HasMaxLength(255);
            entity.Property(x => x.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(30);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<RDispositionCategory>(entity =>
        {
            entity.ToTable("R_DISPOSITION_CATEGORY");
            entity.HasKey(x => x.RDispositionCategoryId);
            entity.Property(x => x.RDispositionCategoryId).HasColumnName("R_DISPOSITION_CATEGORY_ID");
            entity.Property(x => x.DispositionCategory).HasColumnName("DISPOSITION_CATEGORY").HasMaxLength(40);
            entity.Property(x => x.LongName).HasColumnName("LONG_NAME").HasMaxLength(255);
            entity.Property(x => x.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(30);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<RDowntimeType>(entity =>
        {
            entity.ToTable("R_DOWNTIME_TYPE");
            entity.HasKey(x => x.RDowntimeTypeId);
            entity.Property(x => x.RDowntimeTypeId).HasColumnName("R_DOWNTIME_TYPE_ID");
            entity.Property(x => x.DowntimeType).HasColumnName("DOWNTIME_TYPE").HasMaxLength(40);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.LongName).HasColumnName("LONG_NAME").HasMaxLength(255);
            entity.Property(x => x.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(30);
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
        });

        modelBuilder.Entity<REquipmentSpec>(entity =>
        {
            entity.ToTable("R_EQUIPMENT_SPEC");
            entity.Property(x => x.DataType).HasColumnName("DATA_TYPE").HasMaxLength(40);
            entity.Property(x => x.EquipmentSpec).HasColumnName("EQUIPMENT_SPEC").HasMaxLength(100);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.LongName).HasColumnName("LONG_NAME").HasMaxLength(255);
            entity.HasKey(x => x.REquipmentSpecId);
            entity.Property(x => x.REquipmentSpecId).HasColumnName("R_EQUIPMENT_SPEC_ID");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(100);
            entity.Property(x => x.Unit).HasColumnName("UNIT").HasMaxLength(40);
        });

        modelBuilder.Entity<REstimationMethod>(entity =>
        {
            entity.ToTable("R_ESTIMATION_METHOD");
            entity.HasKey(x => x.REstimationMethodId);
            entity.Property(x => x.REstimationMethodId).HasColumnName("R_ESTIMATION_METHOD_ID");
            entity.Property(x => x.EstimationMethod).HasColumnName("ESTIMATION_METHOD").HasMaxLength(40);
            entity.Property(x => x.LongName).HasColumnName("LONG_NAME").HasMaxLength(255);
            entity.Property(x => x.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(30);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<REventSubCategory>(entity =>
        {
            entity.ToTable("R_EVENT_SUB_CATEGORY");
            entity.HasKey(x => x.REventSubCategoryId);
            entity.Property(x => x.REventSubCategoryId).HasColumnName("R_EVENT_SUB_CATEGORY_ID");
            entity.Property(x => x.EventSubCategory).HasColumnName("EVENT_SUB_CATEGORY").HasMaxLength(40);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.REventCategoryId).HasColumnName("R_EVENT_CATEGORY_ID");
            entity.HasOne<REventCategory>().WithMany().HasForeignKey(x => x.REventCategoryId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.EventCategory).HasColumnName("EVENT_CATEGORY").HasMaxLength(40);
            entity.Property(x => x.LongName).HasColumnName("LONG_NAME").HasMaxLength(255);
            entity.Property(x => x.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(30);
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
        });

        modelBuilder.Entity<RFacilityParameter>(entity =>
        {
            entity.ToTable("R_FACILITY_PARAMETER");
            entity.HasKey(x => x.RFacilityParameterId);
            entity.Property(x => x.RFacilityParameterId).HasColumnName("R_FACILITY_PARAMETER_ID");
            entity.Property(x => x.FacilityParameter).HasColumnName("FACILITY_PARAMETER").HasMaxLength(40);
            entity.Property(x => x.LongName).HasColumnName("LONG_NAME").HasMaxLength(255);
            entity.Property(x => x.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(30);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<RFlowPart>(entity =>
        {
            entity.ToTable("R_FLOW_PART");
            entity.HasKey(x => x.RFlowPartId);
            entity.Property(x => x.RFlowPartId).HasColumnName("R_FLOW_PART_ID");
            entity.Property(x => x.FlowPart).HasColumnName("FLOW_PART").HasMaxLength(40);
            entity.Property(x => x.LongName).HasColumnName("LONG_NAME").HasMaxLength(255);
            entity.Property(x => x.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(30);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<RFlowQualifier>(entity =>
        {
            entity.ToTable("R_FLOW_QUALIFIER");
            entity.HasKey(x => x.RFlowQualifierId);
            entity.Property(x => x.RFlowQualifierId).HasColumnName("R_FLOW_QUALIFIER_ID");
            entity.Property(x => x.FlowQualifier).HasColumnName("FLOW_QUALIFIER").HasMaxLength(40);
            entity.Property(x => x.LongName).HasColumnName("LONG_NAME").HasMaxLength(255);
            entity.Property(x => x.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(30);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<RFluidAnalysisMethod>(entity =>
        {
            entity.ToTable("R_FLUID_ANALYSIS_METHOD");
            entity.HasKey(x => x.RFluidAnalysisMethodId);
            entity.Property(x => x.RFluidAnalysisMethodId).HasColumnName("R_FLUID_ANALYSIS_METHOD_ID");
            entity.Property(x => x.FluidAnalysisMethod).HasColumnName("FLUID_ANALYSIS_METHOD").HasMaxLength(40);
            entity.Property(x => x.LongName).HasColumnName("LONG_NAME").HasMaxLength(255);
            entity.Property(x => x.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(30);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<RFluidComponent>(entity =>
        {
            entity.ToTable("R_FLUID_COMPONENT");
            entity.HasKey(x => x.RFluidComponentId);
            entity.Property(x => x.RFluidComponentId).HasColumnName("R_FLUID_COMPONENT_ID");
            entity.Property(x => x.FluidComponent).HasColumnName("FLUID_COMPONENT").HasMaxLength(30);
            entity.Property(x => x.LongName).HasColumnName("LONG_NAME").HasMaxLength(255);
            entity.Property(x => x.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(30);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<RFluidProperty>(entity =>
        {
            entity.ToTable("R_FLUID_PROPERTY");
            entity.HasKey(x => x.RFluidPropertyId);
            entity.Property(x => x.RFluidPropertyId).HasColumnName("R_FLUID_PROPERTY_ID");
            entity.Property(x => x.FluidProperty).HasColumnName("FLUID_PROPERTY").HasMaxLength(40);
            entity.Property(x => x.LongName).HasColumnName("LONG_NAME").HasMaxLength(255);
            entity.Property(x => x.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(30);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<RFluidSampleMethod>(entity =>
        {
            entity.ToTable("R_FLUID_SAMPLE_METHOD");
            entity.HasKey(x => x.RFluidSampleMethodId);
            entity.Property(x => x.RFluidSampleMethodId).HasColumnName("R_FLUID_SAMPLE_METHOD_ID");
            entity.Property(x => x.FluidSampleMethod).HasColumnName("FLUID_SAMPLE_METHOD").HasMaxLength(40);
            entity.Property(x => x.LongName).HasColumnName("LONG_NAME").HasMaxLength(255);
            entity.Property(x => x.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(30);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<RForecastClass>(entity =>
        {
            entity.ToTable("R_FORECAST_CLASS");
            entity.HasKey(x => x.RForecastClassId);
            entity.Property(x => x.RForecastClassId).HasColumnName("R_FORECAST_CLASS_ID");
            entity.Property(x => x.ForecastClass).HasColumnName("FORECAST_CLASS").HasMaxLength(40);
            entity.Property(x => x.RForecastClassTypeId).HasColumnName("R_FORECAST_CLASS_TYPE_ID");
            entity.HasOne<RForecastClassType>().WithMany().HasForeignKey(x => x.RForecastClassTypeId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.LongName).HasColumnName("LONG_NAME").HasMaxLength(255);
            entity.Property(x => x.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(30);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<RForecastClassType>(entity =>
        {
            entity.ToTable("R_FORECAST_CLASS_TYPE");
            entity.HasKey(x => x.RForecastClassTypeId);
            entity.Property(x => x.RForecastClassTypeId).HasColumnName("R_FORECAST_CLASS_TYPE_ID");
            entity.Property(x => x.ForecastClassType).HasColumnName("FORECAST_CLASS_TYPE").HasMaxLength(40);
            entity.Property(x => x.LongName).HasColumnName("LONG_NAME").HasMaxLength(255);
            entity.Property(x => x.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(30);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<RHaulEventType>(entity =>
        {
            entity.ToTable("R_HAUL_EVENT_TYPE");
            entity.HasKey(x => x.RHaulEventTypeId);
            entity.Property(x => x.RHaulEventTypeId).HasColumnName("R_HAUL_EVENT_TYPE_ID");
            entity.Property(x => x.HaulEventType).HasColumnName("HAUL_EVENT_TYPE").HasMaxLength(40);
            entity.Property(x => x.LongName).HasColumnName("LONG_NAME").HasMaxLength(255);
            entity.Property(x => x.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(30);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<RMeasurement>(entity =>
        {
            entity.ToTable("R_MEASUREMENT");
            entity.HasKey(x => x.RMeasurementId);
            entity.Property(x => x.RMeasurementId).HasColumnName("R_MEASUREMENT_ID");
            entity.Property(x => x.Measurement).HasColumnName("MEASUREMENT").HasMaxLength(40);
            entity.Property(x => x.IncludeOnWellTest).HasColumnName("INCLUDE_ON_WELL_TEST");
            entity.Property(x => x.LongName).HasColumnName("LONG_NAME").HasMaxLength(255);
            entity.Property(x => x.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(30);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<RNetVolumeMethod>(entity =>
        {
            entity.ToTable("R_NET_VOLUME_METHOD");
            entity.HasKey(x => x.RNetVolumeMethodId);
            entity.Property(x => x.RNetVolumeMethodId).HasColumnName("R_NET_VOLUME_METHOD_ID");
            entity.Property(x => x.NetVolumeMethod).HasColumnName("NET_VOLUME_METHOD").HasMaxLength(40);
            entity.Property(x => x.LongName).HasColumnName("LONG_NAME").HasMaxLength(255);
            entity.Property(x => x.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(30);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<RPeriodKind>(entity =>
        {
            entity.ToTable("R_PERIOD_KIND");
            entity.HasKey(x => x.RPeriodKindId);
            entity.Property(x => x.RPeriodKindId).HasColumnName("R_PERIOD_KIND_ID");
            entity.Property(x => x.PeriodKind).HasColumnName("PERIOD_KIND").HasMaxLength(40);
            entity.Property(x => x.LongName).HasColumnName("LONG_NAME").HasMaxLength(255);
            entity.Property(x => x.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(30);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<RProductCategory>(entity =>
        {
            entity.ToTable("R_PRODUCT_CATEGORY");
            entity.HasKey(x => x.RProductCategoryId);
            entity.Property(x => x.RProductCategoryId).HasColumnName("R_PRODUCT_CATEGORY_ID");
            entity.Property(x => x.ProductCategory).HasColumnName("PRODUCT_CATEGORY").HasMaxLength(40);
            entity.Property(x => x.LongName).HasColumnName("LONG_NAME").HasMaxLength(255);
            entity.Property(x => x.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(30);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<RQuantityMethod>(entity =>
        {
            entity.ToTable("R_QUANTITY_METHOD");
            entity.HasKey(x => x.RQuantityMethodId);
            entity.Property(x => x.RQuantityMethodId).HasColumnName("R_QUANTITY_METHOD_ID");
            entity.Property(x => x.QuantityMethod).HasColumnName("QUANTITY_METHOD").HasMaxLength(40);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.LongName).HasColumnName("LONG_NAME").HasMaxLength(255);
            entity.Property(x => x.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(30);
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<RRatioCurveType>(entity =>
        {
            entity.ToTable("R_RATIO_CURVE_TYPE");
            entity.HasKey(x => x.RRatioCurveTypeId);
            entity.Property(x => x.RRatioCurveTypeId).HasColumnName("R_RATIO_CURVE_TYPE_ID");
            entity.Property(x => x.RatioCurveType).HasColumnName("RATIO_CURVE_TYPE").HasMaxLength(40);
            entity.Property(x => x.LongName).HasColumnName("LONG_NAME").HasMaxLength(255);
            entity.Property(x => x.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(30);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<RRatioFluidType>(entity =>
        {
            entity.ToTable("R_RATIO_FLUID_TYPE");
            entity.HasKey(x => x.RRatioFluidTypeId);
            entity.Property(x => x.RRatioFluidTypeId).HasColumnName("R_RATIO_FLUID_TYPE_ID");
            entity.Property(x => x.RatioFluidType).HasColumnName("RATIO_FLUID_TYPE").HasMaxLength(40);
            entity.Property(x => x.LongName).HasColumnName("LONG_NAME").HasMaxLength(255);
            entity.Property(x => x.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(30);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<RReportingFlow>(entity =>
        {
            entity.ToTable("R_REPORTING_FLOW");
            entity.HasKey(x => x.RReportingFlowId);
            entity.Property(x => x.RReportingFlowId).HasColumnName("R_REPORTING_FLOW_ID");
            entity.Property(x => x.ReportingFlow).HasColumnName("REPORTING_FLOW").HasMaxLength(40);
            entity.Property(x => x.ParentFlowKindId).HasColumnName("PARENT_FLOW_KIND_ID");
            entity.HasOne<RReportingFlow>().WithMany().HasForeignKey(x => x.ParentFlowKindId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.RDispositionCategoryId).HasColumnName("R_DISPOSITION_CATEGORY_ID");
            entity.HasOne<RDispositionCategory>().WithMany().HasForeignKey(x => x.RDispositionCategoryId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.LongName).HasColumnName("LONG_NAME").HasMaxLength(255);
            entity.Property(x => x.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(30);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<RReportingProduct>(entity =>
        {
            entity.ToTable("R_REPORTING_PRODUCT");
            entity.HasKey(x => x.RReportingProductId);
            entity.Property(x => x.RReportingProductId).HasColumnName("R_REPORTING_PRODUCT_ID");
            entity.Property(x => x.Product).HasColumnName("PRODUCT").HasMaxLength(40);
            entity.Property(x => x.RProductCategoryId).HasColumnName("R_PRODUCT_CATEGORY_ID");
            entity.HasOne<RProductCategory>().WithMany().HasForeignKey(x => x.RProductCategoryId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.LongName).HasColumnName("LONG_NAME").HasMaxLength(255);
            entity.Property(x => x.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(30);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<RSaturationPointType>(entity =>
        {
            entity.ToTable("R_SATURATION_POINT_TYPE");
            entity.HasKey(x => x.RSaturationPointTypeId);
            entity.Property(x => x.RSaturationPointTypeId).HasColumnName("R_SATURATION_POINT_TYPE_ID");
            entity.Property(x => x.SaturationPointType).HasColumnName("SATURATION_POINT_TYPE").HasMaxLength(30);
            entity.Property(x => x.LongName).HasColumnName("LONG_NAME").HasMaxLength(255);
            entity.Property(x => x.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(40);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<RTriggerType>(entity =>
        {
            entity.ToTable("R_TRIGGER_TYPE");
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.HasKey(x => x.RTriggerTypeId);
            entity.Property(x => x.RTriggerTypeId).HasColumnName("R_TRIGGER_TYPE_ID");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.TriggerType).HasColumnName("TRIGGER_TYPE").HasMaxLength(40);
            entity.Property(x => x.LongName).HasColumnName("LONG_NAME").HasMaxLength(255);
            entity.Property(x => x.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(30);
        });

        modelBuilder.Entity<RValidateResult>(entity =>
        {
            entity.ToTable("R_VALIDATE_RESULT");
            entity.HasKey(x => x.RValidateResultId);
            entity.Property(x => x.RValidateResultId).HasColumnName("R_VALIDATE_RESULT_ID");
            entity.Property(x => x.ValidateResult).HasColumnName("VALIDATE_RESULT").HasMaxLength(40);
            entity.Property(x => x.LongName).HasColumnName("LONG_NAME").HasMaxLength(255);
            entity.Property(x => x.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(30);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<RVolumeMethod>(entity =>
        {
            entity.ToTable("R_VOLUME_METHOD");
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.HasKey(x => x.RVolumeMethodId);
            entity.Property(x => x.RVolumeMethodId).HasColumnName("R_VOLUME_METHOD_ID");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.VolumeMethod).HasColumnName("VOLUME_METHOD").HasMaxLength(40);
            entity.Property(x => x.LongName).HasColumnName("LONG_NAME").HasMaxLength(255);
            entity.Property(x => x.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(30);
        });

        modelBuilder.Entity<RWellTestType>(entity =>
        {
            entity.ToTable("R_WELL_TEST_TYPE");
            entity.HasKey(x => x.RWellTestTypeId);
            entity.Property(x => x.RWellTestTypeId).HasColumnName("R_WELL_TEST_TYPE_ID");
            entity.Property(x => x.WellTestType).HasColumnName("WELL_TEST_TYPE").HasMaxLength(30);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.LongName).HasColumnName("LONG_NAME").HasMaxLength(255);
            entity.Property(x => x.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(30);
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
        });

        modelBuilder.Entity<SpBoundary>(entity =>
        {
            entity.ToTable("SP_BOUNDARY");
            entity.HasKey(x => x.SpBoundaryId);
            entity.Property(x => x.SpBoundaryId).HasColumnName("SP_BOUNDARY_ID");
            entity.Property(x => x.PolygonId).HasColumnName("POLYGON_ID");
            entity.HasOne<SpPolygon>().WithMany().HasForeignKey(x => x.PolygonId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.PointSeqNo).HasColumnName("POINT_SEQ_NO");
            entity.Property(x => x.Depth).HasColumnName("DEPTH").HasPrecision(15, 5);
            entity.Property(x => x.Elevation).HasColumnName("ELEVATION").HasPrecision(10, 5);
            entity.Property(x => x.Latitude).HasColumnName("LATITUDE").HasPrecision(14, 9);
            entity.Property(x => x.Longitude).HasColumnName("LONGITUDE").HasPrecision(14, 9);
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<SpDescText>(entity =>
        {
            entity.ToTable("SP_DESC_TEXT");
            entity.HasKey(x => x.SpDescTextId);
            entity.Property(x => x.SpDescTextId).HasColumnName("SP_DESC_TEXT_ID");
            entity.Property(x => x.SpatialDescriptionId).HasColumnName("SPATIAL_DESCRIPTION_ID");
            entity.HasOne<SpatialDescription>().WithMany().HasForeignKey(x => x.SpatialDescriptionId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.TextId).HasColumnName("TEXT_ID").HasMaxLength(40);
            entity.Property(x => x.Description).HasColumnName("DESCRIPTION").HasMaxLength(2000);
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<SpPolygon>(entity =>
        {
            entity.ToTable("SP_POLYGON");
            entity.HasKey(x => x.PolygonId);
            entity.Property(x => x.PolygonId).HasColumnName("POLYGON_ID");
            entity.Property(x => x.PolygonName).HasColumnName("POLYGON_NAME").HasMaxLength(100);
            entity.Property(x => x.BoundaryDirection).HasColumnName("BOUNDARY_DIRECTION").HasMaxLength(20);
            entity.Property(x => x.CrsId).HasColumnName("CRS_ID");
            entity.HasOne<Cartoreferencesystem>().WithMany().HasForeignKey(x => x.CrsId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.DatumElev).HasColumnName("DATUM_ELEV").HasPrecision(10, 5);
            entity.Property(x => x.MaxPlotScale).HasColumnName("MAX_PLOT_SCALE").HasMaxLength(20);
            entity.Property(x => x.MinPlotScale).HasColumnName("MIN_PLOT_SCALE").HasMaxLength(20);
            entity.Property(x => x.ReferenceDatum).HasColumnName("REFERENCE_DATUM").HasMaxLength(40);
            entity.Property(x => x.SpatialDescriptionId).HasColumnName("SPATIAL_DESCRIPTION_ID");
            entity.HasOne<SpatialDescription>().WithMany().HasForeignKey(x => x.SpatialDescriptionId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<PdmVersion>(entity =>
        {
            entity.ToTable("VERSION");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).HasColumnName("ID");
            entity.Property(x => x.VersionValue).HasColumnName("VERSION");
            entity.Property(x => x.Filename).HasColumnName("FILENAME").HasMaxLength(150);
            entity.Property(x => x.Buildurl).HasColumnName("BUILDURL").HasMaxLength(200);
            entity.Property(x => x.Createdate).HasColumnName("CREATEDATE");
        });

        modelBuilder.Entity<WellEvent>(entity =>
        {
            entity.ToTable("WELL_EVENT");
            entity.HasKey(x => x.WellEventId);
            entity.Property(x => x.WellEventId).HasColumnName("WELL_EVENT_ID");
            entity.Property(x => x.WellId).HasColumnName("WELL_ID");
            entity.HasOne<Well>().WithMany().HasForeignKey(x => x.WellId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.Uwi).HasColumnName("UWI").HasMaxLength(50);
            entity.Property(x => x.EventDate).HasColumnName("EVENT_DATE");
            entity.Property(x => x.REventSubCategoryId).HasColumnName("R_EVENT_SUB_CATEGORY_ID");
            entity.HasOne<REventSubCategory>().WithMany().HasForeignKey(x => x.REventSubCategoryId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.EventSubCategory).HasColumnName("EVENT_SUB_CATEGORY").HasMaxLength(40);
            entity.Property(x => x.EventDuration).HasColumnName("EVENT_DURATION").HasPrecision(10, 5);
            entity.Property(x => x.RDowntimeTypeId).HasColumnName("R_DOWNTIME_TYPE_ID");
            entity.HasOne<RDowntimeType>().WithMany().HasForeignKey(x => x.RDowntimeTypeId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.DowntimeType).HasColumnName("DOWNTIME_TYPE").HasMaxLength(40);
            entity.Property(x => x.BaseDepth).HasColumnName("BASE_DEPTH").HasPrecision(15, 5);
            entity.Property(x => x.TopDepth).HasColumnName("TOP_DEPTH").HasPrecision(15, 5);
            entity.Property(x => x.LostVolumeOil).HasColumnName("LOST_VOLUME_OIL").HasPrecision(14, 4);
            entity.Property(x => x.LostVolumeGas).HasColumnName("LOST_VOLUME_GAS").HasPrecision(14, 4);
            entity.Property(x => x.Description).HasColumnName("DESCRIPTION").HasMaxLength(2000);
            entity.Property(x => x.RSourceId).HasColumnName("R_SOURCE_ID");
            entity.HasOne<RSource>().WithMany().HasForeignKey(x => x.RSourceId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.Source).HasColumnName("SOURCE").HasMaxLength(30);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
        });

        modelBuilder.Entity<WellEventPlan>(entity =>
        {
            entity.ToTable("WELL_EVENT_PLAN");
            entity.HasKey(x => x.WellEventPlanId);
            entity.Property(x => x.WellEventPlanId).HasColumnName("WELL_EVENT_PLAN_ID");
            entity.Property(x => x.WellId).HasColumnName("WELL_ID");
            entity.HasOne<Well>().WithMany().HasForeignKey(x => x.WellId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.Uwi).HasColumnName("UWI").HasMaxLength(50);
            entity.Property(x => x.PlannedStartDate).HasColumnName("PLANNED_START_DATE");
            entity.Property(x => x.PlannedEndDate).HasColumnName("PLANNED_END_DATE");
            entity.Property(x => x.REventSubCategoryId).HasColumnName("R_EVENT_SUB_CATEGORY_ID");
            entity.HasOne<REventSubCategory>().WithMany().HasForeignKey(x => x.REventSubCategoryId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.EventSubCategory).HasColumnName("EVENT_SUB_CATEGORY").HasMaxLength(40);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.PlanOwner).HasColumnName("PLAN_OWNER").HasMaxLength(255);
            entity.Property(x => x.RSourceId).HasColumnName("R_SOURCE_ID");
            entity.HasOne<RSource>().WithMany().HasForeignKey(x => x.RSourceId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.Source).HasColumnName("SOURCE").HasMaxLength(30);
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
        });

        modelBuilder.Entity<WellStatusHistory>(entity =>
        {
            entity.ToTable("WELL_STATUS_HISTORY");
            entity.HasKey(x => x.WellStatusHistoryId);
            entity.Property(x => x.WellStatusHistoryId).HasColumnName("WELL_STATUS_HISTORY_ID");
            entity.Property(x => x.WellId).HasColumnName("WELL_ID");
            entity.HasOne<Well>().WithMany().HasForeignKey(x => x.WellId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.Uwi).HasColumnName("UWI").HasMaxLength(50);
            entity.Property(x => x.EffectiveDate).HasColumnName("EFFECTIVE_DATE");
            entity.Property(x => x.RWellStatusId).HasColumnName("R_WELL_STATUS_ID");
            entity.HasOne<RWellStatus>().WithMany().HasForeignKey(x => x.RWellStatusId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.DisplayName).HasColumnName("DISPLAY_NAME").HasMaxLength(50);
            entity.Property(x => x.ExpiryDate).HasColumnName("EXPIRY_DATE");
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
        });

        modelBuilder.Entity<WellTest>(entity =>
        {
            entity.ToTable("WELL_TEST");
            entity.HasKey(x => x.WellTestId);
            entity.Property(x => x.WellTestId).HasColumnName("WELL_TEST_ID");
            entity.Property(x => x.ReportingEntityId).HasColumnName("REPORTING_ENTITY_ID");
            entity.HasOne<ReportingEntity>().WithMany().HasForeignKey(x => x.ReportingEntityId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.StartDate).HasColumnName("START_DATE");
            entity.Property(x => x.EndDate).HasColumnName("END_DATE");
            entity.Property(x => x.TestDuration).HasColumnName("TEST_DURATION").HasPrecision(10, 2);
            entity.Property(x => x.RTimezoneId).HasColumnName("R_TIMEZONE_ID");
            entity.HasOne<RTimezone>().WithMany().HasForeignKey(x => x.RTimezoneId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.RWellTestTypeId).HasColumnName("R_WELL_TEST_TYPE_ID");
            entity.HasOne<RWellTestType>().WithMany().HasForeignKey(x => x.RWellTestTypeId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.PressureTemperatureId).HasColumnName("PRESSURE_TEMPERATURE_ID");
            entity.HasOne<PressureTemperature>().WithMany().HasForeignKey(x => x.PressureTemperatureId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.TestDevice).HasColumnName("TEST_DEVICE").HasMaxLength(40);
            entity.Property(x => x.TestBy).HasColumnName("TEST_BY").HasMaxLength(40);
            entity.Property(x => x.IsValidated).HasColumnName("IS_VALIDATED");
            entity.Property(x => x.RValidateResultId).HasColumnName("R_VALIDATE_RESULT_ID");
            entity.HasOne<RValidateResult>().WithMany().HasForeignKey(x => x.RValidateResultId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
            entity.Property(x => x.Temperature).HasColumnName("TEMPERATURE").HasPrecision(10, 5);
            entity.Property(x => x.Pressure).HasColumnName("PRESSURE").HasPrecision(10, 5);
            entity.Property(x => x.Timezone).HasColumnName("TIMEZONE").HasMaxLength(40);
            entity.Property(x => x.ValidateResult).HasColumnName("VALIDATE_RESULT").HasMaxLength(40);
            entity.Property(x => x.WellTestType).HasColumnName("WELL_TEST_TYPE").HasMaxLength(30);
            entity.Property(x => x.AssociatedObjectName).HasColumnName("ASSOCIATED_OBJECT_NAME").HasMaxLength(50);
        });

        modelBuilder.Entity<WellTestAllocationFactor>(entity =>
        {
            entity.ToTable("WELL_TEST_ALLOCATION_FACTOR");
            entity.HasKey(x => x.WellTestAllocationFactorId);
            entity.Property(x => x.WellTestAllocationFactorId).HasColumnName("WELL_TEST_ALLOCATION_FACTOR_ID");
            entity.Property(x => x.WellTestId).HasColumnName("WELL_TEST_ID");
            entity.HasOne<WellTest>().WithMany().HasForeignKey(x => x.WellTestId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.ToEntityId).HasColumnName("TO_ENTITY_ID");
            entity.HasOne<ReportingEntity>().WithMany().HasForeignKey(x => x.ToEntityId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.AllocationFactor).HasColumnName("ALLOCATION_FACTOR").HasPrecision(10, 2);
            entity.Property(x => x.EffectiveDate).HasColumnName("EFFECTIVE_DATE");
            entity.Property(x => x.ExpiryDate).HasColumnName("EXPIRY_DATE");
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
            entity.Property(x => x.RReportingProductId).HasColumnName("R_REPORTING_PRODUCT_ID");
            entity.HasOne<RReportingProduct>().WithMany().HasForeignKey(x => x.RReportingProductId).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<WellTestFlowMeasurement>(entity =>
        {
            entity.ToTable("WELL_TEST_FLOW_MEASUREMENT");
            entity.HasKey(x => x.WellTestFlowMeasurementId);
            entity.Property(x => x.WellTestFlowMeasurementId).HasColumnName("WELL_TEST_FLOW_MEASUREMENT_ID");
            entity.Property(x => x.WellTestFlowPeriodId).HasColumnName("WELL_TEST_FLOW_PERIOD_ID");
            entity.HasOne<WellTestFlowPeriod>().WithMany().HasForeignKey(x => x.WellTestFlowPeriodId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.RFlowKindId).HasColumnName("R_FLOW_KIND_ID");
            entity.HasOne<RReportingFlow>().WithMany().HasForeignKey(x => x.RFlowKindId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.Rate).HasColumnName("RATE").HasPrecision(14, 4);
            entity.Property(x => x.RateUom).HasColumnName("RATE_UOM").HasMaxLength(40);
            entity.Property(x => x.Volume).HasColumnName("VOLUME").HasPrecision(14, 4);
            entity.Property(x => x.VolumeUom).HasColumnName("VOLUME_UOM").HasMaxLength(40);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
            entity.Property(x => x.ReportingFlow).HasColumnName("REPORTING_FLOW").HasMaxLength(40);
            entity.Property(x => x.TestProduct).HasColumnName("TEST_PRODUCT").HasMaxLength(40);
            entity.Property(x => x.WellTestId).HasColumnName("WELL_TEST_ID");
            entity.HasOne<WellTestFlowPeriod>().WithMany().HasForeignKey(x => x.WellTestId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.FlowPeriod).HasColumnName("FLOW_PERIOD");
            entity.HasOne<WellTestFlowPeriod>().WithMany().HasForeignKey(x => x.FlowPeriod).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.RReportingProductId).HasColumnName("R_REPORTING_PRODUCT_ID");
            entity.HasOne<RReportingProduct>().WithMany().HasForeignKey(x => x.RReportingProductId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.Product).HasColumnName("PRODUCT").HasMaxLength(40);
        });

        modelBuilder.Entity<WellTestFlowPeriod>(entity =>
        {
            entity.ToTable("WELL_TEST_FLOW_PERIOD");
            entity.HasKey(x => x.WellTestFlowPeriodId);
            entity.Property(x => x.WellTestFlowPeriodId).HasColumnName("WELL_TEST_FLOW_PERIOD_ID");
            entity.Property(x => x.WellTestId).HasColumnName("WELL_TEST_ID");
            entity.HasOne<WellTest>().WithMany().HasForeignKey(x => x.WellTestId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.FlowPeriod).HasColumnName("FLOW_PERIOD");
            entity.Property(x => x.StartDate).HasColumnName("START_DATE");
            entity.Property(x => x.EndDate).HasColumnName("END_DATE");
            entity.Property(x => x.TestDuration).HasColumnName("TEST_DURATION").HasPrecision(10, 2);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
        });

        modelBuilder.Entity<WellTestMeasurement>(entity =>
        {
            entity.ToTable("WELL_TEST_MEASUREMENT");
            entity.HasKey(x => x.WellTestMeasurementId);
            entity.Property(x => x.WellTestMeasurementId).HasColumnName("WELL_TEST_MEASUREMENT_ID");
            entity.Property(x => x.WellTestFlowPeriodId).HasColumnName("WELL_TEST_FLOW_PERIOD_ID");
            entity.HasOne<WellTestFlowPeriod>().WithMany().HasForeignKey(x => x.WellTestFlowPeriodId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.RMeasurementId).HasColumnName("R_MEASUREMENT_ID");
            entity.HasOne<RMeasurement>().WithMany().HasForeignKey(x => x.RMeasurementId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.Value).HasColumnName("VALUE").HasPrecision(14, 4);
            entity.Property(x => x.ValueOum).HasColumnName("VALUE_OUM").HasMaxLength(40);
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(2000);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
            entity.Property(x => x.Measurement).HasColumnName("MEASUREMENT").HasMaxLength(40);
            entity.Property(x => x.WellTestId).HasColumnName("WELL_TEST_ID");
            entity.HasOne<WellTestFlowPeriod>().WithMany().HasForeignKey(x => x.WellTestId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.FlowPeriod).HasColumnName("FLOW_PERIOD");
            entity.HasOne<WellTestFlowPeriod>().WithMany().HasForeignKey(x => x.FlowPeriod).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<WellVolDaily>(entity =>
        {
            entity.ToTable("WELL_VOL_DAILY");
            entity.HasKey(x => x.WellVolumeDailyId);
            entity.Property(x => x.WellVolumeDailyId).HasColumnName("WELL_VOLUME_DAILY_ID");
            entity.Property(x => x.WellId).HasColumnName("WELL_ID");
            entity.HasOne<Well>().WithMany().HasForeignKey(x => x.WellId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.Uwi).HasColumnName("UWI").HasMaxLength(50);
            entity.Property(x => x.VolumeDate).HasColumnName("VOLUME_DATE");
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.HoursOn).HasColumnName("HOURS_ON").HasPrecision(14, 4);
            entity.Property(x => x.OilVolume).HasColumnName("OIL_VOLUME").HasPrecision(20, 10);
            entity.Property(x => x.OilQuality).HasColumnName("OIL_QUALITY").HasPrecision(7, 2);
            entity.Property(x => x.GasVolume).HasColumnName("GAS_VOLUME").HasPrecision(20, 10);
            entity.Property(x => x.GasQuality).HasColumnName("GAS_QUALITY").HasPrecision(7, 2);
            entity.Property(x => x.GasEnergy).HasColumnName("GAS_ENERGY").HasPrecision(20, 10);
            entity.Property(x => x.BoeVolume).HasColumnName("BOE_VOLUME").HasPrecision(20, 10);
            entity.Property(x => x.WaterVolume).HasColumnName("WATER_VOLUME").HasPrecision(20, 10);
            entity.Property(x => x.LiquidVolume).HasColumnName("LIQUID_VOLUME").HasPrecision(20, 10);
            entity.Property(x => x.CondensateVolume).HasColumnName("CONDENSATE_VOLUME").HasPrecision(20, 10);
            entity.Property(x => x.Co2Volume).HasColumnName("CO2_VOLUME").HasPrecision(20, 10);
            entity.Property(x => x.NitrogenVolume).HasColumnName("NITROGEN_VOLUME").HasPrecision(20, 10);
            entity.Property(x => x.NglVolume).HasColumnName("NGL_VOLUME").HasPrecision(20, 10);
            entity.Property(x => x.SulphurVolume).HasColumnName("SULPHUR_VOLUME").HasPrecision(20, 10);
            entity.Property(x => x.InjectionCycle).HasColumnName("INJECTION_CYCLE");
            entity.Property(x => x.InjWaterVolume).HasColumnName("INJ_WATER_VOLUME").HasPrecision(20, 10);
            entity.Property(x => x.InjOilVolume).HasColumnName("INJ_OIL_VOLUME").HasPrecision(20, 10);
            entity.Property(x => x.InjGasVolume).HasColumnName("INJ_GAS_VOLUME").HasPrecision(20, 10);
            entity.Property(x => x.InjCo2Volume).HasColumnName("INJ_CO2_VOLUME").HasPrecision(20, 10);
            entity.Property(x => x.InjSteamVolume).HasColumnName("INJ_STEAM_VOLUME").HasPrecision(20, 10);
            entity.Property(x => x.InjPolymerVolume).HasColumnName("INJ_POLYMER_VOLUME").HasPrecision(20, 10);
            entity.Property(x => x.TubingPress).HasColumnName("TUBING_PRESS").HasPrecision(20, 10);
            entity.Property(x => x.CasingPress).HasColumnName("CASING_PRESS").HasPrecision(20, 10);
            entity.Property(x => x.BhPress).HasColumnName("BH_PRESS").HasPrecision(20, 10);
            entity.Property(x => x.FlPress).HasColumnName("FL_PRESS").HasPrecision(20, 10);
            entity.Property(x => x.SepPress).HasColumnName("SEP_PRESS").HasPrecision(20, 10);
            entity.Property(x => x.InjectionPress).HasColumnName("INJECTION_PRESS").HasPrecision(20, 10);
            entity.Property(x => x.WhTemp).HasColumnName("WH_TEMP").HasPrecision(20, 10);
            entity.Property(x => x.BhTemp).HasColumnName("BH_TEMP").HasPrecision(20, 10);
            entity.Property(x => x.FlTemp).HasColumnName("FL_TEMP").HasPrecision(20, 10);
            entity.Property(x => x.SepTemp).HasColumnName("SEP_TEMP").HasPrecision(20, 10);
            entity.Property(x => x.InjWhSteamPress).HasColumnName("INJ_WH_STEAM_PRESS").HasPrecision(20, 10);
            entity.Property(x => x.InjWhSteamTemp).HasColumnName("INJ_WH_STEAM_TEMP").HasPrecision(20, 10);
            entity.Property(x => x.InjWhSteamDry).HasColumnName("INJ_WH_STEAM_DRY").HasPrecision(20, 10);
            entity.Property(x => x.WaterCutPercent).HasColumnName("WATER_CUT_PERCENT").HasPrecision(20, 10);
            entity.Property(x => x.GasOilRatio).HasColumnName("GAS_OIL_RATIO").HasPrecision(20, 10);
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.CumOilVolume).HasColumnName("CUM_OIL_VOLUME").HasPrecision(20, 10);
            entity.Property(x => x.CumGasVolume).HasColumnName("CUM_GAS_VOLUME").HasPrecision(20, 10);
            entity.Property(x => x.CumBoeVolume).HasColumnName("CUM_BOE_VOLUME").HasPrecision(20, 10);
            entity.Property(x => x.CumWaterVolume).HasColumnName("CUM_WATER_VOLUME").HasPrecision(20, 10);
            entity.Property(x => x.CumLiquidVolume).HasColumnName("CUM_LIQUID_VOLUME").HasPrecision(20, 10);
            entity.Property(x => x.CumCondensateVolume).HasColumnName("CUM_CONDENSATE_VOLUME").HasPrecision(20, 10);
            entity.Property(x => x.CumCo2Volume).HasColumnName("CUM_CO2_VOLUME").HasPrecision(20, 10);
            entity.Property(x => x.CumNitrogenVolume).HasColumnName("CUM_NITROGEN_VOLUME").HasPrecision(20, 10);
            entity.Property(x => x.CumSulphurVolume).HasColumnName("CUM_SULPHUR_VOLUME").HasPrecision(20, 10);
            entity.Property(x => x.CumInjWaterVolume).HasColumnName("CUM_INJ_WATER_VOLUME").HasPrecision(20, 10);
            entity.Property(x => x.CumInjOilVolume).HasColumnName("CUM_INJ_OIL_VOLUME").HasPrecision(20, 10);
            entity.Property(x => x.CumInjGasVolume).HasColumnName("CUM_INJ_GAS_VOLUME").HasPrecision(20, 10);
            entity.Property(x => x.CumInjCo2Volume).HasColumnName("CUM_INJ_CO2_VOLUME").HasPrecision(20, 10);
            entity.Property(x => x.CumInjSteamVolume).HasColumnName("CUM_INJ_STEAM_VOLUME").HasPrecision(20, 10);
            entity.Property(x => x.CumInjPolymerVolume).HasColumnName("CUM_INJ_POLYMER_VOLUME").HasPrecision(20, 10);
            entity.Property(x => x.CumNglVolume).HasColumnName("CUM_NGL_VOLUME").HasPrecision(14, 4);
            entity.Property(x => x.RVolumeMethodId).HasColumnName("R_VOLUME_METHOD_ID");
            entity.Property(x => x.VolumeMethod).HasColumnName("VOLUME_METHOD").HasMaxLength(40);
        });

        modelBuilder.Entity<WellVolMonthly>(entity =>
        {
            entity.ToTable("WELL_VOL_MONTHLY");
            entity.HasKey(x => x.WellVolumeMonthlyId);
            entity.Property(x => x.WellVolumeMonthlyId).HasColumnName("WELL_VOLUME_MONTHLY_ID");
            entity.Property(x => x.WellId).HasColumnName("WELL_ID");
            entity.HasOne<Well>().WithMany().HasForeignKey(x => x.WellId).OnDelete(DeleteBehavior.NoAction);
            entity.Property(x => x.Uwi).HasColumnName("UWI").HasMaxLength(50);
            entity.Property(x => x.VolumeDate).HasColumnName("VOLUME_DATE");
            entity.Property(x => x.YearMonth).HasColumnName("YEAR_MONTH");
            entity.Property(x => x.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(x => x.DaysOn).HasColumnName("DAYS_ON").HasPrecision(14, 4);
            entity.Property(x => x.MonthlyOil).HasColumnName("MONTHLY_OIL").HasPrecision(20, 10);
            entity.Property(x => x.AvgOil).HasColumnName("AVG_OIL").HasPrecision(20, 10);
            entity.Property(x => x.AvgOilQuality).HasColumnName("AVG_OIL_QUALITY").HasPrecision(7, 2);
            entity.Property(x => x.MonthlyGas).HasColumnName("MONTHLY_GAS").HasPrecision(20, 10);
            entity.Property(x => x.AvgGas).HasColumnName("AVG_GAS").HasPrecision(20, 10);
            entity.Property(x => x.AvgGasQuality).HasColumnName("AVG_GAS_QUALITY").HasPrecision(7, 2);
            entity.Property(x => x.AvgGasEnergy).HasColumnName("AVG_GAS_ENERGY").HasPrecision(20, 10);
            entity.Property(x => x.MonthlyBoe).HasColumnName("MONTHLY_BOE").HasPrecision(20, 10);
            entity.Property(x => x.AvgBoe).HasColumnName("AVG_BOE").HasPrecision(20, 10);
            entity.Property(x => x.MonthlyWater).HasColumnName("MONTHLY_WATER").HasPrecision(20, 10);
            entity.Property(x => x.AvgWater).HasColumnName("AVG_WATER").HasPrecision(20, 10);
            entity.Property(x => x.MonthlyLiquid).HasColumnName("MONTHLY_LIQUID").HasPrecision(20, 10);
            entity.Property(x => x.AvgLiquid).HasColumnName("AVG_LIQUID").HasPrecision(20, 10);
            entity.Property(x => x.MonthlyCondensate).HasColumnName("MONTHLY_CONDENSATE").HasPrecision(20, 10);
            entity.Property(x => x.AvgCondensate).HasColumnName("AVG_CONDENSATE").HasPrecision(20, 10);
            entity.Property(x => x.MonthlyCo2).HasColumnName("MONTHLY_CO2").HasPrecision(20, 10);
            entity.Property(x => x.AvgCo2).HasColumnName("AVG_CO2").HasPrecision(20, 10);
            entity.Property(x => x.MonthlyNitrogen).HasColumnName("MONTHLY_NITROGEN").HasPrecision(20, 10);
            entity.Property(x => x.AvgNitrogen).HasColumnName("AVG_NITROGEN").HasPrecision(20, 10);
            entity.Property(x => x.MonthlyNgl).HasColumnName("MONTHLY_NGL").HasPrecision(20, 10);
            entity.Property(x => x.AvgNgl).HasColumnName("AVG_NGL").HasPrecision(20, 10);
            entity.Property(x => x.MonthlySulphur).HasColumnName("MONTHLY_SULPHUR").HasPrecision(20, 10);
            entity.Property(x => x.AvgSulphur).HasColumnName("AVG_SULPHUR").HasPrecision(20, 10);
            entity.Property(x => x.MonthlyInjWater).HasColumnName("MONTHLY_INJ_WATER").HasPrecision(20, 10);
            entity.Property(x => x.AvgInjWater).HasColumnName("AVG_INJ_WATER").HasPrecision(20, 10);
            entity.Property(x => x.MonthlyInjOil).HasColumnName("MONTHLY_INJ_OIL").HasPrecision(20, 10);
            entity.Property(x => x.AvgInjOil).HasColumnName("AVG_INJ_OIL").HasPrecision(20, 10);
            entity.Property(x => x.MonthlyInjGas).HasColumnName("MONTHLY_INJ_GAS").HasPrecision(20, 10);
            entity.Property(x => x.AvgInjGas).HasColumnName("AVG_INJ_GAS").HasPrecision(20, 10);
            entity.Property(x => x.MonthlyInjCo2).HasColumnName("MONTHLY_INJ_CO2").HasPrecision(20, 10);
            entity.Property(x => x.AvgInjCo2).HasColumnName("AVG_INJ_CO2").HasPrecision(20, 10);
            entity.Property(x => x.MonthlyInjSteam).HasColumnName("MONTHLY_INJ_STEAM").HasPrecision(20, 10);
            entity.Property(x => x.AvgInjSteam).HasColumnName("AVG_INJ_STEAM").HasPrecision(20, 10);
            entity.Property(x => x.MonthlyInjPolymer).HasColumnName("MONTHLY_INJ_POLYMER").HasPrecision(20, 10);
            entity.Property(x => x.AvgInjPolymer).HasColumnName("AVG_INJ_POLYMER").HasPrecision(20, 10);
            entity.Property(x => x.AvgTubingPress).HasColumnName("AVG_TUBING_PRESS").HasPrecision(20, 10);
            entity.Property(x => x.MaxTubingPress).HasColumnName("MAX_TUBING_PRESS").HasPrecision(20, 10);
            entity.Property(x => x.MinTubingPress).HasColumnName("MIN_TUBING_PRESS").HasPrecision(20, 10);
            entity.Property(x => x.AvgCasingPress).HasColumnName("AVG_CASING_PRESS").HasPrecision(20, 10);
            entity.Property(x => x.MaxCasingPress).HasColumnName("MAX_CASING_PRESS").HasPrecision(20, 10);
            entity.Property(x => x.MinCasingPress).HasColumnName("MIN_CASING_PRESS").HasPrecision(20, 10);
            entity.Property(x => x.AvgBhPress).HasColumnName("AVG_BH_PRESS").HasPrecision(20, 10);
            entity.Property(x => x.MaxBhPress).HasColumnName("MAX_BH_PRESS").HasPrecision(20, 10);
            entity.Property(x => x.MinBhPress).HasColumnName("MIN_BH_PRESS").HasPrecision(20, 10);
            entity.Property(x => x.AvgFlPress).HasColumnName("AVG_FL_PRESS").HasPrecision(20, 10);
            entity.Property(x => x.MaxFlPress).HasColumnName("MAX_FL_PRESS").HasPrecision(20, 10);
            entity.Property(x => x.MinFlPress).HasColumnName("MIN_FL_PRESS").HasPrecision(20, 10);
            entity.Property(x => x.AvgSepPress).HasColumnName("AVG_SEP_PRESS").HasPrecision(20, 10);
            entity.Property(x => x.MaxSepPress).HasColumnName("MAX_SEP_PRESS").HasPrecision(20, 10);
            entity.Property(x => x.MinSepPress).HasColumnName("MIN_SEP_PRESS").HasPrecision(20, 10);
            entity.Property(x => x.AvgInjectionPress).HasColumnName("AVG_INJECTION_PRESS").HasPrecision(20, 10);
            entity.Property(x => x.MaxInjectionPress).HasColumnName("MAX_INJECTION_PRESS").HasPrecision(20, 10);
            entity.Property(x => x.MinInjectionPress).HasColumnName("MIN_INJECTION_PRESS").HasPrecision(20, 10);
            entity.Property(x => x.AvgWhTemp).HasColumnName("AVG_WH_TEMP").HasPrecision(20, 10);
            entity.Property(x => x.MaxWhTemp).HasColumnName("MAX_WH_TEMP").HasPrecision(20, 10);
            entity.Property(x => x.MinWhTemp).HasColumnName("MIN_WH_TEMP").HasPrecision(20, 10);
            entity.Property(x => x.AvgBhTemp).HasColumnName("AVG_BH_TEMP").HasPrecision(20, 10);
            entity.Property(x => x.MaxBhTemp).HasColumnName("MAX_BH_TEMP").HasPrecision(20, 10);
            entity.Property(x => x.MinBhTemp).HasColumnName("MIN_BH_TEMP").HasPrecision(20, 10);
            entity.Property(x => x.AvgFlTemp).HasColumnName("AVG_FL_TEMP").HasPrecision(20, 10);
            entity.Property(x => x.MaxFlTemp).HasColumnName("MAX_FL_TEMP").HasPrecision(20, 10);
            entity.Property(x => x.MinFlTemp).HasColumnName("MIN_FL_TEMP").HasPrecision(20, 10);
            entity.Property(x => x.AvgSepTemp).HasColumnName("AVG_SEP_TEMP").HasPrecision(20, 10);
            entity.Property(x => x.MaxSepTemp).HasColumnName("MAX_SEP_TEMP").HasPrecision(20, 10);
            entity.Property(x => x.MinSepTemp).HasColumnName("MIN_SEP_TEMP").HasPrecision(20, 10);
            entity.Property(x => x.AvgInjWhSteamPress).HasColumnName("AVG_INJ_WH_STEAM_PRESS").HasPrecision(20, 10);
            entity.Property(x => x.MaxInjWhSteamPress).HasColumnName("MAX_INJ_WH_STEAM_PRESS").HasPrecision(20, 10);
            entity.Property(x => x.MinInjWhSteamPress).HasColumnName("MIN_INJ_WH_STEAM_PRESS").HasPrecision(20, 10);
            entity.Property(x => x.AvgInjWhSteamTemp).HasColumnName("AVG_INJ_WH_STEAM_TEMP").HasPrecision(20, 10);
            entity.Property(x => x.MaxInjWhSteamTemp).HasColumnName("MAX_INJ_WH_STEAM_TEMP").HasPrecision(20, 10);
            entity.Property(x => x.MinInjWhSteamTemp).HasColumnName("MIN_INJ_WH_STEAM_TEMP").HasPrecision(20, 10);
            entity.Property(x => x.AvgInjWhSteamDry).HasColumnName("AVG_INJ_WH_STEAM_DRY").HasPrecision(20, 10);
            entity.Property(x => x.MaxInjWhSteamDry).HasColumnName("MAX_INJ_WH_STEAM_DRY").HasPrecision(20, 10);
            entity.Property(x => x.MinInjWhSteamDry).HasColumnName("MIN_INJ_WH_STEAM_DRY").HasPrecision(20, 10);
            entity.Property(x => x.MonthWaterCutPercent).HasColumnName("MONTH_WATER_CUT_PERCENT").HasPrecision(20, 10);
            entity.Property(x => x.MonthGasOilRatio).HasColumnName("MONTH_GAS_OIL_RATIO").HasPrecision(20, 10);
            entity.Property(x => x.RowChangedBy).HasColumnName("ROW_CHANGED_BY").HasMaxLength(100);
            entity.Property(x => x.RowChangedDate).HasColumnName("ROW_CHANGED_DATE");
            entity.Property(x => x.RowCreatedBy).HasColumnName("ROW_CREATED_BY").HasMaxLength(100);
            entity.Property(x => x.RowCreatedDate).HasColumnName("ROW_CREATED_DATE");
            entity.Property(x => x.CumOil).HasColumnName("CUM_OIL").HasPrecision(20, 10);
            entity.Property(x => x.CumGas).HasColumnName("CUM_GAS").HasPrecision(20, 10);
            entity.Property(x => x.CumBoe).HasColumnName("CUM_BOE").HasPrecision(20, 10);
            entity.Property(x => x.CumWater).HasColumnName("CUM_WATER").HasPrecision(20, 10);
            entity.Property(x => x.CumLiquid).HasColumnName("CUM_LIQUID").HasPrecision(20, 10);
            entity.Property(x => x.CumCondensate).HasColumnName("CUM_CONDENSATE").HasPrecision(20, 10);
            entity.Property(x => x.CumCo2).HasColumnName("CUM_CO2").HasPrecision(20, 10);
            entity.Property(x => x.CumNitrogen).HasColumnName("CUM_NITROGEN").HasPrecision(20, 10);
            entity.Property(x => x.CumSulphur).HasColumnName("CUM_SULPHUR").HasPrecision(20, 10);
            entity.Property(x => x.CumInjWater).HasColumnName("CUM_INJ_WATER").HasPrecision(20, 10);
            entity.Property(x => x.CumInjOil).HasColumnName("CUM_INJ_OIL").HasPrecision(20, 10);
            entity.Property(x => x.CumInjGas).HasColumnName("CUM_INJ_GAS").HasPrecision(20, 10);
            entity.Property(x => x.CumInjCo2).HasColumnName("CUM_INJ_CO2").HasPrecision(20, 10);
            entity.Property(x => x.CumInjSteam).HasColumnName("CUM_INJ_STEAM").HasPrecision(20, 10);
            entity.Property(x => x.CumInjPolymer).HasColumnName("CUM_INJ_POLYMER").HasPrecision(20, 10);
            entity.Property(x => x.CumNgl).HasColumnName("CUM_NGL").HasPrecision(20, 10);
        });
    }
}


namespace OSDU.Data.MasterData;

public class FieldOrgUnit {
 public int FieldOrgUnitId { get; set; }
 public int FieldId { get; set; }
 public int OrgUnitId { get; set; }
 public DateTime? EffectiveDate { get; set; }
 public DateTime? ExpiryDate { get; set; }
 public string? Remark { get; set; }
 public bool IsActive { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowChangedBy { get; set; }
}

public class FacilityOrgUnit {
 public int FacilityOrgUnitId { get; set; }
 public int FacilityId { get; set; }
 public int OrgUnitId { get; set; }
 public DateTime? EffectiveDate { get; set; }
 public DateTime? ExpiryDate { get; set; }
 public string? Remark { get; set; }
 public bool IsActive { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowChangedBy { get; set; }
}

public class WellOrgUnit {
 public int WellOrgUnitId { get; set; }
 public int WellId { get; set; }
 public int OrgUnitId { get; set; }
 public DateTime? EffectiveDate { get; set; }
 public DateTime? ExpiryDate { get; set; }
 public string? Remark { get; set; }
 public bool IsActive { get; set; }
 public string? RowCreatedBy { get; set; }
 public DateTime? RowCreatedDate { get; set; }
 public DateTime? RowChangedDate { get; set; }
 public string? RowChangedBy { get; set; }
}
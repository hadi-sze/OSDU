using System.ComponentModel.DataAnnotations;
namespace OSDU.Business;
public class FacilityInput {
 [StringLength(8)] public string? DepthUom { get; set; }
 [StringLength(8)] public string? ElevationUom { get; set; }
 [StringLength(8)] public string? FacilityDiameterUom { get; set; }
 [Required]
 [StringLength(40)]
 public string FacilityName { get; set; } = "";
 public int? FacilityTypeId { get; set; }
 [StringLength(40)]
 public string? FacilityType { get; set; }
 public bool IsActive { get; set; }
 public DateTime? ConstructedDate { get; set; }
 public DateTime? ActiveDate { get; set; }
 public DateTime? AbandonedDate { get; set; }
 public bool OffshoreInd { get; set; }
 public int? REquipmentCatalogueId { get; set; }
 [StringLength(40)]
 public string? EquipmentCatalogue { get; set; }
 public decimal? XCoordinate { get; set; }
 public decimal? YCoordinate { get; set; }
 public int? CrsId { get; set; }
 [StringLength(50)]
 public string? CrsName { get; set; }
 [StringLength(40)]
 public string? CurrentOperator { get; set; }
 public decimal? Depth { get; set; }
 public decimal? Elevation { get; set; }
 public decimal? FacilityDiameter { get; set; }
 [StringLength(40)]
 public string? FacilityFunction { get; set; }
 public int? FacilityNo { get; set; }
 [StringLength(30)]
 public string? FacilityShortName { get; set; }
 [StringLength(255)]
 public string? FacilityLongName { get; set; }
 public DateTime? LastInjectionDate { get; set; }
 public DateTime? LastProductionDate { get; set; }
 public DateTime? LastReportedDate { get; set; }
 public DateTime? OnInjectionDate { get; set; }
 public DateTime? OnProductionDate { get; set; }
 [StringLength(2000)]
 public string? Remark { get; set; }
 public bool? IsVirtual { get; set; }
 [StringLength(64)]
 public string? Uidref { get; set; }
 public int? RDataAccessCategoryId { get; set; }
}
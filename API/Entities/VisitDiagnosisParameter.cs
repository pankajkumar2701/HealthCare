using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HealthCare.Entities
{
    /// <summary> 
    /// Represents a visitdiagnosisparameter entity with essential details
    /// </summary>
    public class VisitDiagnosisParameter
    {
        /// <summary>
        /// TenantId of the VisitDiagnosisParameter 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the VisitDiagnosisParameter 
        /// </summary>
        [Key]
        public Guid? Id { get; set; }

        /// <summary>
        /// Required field Name of the VisitDiagnosisParameter 
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Foreign key referencing the VisitDiagnosis to which the VisitDiagnosisParameter belongs 
        /// </summary>
        public Guid? VisitDiagnosisId { get; set; }

        /// <summary>
        /// Navigation property representing the associated VisitDiagnosis
        /// </summary>
        [ForeignKey("VisitDiagnosisId")]
        public VisitDiagnosis? VisitDiagnosis { get; set; }
        /// <summary>
        /// Foreign key referencing the ClinicalParameter to which the VisitDiagnosisParameter belongs 
        /// </summary>
        public Guid? ClinicalParameterId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ClinicalParameter
        /// </summary>
        [ForeignKey("ClinicalParameterId")]
        public ClinicalParameter? ClinicalParameter { get; set; }
        /// <summary>
        /// Foreign key referencing the ClinicalParameterValue to which the VisitDiagnosisParameter belongs 
        /// </summary>
        public Guid? ClinicalParameterValueId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ClinicalParameterValue
        /// </summary>
        [ForeignKey("ClinicalParameterValueId")]
        public ClinicalParameterValue? ClinicalParameterValue { get; set; }
        /// <summary>
        /// ClinicalParameterValueName of the VisitDiagnosisParameter 
        /// </summary>
        public string? ClinicalParameterValueName { get; set; }
        /// <summary>
        /// TextValue of the VisitDiagnosisParameter 
        /// </summary>
        public string? TextValue { get; set; }
        /// <summary>
        /// NumberValue of the VisitDiagnosisParameter 
        /// </summary>
        public int? NumberValue { get; set; }
        /// <summary>
        /// numericValue of the VisitDiagnosisParameter 
        /// </summary>
        public int? numericValue { get; set; }
        /// <summary>
        /// DateValue of the VisitDiagnosisParameter 
        /// </summary>
        public DateTime? DateValue { get; set; }
        /// <summary>
        /// DateTimeValue of the VisitDiagnosisParameter 
        /// </summary>
        public DateTime? DateTimeValue { get; set; }
        /// <summary>
        /// TimeValue of the VisitDiagnosisParameter 
        /// </summary>
        public DateTime? TimeValue { get; set; }
        /// <summary>
        /// SystolicValue of the VisitDiagnosisParameter 
        /// </summary>
        public int? SystolicValue { get; set; }
        /// <summary>
        /// DiastolicValue of the VisitDiagnosisParameter 
        /// </summary>
        public int? DiastolicValue { get; set; }
        /// <summary>
        /// YearValue of the VisitDiagnosisParameter 
        /// </summary>
        public int? YearValue { get; set; }
        /// <summary>
        /// DurationValue of the VisitDiagnosisParameter 
        /// </summary>
        public int? DurationValue { get; set; }
        /// <summary>
        /// Foreign key referencing the Uom to which the VisitDiagnosisParameter belongs 
        /// </summary>
        public Guid? UomId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Uom
        /// </summary>
        [ForeignKey("UomId")]
        public Uom? Uom { get; set; }
        /// <summary>
        /// AssociatedNotes of the VisitDiagnosisParameter 
        /// </summary>
        public string? AssociatedNotes { get; set; }
        /// <summary>
        /// IsSpecificValue of the VisitDiagnosisParameter 
        /// </summary>
        public bool? IsSpecificValue { get; set; }
        /// <summary>
        /// MultiChoiceValue of the VisitDiagnosisParameter 
        /// </summary>
        public string? MultiChoiceValue { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<VisitDiagnosis>? VisitDiagnosis { get; set; }
    }
}
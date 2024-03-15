using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HealthCare.Entities
{
    /// <summary> 
    /// Represents a visitchiefcomplaintparameter entity with essential details
    /// </summary>
    public class VisitChiefComplaintParameter
    {
        /// <summary>
        /// TenantId of the VisitChiefComplaintParameter 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the VisitChiefComplaintParameter 
        /// </summary>
        [Key]
        public Guid? Id { get; set; }

        /// <summary>
        /// Required field Name of the VisitChiefComplaintParameter 
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Foreign key referencing the ClinicalParameter to which the VisitChiefComplaintParameter belongs 
        /// </summary>
        public Guid? ClinicalParameterId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ClinicalParameter
        /// </summary>
        [ForeignKey("ClinicalParameterId")]
        public ClinicalParameter? ClinicalParameter { get; set; }
        /// <summary>
        /// Foreign key referencing the ClinicalParameterValue to which the VisitChiefComplaintParameter belongs 
        /// </summary>
        public Guid? ClinicalParameterValueId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ClinicalParameterValue
        /// </summary>
        [ForeignKey("ClinicalParameterValueId")]
        public ClinicalParameterValue? ClinicalParameterValue { get; set; }
        /// <summary>
        /// IsSpecificValue of the VisitChiefComplaintParameter 
        /// </summary>
        public bool? IsSpecificValue { get; set; }
        /// <summary>
        /// TextValue of the VisitChiefComplaintParameter 
        /// </summary>
        public string? TextValue { get; set; }
        /// <summary>
        /// NumberValue of the VisitChiefComplaintParameter 
        /// </summary>
        public int? NumberValue { get; set; }
        /// <summary>
        /// numericValue of the VisitChiefComplaintParameter 
        /// </summary>
        public decimal? numericValue { get; set; }
        /// <summary>
        /// DateValue of the VisitChiefComplaintParameter 
        /// </summary>
        public DateTime? DateValue { get; set; }
        /// <summary>
        /// DateTimeValue of the VisitChiefComplaintParameter 
        /// </summary>
        public DateTime? DateTimeValue { get; set; }
        /// <summary>
        /// TimeValue of the VisitChiefComplaintParameter 
        /// </summary>
        public DateTime? TimeValue { get; set; }
        /// <summary>
        /// SystolicValue of the VisitChiefComplaintParameter 
        /// </summary>
        public int? SystolicValue { get; set; }
        /// <summary>
        /// DiastolicValue of the VisitChiefComplaintParameter 
        /// </summary>
        public int? DiastolicValue { get; set; }
        /// <summary>
        /// YearValue of the VisitChiefComplaintParameter 
        /// </summary>
        public int? YearValue { get; set; }
        /// <summary>
        /// DurationValue of the VisitChiefComplaintParameter 
        /// </summary>
        public int? DurationValue { get; set; }
        /// <summary>
        /// Foreign key referencing the Uom to which the VisitChiefComplaintParameter belongs 
        /// </summary>
        public Guid? UomId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Uom
        /// </summary>
        [ForeignKey("UomId")]
        public Uom? Uom { get; set; }
        /// <summary>
        /// ClinicalParameterValueName of the VisitChiefComplaintParameter 
        /// </summary>
        public string? ClinicalParameterValueName { get; set; }
        /// <summary>
        /// AssociatedNotes of the VisitChiefComplaintParameter 
        /// </summary>
        public string? AssociatedNotes { get; set; }
        /// <summary>
        /// MultiChoiceValue of the VisitChiefComplaintParameter 
        /// </summary>
        public string? MultiChoiceValue { get; set; }
    }
}
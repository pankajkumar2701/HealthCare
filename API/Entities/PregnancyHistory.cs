using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HealthCare.Entities
{
    /// <summary> 
    /// Represents a pregnancyhistory entity with essential details
    /// </summary>
    public class PregnancyHistory
    {
        /// <summary>
        /// Primary key for the PregnancyHistory 
        /// </summary>
        [Key]
        public Guid? Id { get; set; }
        /// <summary>
        /// TenantId of the PregnancyHistory 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Required field Name of the PregnancyHistory 
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Foreign key referencing the Patient to which the PregnancyHistory belongs 
        /// </summary>
        public Guid? PatientId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Patient
        /// </summary>
        [ForeignKey("PatientId")]
        public Patient? Patient { get; set; }

        /// <summary>
        /// Required field CloseDate of the PregnancyHistory 
        /// </summary>
        [Required]
        public DateTime CloseDate { get; set; }
        /// <summary>
        /// CloseReason of the PregnancyHistory 
        /// </summary>
        public int? CloseReason { get; set; }
        /// <summary>
        /// LmpDate of the PregnancyHistory 
        /// </summary>
        public DateTime? LmpDate { get; set; }
        /// <summary>
        /// EddDate of the PregnancyHistory 
        /// </summary>
        public DateTime? EddDate { get; set; }
        /// <summary>
        /// CreatedBy of the PregnancyHistory 
        /// </summary>
        public Guid? CreatedBy { get; set; }
        /// <summary>
        /// CreatedOn of the PregnancyHistory 
        /// </summary>
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// PreferenceType of the PregnancyHistory 
        /// </summary>
        public int? PreferenceType { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<Patient>? Patient { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HealthCare.Entities
{
    /// <summary> 
    /// Represents a visitinvestigation entity with essential details
    /// </summary>
    public class VisitInvestigation
    {
        /// <summary>
        /// TenantId of the VisitInvestigation 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the VisitInvestigation 
        /// </summary>
        [Key]
        public Guid? Id { get; set; }

        /// <summary>
        /// Required field Sequence of the VisitInvestigation 
        /// </summary>
        [Required]
        public int Sequence { get; set; }
        /// <summary>
        /// Summary of the VisitInvestigation 
        /// </summary>
        public string? Summary { get; set; }
        /// <summary>
        /// Foreign key referencing the DoctorInvestigation to which the VisitInvestigation belongs 
        /// </summary>
        public Guid? DoctorInvestigationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated DoctorInvestigation
        /// </summary>
        [ForeignKey("DoctorInvestigationId")]
        public DoctorInvestigation? DoctorInvestigation { get; set; }
        /// <summary>
        /// DoctorInvestigationProfileItemId of the VisitInvestigation 
        /// </summary>
        public Guid? DoctorInvestigationProfileItemId { get; set; }
        /// <summary>
        /// DoctorInvestigationProfileName of the VisitInvestigation 
        /// </summary>
        public string? DoctorInvestigationProfileName { get; set; }
        /// <summary>
        /// VisitId of the VisitInvestigation 
        /// </summary>
        public Guid? VisitId { get; set; }
        /// <summary>
        /// Foreign key referencing the Patient to which the VisitInvestigation belongs 
        /// </summary>
        public Guid? PatientId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Patient
        /// </summary>
        [ForeignKey("PatientId")]
        public Patient? Patient { get; set; }
        /// <summary>
        /// InvestigationId of the VisitInvestigation 
        /// </summary>
        public Guid? InvestigationId { get; set; }
        /// <summary>
        /// InvestigationProfileId of the VisitInvestigation 
        /// </summary>
        public Guid? InvestigationProfileId { get; set; }
        /// <summary>
        /// ProductId of the VisitInvestigation 
        /// </summary>
        public Guid? ProductId { get; set; }
        /// <summary>
        /// ProductName of the VisitInvestigation 
        /// </summary>
        public string? ProductName { get; set; }
        /// <summary>
        /// Foreign key referencing the InvoiceLine to which the VisitInvestigation belongs 
        /// </summary>
        public Guid? InvoiceLineId { get; set; }

        /// <summary>
        /// Navigation property representing the associated InvoiceLine
        /// </summary>
        [ForeignKey("InvoiceLineId")]
        public InvoiceLine? InvoiceLine { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<Visit>? Visit { get; set; }
    }
}
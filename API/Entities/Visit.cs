using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HealthCare.Entities
{
    /// <summary> 
    /// Represents a visit entity with essential details
    /// </summary>
    public class Visit
    {
        /// <summary>
        /// TenantId of the Visit 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the Visit 
        /// </summary>
        [Key]
        public Guid? Id { get; set; }

        /// <summary>
        /// Required field Name of the Visit 
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// VisitTypeId of the Visit 
        /// </summary>
        public Guid? VisitTypeId { get; set; }
        /// <summary>
        /// VisitModeId of the Visit 
        /// </summary>
        public Guid? VisitModeId { get; set; }
        /// <summary>
        /// Foreign key referencing the Patient to which the Visit belongs 
        /// </summary>
        public Guid? PatientId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Patient
        /// </summary>
        [ForeignKey("PatientId")]
        public Patient? Patient { get; set; }
        /// <summary>
        /// VisitStartDate of the Visit 
        /// </summary>
        public DateTime? VisitStartDate { get; set; }
        /// <summary>
        /// VisitCloseDate of the Visit 
        /// </summary>
        public DateTime? VisitCloseDate { get; set; }
        /// <summary>
        /// PreviousVisitDate of the Visit 
        /// </summary>
        public DateTime? PreviousVisitDate { get; set; }
        /// <summary>
        /// PreviousVisitId of the Visit 
        /// </summary>
        public Guid? PreviousVisitId { get; set; }
        /// <summary>
        /// PrescriptionConverted of the Visit 
        /// </summary>
        public bool? PrescriptionConverted { get; set; }
        /// <summary>
        /// VisitAttending of the Visit 
        /// </summary>
        public bool? VisitAttending { get; set; }
        /// <summary>
        /// Foreign key referencing the Location to which the Visit belongs 
        /// </summary>
        public Guid? LocationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Location
        /// </summary>
        [ForeignKey("LocationId")]
        public Location? Location { get; set; }
        /// <summary>
        /// ContactId of the Visit 
        /// </summary>
        public Guid? ContactId { get; set; }
        /// <summary>
        /// CreditVisit of the Visit 
        /// </summary>
        public bool? CreditVisit { get; set; }
        /// <summary>
        /// CoverCategoryId of the Visit 
        /// </summary>
        public string? CoverCategoryId { get; set; }
        /// <summary>
        /// MedicationLayout of the Visit 
        /// </summary>
        public int? MedicationLayout { get; set; }
        /// <summary>
        /// Foreign key referencing the VisitType to which the Visit belongs 
        /// </summary>
        public Guid? VisitType { get; set; }

        /// <summary>
        /// Navigation property representing the associated VisitType
        /// </summary>
        [ForeignKey("VisitType")]
        public VisitType? VisitTypeVisitType { get; set; }
        /// <summary>
        /// Foreign key referencing the VisitMode to which the Visit belongs 
        /// </summary>
        public Guid? VisitMode { get; set; }

        /// <summary>
        /// Navigation property representing the associated VisitMode
        /// </summary>
        [ForeignKey("VisitMode")]
        public VisitMode? VisitModeVisitMode { get; set; }
        /// <summary>
        /// Foreign key referencing the Patient to which the Visit belongs 
        /// </summary>
        public Guid? Patient { get; set; }

        /// <summary>
        /// Navigation property representing the associated Patient
        /// </summary>
        [ForeignKey("Patient")]
        public Patient? PatientPatient { get; set; }
        /// <summary>
        /// Foreign key referencing the Doctor to which the Visit belongs 
        /// </summary>
        public Guid? Doctor { get; set; }

        /// <summary>
        /// Navigation property representing the associated Doctor
        /// </summary>
        [ForeignKey("Doctor")]
        public Doctor? DoctorDoctor { get; set; }
        /// <summary>
        /// Foreign key referencing the Location to which the Visit belongs 
        /// </summary>
        public Guid? Location { get; set; }

        /// <summary>
        /// Navigation property representing the associated Location
        /// </summary>
        [ForeignKey("Location")]
        public Location? LocationLocation { get; set; }
        /// <summary>
        /// Foreign key referencing the Address to which the Visit belongs 
        /// </summary>
        public Guid? Contact { get; set; }

        /// <summary>
        /// Navigation property representing the associated Address
        /// </summary>
        [ForeignKey("Contact")]
        public Address? ContactAddress { get; set; }
        /// <summary>
        /// Foreign key referencing the Appointment to which the Visit belongs 
        /// </summary>
        public Guid? Appointment { get; set; }

        /// <summary>
        /// Navigation property representing the associated Appointment
        /// </summary>
        [ForeignKey("Appointment")]
        public Appointment? AppointmentAppointment { get; set; }
        /// <summary>
        /// Foreign key referencing the DayVisit to which the Visit belongs 
        /// </summary>
        public Guid? DayVisit { get; set; }

        /// <summary>
        /// Navigation property representing the associated DayVisit
        /// </summary>
        [ForeignKey("DayVisit")]
        public DayVisit? DayVisitDayVisit { get; set; }
        /// <summary>
        /// Foreign key referencing the VisitChiefComplaint to which the Visit belongs 
        /// </summary>
        public Guid? VisitChiefComplaint { get; set; }

        /// <summary>
        /// Navigation property representing the associated VisitChiefComplaint
        /// </summary>
        [ForeignKey("VisitChiefComplaint")]
        public VisitChiefComplaint? VisitChiefComplaintVisitChiefComplaint { get; set; }
        /// <summary>
        /// Foreign key referencing the VisitDiagnosis to which the Visit belongs 
        /// </summary>
        public Guid? VisitDiagnosis { get; set; }

        /// <summary>
        /// Navigation property representing the associated VisitDiagnosis
        /// </summary>
        [ForeignKey("VisitDiagnosis")]
        public VisitDiagnosis? VisitDiagnosisVisitDiagnosis { get; set; }
        /// <summary>
        /// Foreign key referencing the VisitGuideline to which the Visit belongs 
        /// </summary>
        public Guid? VisitGuideline { get; set; }

        /// <summary>
        /// Navigation property representing the associated VisitGuideline
        /// </summary>
        [ForeignKey("VisitGuideline")]
        public VisitGuideline? VisitGuidelineVisitGuideline { get; set; }
        /// <summary>
        /// Foreign key referencing the VisitVitalTemplateParameter to which the Visit belongs 
        /// </summary>
        public Guid? VisitVitalTemplateParameter { get; set; }

        /// <summary>
        /// Navigation property representing the associated VisitVitalTemplateParameter
        /// </summary>
        [ForeignKey("VisitVitalTemplateParameter")]
        public VisitVitalTemplateParameter? VisitVitalTemplateParameterVisitVitalTemplateParameter { get; set; }
        /// <summary>
        /// Foreign key referencing the VisitInvestigation to which the Visit belongs 
        /// </summary>
        public Guid? VisitInvestigation { get; set; }

        /// <summary>
        /// Navigation property representing the associated VisitInvestigation
        /// </summary>
        [ForeignKey("VisitInvestigation")]
        public VisitInvestigation? VisitInvestigationVisitInvestigation { get; set; }
        /// <summary>
        /// VisitClinicalPrintableNotes of the Visit 
        /// </summary>
        public string? VisitClinicalPrintableNotes { get; set; }
        /// <summary>
        /// Foreign key referencing the Invoice to which the Visit belongs 
        /// </summary>
        public Guid? Invoice { get; set; }

        /// <summary>
        /// Navigation property representing the associated Invoice
        /// </summary>
        [ForeignKey("Invoice")]
        public Invoice? InvoiceInvoice { get; set; }
        /// <summary>
        /// Foreign key referencing the Dispense to which the Visit belongs 
        /// </summary>
        public Guid? Dispenses { get; set; }

        /// <summary>
        /// Navigation property representing the associated Dispense
        /// </summary>
        [ForeignKey("Dispenses")]
        public Dispense? DispensesDispense { get; set; }
        /// <summary>
        /// VisitReferralNotes of the Visit 
        /// </summary>
        public string? VisitReferralNotes { get; set; }
        /// <summary>
        /// Foreign key referencing the VisitMedicalCertificate to which the Visit belongs 
        /// </summary>
        public Guid? VisitMedicalCertificates { get; set; }

        /// <summary>
        /// Navigation property representing the associated VisitMedicalCertificate
        /// </summary>
        [ForeignKey("VisitMedicalCertificates")]
        public VisitMedicalCertificate? VisitMedicalCertificatesVisitMedicalCertificate { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<VisitMedicalCertificate>? VisitMedicalCertificate { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<Invoice>? Invoice { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<Dispense>? Dispense { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<PatientPharmacyQueue>? PatientPharmacyQueue { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<VisitVitalTemplateParameter>? VisitVitalTemplateParameter { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<VisitGuideline>? VisitGuideline { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<VisitDiagnosis>? VisitDiagnosis { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<VisitChiefComplaint>? VisitChiefComplaint { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<Appointment>? Appointment { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<DayVisit>? DayVisit { get; set; }
    }
}
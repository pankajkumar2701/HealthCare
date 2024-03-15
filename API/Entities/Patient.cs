using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HealthCare.Entities
{
    /// <summary> 
    /// Represents a patient entity with essential details
    /// </summary>
    public class Patient
    {
        /// <summary>
        /// TenantId of the Patient 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the Patient 
        /// </summary>
        [Key]
        public Guid? PatientId { get; set; }
        /// <summary>
        /// Code of the Patient 
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// Required field Name of the Patient 
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Foreign key referencing the Title to which the Patient belongs 
        /// </summary>
        public Guid? TitleId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Title
        /// </summary>
        [ForeignKey("TitleId")]
        public Title? Title { get; set; }

        /// <summary>
        /// Required field FirstName of the Patient 
        /// </summary>
        [Required]
        public string FirstName { get; set; }
        /// <summary>
        /// MiddleName of the Patient 
        /// </summary>
        public string? MiddleName { get; set; }
        /// <summary>
        /// LastName of the Patient 
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Foreign key referencing the Gender to which the Patient belongs 
        /// </summary>
        [Required]
        public Guid GenderId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Gender
        /// </summary>
        [ForeignKey("GenderId")]
        public Gender? Gender { get; set; }

        /// <summary>
        /// Required field Dob of the Patient 
        /// </summary>
        [Required]
        public DateTime Dob { get; set; }

        /// <summary>
        /// Required field Age of the Patient 
        /// </summary>
        [Required]
        public int Age { get; set; }
        /// <summary>
        /// DobIsApproximate of the Patient 
        /// </summary>
        public bool? DobIsApproximate { get; set; }
        /// <summary>
        /// NationalIdNumber of the Patient 
        /// </summary>
        public string? NationalIdNumber { get; set; }
        /// <summary>
        /// RegisteredOn of the Patient 
        /// </summary>
        public DateTime? RegisteredOn { get; set; }
        /// <summary>
        /// DateOfDeath of the Patient 
        /// </summary>
        public DateTime? DateOfDeath { get; set; }
        /// <summary>
        /// ReasonOfDeath of the Patient 
        /// </summary>
        public string? ReasonOfDeath { get; set; }
        /// <summary>
        /// IsDeceased of the Patient 
        /// </summary>
        public bool? IsDeceased { get; set; }
        /// <summary>
        /// ReferredBy of the Patient 
        /// </summary>
        public string? ReferredBy { get; set; }

        /// <summary>
        /// Required field Mobile of the Patient 
        /// </summary>
        [Required]
        public string Mobile { get; set; }
        /// <summary>
        /// Email of the Patient 
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Foreign key referencing the Address to which the Patient belongs 
        /// </summary>
        public Guid? AddressId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Address
        /// </summary>
        [ForeignKey("AddressId")]
        public Address? Address { get; set; }
        /// <summary>
        /// LastVisitDate of the Patient 
        /// </summary>
        public DateTime? LastVisitDate { get; set; }
        /// <summary>
        /// EntityCode of the Patient 
        /// </summary>
        public string? EntityCode { get; set; }
        /// <summary>
        /// EntitySubTypeCode of the Patient 
        /// </summary>
        public string? EntitySubTypeCode { get; set; }
        /// <summary>
        /// BloodGroup of the Patient 
        /// </summary>
        public string? BloodGroup { get; set; }
        /// <summary>
        /// FileNumber of the Patient 
        /// </summary>
        public string? FileNumber { get; set; }
        /// <summary>
        /// CreatedBy of the Patient 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Required field CreatedOn of the Patient 
        /// </summary>
        [Required]
        public DateTime CreatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the Patient 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
        /// <summary>
        /// UpdatedOn of the Patient 
        /// </summary>
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// AlternateMobile of the Patient 
        /// </summary>
        public string? AlternateMobile { get; set; }
        /// <summary>
        /// IsDisabled of the Patient 
        /// </summary>
        public bool? IsDisabled { get; set; }
        /// <summary>
        /// MobileNumberCountryCode of the Patient 
        /// </summary>
        public int? MobileNumberCountryCode { get; set; }
        /// <summary>
        /// AlternateNumberCountryCode of the Patient 
        /// </summary>
        public int? AlternateNumberCountryCode { get; set; }
        /// <summary>
        /// Foreign key referencing the Location to which the Patient belongs 
        /// </summary>
        public Guid? LocationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Location
        /// </summary>
        [ForeignKey("LocationId")]
        public Location? Location { get; set; }
        /// <summary>
        /// Foreign key referencing the PatientNotes to which the Patient belongs 
        /// </summary>
        public Guid? PatientNotes { get; set; }

        /// <summary>
        /// Navigation property representing the associated PatientNotes
        /// </summary>
        [ForeignKey("PatientNotes")]
        public PatientNotes? PatientNotesPatientNotes { get; set; }
        /// <summary>
        /// Import of the Patient 
        /// </summary>
        public bool? Import { get; set; }
        /// <summary>
        /// Foreign key referencing the Membership to which the Patient belongs 
        /// </summary>
        public Guid? MembershipId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Membership
        /// </summary>
        [ForeignKey("MembershipId")]
        public Membership? Membership { get; set; }
        /// <summary>
        /// PatientEnrollment of the Patient 
        /// </summary>
        public bool? PatientEnrollment { get; set; }
        /// <summary>
        /// EnrollmentDate of the Patient 
        /// </summary>
        public DateTime? EnrollmentDate { get; set; }
        /// <summary>
        /// Landline of the Patient 
        /// </summary>
        public string? Landline { get; set; }
        /// <summary>
        /// IsVip of the Patient 
        /// </summary>
        public bool? IsVip { get; set; }
        /// <summary>
        /// IsConfidential of the Patient 
        /// </summary>
        public bool? IsConfidential { get; set; }
        /// <summary>
        /// Foreign key referencing the PatientAllergy to which the Patient belongs 
        /// </summary>
        public Guid? PatientAllergy { get; set; }

        /// <summary>
        /// Navigation property representing the associated PatientAllergy
        /// </summary>
        [ForeignKey("PatientAllergy")]
        public PatientAllergy? PatientAllergyPatientAllergy { get; set; }
        /// <summary>
        /// Foreign key referencing the PatientStatistics to which the Patient belongs 
        /// </summary>
        public Guid? PatientStatistics { get; set; }

        /// <summary>
        /// Navigation property representing the associated PatientStatistics
        /// </summary>
        [ForeignKey("PatientStatistics")]
        public PatientStatistics? PatientStatisticsPatientStatistics { get; set; }
        /// <summary>
        /// Foreign key referencing the PatientPatientCategory to which the Patient belongs 
        /// </summary>
        public Guid? PatientPatientCategories { get; set; }

        /// <summary>
        /// Navigation property representing the associated PatientPatientCategory
        /// </summary>
        [ForeignKey("PatientPatientCategories")]
        public PatientPatientCategory? PatientPatientCategoriesPatientPatientCategory { get; set; }
        /// <summary>
        /// Foreign key referencing the PatientComorbidity to which the Patient belongs 
        /// </summary>
        public Guid? PatientComorbidities { get; set; }

        /// <summary>
        /// Navigation property representing the associated PatientComorbidity
        /// </summary>
        [ForeignKey("PatientComorbidities")]
        public PatientComorbidity? PatientComorbiditiesPatientComorbidity { get; set; }
        /// <summary>
        /// Foreign key referencing the ContactMember to which the Patient belongs 
        /// </summary>
        public Guid? ContactMembers { get; set; }

        /// <summary>
        /// Navigation property representing the associated ContactMember
        /// </summary>
        [ForeignKey("ContactMembers")]
        public ContactMember? ContactMembersContactMember { get; set; }
        /// <summary>
        /// Foreign key referencing the PatientPayor to which the Patient belongs 
        /// </summary>
        public Guid? PatientPayors { get; set; }

        /// <summary>
        /// Navigation property representing the associated PatientPayor
        /// </summary>
        [ForeignKey("PatientPayors")]
        public PatientPayor? PatientPayorsPatientPayor { get; set; }
        /// <summary>
        /// Foreign key referencing the PatientLifeStyle to which the Patient belongs 
        /// </summary>
        public Guid? PatientLifeStyle { get; set; }

        /// <summary>
        /// Navigation property representing the associated PatientLifeStyle
        /// </summary>
        [ForeignKey("PatientLifeStyle")]
        public PatientLifeStyle? PatientLifeStylePatientLifeStyle { get; set; }
        /// <summary>
        /// Foreign key referencing the PatientEnrollmentLink to which the Patient belongs 
        /// </summary>
        public Guid? PatientEnrollmentLinks { get; set; }

        /// <summary>
        /// Navigation property representing the associated PatientEnrollmentLink
        /// </summary>
        [ForeignKey("PatientEnrollmentLinks")]
        public PatientEnrollmentLink? PatientEnrollmentLinksPatientEnrollmentLink { get; set; }
        /// <summary>
        /// Foreign key referencing the PatientHospitalisationHistory to which the Patient belongs 
        /// </summary>
        public Guid? PatientHospitalisationHistories { get; set; }

        /// <summary>
        /// Navigation property representing the associated PatientHospitalisationHistory
        /// </summary>
        [ForeignKey("PatientHospitalisationHistories")]
        public PatientHospitalisationHistory? PatientHospitalisationHistoriesPatientHospitalisationHistory { get; set; }
        /// <summary>
        /// Foreign key referencing the PregnancyHistory to which the Patient belongs 
        /// </summary>
        public Guid? PregnancyHistories { get; set; }

        /// <summary>
        /// Navigation property representing the associated PregnancyHistory
        /// </summary>
        [ForeignKey("PregnancyHistories")]
        public PregnancyHistory? PregnancyHistoriesPregnancyHistory { get; set; }
        /// <summary>
        /// Foreign key referencing the PatientMedicalHistoryNote to which the Patient belongs 
        /// </summary>
        public Guid? PatientMedicalHistoryNotes { get; set; }

        /// <summary>
        /// Navigation property representing the associated PatientMedicalHistoryNote
        /// </summary>
        [ForeignKey("PatientMedicalHistoryNotes")]
        public PatientMedicalHistoryNote? PatientMedicalHistoryNotesPatientMedicalHistoryNote { get; set; }
        /// <summary>
        /// Foreign key referencing the PatientPregnancy to which the Patient belongs 
        /// </summary>
        public Guid? PatientPregnancies { get; set; }

        /// <summary>
        /// Navigation property representing the associated PatientPregnancy
        /// </summary>
        [ForeignKey("PatientPregnancies")]
        public PatientPregnancy? PatientPregnanciesPatientPregnancy { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<PatientNotes>? PatientNotes { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<PatientAllergy>? PatientAllergy { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<PatientStatistics>? PatientStatistics { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<PatientPatientCategory>? PatientPatientCategory { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<PatientComorbidity>? PatientComorbidity { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<ContactMember>? ContactMember { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<PatientPayor>? PatientPayor { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<PatientLifeStyle>? PatientLifeStyle { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<PatientEnrollmentLink>? PatientEnrollmentLink { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<PatientHospitalisationHistory>? PatientHospitalisationHistory { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<PregnancyHistory>? PregnancyHistory { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<PatientMedicalHistoryNote>? PatientMedicalHistoryNote { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<PatientPregnancy>? PatientPregnancy { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<Visit>? Visit { get; set; }
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
        public ICollection<PaymentGateway>? PaymentGateway { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<Payment>? Payment { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<VisitInvestigation>? VisitInvestigation { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<VisitGuideline>? VisitGuideline { get; set; }
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
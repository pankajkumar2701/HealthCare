using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HealthCare.Entities
{
    /// <summary> 
    /// Represents a invoice entity with essential details
    /// </summary>
    public class Invoice
    {
        /// <summary>
        /// TenantId of the Invoice 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the Invoice 
        /// </summary>
        [Key]
        public Guid? Id { get; set; }

        /// <summary>
        /// Required field Name of the Invoice 
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Foreign key referencing the Visit to which the Invoice belongs 
        /// </summary>
        public Guid? VisitId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Visit
        /// </summary>
        [ForeignKey("VisitId")]
        public Visit? Visit { get; set; }
        /// <summary>
        /// Foreign key referencing the Patient to which the Invoice belongs 
        /// </summary>
        public Guid? PatientId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Patient
        /// </summary>
        [ForeignKey("PatientId")]
        public Patient? Patient { get; set; }
        /// <summary>
        /// GrossAmount of the Invoice 
        /// </summary>
        public int? GrossAmount { get; set; }
        /// <summary>
        /// NetAmount of the Invoice 
        /// </summary>
        public int? NetAmount { get; set; }
        /// <summary>
        /// DiscountAmount of the Invoice 
        /// </summary>
        public int? DiscountAmount { get; set; }
        /// <summary>
        /// DueAmount of the Invoice 
        /// </summary>
        public int? DueAmount { get; set; }
        /// <summary>
        /// CoPayAmount of the Invoice 
        /// </summary>
        public int? CoPayAmount { get; set; }
        /// <summary>
        /// PayorAmount of the Invoice 
        /// </summary>
        public int? PayorAmount { get; set; }
        /// <summary>
        /// InvoiceDate of the Invoice 
        /// </summary>
        public DateTime? InvoiceDate { get; set; }
        /// <summary>
        /// DueDate of the Invoice 
        /// </summary>
        public DateTime? DueDate { get; set; }
        /// <summary>
        /// IsVoid of the Invoice 
        /// </summary>
        public bool? IsVoid { get; set; }
        /// <summary>
        /// InvoiceType of the Invoice 
        /// </summary>
        public int? InvoiceType { get; set; }
        /// <summary>
        /// PayorType of the Invoice 
        /// </summary>
        public int? PayorType { get; set; }
        /// <summary>
        /// Foreign key referencing the Doctor to which the Invoice belongs 
        /// </summary>
        public Guid? DoctorId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Doctor
        /// </summary>
        [ForeignKey("DoctorId")]
        public Doctor? Doctor { get; set; }
        /// <summary>
        /// Foreign key referencing the Location to which the Invoice belongs 
        /// </summary>
        public Guid? LocationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Location
        /// </summary>
        [ForeignKey("LocationId")]
        public Location? Location { get; set; }
        /// <summary>
        /// Foreign key referencing the Payment to which the Invoice belongs 
        /// </summary>
        public Guid? Payment { get; set; }

        /// <summary>
        /// Navigation property representing the associated Payment
        /// </summary>
        [ForeignKey("Payment")]
        public Payment? PaymentPayment { get; set; }
        /// <summary>
        /// Foreign key referencing the Appointment to which the Invoice belongs 
        /// </summary>
        public Guid? Appointment { get; set; }

        /// <summary>
        /// Navigation property representing the associated Appointment
        /// </summary>
        [ForeignKey("Appointment")]
        public Appointment? AppointmentAppointment { get; set; }
        /// <summary>
        /// Foreign key referencing the DayVisit to which the Invoice belongs 
        /// </summary>
        public Guid? DayVisit { get; set; }

        /// <summary>
        /// Navigation property representing the associated DayVisit
        /// </summary>
        [ForeignKey("DayVisit")]
        public DayVisit? DayVisitDayVisit { get; set; }
        /// <summary>
        /// Foreign key referencing the Address to which the Invoice belongs 
        /// </summary>
        public Guid? ReferredById { get; set; }

        /// <summary>
        /// Navigation property representing the associated Address
        /// </summary>
        [ForeignKey("ReferredById")]
        public Address? ReferredByIdAddress { get; set; }
        /// <summary>
        /// ReferenceNumber of the Invoice 
        /// </summary>
        public string? ReferenceNumber { get; set; }
        /// <summary>
        /// PayorIsSame of the Invoice 
        /// </summary>
        public bool? PayorIsSame { get; set; }
        /// <summary>
        /// Foreign key referencing the Address to which the Invoice belongs 
        /// </summary>
        public Guid? PayorId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Address
        /// </summary>
        [ForeignKey("PayorId")]
        public Address? PayorIdAddress { get; set; }
        /// <summary>
        /// PlaceOfSupply of the Invoice 
        /// </summary>
        public string? PlaceOfSupply { get; set; }
        /// <summary>
        /// TaxAmount of the Invoice 
        /// </summary>
        public int? TaxAmount { get; set; }
        /// <summary>
        /// AmountInText of the Invoice 
        /// </summary>
        public string? AmountInText { get; set; }
        /// <summary>
        /// PaymentStatus of the Invoice 
        /// </summary>
        public int? PaymentStatus { get; set; }
        /// <summary>
        /// InvoiceBaseType of the Invoice 
        /// </summary>
        public int? InvoiceBaseType { get; set; }
        /// <summary>
        /// InvoiceStatus of the Invoice 
        /// </summary>
        public int? InvoiceStatus { get; set; }
        /// <summary>
        /// CoverCategoryId of the Invoice 
        /// </summary>
        public string? CoverCategoryId { get; set; }
        /// <summary>
        /// UserFullName of the Invoice 
        /// </summary>
        public string? UserFullName { get; set; }
        /// <summary>
        /// Foreign key referencing the Dispense to which the Invoice belongs 
        /// </summary>
        public Guid? Dispense { get; set; }

        /// <summary>
        /// Navigation property representing the associated Dispense
        /// </summary>
        [ForeignKey("Dispense")]
        public Dispense? DispenseDispense { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<Visit>? Visit { get; set; }
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
        public ICollection<AccountSettlement>? AccountSettlement { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<Payment>? Payment { get; set; }
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
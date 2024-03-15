using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HealthCare.Entities
{
    /// <summary> 
    /// Represents a appointmentreminderlog entity with essential details
    /// </summary>
    public class AppointmentReminderLog
    {
        /// <summary>
        /// TenantId of the AppointmentReminderLog 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the AppointmentReminderLog 
        /// </summary>
        [Key]
        public Guid? Id { get; set; }

        /// <summary>
        /// Required field Name of the AppointmentReminderLog 
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Foreign key referencing the Appointment to which the AppointmentReminderLog belongs 
        /// </summary>
        public Guid? AppointmentId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Appointment
        /// </summary>
        [ForeignKey("AppointmentId")]
        public Appointment? Appointment { get; set; }
        /// <summary>
        /// LogDateTime of the AppointmentReminderLog 
        /// </summary>
        public DateTime? LogDateTime { get; set; }
        /// <summary>
        /// EmailStatus of the AppointmentReminderLog 
        /// </summary>
        public bool? EmailStatus { get; set; }
        /// <summary>
        /// SmsStatus of the AppointmentReminderLog 
        /// </summary>
        public bool? SmsStatus { get; set; }
        /// <summary>
        /// WhatsAppStatus of the AppointmentReminderLog 
        /// </summary>
        public bool? WhatsAppStatus { get; set; }
        /// <summary>
        /// Foreign key referencing the Appointment to which the AppointmentReminderLog belongs 
        /// </summary>
        public Guid? Appointment { get; set; }

        /// <summary>
        /// Navigation property representing the associated Appointment
        /// </summary>
        [ForeignKey("Appointment")]
        public Appointment? AppointmentAppointment { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<Appointment>? Appointment { get; set; }
    }
}
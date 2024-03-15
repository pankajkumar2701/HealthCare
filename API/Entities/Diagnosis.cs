using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HealthCare.Entities
{
    /// <summary> 
    /// Represents a diagnosis entity with essential details
    /// </summary>
    public class Diagnosis
    {
        /// <summary>
        /// TenantId of the Diagnosis 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the Diagnosis 
        /// </summary>
        [Key]
        public Guid? Id { get; set; }

        /// <summary>
        /// Required field Name of the Diagnosis 
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Required field Sequence of the Diagnosis 
        /// </summary>
        [Required]
        public int Sequence { get; set; }
        /// <summary>
        /// Favourite of the Diagnosis 
        /// </summary>
        public bool? Favourite { get; set; }
        /// <summary>
        /// IsDeleted of the Diagnosis 
        /// </summary>
        public bool? IsDeleted { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<VisitDiagnosis>? VisitDiagnosis { get; set; }
    }
}
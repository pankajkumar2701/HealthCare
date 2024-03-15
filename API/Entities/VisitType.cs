using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HealthCare.Entities
{
    /// <summary> 
    /// Represents a visittype entity with essential details
    /// </summary>
    public class VisitType
    {
        /// <summary>
        /// Default of the VisitType 
        /// </summary>
        public bool? Default { get; set; }
        /// <summary>
        /// TenantId of the VisitType 
        /// </summary>
        public Guid? TenantId { get; set; }
        /// <summary>
        /// Id of the VisitType 
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Required field Name of the VisitType 
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<Visit>? Visit { get; set; }
    }
}
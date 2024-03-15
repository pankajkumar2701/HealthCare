using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HealthCare.Entities
{
    /// <summary> 
    /// Represents a currency entity with essential details
    /// </summary>
    public class Currency
    {
        /// <summary>
        /// Primary key for the Currency 
        /// </summary>
        [Key]
        public Guid? Id { get; set; }
        /// <summary>
        /// TenantId of the Currency 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Required field Name of the Currency 
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Code of the Currency 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Symbol of the Currency 
        /// </summary>
        public string? Symbol { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<Country>? Country { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<AccountSettlement>? AccountSettlement { get; set; }
    }
}
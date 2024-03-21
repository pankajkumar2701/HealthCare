using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HealthCare.Entities
{
    /// <summary> 
    /// Represents a pricelist entity with essential details
    /// </summary>
    public class PriceList
    {
        /// <summary>
        /// TenantId of the PriceList 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the PriceList 
        /// </summary>
        [Key]
        public Guid? Id { get; set; }
        /// <summary>
        /// PriceListBaseType of the PriceList 
        /// </summary>
        public int? PriceListBaseType { get; set; }
        /// <summary>
        /// PricelistType of the PriceList 
        /// </summary>
        public int? PricelistType { get; set; }

        /// <summary>
        /// Required field Name of the PriceList 
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// PricelistStatus of the PriceList 
        /// </summary>
        public int? PricelistStatus { get; set; }
        /// <summary>
        /// Notes of the PriceList 
        /// </summary>
        public string? Notes { get; set; }
        /// <summary>
        /// StartDate of the PriceList 
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// EndDate of the PriceList 
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// CreatedBy of the PriceList 
        /// </summary>
        public Guid? CreatedBy { get; set; }
        /// <summary>
        /// CreatedOn of the PriceList 
        /// </summary>
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the PriceList 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
        /// <summary>
        /// UpdatedOn of the PriceList 
        /// </summary>
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Enable of the PriceList 
        /// </summary>
        public bool? Enable { get; set; }
        /// <summary>
        /// Foreign key referencing the PriceListComponent to which the PriceList belongs 
        /// </summary>
        public Guid? PriceListComponents { get; set; }

        /// <summary>
        /// Navigation property representing the associated PriceListComponent
        /// </summary>
        [ForeignKey("PriceListComponents")]
        public PriceListComponent? PriceListComponentsPriceListComponent { get; set; }
        /// <summary>
        /// Foreign key referencing the PriceListItem to which the PriceList belongs 
        /// </summary>
        public Guid? PriceListItems { get; set; }

        /// <summary>
        /// Navigation property representing the associated PriceListItem
        /// </summary>
        [ForeignKey("PriceListItems")]
        public PriceListItem? PriceListItemsPriceListItem { get; set; }
        /// <summary>
        /// Foreign key referencing the PriceListVersion to which the PriceList belongs 
        /// </summary>
        public Guid? PriceListVersions { get; set; }

        /// <summary>
        /// Navigation property representing the associated PriceListVersion
        /// </summary>
        [ForeignKey("PriceListVersions")]
        public PriceListVersion? PriceListVersionsPriceListVersion { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<PriceListVersion>? PriceListVersion { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<PriceListItem>? PriceListItem { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<PriceListComponent>? PriceListComponent { get; set; }
    }
}
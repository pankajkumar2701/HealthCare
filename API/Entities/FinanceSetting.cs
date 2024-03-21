using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HealthCare.Entities
{
    /// <summary> 
    /// Represents a financesetting entity with essential details
    /// </summary>
    public class FinanceSetting
    {
        /// <summary>
        /// TenantId of the FinanceSetting 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the FinanceSetting 
        /// </summary>
        [Key]
        public Guid? Id { get; set; }

        /// <summary>
        /// Required field Name of the FinanceSetting 
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// FinancialYearType of the FinanceSetting 
        /// </summary>
        public int? FinancialYearType { get; set; }
        /// <summary>
        /// Foreign key referencing the Product to which the FinanceSetting belongs 
        /// </summary>
        public Guid? ProductId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Product
        /// </summary>
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
        /// <summary>
        /// CreatedBy of the FinanceSetting 
        /// </summary>
        public Guid? CreatedBy { get; set; }
        /// <summary>
        /// CreatedOn of the FinanceSetting 
        /// </summary>
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the FinanceSetting 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
        /// <summary>
        /// UpdatedOn of the FinanceSetting 
        /// </summary>
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<Product>? Product { get; set; }
    }
}
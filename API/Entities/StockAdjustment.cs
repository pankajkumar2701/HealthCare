using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HealthCare.Entities
{
    /// <summary> 
    /// Represents a stockadjustment entity with essential details
    /// </summary>
    public class StockAdjustment
    {
        /// <summary>
        /// TenantId of the StockAdjustment 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the StockAdjustment 
        /// </summary>
        [Key]
        public Guid? Id { get; set; }
        /// <summary>
        /// ReferenceNo of the StockAdjustment 
        /// </summary>
        public string? ReferenceNo { get; set; }
        /// <summary>
        /// Code of the StockAdjustment 
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// Required field Name of the StockAdjustment 
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// AdjustmentDate of the StockAdjustment 
        /// </summary>
        public DateTime? AdjustmentDate { get; set; }
        /// <summary>
        /// Foreign key referencing the Location to which the StockAdjustment belongs 
        /// </summary>
        public Guid? LocationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Location
        /// </summary>
        [ForeignKey("LocationId")]
        public Location? Location { get; set; }
        /// <summary>
        /// Foreign key referencing the StockAdjustmentItem to which the StockAdjustment belongs 
        /// </summary>
        public Guid? StockAdjustmentItem { get; set; }

        /// <summary>
        /// Navigation property representing the associated StockAdjustmentItem
        /// </summary>
        [ForeignKey("StockAdjustmentItem")]
        public StockAdjustmentItem? StockAdjustmentItemStockAdjustmentItem { get; set; }
        /// <summary>
        /// Foreign key referencing the StockAdjustmentFile to which the StockAdjustment belongs 
        /// </summary>
        public Guid? StockAdjustmentFile { get; set; }

        /// <summary>
        /// Navigation property representing the associated StockAdjustmentFile
        /// </summary>
        [ForeignKey("StockAdjustmentFile")]
        public StockAdjustmentFile? StockAdjustmentFileStockAdjustmentFile { get; set; }
        /// <summary>
        /// Status of the StockAdjustment 
        /// </summary>
        public int? Status { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<StockAdjustmentItem>? StockAdjustmentItem { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<StockAdjustmentFile>? StockAdjustmentFile { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HealthCare.Entities
{
    /// <summary> 
    /// Represents a productbatch entity with essential details
    /// </summary>
    public class ProductBatch
    {
        /// <summary>
        /// TenantId of the ProductBatch 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the ProductBatch 
        /// </summary>
        [Key]
        public Guid? Id { get; set; }

        /// <summary>
        /// Required field Name of the ProductBatch 
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// PurchaseValue of the ProductBatch 
        /// </summary>
        public int? PurchaseValue { get; set; }
        /// <summary>
        /// Foreign key referencing the ProductUom to which the ProductBatch belongs 
        /// </summary>
        public Guid? ProductUomId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ProductUom
        /// </summary>
        [ForeignKey("ProductUomId")]
        public ProductUom? ProductUom { get; set; }
        /// <summary>
        /// BatchNumber of the ProductBatch 
        /// </summary>
        public string? BatchNumber { get; set; }
        /// <summary>
        /// BatchQuantity of the ProductBatch 
        /// </summary>
        public int? BatchQuantity { get; set; }
        /// <summary>
        /// PackReceiptQuantity of the ProductBatch 
        /// </summary>
        public int? PackReceiptQuantity { get; set; }
        /// <summary>
        /// UnitPrice of the ProductBatch 
        /// </summary>
        public int? UnitPrice { get; set; }
        /// <summary>
        /// ExpiryDate of the ProductBatch 
        /// </summary>
        public DateTime? ExpiryDate { get; set; }
        /// <summary>
        /// ManufactureDate of the ProductBatch 
        /// </summary>
        public DateTime? ManufactureDate { get; set; }
        /// <summary>
        /// AverageCost of the ProductBatch 
        /// </summary>
        public int? AverageCost { get; set; }
        /// <summary>
        /// Import of the ProductBatch 
        /// </summary>
        public bool? Import { get; set; }
        /// <summary>
        /// Foreign key referencing the Location to which the ProductBatch belongs 
        /// </summary>
        public Guid? Location { get; set; }

        /// <summary>
        /// Navigation property representing the associated Location
        /// </summary>
        [ForeignKey("Location")]
        public Location? LocationLocation { get; set; }
        /// <summary>
        /// Foreign key referencing the Product to which the ProductBatch belongs 
        /// </summary>
        public Guid? Product { get; set; }

        /// <summary>
        /// Navigation property representing the associated Product
        /// </summary>
        [ForeignKey("Product")]
        public Product? ProductProduct { get; set; }
        /// <summary>
        /// Foreign key referencing the InvoiceLine to which the ProductBatch belongs 
        /// </summary>
        public Guid? InvoiceLineId { get; set; }

        /// <summary>
        /// Navigation property representing the associated InvoiceLine
        /// </summary>
        [ForeignKey("InvoiceLineId")]
        public InvoiceLine? InvoiceLine { get; set; }
        /// <summary>
        /// ProductCode of the ProductBatch 
        /// </summary>
        public string? ProductCode { get; set; }
        /// <summary>
        /// Error of the ProductBatch 
        /// </summary>
        public string? Error { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<InvoiceLine>? InvoiceLine { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<DispenseItem>? DispenseItem { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<Product>? Product { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<GoodsReceiptItem>? GoodsReceiptItem { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<GoodsReturnItem>? GoodsReturnItem { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<StockAdjustmentItem>? StockAdjustmentItem { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HealthCare.Entities
{
    /// <summary> 
    /// Represents a productuom entity with essential details
    /// </summary>
    public class ProductUom
    {
        /// <summary>
        /// TenantId of the ProductUom 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the ProductUom 
        /// </summary>
        [Key]
        public Guid? Id { get; set; }

        /// <summary>
        /// Required field Name of the ProductUom 
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Foreign key referencing the Product to which the ProductUom belongs 
        /// </summary>
        public Guid? ProductId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Product
        /// </summary>
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
        /// <summary>
        /// Foreign key referencing the Uom to which the ProductUom belongs 
        /// </summary>
        public Guid? UomId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Uom
        /// </summary>
        [ForeignKey("UomId")]
        public Uom? Uom { get; set; }
        /// <summary>
        /// ConversionQuantity of the ProductUom 
        /// </summary>
        public int? ConversionQuantity { get; set; }
        /// <summary>
        /// Purchase of the ProductUom 
        /// </summary>
        public bool? Purchase { get; set; }
        /// <summary>
        /// Selling of the ProductUom 
        /// </summary>
        public bool? Selling { get; set; }
        /// <summary>
        /// PurchaseDefault of the ProductUom 
        /// </summary>
        public bool? PurchaseDefault { get; set; }
        /// <summary>
        /// SellingDefault of the ProductUom 
        /// </summary>
        public bool? SellingDefault { get; set; }
        /// <summary>
        /// LowestUom of the ProductUom 
        /// </summary>
        public bool? LowestUom { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<InvoiceLine>? InvoiceLine { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<Product>? Product { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<ProductBatch>? ProductBatch { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<GoodsReturnItem>? GoodsReturnItem { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<PriceListItem>? PriceListItem { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<PurchaseOrderLine>? PurchaseOrderLine { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<RequisitionLine>? RequisitionLine { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<StockAdjustmentItem>? StockAdjustmentItem { get; set; }
    }
}
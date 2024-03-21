using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HealthCare.Entities
{
    /// <summary> 
    /// Represents a purchaseorderline entity with essential details
    /// </summary>
    public class PurchaseOrderLine
    {
        /// <summary>
        /// Primary key for the PurchaseOrderLine 
        /// </summary>
        [Key]
        public Guid? Id { get; set; }
        /// <summary>
        /// TenantId of the PurchaseOrderLine 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Required field Name of the PurchaseOrderLine 
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Foreign key referencing the PurchaseOrder to which the PurchaseOrderLine belongs 
        /// </summary>
        public Guid? PurchaseOrderId { get; set; }

        /// <summary>
        /// Navigation property representing the associated PurchaseOrder
        /// </summary>
        [ForeignKey("PurchaseOrderId")]
        public PurchaseOrder? PurchaseOrder { get; set; }
        /// <summary>
        /// Foreign key referencing the Product to which the PurchaseOrderLine belongs 
        /// </summary>
        public Guid? ProductId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Product
        /// </summary>
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
        /// <summary>
        /// OrderQuantity of the PurchaseOrderLine 
        /// </summary>
        public int? OrderQuantity { get; set; }
        /// <summary>
        /// Foreign key referencing the ProductUom to which the PurchaseOrderLine belongs 
        /// </summary>
        public Guid? ProductUomId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ProductUom
        /// </summary>
        [ForeignKey("ProductUomId")]
        public ProductUom? ProductUom { get; set; }
        /// <summary>
        /// TotalQuantity of the PurchaseOrderLine 
        /// </summary>
        public int? TotalQuantity { get; set; }
        /// <summary>
        /// PackUnitPrice of the PurchaseOrderLine 
        /// </summary>
        public int? PackUnitPrice { get; set; }
        /// <summary>
        /// TaxAmount of the PurchaseOrderLine 
        /// </summary>
        public int? TaxAmount { get; set; }
        /// <summary>
        /// TotalAmount of the PurchaseOrderLine 
        /// </summary>
        public int? TotalAmount { get; set; }
        /// <summary>
        /// LineRejected of the PurchaseOrderLine 
        /// </summary>
        public bool? LineRejected { get; set; }
        /// <summary>
        /// Reason of the PurchaseOrderLine 
        /// </summary>
        public string? Reason { get; set; }
        /// <summary>
        /// Foreign key referencing the Requisition to which the PurchaseOrderLine belongs 
        /// </summary>
        public Guid? RequisitionId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Requisition
        /// </summary>
        [ForeignKey("RequisitionId")]
        public Requisition? Requisition { get; set; }
        /// <summary>
        /// Foreign key referencing the RequisitionLine to which the PurchaseOrderLine belongs 
        /// </summary>
        public Guid? RequisitionLineId { get; set; }

        /// <summary>
        /// Navigation property representing the associated RequisitionLine
        /// </summary>
        [ForeignKey("RequisitionLineId")]
        public RequisitionLine? RequisitionLine { get; set; }
        /// <summary>
        /// RemainingQuantity of the PurchaseOrderLine 
        /// </summary>
        public int? RemainingQuantity { get; set; }
        /// <summary>
        /// Foreign key referencing the GoodsReceipt to which the PurchaseOrderLine belongs 
        /// </summary>
        public Guid? GoodsReceiptId { get; set; }

        /// <summary>
        /// Navigation property representing the associated GoodsReceipt
        /// </summary>
        [ForeignKey("GoodsReceiptId")]
        public GoodsReceipt? GoodsReceipt { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<GoodsReceiptItem>? GoodsReceiptItem { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<RequisitionLine>? RequisitionLine { get; set; }
    }
}
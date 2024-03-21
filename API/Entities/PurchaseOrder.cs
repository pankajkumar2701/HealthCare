using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HealthCare.Entities
{
    /// <summary> 
    /// Represents a purchaseorder entity with essential details
    /// </summary>
    public class PurchaseOrder
    {
        /// <summary>
        /// Primary key for the PurchaseOrder 
        /// </summary>
        [Key]
        public Guid? Id { get; set; }
        /// <summary>
        /// TenantId of the PurchaseOrder 
        /// </summary>
        public Guid? TenantId { get; set; }
        /// <summary>
        /// Code of the PurchaseOrder 
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// Required field Name of the PurchaseOrder 
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// PurchaseOrderDate of the PurchaseOrder 
        /// </summary>
        public DateTime? PurchaseOrderDate { get; set; }
        /// <summary>
        /// Foreign key referencing the Location to which the PurchaseOrder belongs 
        /// </summary>
        public Guid? LocationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Location
        /// </summary>
        [ForeignKey("LocationId")]
        public Location? Location { get; set; }
        /// <summary>
        /// Foreign key referencing the PurchaseOrderFile to which the PurchaseOrder belongs 
        /// </summary>
        public Guid? PurchaseOrderFile { get; set; }

        /// <summary>
        /// Navigation property representing the associated PurchaseOrderFile
        /// </summary>
        [ForeignKey("PurchaseOrderFile")]
        public PurchaseOrderFile? PurchaseOrderFilePurchaseOrderFile { get; set; }
        /// <summary>
        /// Foreign key referencing the Requisition to which the PurchaseOrder belongs 
        /// </summary>
        public Guid? Requisition { get; set; }

        /// <summary>
        /// Navigation property representing the associated Requisition
        /// </summary>
        [ForeignKey("Requisition")]
        public Requisition? RequisitionRequisition { get; set; }
        /// <summary>
        /// OrderBy of the PurchaseOrder 
        /// </summary>
        public Guid? OrderBy { get; set; }
        /// <summary>
        /// ExpectedDeliveryDate of the PurchaseOrder 
        /// </summary>
        public DateTime? ExpectedDeliveryDate { get; set; }
        /// <summary>
        /// CompletedDate of the PurchaseOrder 
        /// </summary>
        public DateTime? CompletedDate { get; set; }
        /// <summary>
        /// InUsed of the PurchaseOrder 
        /// </summary>
        public bool? InUsed { get; set; }
        /// <summary>
        /// ReceivedStatus of the PurchaseOrder 
        /// </summary>
        public int? ReceivedStatus { get; set; }
        /// <summary>
        /// ReferenceNumber of the PurchaseOrder 
        /// </summary>
        public string? ReferenceNumber { get; set; }
        /// <summary>
        /// OrderAmount of the PurchaseOrder 
        /// </summary>
        public int? OrderAmount { get; set; }
        /// <summary>
        /// TotalAttachment of the PurchaseOrder 
        /// </summary>
        public int? TotalAttachment { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<GoodsReceiptPurchaseOrderRelation>? GoodsReceiptPurchaseOrderRelation { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<GoodsReceiptItem>? GoodsReceiptItem { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<PurchaseOrderLine>? PurchaseOrderLine { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<PurchaseOrderFile>? PurchaseOrderFile { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<RequisitionLine>? RequisitionLine { get; set; }
    }
}
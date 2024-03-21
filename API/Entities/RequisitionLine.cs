using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HealthCare.Entities
{
    /// <summary> 
    /// Represents a requisitionline entity with essential details
    /// </summary>
    public class RequisitionLine
    {
        /// <summary>
        /// Primary key for the RequisitionLine 
        /// </summary>
        [Key]
        public Guid? Id { get; set; }
        /// <summary>
        /// TenantId of the RequisitionLine 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Required field Name of the RequisitionLine 
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Foreign key referencing the Requisition to which the RequisitionLine belongs 
        /// </summary>
        public Guid? RequisitionId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Requisition
        /// </summary>
        [ForeignKey("RequisitionId")]
        public Requisition? Requisition { get; set; }
        /// <summary>
        /// Foreign key referencing the Product to which the RequisitionLine belongs 
        /// </summary>
        public Guid? ProductId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Product
        /// </summary>
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
        /// <summary>
        /// OrderQuantity of the RequisitionLine 
        /// </summary>
        public int? OrderQuantity { get; set; }
        /// <summary>
        /// Foreign key referencing the ProductUom to which the RequisitionLine belongs 
        /// </summary>
        public Guid? ProductUomId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ProductUom
        /// </summary>
        [ForeignKey("ProductUomId")]
        public ProductUom? ProductUom { get; set; }
        /// <summary>
        /// TotalQuantity of the RequisitionLine 
        /// </summary>
        public int? TotalQuantity { get; set; }
        /// <summary>
        /// RequisitionLineRejected of the RequisitionLine 
        /// </summary>
        public bool? RequisitionLineRejected { get; set; }
        /// <summary>
        /// Foreign key referencing the PurchaseOrder to which the RequisitionLine belongs 
        /// </summary>
        public Guid? PurchaseOrderId { get; set; }

        /// <summary>
        /// Navigation property representing the associated PurchaseOrder
        /// </summary>
        [ForeignKey("PurchaseOrderId")]
        public PurchaseOrder? PurchaseOrder { get; set; }
        /// <summary>
        /// Foreign key referencing the PurchaseOrderLine to which the RequisitionLine belongs 
        /// </summary>
        public Guid? PurchaseOrderLineId { get; set; }

        /// <summary>
        /// Navigation property representing the associated PurchaseOrderLine
        /// </summary>
        [ForeignKey("PurchaseOrderLineId")]
        public PurchaseOrderLine? PurchaseOrderLine { get; set; }
        /// <summary>
        /// CreatedBy of the RequisitionLine 
        /// </summary>
        public Guid? CreatedBy { get; set; }
        /// <summary>
        /// CreatedOn of the RequisitionLine 
        /// </summary>
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the RequisitionLine 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
        /// <summary>
        /// UpdatedOn of the RequisitionLine 
        /// </summary>
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Reason of the RequisitionLine 
        /// </summary>
        public string? Reason { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<PurchaseOrderLine>? PurchaseOrderLine { get; set; }
    }
}
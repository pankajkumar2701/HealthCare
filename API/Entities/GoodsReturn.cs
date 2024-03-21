using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HealthCare.Entities
{
    /// <summary> 
    /// Represents a goodsreturn entity with essential details
    /// </summary>
    public class GoodsReturn
    {
        /// <summary>
        /// TenantId of the GoodsReturn 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the GoodsReturn 
        /// </summary>
        [Key]
        public Guid? Id { get; set; }
        /// <summary>
        /// GrrNumber of the GoodsReturn 
        /// </summary>
        public string? GrrNumber { get; set; }
        /// <summary>
        /// ReturnDate of the GoodsReturn 
        /// </summary>
        public DateTime? ReturnDate { get; set; }
        /// <summary>
        /// Foreign key referencing the GoodsReceipt to which the GoodsReturn belongs 
        /// </summary>
        public Guid? GoodsReceiptId { get; set; }

        /// <summary>
        /// Navigation property representing the associated GoodsReceipt
        /// </summary>
        [ForeignKey("GoodsReceiptId")]
        public GoodsReceipt? GoodsReceipt { get; set; }
        /// <summary>
        /// Supplier of the GoodsReturn 
        /// </summary>
        public string? Supplier { get; set; }
        /// <summary>
        /// Foreign key referencing the Location to which the GoodsReturn belongs 
        /// </summary>
        public Guid? LocationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Location
        /// </summary>
        [ForeignKey("LocationId")]
        public Location? Location { get; set; }
        /// <summary>
        /// Foreign key referencing the GoodsReturnFile to which the GoodsReturn belongs 
        /// </summary>
        public Guid? GoodsReturnFile { get; set; }

        /// <summary>
        /// Navigation property representing the associated GoodsReturnFile
        /// </summary>
        [ForeignKey("GoodsReturnFile")]
        public GoodsReturnFile? GoodsReturnFileGoodsReturnFile { get; set; }
        /// <summary>
        /// Foreign key referencing the GoodsReturnItem to which the GoodsReturn belongs 
        /// </summary>
        public Guid? GoodsReturnItem { get; set; }

        /// <summary>
        /// Navigation property representing the associated GoodsReturnItem
        /// </summary>
        [ForeignKey("GoodsReturnItem")]
        public GoodsReturnItem? GoodsReturnItemGoodsReturnItem { get; set; }
        /// <summary>
        /// Foreign key referencing the SubReason to which the GoodsReturn belongs 
        /// </summary>
        public Guid? SubReason { get; set; }

        /// <summary>
        /// Navigation property representing the associated SubReason
        /// </summary>
        [ForeignKey("SubReason")]
        public SubReason? SubReasonSubReason { get; set; }
        /// <summary>
        /// Reason of the GoodsReturn 
        /// </summary>
        public string? Reason { get; set; }
        /// <summary>
        /// ReferrenceNo of the GoodsReturn 
        /// </summary>
        public string? ReferrenceNo { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<GoodsReceipt>? GoodsReceipt { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<SubReason>? SubReason { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<GoodsReturnItem>? GoodsReturnItem { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<GoodsReturnFile>? GoodsReturnFile { get; set; }
    }
}
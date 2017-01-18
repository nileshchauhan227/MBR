using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.DTO
{
    public class PurchaseReturnMasterDTO
    {
        private List<PurchaseReturnDetailDTO> _purchaseReturnDetails;
        public long ID { get; set; }
        public DateTime ReturnDate { get; set; }
        public long PurchaseID { get; set; }
        public string ReasonForReturn { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public List<PurchaseReturnDetailDTO> PurchaseReturnDetailList
        {
            get
            {
                if (_purchaseReturnDetails == null)
                {
                    _purchaseReturnDetails = new List<PurchaseReturnDetailDTO>();
                    return _purchaseReturnDetails;
                }
                else
                {
                    return _purchaseReturnDetails;
                }
            }
            set
            {
                _purchaseReturnDetails = value;
            }
        }


        public string VendorName { get; set; }

        public string InvoiceNumber { get; set; }

        public DateTime? InvoiceDate { get; set; }
    }
    public class PurchaseReturnDetailDTO
    {
        public long ID { get; set; }
        public long PurchaseReturnMasterID { get; set; }
        public int ItemID { get; set; }
        public string ItemCode { get; set; }
        public decimal? Qty { get; set; }
        public bool? IsDeleted { get; set; }

        public string ItemName { get; set; }

        public string Unit { get; set; }
    }
}

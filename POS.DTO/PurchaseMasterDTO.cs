using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.DTO
{
    public class PurchaseMasterDTO
    {
        List<PurchaseDetailDTO> _PurchaseDetailList = new List<PurchaseDetailDTO>();

        public long PurchaseID { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string PONumber { get; set; }
        public DateTime? PODate { get; set; }
        public string ReceivedBy { get; set; }
        public string Remarks { get; set; }
        public decimal InvoiceAmount { get; set; }
        public Int16 TransactionType { get; set; }
        public string Career { get; set; }
        public int VendorID { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public List<PurchaseDetailDTO> PurchaseDetailList
        {
            get
            {
                if (_PurchaseDetailList != null)
                    return _PurchaseDetailList;
                else
                    return new List<PurchaseDetailDTO>();
            }
            set
            {
                _PurchaseDetailList = value;
            }

        }

        public string VendorName { get; set; }
    }
}

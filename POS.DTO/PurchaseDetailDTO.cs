using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.DTO
{
    public class PurchaseDetailDTO
    {
        public PurchaseDetailDTO()
        {
            barcodes = new List<string>();
        }

        public long PurchaseDetailID { get; set; }
        public long PurchaseID { get; set; }
        public int ItemID { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public bool IsDeleted { get; set; }
        public decimal? PricePerItem { get; set; }
        public decimal? MRPPerItem { get; set; }

        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Unit { get; set; }
        public List<string> barcodes { get; set; }
    }
}

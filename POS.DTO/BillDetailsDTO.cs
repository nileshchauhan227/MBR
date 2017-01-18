using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.DTO
{
    public class BillDetailsDTO
    {
        public int BillDetailID { get; set; }
        public int BillID { get; set; }
        public int ItemID { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal Discount { get; set; }
        public decimal Amount { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public decimal ItemRate { get; set; }
        public decimal ItemDiscount { get; set; }
        public decimal? Tax { get; set; }
        public bool IsDeleted { get; set; }
        public string Unit { get; set; }
    }
}

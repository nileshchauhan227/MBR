using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.DTO
{
    public class KOTDetailDTO
    {
        public int ID { get; set; }
        public int KOTID { get; set; }
        public int ItemID { get; set; }
        public decimal Quantity { get; set; }
        public bool IsServed { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public decimal? ItemRate { get; set; }
        public decimal? Discount { get; set; }
        public decimal? OtherDiscount { get; set; }
        public bool IsDeleted { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.DTO
{
    public class ItemMasterDTO
    {
        public int ItemID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int GroupID { get; set; }
        public int UnitID { get; set; }
        public decimal? Discount { get; set; }
        public double? Rate { get; set; }
        public decimal? OtherDiscount { get; set; }
        public bool? IsActive { get; set; }
        public Boolean? ServiceTax { get; set; }
        public int FirmId { get; set; }
        public string Group { get; set; }
        public string unit { get; set; }
        public bool IsSaleable { get; set; }
        public bool? IsUniqueSerialNumber { get; set; }
        public decimal? OpeningBalance { get; set; }
        public List<string> barcodes { get; set; }
        public int CustomerId { get; set; }
        
    }
}

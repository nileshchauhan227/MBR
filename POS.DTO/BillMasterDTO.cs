using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.DTO
{
    public class BillMasterDTO
    {
        public BillMasterDTO()
        {
            details = new List<BillDetailsDTO>();
        }
        public int BillID { get; set; }
        public int Rnumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Party { get; set; }
        public string PaymentMode { get; set; }
        public int TableID { get; set; }
        public int WaiterID { get; set; }
        public int CustomerId { get; set; }
        public int BillTypeId { get; set; }
        public string MobileNo { get; set; }
        public int NoOfItems { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal Discount { get; set; }
        public string DiscountReason { get; set; }
        public decimal? Tax { get; set; }
        public decimal? AdditionalTax { get; set; }
        public decimal? AdditionalPercentage { get; set; }
        
        public decimal NetAmount { get; set; }
        public decimal CashReceived { get; set; }
        public decimal RoundOff { get; set; }
        public bool IsPrinted { get; set; }
        public List<BillDetailsDTO> details { get; set; }

        public string Series { get; set; }
        public List<int> KotIDs { get; set; }

        public string TableName { get; set; }

        public string BillNumber
        {
            get
            {
                return this.Series + "/" + this.Rnumber.ToString();
            }
        }

        public bool IsDeleted { get; set; }
    }
}

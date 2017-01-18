using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.DTO
{
    public class KOTMasterDTO
    {
        public KOTMasterDTO()
        {
            this.detailList = new List<KOTDetailDTO>();
        }
        public int KOTID { get; set; }
        public int SRNumber { get; set; }
        public DateTime KOTDateTime { get; set; }
        public DateTime? KOTDate { get; set; }
        public int Quantity { get; set; }
        public int TableID { get; set; }
        public bool IsBillGenerated { get; set; }
        public bool TobeMaintained { get; set; }

        public List<KOTDetailDTO> detailList { get; set; }

        public Int32 InvoiceNo { get; set; }
        public string TableNumber { get; set; }
        public decimal NetAmount { get; set; }
        public string strKOTDate { get; set; }
        public string strKOTTime { get; set; }
        public decimal qQuantity { get; set; }
        public Boolean IsSelected { get; set; }
        public bool? IsDeleted { get; set; }

    }
}

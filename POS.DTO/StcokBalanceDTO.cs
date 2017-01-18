using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.DTO
{
    public class StcokBalanceDTO
    {
        public Int64 Id { get; set; }
        public String ItemCode { get; set; }
        public String ItemName { get; set; }
        public Decimal OpeningQty { get; set; }
    }
}

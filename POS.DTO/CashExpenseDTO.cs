using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.DTO
{
    public class CashExpenseDTO
    {
        public int Id { get; set; }
        public System.String ExpDetail { get; set; }
        public System.DateTime ExpDate { get; set; }
        public System.String ReceiverName { get; set; }
        public System.Decimal Amount { get; set; }
        public System.Boolean IsDeleted { get; set; }
        
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime UpdatedDate { get; set; }







    }
}

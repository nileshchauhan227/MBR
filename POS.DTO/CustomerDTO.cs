using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.DTO
{
    public class CustomerDTO
    {
        public Int32 CustomerId { get; set; }
        public String CustomerName { get; set; }
        public String CustomerAddress { get; set; }
        public String EmailId { get; set; }
        public String PhoneNo { get; set; }
        public Int32 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32 UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Boolean IsDeleted {get;set;}
    }
}

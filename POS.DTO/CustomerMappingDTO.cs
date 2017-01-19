using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.DTO
{
    public class CustomerMappingDTO
    {
        public System.Int32 MappingId { get; set; }
        public System.Int32 ItemId { get; set; }
        public System.Int32 CustomerId { get; set; }
        public System.Decimal Rate { get; set; }
        public System.String ItemName { get; set; }
        public System.String CustomerName { get; set; }
    }
}

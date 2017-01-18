using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.DTO
{
    public class ConfigurationDTO
    {
        public System.Int32 ConfigurationID { get; set; }
        public System.String ConfigurationKey { get; set; }
        public System.String ConfigurationValue { get; set; }
        public System.String Instruction { get; set; }
        public Nullable<System.Int32> CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Nullable<System.Int32> UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}



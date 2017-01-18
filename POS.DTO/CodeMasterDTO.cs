using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.DTO
{
    public class CodeMasterDTO
    {
        public int ID { get; set; }
        
        public string Name { get; set; }
        public string Code { get; set; }
        public int CodeTypeID { get; set; }
        public string CodeType { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.DTO
{
   public class CompanyMasterDTO
    {
        public int Id { get; set; }
        public System.String CompanyName { get; set; }
        public System.String CompanyAddress { get; set; }
        public System.String PhoneNo { get; set; }
        public System.String MobileNo { get; set; }
        public System.String EmailId { get; set; }
        public System.Boolean IsDeleted { get; set; }

        public System.DateTime CreatedDate { get; set; }
        public System.DateTime UpdatedDate { get; set; }


    }
}

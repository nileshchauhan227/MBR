using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.DTO
{
    public class UserLoginDTO
    {
        public int ID { get; set; }
        public string LoginID { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public int? UserType { get; set; }
    }
}

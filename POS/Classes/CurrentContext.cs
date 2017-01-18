using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.Classes
{
    public class CurrentUser
    {
        public static int ID { get; set; }
        public static string LoginID { get; set; }
        public static string DisplayName { get; set; }
        public static int UserType { get; set; }
    }
}

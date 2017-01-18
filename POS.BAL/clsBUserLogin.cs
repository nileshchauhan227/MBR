using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.DAL;
using POS.DTO;

namespace POS.BAL
{
    public class clsBUserLogin
    {
        public static bool IsUserExist(string LoginID)
        {
            using (clsDUserLogin obj = new clsDUserLogin())
                return obj.IsUserExist(LoginID);
        }
        public static UserLoginDTO GetUserLogin(string LoginID, string Password)
        {
            using (clsDUserLogin obj = new clsDUserLogin())
                return obj.GetUserLogin(LoginID, Password);
        }

        public static bool UpdatePassword(string LoginID, string Password, string newPassword)
        {
            using (clsDUserLogin obj = new clsDUserLogin())
                return obj.UpdatePassword(LoginID, Password, newPassword);
        }
    }
}

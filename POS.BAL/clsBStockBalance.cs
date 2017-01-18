using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.DTO;
using POS.DAL;

namespace POS.BAL
{
    public class clsBStockBalance
    {
        public static List<StcokBalanceDTO> GetAllRecordList()
        {
            using (clsDStockBalance clsDStockBalance = new clsDStockBalance())
            {
                return clsDStockBalance.GetAllRecordList();
            }

        }
        public static Int64 Update(List<StcokBalanceDTO> lst)
        {
            using (clsDStockBalance clsDStockBalance = new clsDStockBalance())
            {
                return clsDStockBalance.Update(lst);
            }
        }

        public static bool IsOpeningExists(DateTime dt)
        {
            using (clsDStockBalance clsDStockBalance = new clsDStockBalance())
            {
                return clsDStockBalance.IsOpeningExists(dt);
            }
        }

        public static bool UpodateStockBalance(string openclose)
        {
            using (clsDStockBalance clsDStockBalance = new clsDStockBalance())
            {
                return clsDStockBalance.UpodateStockBalance(openclose);
            }
        }

        public static bool IsItemExistsInStockBalance(int ItemID)
        {
            using (clsDStockBalance clsDStockBalance = new clsDStockBalance())
            {
                return clsDStockBalance.IsItemExistsInStockBalance(ItemID);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.DTO;
using System.Data.Objects;
using System.Data.SqlClient;

namespace POS.DAL
{
    public class clsDStockBalance : DALBase
    {
        public List<StcokBalanceDTO> GetAllRecordList()
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var res = (from x in context.StockBalance
                           join y in context.ItemMaster on x.ItemID equals y.ItemID
                           select new StcokBalanceDTO
                           {
                               Id = x.ID,
                               ItemCode = x.ItemCode,
                               ItemName = y.ItemName,
                               OpeningQty = x.OpeningQty.HasValue ? x.OpeningQty.Value : 0
                           }
                               ).ToList();

                return res;
            }
        }
        public Int64 Update(List<StcokBalanceDTO> lst)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                Int64 Retrun = 0;
                foreach (StcokBalanceDTO c in lst)
                {
                    StockBalance c1 = context.StockBalance.Where(x => x.ID == c.Id).SingleOrDefault();
                    if (c1 != null)
                    {
                        c1.OpeningQty = c.OpeningQty;
                        c1.UpdatedBy = "1";
                        c1.UpdatedDate = DateTime.Now;
                        context.SaveChanges();
                        Retrun = c1.ID;
                    }
                }
                return Retrun;
            }
        }

        public bool IsOpeningExists(DateTime dt)
        {
            try
            {
                using (POS_RutuEntities context = new POS_RutuEntities())
                {
                    return context.StockBalance.Any(x => EntityFunctions.TruncateTime(x.TransactionDate) == EntityFunctions.TruncateTime(dt));
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpodateStockBalance(string openclose)
        {
            try
            {
                using (POS_RutuEntities context = new POS_RutuEntities())
                {
                    context.UpodateStockBalance(openclose,DateTime.Now);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsItemExistsInStockBalance(int ItemID)
        {
            try
            {
                using (POS_RutuEntities context = new POS_RutuEntities())
                {
                    return context.StockBalance.Any(x => x.ItemID == ItemID);
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void UpdateBarcodeMaster(int itemID, string barcode, short isUnique, POS_RutuEntities context)
        {
            var objitembarcode = context.ItemBarcode.FirstOrDefault(x => x.ItemID == itemID && x.BarCode == barcode);
            if (objitembarcode == null)
            {
                objitembarcode = new ItemBarcode()
                {
                    BarCode = barcode,
                    ItemID = itemID,
                    IsSold = false,
                    Status = isUnique
                };
                context.ItemBarcode.AddObject(objitembarcode);
            }

        }

    }
}

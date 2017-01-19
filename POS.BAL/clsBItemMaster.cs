using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.DTO;
using POS.DAL;

namespace POS.BAL
{
    public class clsBItemMaster
    {
        public static List<ItemMasterDTO> GetItems(string searchText = "", bool? IsActive = null, bool? IsSaleable = null)
        {
            using (clsDItemMaster obj = new clsDItemMaster())
            {
                return obj.GetItems(searchText, IsActive, IsSaleable);
            }
        }
        public static List<ItemMasterDTO> GetItemsForBilling()
        {
            using (clsDItemMaster obj = new clsDItemMaster())
            {
                return obj.GetItemsForBilling();
            }
        }
        public static List<ItemMasterDTO> GetItemsForCustomer()
        {
            using (clsDItemMaster obj = new clsDItemMaster())
            {
                return obj.GetItemsForCustomer();
            }
        }
        public static ItemMasterDTO GetItems(int ItemID)
        {
            using (clsDItemMaster obj = new clsDItemMaster())
            {
                return obj.GetItems(ItemID);
            }
        }
        public static int Add(ItemMasterDTO objtoAdd)
        {
            using (clsDItemMaster obj = new clsDItemMaster())
            {
                return obj.Add(objtoAdd);
            }
        }
        public static int Update(ItemMasterDTO objtoAdd)
        {
            using (clsDItemMaster obj = new clsDItemMaster())
            {
                return obj.Update(objtoAdd);
            }
        }
         public static bool Delete(int ItemID)
         {
             using (clsDItemMaster obj = new clsDItemMaster())
             {
                 return obj.Delete(ItemID);
             }
         }

         public static bool isExistCode(string code, int itemID)
         {
             using (clsDItemMaster obj = new clsDItemMaster())
             {
                 return obj.isExistCode(code, itemID);
             }
         }

         public static ItemMasterDTO GetItemByCode(string ItemCode)
         {
             using (clsDItemMaster obj = new clsDItemMaster())
             {
                 return obj.GetItemByCode(ItemCode);
             }

         }
         public static ItemMasterDTO GetItemByName(string itemName)
         {
             using (clsDItemMaster obj = new clsDItemMaster())
             {
                 return obj.GetItemByName(itemName);
             }
         }
         //public static List<ItemMasterDTO> ItemwiseReport()
         //{
         //    using (clsDItemMaster obj = new clsDItemMaster())
         //    {
         //        return obj.ItemwiseReport();
         //    }

         //}



      
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.DTO;

namespace POS.DAL
{
    public class clsDItemMaster : DALBase
    {
        public List<ItemMasterDTO> GetItems(string serachText = "", bool? IsActive = null, bool? IsSaleable = null)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var query = (from x in context.ItemMaster
                             join g in context.CodeMaster on x.GroupID equals g.ID
                             join u in context.CodeMaster on x.UnitID equals u.ID
                             join f in context.CodeMaster on x.FirmId equals f.ID
                             where
                             (
                             x.ItemCode.ToLower().Contains(serachText == "" ? x.ItemCode : serachText.ToLower())
                             || x.ItemName.ToLower().Contains(serachText == "" ? x.ItemName : serachText.ToLower())
                             )
                             && (x.IsActive ?? false) == (IsActive == true ? x.IsActive : x.IsActive)
                             && x.IsSaleable == (IsSaleable.HasValue ? IsSaleable.Value : x.IsSaleable)
                             select new ItemMasterDTO
                             {
                                 ItemID = x.ItemID,
                                 //FirmId = x.FirmId.HasValue ? x.FirmId.Value : 0,
                                 ItemCode = x.ItemCode,
                                 ItemName = x.ItemName,
                                 GroupID = x.GroupID,
                                 UnitID = x.UnitID,
                                 Discount = x.Discount,
                                 Rate = x.Rate,
                                 OtherDiscount = x.OtherDiscount,
                                 ServiceTax = x.ServiceTax ?? false,
                                 IsActive = x.IsActive,
                                 Group = g.Name,
                                 unit = u.Name,
                                 IsSaleable = x.IsSaleable.HasValue ? x.IsSaleable.Value : false,
                                 IsUniqueSerialNumber = x.IsUniqueSerialNumber,
                                 OpeningBalance = x.OpeningBalance
                             }).ToList();
                return query;
            }
        }
        public List<ItemMasterDTO> GetItemsForBilling()
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var query = (from x in context.ItemMaster
                             join g in context.CodeMaster on x.GroupID equals g.ID
                             join u in context.CodeMaster on x.UnitID equals u.ID
                             join f in context.CodeMaster on x.FirmId equals f.ID
                             join c in context.ItemBarcode on x.ItemID equals c.ItemID
                             where (x.IsActive ?? true) == true
                             && (x.IsSaleable ?? false) == true
                             && (c.IsSold ?? false) == false
                             select new ItemMasterDTO
                             {
                                 ItemID = x.ItemID,
                                 //FirmId = x.FirmId.HasValue ? x.FirmId.Value : 0,
                                 ItemCode = c.BarCode,
                                 ItemName = x.ItemName,
                                 GroupID = x.GroupID,
                                 UnitID = x.UnitID,
                                 Discount = x.Discount,
                                 Rate = x.Rate,
                                 OtherDiscount = x.OtherDiscount,
                                 ServiceTax = x.ServiceTax ?? false,
                                 IsActive = x.IsActive,
                                 Group = g.Name,
                                 unit = u.Name,
                                 IsSaleable = x.IsSaleable.HasValue ? x.IsSaleable.Value : false,
                                 IsUniqueSerialNumber = x.IsUniqueSerialNumber,
                                 OpeningBalance = x.OpeningBalance
                             }).ToList();
                return query;
            }
        }

        public ItemMasterDTO GetItems(int ItemID)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var query = (from x in context.ItemMaster
                             join g in context.CodeMaster on x.GroupID equals g.ID
                             join u in context.CodeMaster on x.UnitID equals u.ID
                             join f in context.CodeMaster on x.FirmId equals f.ID
                             where x.ItemID == ItemID
                             select new ItemMasterDTO
                             {
                                 ItemID = x.ItemID,
                                 FirmId = x.FirmId.HasValue ? x.FirmId.Value : 0,
                                 ItemCode = x.ItemCode,
                                 ItemName = x.ItemName,
                                 GroupID = x.GroupID,
                                 UnitID = x.UnitID,
                                 Discount = x.Discount,
                                 Rate = x.Rate,
                                 OtherDiscount = x.OtherDiscount,
                                 ServiceTax = x.ServiceTax.HasValue ? x.ServiceTax.Value : false,
                                 IsActive = x.IsActive,
                                 Group = g.Name,
                                 unit = u.Name,
                                 IsSaleable = x.IsSaleable.HasValue ? x.IsSaleable.Value : false,
                                 IsUniqueSerialNumber = x.IsUniqueSerialNumber,
                                 OpeningBalance = x.OpeningBalance
                             }).SingleOrDefault();
                return query;
            }
        }
        public int Add(ItemMasterDTO objtoAdd)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var itemMaster = new ItemMaster();
                itemMaster.ItemID = objtoAdd.ItemID;
                itemMaster.FirmId = objtoAdd.FirmId;
                itemMaster.ItemCode = objtoAdd.ItemCode;
                itemMaster.ItemName = objtoAdd.ItemName;
                itemMaster.GroupID = objtoAdd.GroupID;
                itemMaster.UnitID = objtoAdd.UnitID;
                itemMaster.Discount = objtoAdd.Discount;
                itemMaster.Rate = objtoAdd.Rate;
                itemMaster.OtherDiscount = objtoAdd.OtherDiscount;
                itemMaster.IsActive = objtoAdd.IsActive;
                itemMaster.ServiceTax = objtoAdd.ServiceTax;
                itemMaster.IsSaleable = objtoAdd.IsSaleable;
                itemMaster.IsUniqueSerialNumber = objtoAdd.IsUniqueSerialNumber;
                itemMaster.OpeningBalance = objtoAdd.OpeningBalance;
                context.ItemMaster.AddObject(itemMaster);
                context.SaveChanges();
                clsDStockBalance objStockBalance = new clsDStockBalance();
                objStockBalance.UpdateBarcodeMaster(itemMaster.ItemID, objtoAdd.ItemCode, ((objtoAdd.IsUniqueSerialNumber ?? false) ? (short)1 : (short)0), context);
                if (objtoAdd.barcodes != null)
                    foreach (var item in objtoAdd.barcodes)
                    {
                        context.ItemBarcode.AddObject(new ItemBarcode { BarCode = item, ItemID = itemMaster.ItemID, IsSold = false });
                    }

                context.SaveChanges();
                return 1;
            }
        }
        public int Update(ItemMasterDTO objtoAdd)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                clsDStockBalance objStockBalance = new clsDStockBalance();
                var itemMaster = context.ItemMaster.FirstOrDefault(x => x.ItemID == objtoAdd.ItemID);
                if (itemMaster != null)
                {
                    itemMaster.ItemCode = objtoAdd.ItemCode;
                    itemMaster.ItemName = objtoAdd.ItemName;
                    itemMaster.GroupID = objtoAdd.GroupID;
                    itemMaster.FirmId = objtoAdd.FirmId;
                    itemMaster.UnitID = objtoAdd.UnitID;
                    itemMaster.Discount = objtoAdd.Discount;
                    itemMaster.Rate = objtoAdd.Rate;
                    itemMaster.OtherDiscount = objtoAdd.OtherDiscount;
                    itemMaster.ServiceTax = objtoAdd.ServiceTax;
                    itemMaster.IsActive = objtoAdd.IsActive;
                    itemMaster.IsSaleable = objtoAdd.IsSaleable;
                    itemMaster.IsUniqueSerialNumber = objtoAdd.IsUniqueSerialNumber;
                    itemMaster.OpeningBalance = objtoAdd.OpeningBalance;
                }
                objStockBalance.UpdateBarcodeMaster(objtoAdd.ItemID, objtoAdd.ItemCode, ((objtoAdd.IsUniqueSerialNumber ?? false) ? (short)1 : (short)0), context);
                return context.SaveChanges();
            }
        }
        public bool Delete(int ItemID)
        {
            try
            {
                using (POS_RutuEntities context = new POS_RutuEntities())
                {
                    var objToDelete = context.ItemMaster.FirstOrDefault(x => x.ItemID == ItemID);
                    var objItembarcode = context.ItemBarcode.Where(x => x.ItemID == ItemID).ToList();
                    if (objToDelete != null)
                    {
                        foreach (var barcode in objItembarcode)
                        {
                            context.ItemBarcode.DeleteObject(barcode);
                        }
                        context.ItemMaster.DeleteObject(objToDelete);                        
                        context.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool isExistCode(string code, int id)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                return (context.ItemMaster.Any(x => x.ItemCode == code && x.ItemID != id));
            }
        }

        public ItemMasterDTO GetItemByCode(string ItemCode)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var query = (from x in context.ItemMaster
                             where x.ItemCode == ItemCode
                             select new ItemMasterDTO
                             {
                                 ItemID = x.ItemID,
                                 ItemCode = x.ItemCode,
                                 ItemName = x.ItemName,
                                 GroupID = x.GroupID,
                                 UnitID = x.UnitID,
                                 Discount = x.Discount,
                                 Rate = x.Rate,
                                 OtherDiscount = x.OtherDiscount,
                                 IsActive = x.IsActive,
                                 Group = x.CodeMaster.Name,
                                 unit = x.CodeMaster.Name,
                                 IsSaleable = x.IsSaleable ?? false,
                                 IsUniqueSerialNumber = x.IsUniqueSerialNumber,
                                 OpeningBalance = x.OpeningBalance,
                             }).SingleOrDefault();
                return query;
            }
        }

        public ItemMasterDTO GetItemByName(string itemName)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var query = (from x in context.ItemMaster
                             where x.ItemName == itemName
                             select new ItemMasterDTO
                             {
                                 ItemID = x.ItemID,
                                 ItemCode = x.ItemCode,
                                 ItemName = x.ItemName,
                                 GroupID = x.GroupID,
                                 UnitID = x.UnitID,
                                 Discount = x.Discount,
                                 Rate = x.Rate,
                                 OtherDiscount = x.OtherDiscount,
                                 IsActive = x.IsActive,
                                 Group = x.CodeMaster.Name,
                                 unit = x.CodeMaster.Name,
                                 IsSaleable = x.IsSaleable ?? false,
                                 IsUniqueSerialNumber = x.IsUniqueSerialNumber,
                                 OpeningBalance = x.OpeningBalance,
                             }).SingleOrDefault();
                return query;
            }
        }
    }
}

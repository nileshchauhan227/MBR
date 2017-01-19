using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.DTO;
using System.Data.Objects;

namespace POS.DAL
{
    public class clsDBill : DALBase
    {
        public int GetNextInvoiceNumber()
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var model = context.BillMaster.OrderByDescending(x => x.Rnumber).FirstOrDefault();
                if (model != null)
                {
                    var val = context.BillMaster.Max(x => x.Rnumber);
                    return val + 1;
                }
                else
                {
                    return 1;
                }

            }
        }
        public int AddBill(BillMasterDTO objToSave)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                BillMaster objBill = new BillMaster();
                objBill.Series = objToSave.Series;
                objBill.Rnumber = objToSave.Rnumber;
                objBill.InvoiceDate = objToSave.InvoiceDate;
                if (!string.IsNullOrWhiteSpace(objToSave.Party))
                    objBill.Party = objToSave.Party;
                if (!string.IsNullOrWhiteSpace(objToSave.PaymentMode))
                    objBill.PaymentMode = objToSave.PaymentMode;
                if(objToSave.TableID > 0)
                    objBill.TableID = objToSave.TableID;
                if (objToSave.WaiterID > 0)
                    objBill.WaiterID = objToSave.WaiterID;
                objBill.MobileNo = objToSave.MobileNo;
                objBill.NoOfItems = objToSave.NoOfItems;
                objBill.GrossAmount = objToSave.GrossAmount;
                objBill.DiscountPercentage = objToSave.DiscountPercentage;
                objBill.Discount = objToSave.Discount;
                objBill.DiscountReason = objToSave.DiscountReason;
                objBill.Tax = objToSave.Tax;
                objBill.NetAmount = objToSave.NetAmount;
                if(objBill.NetAmount > 0)
                    objBill.CashReceived = objToSave.CashReceived;
                objBill.RoundOff = objToSave.RoundOff;
                objBill.IsPrinted = objToSave.IsPrinted;
                objBill.IsDeleted = objToSave.IsDeleted;
                if (objToSave.CustomerId > 0)
                    objBill.CustomerId = objToSave.CustomerId;
                if (objToSave.AdditionalPercentage > 0)
                    objBill.AdditionalPercentage = objToSave.AdditionalPercentage;
                if (objToSave.AdditionalTax > 0)
                    objBill.AdditionalTax = objToSave.AdditionalTax;
                if (objToSave.BillTypeId > 0)
                    objBill.BillTypeId = objToSave.BillTypeId;
                if (objToSave.NarrationId > 0)
                    objBill.NarrationId = objToSave.NarrationId;
                if (!string.IsNullOrWhiteSpace(objToSave.ChallanNo))
                    objBill.ChallanNo = objToSave.ChallanNo;

                foreach (BillDetailsDTO item in objToSave.details)
                {
                    objBill.BillDetails.Add(new BillDetails() { BillID = objBill.BillID, ItemID = item.ItemID, Quantity = item.Quantity, Rate = item.Rate, Discount = item.Discount, Amount = item.Amount, Tax = item.Tax, IsDeleted = item.IsDeleted });

                    var objitem = context.ItemMaster.Where(x => x.ItemID == item.ItemID).FirstOrDefault();
                    objitem.OpeningBalance = (objitem.OpeningBalance ?? 0) - item.Quantity;

                }
                context.BillMaster.AddObject(objBill);
                context.SaveChanges();

                if (objToSave.KotIDs != null)
                {
                    foreach (var kotid in objToSave.KotIDs)
                    {
                        KOTMaster objKot = context.KOTMaster.FirstOrDefault(x => x.KOTID == kotid);
                        if (objKot != null && objKot.KOTID == kotid)
                        {
                            objKot.IsBillGenerated = true;
                            objKot.BillID = objBill.BillID;
                        }
                    }
                }
                context.SaveChanges();
                return objBill.BillID;
            }
        }
        public BillMasterDTO GetBillDetail(int currentRunningNumber, string fetchRecord)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                BillMaster obj = null;
                switch (fetchRecord)
                {
                    case "Previous":
                        obj = context.BillMaster.Where(x => x.Rnumber < currentRunningNumber && (x.IsDeleted ?? false) == false).OrderByDescending(x => x.Rnumber).FirstOrDefault();
                        break;
                    case "Next":
                        obj = context.BillMaster.Where(x => x.Rnumber > currentRunningNumber && (x.IsDeleted ?? false) == false).OrderBy(x => x.Rnumber).FirstOrDefault();
                        break;
                    case "Last":
                        obj = context.BillMaster.Where(x => (x.IsDeleted ?? false) == false).OrderByDescending(x => x.Rnumber).FirstOrDefault();
                        break;
                    default:
                        obj = new BillMaster();
                        break;
                }

                if (obj != null && obj.Rnumber > 0)
                {
                    var res = new BillMasterDTO()
                     {
                         BillID = obj.BillID,
                         Series = obj.Series,
                         Rnumber = obj.Rnumber,
                         InvoiceDate = obj.InvoiceDate,
                         Party = obj.Party,
                         PaymentMode =  obj.PaymentMode,
                         TableID = obj.TableID.HasValue ? obj.TableID.Value : 0,
                         WaiterID = obj.WaiterID ?? 0,
                         MobileNo = obj.MobileNo,
                         NoOfItems = obj.NoOfItems.HasValue? obj.NoOfItems.Value : 0,
                         GrossAmount = obj.GrossAmount.Value,
                         DiscountPercentage = obj.DiscountPercentage.Value,
                         Discount = obj.Discount.HasValue ? obj.Discount.Value: 0,
                         DiscountReason = obj.DiscountReason,
                         Tax = obj.Tax,
                         NetAmount = obj.NetAmount.Value,
                         CashReceived = obj.CashReceived.HasValue? obj.CashReceived.Value : 0,
                         RoundOff = obj.RoundOff.Value,
                         IsPrinted = obj.IsPrinted.Value,
                         CustomerId = obj.CustomerId.HasValue ? obj.CustomerId.Value : 0,
                         BillTypeId = obj.BillTypeId.HasValue ? obj.BillTypeId.Value : 0,
                         AdditionalTax = obj.AdditionalTax.HasValue ? obj.AdditionalTax.Value : 0,
                         AdditionalPercentage = obj.AdditionalPercentage.HasValue ? obj.AdditionalPercentage.Value : 0,
                         ChallanNo =  obj.ChallanNo,
                         NarrationId = obj.NarrationId.HasValue ? obj.NarrationId.Value : 0
                     };
                    foreach (var item in obj.BillDetails)
                    {
                        res.details.Add(new BillDetailsDTO() 
                        { 
                            Quantity = item.Quantity ?? 0, 
                            Rate = item.Rate ?? 0, 
                            Discount = item.Discount ?? 0, 
                            Amount = item.Amount ?? 0, 
                            ItemID = item.ItemID ?? 0, 
                            BillDetailID = item.BillDetailID, 
                            BillID = item.BillID, 
                            ItemCode = item.ItemMaster.ItemCode, 
                            ItemName = item.ItemMaster.ItemName, 
                            Tax = item.Tax,
                            Unit = (from x in context.ItemMaster
                                           join u in context.CodeMaster on x.UnitID equals u.ID
                                           where x.ItemID == item.ItemID
                                           select u).FirstOrDefault().Name,
                        });
                    }

                    return res;
                }
                else
                    return new BillMasterDTO();
            }
        }
        public bool Delete(int BillID)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {

                var obj = context.BillMaster.FirstOrDefault(x => x.Rnumber == BillID);
                var res = context.BillDetails.Where(x => x.BillID == obj.BillID).ToList();

                if (res.Count() != 0)
                {
                    foreach (var item in res)
                    {
                        var objdetail = context.BillDetails.FirstOrDefault(x => x.BillDetailID == item.BillDetailID);
                        objdetail.IsDeleted = true;

                        var objitem = context.ItemMaster.Where(x => x.ItemID == item.ItemID).FirstOrDefault();
                        objitem.OpeningBalance = (objitem.OpeningBalance ?? 0) + item.Quantity;
                    }
                }
                obj.IsDeleted = true;
                var kots = context.KOTMaster.Where(x => x.BillID == obj.BillID).ToList();
                foreach (var item in kots)
                {
                    //item.BillID = null;
                    //item.IsBillGenerated = false;
                    item.IsDeleted = true;
                }
                context.SaveChanges();
                return true;
            }
        }




        public bool UpdatePrintFlagByRunningNumber(int RunningNumber)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var obj = context.BillMaster.FirstOrDefault(x => x.Rnumber == RunningNumber);
                obj.IsPrinted = true;
                context.SaveChanges();
                return true;
            }
        }

        public object Update(BillMasterDTO objToSave)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var objBill = context.BillMaster.FirstOrDefault(x => x.BillID == objToSave.BillID);
                if (objBill != null)
                {
                    objBill.Party = objToSave.Party;
                    objBill.PaymentMode = objToSave.PaymentMode;
                    objBill.TableID = objToSave.TableID;
                    if (objToSave.WaiterID > 0)
                        objBill.WaiterID = objToSave.WaiterID;
                    objBill.MobileNo = objToSave.MobileNo;
                    objBill.NoOfItems = objToSave.NoOfItems;
                    objBill.GrossAmount = objToSave.GrossAmount;
                    objBill.DiscountPercentage = objToSave.DiscountPercentage;
                    objBill.Discount = objToSave.Discount;
                    objBill.DiscountReason = objToSave.DiscountReason;
                    objBill.Tax = objToSave.Tax;
                    objBill.NetAmount = objToSave.NetAmount;
                    objBill.CashReceived = objToSave.CashReceived;
                    objBill.RoundOff = objToSave.RoundOff;
                    objBill.IsPrinted = objToSave.IsPrinted;
                }
                foreach (BillDetailsDTO item in objToSave.details)
                {
                    if (item.BillDetailID == 0)
                    {
                        objBill.BillDetails.Add(new BillDetails() { BillID = objBill.BillID, ItemID = item.ItemID, Quantity = item.Quantity, Rate = item.Rate, Discount = item.Discount, Amount = item.Amount, Tax = item.Tax });
                    }
                }
                context.BillMaster.AddObject(objBill);
                context.SaveChanges();

                if (objToSave.KotIDs != null)
                {
                    foreach (var kotid in objToSave.KotIDs)
                    {
                        KOTMaster objKot = context.KOTMaster.FirstOrDefault(x => x.KOTID == kotid);
                        if (objKot != null && objKot.KOTID == kotid)
                        {
                            objKot.IsBillGenerated = true;
                            objKot.BillID = objBill.BillID;
                        }
                    }
                }
                context.SaveChanges();
                return objBill.BillID;
            }
        }

        public List<BillMasterDTO> GetPendingPrintBill(DateTime dateTime)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var res = (from obj in context.BillMaster
                           join t in context.CodeMaster on obj.TableID equals t.ID into tables
                           from t in tables.DefaultIfEmpty()
                           where obj.IsPrinted == false && EntityFunctions.TruncateTime(dateTime) == EntityFunctions.TruncateTime(obj.InvoiceDate)
                           select new BillMasterDTO
                           {
                               BillID = obj.BillID,

                               //Series = obj.Series,
                               //Rnumber = obj.Rnumber,
                               //InvoiceDate = obj.InvoiceDate,
                               //Party = obj.Party,
                               //PaymentMode = obj.PaymentMode,
                               //TableID = obj.TableID.Value,
                               TableName = t.Name,
                               //WaiterID = obj.WaiterID ?? 0,
                               //MobileNo = obj.MobileNo,
                               //NoOfItems = obj.NoOfItems.Value,
                               //GrossAmount = obj.GrossAmount.Value,
                               //DiscountPercentage = obj.DiscountPercentage.Value,
                               //Discount = obj.Discount.Value,
                               //DiscountReason = obj.DiscountReason,
                               //Tax = obj.Tax,
                               NetAmount = obj.NetAmount.Value,
                               //CashReceived = obj.CashReceived.Value,
                               //RoundOff = obj.RoundOff.Value,
                               //IsPrinted = obj.IsPrinted.Value
                           }).ToList();
                return res;
            }
        }
    }
}

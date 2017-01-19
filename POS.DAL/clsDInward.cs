using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.DTO;
using POS.DTO.Interface;

namespace POS.DAL
{
    public class clsDInward : DALBase, IManageCrudOperation<PurchaseMasterDTO>, IManageNextPreFirstLast<PurchaseMasterDTO>
    {
        public List<PurchaseMasterDTO> GetAll()
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                return (from item in context.PurchaseMaster
                        where item.IsDeleted == false
                        select new PurchaseMasterDTO
                        {
                            PurchaseID = item.PurchaseID,
                            PONumber = item.PONumber,
                            PODate = item.PODate,
                            InvoiceNumber = item.InvoiceNumber,
                            InvoiceDate = item.InvoiceDate,
                            ReceivedBy = item.ReceivedBy,
                            Remarks = item.Remarks,
                            InvoiceAmount = item.InvoiceAmount,
                            TransactionType = item.TransactionType,
                            Career = item.Career,
                            VendorID = item.VendorID,
                            IsDeleted = item.IsDeleted,
                            CreatedDate = item.CreatedDate,
                            CreatedBy = item.CreatedBy,
                            UpdatedDate = item.UpdatedDate,
                            UpdatedBy = item.UpdatedBy,
                            VendorName = item.CompanyMaster.CompanyName
                        }).ToList();
            }
        }

        public long Create(PurchaseMasterDTO obj)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                PurchaseMaster objMaster = new PurchaseMaster
                {
                    PurchaseID = obj.PurchaseID,
                    PONumber = obj.PONumber,
                    PODate = obj.PODate,
                    InvoiceNumber = obj.InvoiceNumber,
                    InvoiceDate = obj.InvoiceDate,
                    ReceivedBy = obj.ReceivedBy,
                    Remarks = obj.Remarks,
                    InvoiceAmount = obj.InvoiceAmount,
                    TransactionType = obj.TransactionType,
                    Career = obj.Career,
                    VendorID = obj.VendorID,
                    IsDeleted = obj.IsDeleted,
                    CreatedDate = obj.CreatedDate,
                    CreatedBy = obj.CreatedBy,
                    UpdatedDate = obj.UpdatedDate,
                    UpdatedBy = obj.UpdatedBy,

                };

                foreach (var item in obj.PurchaseDetailList)
                {
                    var detail = new PurchaseDetail
                    {
                        PurchaseDetailID = item.PurchaseDetailID,
                        PurchaseID = item.PurchaseID,
                        ItemID = item.ItemID,
                        ItemCode = item.ItemCode,
                        Description = item.Description,
                        Quantity = item.Quantity,
                        IsDeleted = item.IsDeleted,
                        PricePerItem = item.PricePerItem,
                        MRPPerItem = item.MRPPerItem,
                    };

                    if (item.barcodes != null)
                        foreach (string barcode in item.barcodes)
                        {
                            detail.ItemBarcode.Add(new ItemBarcode { ItemID = item.ItemID, BarCode = barcode, IsSold = false });
                        }
                    objMaster.PurchaseDetail.Add(detail);
                    var objitem = context.ItemMaster.Where(x => x.ItemID == item.ItemID).FirstOrDefault();
                    objitem.OpeningBalance = (objitem.OpeningBalance ?? 0) + item.Quantity;
                }

                context.PurchaseMaster.AddObject(objMaster);
                context.SaveChanges();
                return objMaster.PurchaseID;
            }
        }

        public bool Update(PurchaseMasterDTO obj)
        {
            clsDStockBalance objStockBalance = new clsDStockBalance();
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var objPurchaseMaster = context.PurchaseMaster.FirstOrDefault(x => x.PurchaseID == obj.PurchaseID);
                objPurchaseMaster.PurchaseID = obj.PurchaseID;
                objPurchaseMaster.PONumber = obj.PONumber;
                objPurchaseMaster.PODate = obj.PODate;
                objPurchaseMaster.InvoiceNumber = obj.InvoiceNumber;
                objPurchaseMaster.InvoiceDate = obj.InvoiceDate;
                objPurchaseMaster.ReceivedBy = obj.ReceivedBy;
                objPurchaseMaster.Remarks = obj.Remarks;
                objPurchaseMaster.InvoiceAmount = obj.InvoiceAmount;
                objPurchaseMaster.TransactionType = obj.TransactionType;
                objPurchaseMaster.Career = obj.Career;
                objPurchaseMaster.VendorID = obj.VendorID;
                objPurchaseMaster.IsDeleted = obj.IsDeleted;
                //objPurchaseMaster.CreatedDate = obj.CreatedDate;
                //objPurchaseMaster.CreatedBy = obj.CreatedBy;
                objPurchaseMaster.UpdatedDate = obj.UpdatedDate;

                var tobeDelete = objPurchaseMaster.PurchaseDetail.Where(o => !obj.PurchaseDetailList.Select(x => x.PurchaseDetailID).Contains(o.PurchaseDetailID)).ToList();

                foreach (var item in tobeDelete)
                {
                    item.IsDeleted = true;
                    var objitem = context.ItemMaster.Where(x => x.ItemID == item.ItemID).FirstOrDefault();
                    objitem.OpeningBalance = (objitem.OpeningBalance ?? 0) - item.Quantity;
                }
                foreach (var item in obj.PurchaseDetailList)
                {
                    if (item.PurchaseDetailID == 0)//Added new
                    {
                        objPurchaseMaster.PurchaseDetail.Add(new PurchaseDetail
                        {
                            PurchaseDetailID = item.PurchaseDetailID,
                            PurchaseID = item.PurchaseID,
                            ItemID = item.ItemID,
                            ItemCode = item.ItemCode,
                            Description = item.Description,
                            Quantity = item.Quantity,
                            IsDeleted = item.IsDeleted,
                            PricePerItem = item.PricePerItem,
                            MRPPerItem = item.MRPPerItem,
                        });
                        var objitem = context.ItemMaster.Where(x => x.ItemID == item.ItemID).FirstOrDefault();
                        objitem.OpeningBalance = (objitem.OpeningBalance ?? 0) + item.Quantity;
                    }
                    else
                    {
                        var detailitem = objPurchaseMaster.PurchaseDetail.FirstOrDefault(x => x.PurchaseDetailID == item.PurchaseDetailID && x.IsDeleted == false);
                        decimal oldqty = detailitem.Quantity;
                        if (detailitem != null) //update
                        {
                            //detailitem.PurchaseDetailID = item.PurchaseDetailID;
                            //detailitem.PurchaseID = item.PurchaseID;
                            detailitem.ItemID = item.ItemID;
                            detailitem.ItemCode = item.ItemCode;
                            detailitem.Description = item.Description;
                            detailitem.Quantity = item.Quantity;
                            detailitem.IsDeleted = item.IsDeleted;
                            detailitem.PricePerItem = item.PricePerItem;
                            detailitem.MRPPerItem = item.MRPPerItem;
                        }
                        var objitem = context.ItemMaster.Where(x => x.ItemID == item.ItemID).FirstOrDefault();
                        objitem.OpeningBalance = (objitem.OpeningBalance ?? 0) - oldqty + item.Quantity;
                    }
                    objStockBalance.UpdateBarcodeMaster(item.ItemID, item.ItemCode, 0, context);
                }
                context.SaveChanges();
            }

            return true;
        }

        public bool Delete(long key)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var obj = context.PurchaseMaster.FirstOrDefault(x => x.PurchaseID == key);
                foreach (var item in obj.PurchaseDetail)
                {
                    item.IsDeleted = true;
                    var objitem = context.ItemMaster.Where(x => x.ItemID == item.ItemID).FirstOrDefault();
                    objitem.OpeningBalance = (objitem.OpeningBalance ?? 0) - item.Quantity;
                }
                obj.IsDeleted = true;
                context.SaveChanges();
                return true;
            }
        }

        public PurchaseMasterDTO GetByID(long key)
        {
            return GetRecord(key, "Current");
        }

        public PurchaseMasterDTO GetPrevious(long key)
        {
            return GetRecord(key, "Previous");
        }

        public PurchaseMasterDTO GetNext(long key)
        {
            return GetRecord(key, "Next");
        }

        public PurchaseMasterDTO GetFirst(long key)
        {
            return GetRecord(key, "First");
        }

        public PurchaseMasterDTO GetLast(long key)
        {
            return GetRecord(key, "Last");
        }

        private PurchaseMasterDTO GetRecord(long currentRunningNumber, string fetchRecord)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                PurchaseMaster item = null;
                switch (fetchRecord)
                {
                    case "Previous":
                        item = context.PurchaseMaster.Where(x => x.PurchaseID < currentRunningNumber && x.IsDeleted == false).OrderByDescending(x => x.PurchaseID).FirstOrDefault();
                        break;
                    case "Next":
                        item = context.PurchaseMaster.Where(x => x.PurchaseID > currentRunningNumber && x.IsDeleted == false).OrderBy(x => x.PurchaseID).FirstOrDefault();
                        break;
                    case "Last":
                        item = context.PurchaseMaster.LastOrDefault();
                        break;
                    case "First":
                        item = context.PurchaseMaster.FirstOrDefault();
                        break;
                    case "Current":
                        item = context.PurchaseMaster.FirstOrDefault(c => c.PurchaseID == currentRunningNumber);
                        break;
                    default:
                        item = new PurchaseMaster();
                        break;
                }
                if (item != null && item.PurchaseID > 0)
                {
                    var res = new PurchaseMasterDTO()
                    {
                        PurchaseID = item.PurchaseID,
                        PONumber = item.PONumber,
                        PODate = item.PODate,
                        InvoiceNumber = item.InvoiceNumber,
                        InvoiceDate = item.InvoiceDate,
                        ReceivedBy = item.ReceivedBy,
                        Remarks = item.Remarks,
                        InvoiceAmount = item.InvoiceAmount,
                        TransactionType = item.TransactionType,
                        Career = item.Career,
                        VendorID = item.VendorID,
                        IsDeleted = item.IsDeleted,
                        CreatedDate = item.CreatedDate,
                        CreatedBy = item.CreatedBy,
                        UpdatedDate = item.UpdatedDate,
                        UpdatedBy = item.UpdatedBy,
                    };
                    foreach (var detail in item.PurchaseDetail)
                    {
                        res.PurchaseDetailList.Add(new PurchaseDetailDTO()
                        {
                            PurchaseDetailID = detail.PurchaseDetailID,
                            PurchaseID = detail.PurchaseID,
                            ItemID = detail.ItemID,
                            Description = detail.Description,
                            Quantity = detail.Quantity,
                            IsDeleted = detail.IsDeleted,
                            PricePerItem = detail.PricePerItem,
                            MRPPerItem = detail.MRPPerItem,

                            ItemCode = detail.ItemCode,
                            ItemName = detail.ItemMaster.ItemName,
                            Unit = (from x in context.ItemMaster
                                    join u in context.CodeMaster on x.UnitID equals u.ID
                                    where x.ItemID == detail.ItemID
                                    select u).FirstOrDefault().Name,
                        });
                    }
                    return res;
                }
                else
                    return new PurchaseMasterDTO();

            }
        }

        public int GetNextInwardNumber()
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                return context.PurchaseMaster.Count() + 1;
            }
        }
    }
}

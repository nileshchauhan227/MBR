using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.DTO.Interface;
using POS.DTO;

namespace POS.DAL
{
    public class clsDPurchaseReturn : DALBase, IManageCrudOperation<PurchaseReturnMasterDTO>, IManageNextPreFirstLast<PurchaseReturnMasterDTO>
    {
        public List<PurchaseReturnMasterDTO> GetAll()
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                return (from item in context.PurchaseReturnMaster
                        join pm in context.PurchaseMaster on item.PurchaseID equals pm.PurchaseID
                        join vm in context.CompanyMaster on pm.VendorID equals vm.Id
                        where item.IsDeleted == false
                        select new PurchaseReturnMasterDTO
                        {
                            ID = item.ID,
                            InvoiceNumber = pm.InvoiceNumber,
                            InvoiceDate = pm.InvoiceDate,
                            ReturnDate = item.ReturnDate,
                            PurchaseID = item.PurchaseID,
                            ReasonForReturn = item.ReasonForReturn,
                            CreatedBy = item.CreatedBy,
                            CreatedDate = item.CreatedDate,
                            UpdatedBy = item.UpdatedBy,
                            UpdatedDate = item.UpdatedDate,
                            IsDeleted = item.IsDeleted,
                            VendorName = vm.CompanyName,
                        }).ToList();
            }
        }
        public long Create(PurchaseReturnMasterDTO obj)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                PurchaseReturnMaster objMaster = new PurchaseReturnMaster
                {
                    //  ID = obj.ID,
                    ReturnDate = obj.ReturnDate,
                    PurchaseID = obj.PurchaseID,
                    ReasonForReturn = obj.ReasonForReturn,
                    CreatedBy = obj.CreatedBy,
                    CreatedDate = obj.CreatedDate,
                    UpdatedBy = obj.UpdatedBy,
                    UpdatedDate = obj.UpdatedDate,
                    IsDeleted = obj.IsDeleted,
                };

                foreach (var item in obj.PurchaseReturnDetailList)
                {
                    objMaster.PurchaseReturnDetail.Add(new PurchaseReturnDetail
                    {
                        ID = item.ID,
                        PurchaseReturnMasterID = item.PurchaseReturnMasterID,
                        ItemID = item.ItemID,
                        ItemCode = item.ItemCode,
                        Qty = item.Qty,
                        IsDeleted = item.IsDeleted
                    });

                    var objitem = context.ItemMaster.Where(x => x.ItemID == item.ItemID).FirstOrDefault();
                    objitem.OpeningBalance = (objitem.OpeningBalance ?? 0) - item.Qty;
                }
                context.PurchaseReturnMaster.AddObject(objMaster);
                context.SaveChanges();
                return objMaster.ID;
            }
        }
        public bool Update(PurchaseReturnMasterDTO obj)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var objPurchaseReturnMaster = context.PurchaseReturnMaster.FirstOrDefault(x => x.ID == obj.ID);
                objPurchaseReturnMaster.ReturnDate = obj.ReturnDate;
                objPurchaseReturnMaster.PurchaseID = obj.PurchaseID;
                objPurchaseReturnMaster.ReasonForReturn = obj.ReasonForReturn;
                objPurchaseReturnMaster.CreatedBy = obj.CreatedBy;
                //objPurchaseReturnMaster.CreatedDate = obj.CreatedDate;
                //objPurchaseReturnMaster.UpdatedBy = obj.UpdatedBy;
                objPurchaseReturnMaster.UpdatedDate = obj.UpdatedDate;
                objPurchaseReturnMaster.IsDeleted = obj.IsDeleted;

                var tobeDelete = objPurchaseReturnMaster.PurchaseReturnDetail.Where(o => !obj.PurchaseReturnDetailList.Select(x => x.ID).Contains(o.ID)).ToList();
                foreach (var item in tobeDelete)
                {
                    item.IsDeleted = true;
                }

                foreach (var item in obj.PurchaseReturnDetailList)
                {
                    if (item.ID == 0)//Added new
                    {
                        objPurchaseReturnMaster.PurchaseReturnDetail.Add(new PurchaseReturnDetail
                        {
                            ID = item.ID,
                            PurchaseReturnMasterID = objPurchaseReturnMaster.ID,
                            ItemID = item.ItemID,
                            ItemCode = item.ItemCode,
                            Qty = item.Qty,
                            IsDeleted = item.IsDeleted
                        });
                    }
                    else
                    {
                        var detailitem = objPurchaseReturnMaster.PurchaseReturnDetail.FirstOrDefault(x => x.ID == item.ID && (x.IsDeleted ?? false) == false);
                        decimal? oldQty = detailitem.Qty;
                        if (detailitem != null) //update
                        {
                            detailitem.ItemID = item.ItemID;
                            detailitem.ItemCode = item.ItemCode;
                            detailitem.Qty = item.Qty;
                            detailitem.IsDeleted = item.IsDeleted;
                        }
                        var objitem = context.ItemMaster.Where(x => x.ItemID == item.ItemID).FirstOrDefault();
                        objitem.OpeningBalance = (objitem.OpeningBalance ?? 0) + oldQty - item.Qty;
                    }
                }
                context.SaveChanges();
            }

            return true;
        }
        public bool Delete(long key)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var obj = context.PurchaseReturnMaster.FirstOrDefault(x => x.ID == key);
                foreach (var item in obj.PurchaseReturnDetail)
                {
                    item.IsDeleted = true;

                    var objitem = context.ItemMaster.Where(x => x.ItemID == item.ItemID).FirstOrDefault();
                    objitem.OpeningBalance = (objitem.OpeningBalance ?? 0) + item.Qty;
                }
                obj.IsDeleted = true;
                context.SaveChanges();
                return true;
            }
        }

        public PurchaseReturnMasterDTO GetByID(long key)
        {
            return GetRecord(key, "Current");
        }

        public PurchaseReturnMasterDTO GetPrevious(long key)
        {
            return GetRecord(key, "Previous");
        }

        public PurchaseReturnMasterDTO GetNext(long key)
        {
            return GetRecord(key, "Next");
        }

        public PurchaseReturnMasterDTO GetFirst(long key)
        {
            return GetRecord(key, "First");
        }

        public PurchaseReturnMasterDTO GetLast(long key)
        {
            return GetRecord(key, "Last");
        }

        private PurchaseReturnMasterDTO GetRecord(long currentRunningNumber, string fetchRecord)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                PurchaseReturnMaster item = null;
                switch (fetchRecord)
                {
                    case "Previous":
                        item = context.PurchaseReturnMaster.Where(x => x.ID < currentRunningNumber && x.IsDeleted == false).OrderByDescending(x => x.ID).FirstOrDefault();
                        break;
                    case "Next":
                        item = context.PurchaseReturnMaster.Where(x => x.ID > currentRunningNumber && x.IsDeleted == false).OrderBy(x => x.ID).FirstOrDefault();
                        break;
                    case "Last":
                        item = context.PurchaseReturnMaster.LastOrDefault();
                        break;
                    case "First":
                        item = context.PurchaseReturnMaster.FirstOrDefault();
                        break;
                    case "Current":
                        item = context.PurchaseReturnMaster.FirstOrDefault(c => c.ID == currentRunningNumber);
                        break;
                    default:
                        item = new PurchaseReturnMaster();
                        break;
                }
                if (item != null && item.ID > 0)
                {
                    var res = new PurchaseReturnMasterDTO()
                    {
                        ID = item.ID,
                        ReturnDate = item.ReturnDate,
                        PurchaseID = item.PurchaseID,
                        ReasonForReturn = item.ReasonForReturn,
                        CreatedBy = item.CreatedBy,
                        CreatedDate = item.CreatedDate,
                        UpdatedBy = item.UpdatedBy,
                        UpdatedDate = item.UpdatedDate,
                        IsDeleted = item.IsDeleted,
                    };
                    foreach (var detail in item.PurchaseReturnDetail)
                    {
                        res.PurchaseReturnDetailList.Add(new PurchaseReturnDetailDTO()
                        {
                            ID = detail.ID,
                            PurchaseReturnMasterID = detail.PurchaseReturnMasterID,
                            ItemID = detail.ItemID,
                            ItemCode = detail.ItemCode,
                            Qty = detail.Qty,
                            IsDeleted = detail.IsDeleted,
                            ItemName = detail.ItemMaster.ItemName,
                            Unit = context.CodeMaster.FirstOrDefault(x => x.ID == detail.ItemMaster.UnitID).Name
                        });
                    }
                    return res;
                }
                else
                    return new PurchaseReturnMasterDTO();

            }
        }
    }
}

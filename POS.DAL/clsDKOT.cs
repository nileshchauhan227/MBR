using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using POS.DTO;
using System.Data.SqlClient;

namespace POS.DAL
{
    public class clsDKOT : DALBase
    {
        public int GetNextKOTID(DateTime date)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var res = (context.KOTMaster.Where(x => EntityFunctions.TruncateTime(x.KOTDateTime) == EntityFunctions.TruncateTime(date.Date)).OrderByDescending(x => x.SRNumber).FirstOrDefault());
                if (res != null)
                    return res.SRNumber + 1;
                else
                    return 1;
            }
        }

        public int Add(DTO.KOTMasterDTO objMaster)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var objToAdd = new KOTMaster();
                objToAdd.KOTID = objMaster.KOTID;
                objToAdd.KOTDateTime = objMaster.KOTDateTime;
                objToAdd.SRNumber = objMaster.SRNumber;
                objToAdd.TableID = objMaster.TableID;
                objToAdd.Quantity = objMaster.Quantity;
                objToAdd.IsBillGenerated = objMaster.IsBillGenerated;
                foreach (KOTDetailDTO item in objMaster.detailList)
                {
                    objToAdd.KOTDetail.Add(new KOTDetail() { ItemID = item.ItemID, Quantity = item.Quantity, IsServed = false, KOTID = objToAdd.KOTID });
                }
                context.KOTMaster.AddObject(objToAdd);
                context.SaveChanges();
                return objToAdd.KOTID;
            }
        }

        public int Update(KOTMasterDTO objMaster)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var objToAdd = context.KOTMaster.FirstOrDefault(x => x.KOTID == objMaster.KOTID);
                var details = objToAdd.KOTDetail.ToList();
                foreach (var item in details)
                {
                    context.KOTDetail.DeleteObject(item);
                }

                foreach (KOTDetailDTO item in objMaster.detailList)
                {
                    objToAdd.KOTDetail.Add(new KOTDetail() { ItemID = item.ItemID, Quantity = item.Quantity, IsServed = false, KOTID = objToAdd.KOTID });
                }
                context.SaveChanges();
                return objToAdd.KOTID;
            }
        }

        public bool Delete(int ID)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var parent = context.KOTMaster.SingleOrDefault(x => x.KOTID == ID);
                foreach (var item in parent.KOTDetail.ToList())
                {
                    parent.KOTDetail.Remove(item);
                }
                return context.SaveChanges() > 0;
            }
        }

        public KOTMasterDTO GetKOTDetails(int id)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var master = context.KOTMaster.Include("KOTDetail").SingleOrDefault(x => x.KOTID == id);
                if (master == null)
                {
                    return new KOTMasterDTO();
                }
                else
                {
                    KOTMasterDTO objtoReturn = new KOTMasterDTO();
                    objtoReturn.IsBillGenerated = master.IsBillGenerated.Value;
                    objtoReturn.KOTDateTime = master.KOTDateTime;
                    objtoReturn.KOTID = master.KOTID;
                    objtoReturn.Quantity = master.Quantity;
                    objtoReturn.SRNumber = master.SRNumber;
                    objtoReturn.TableID = master.TableID;
                    objtoReturn.TobeMaintained = master.TobeMaintained ?? false;
                    objtoReturn.detailList = (from x in master.KOTDetail
                                              select new KOTDetailDTO
                                              {
                                                  ID = x.ID,
                                                  IsServed = x.IsServed ?? false,
                                                  ItemID = x.ItemID.Value,
                                                  KOTID = x.KOTID.Value,
                                                  Quantity = x.Quantity.Value,
                                                  ItemRate = x.ItemMaster.Rate ?? 0,
                                                  Discount = x.ItemMaster.Discount ?? 0,
                                                  OtherDiscount = x.ItemMaster.OtherDiscount ?? 0,
                                                  ItemCode = x.ItemMaster.ItemCode,
                                                  ItemName = x.ItemMaster.ItemName
                                              }).ToList();
                    return objtoReturn;

                }

            }
        }

        public KOTMasterDTO GetKOTDetailsBySrNo(int SrNo)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var master = context.KOTMaster.SingleOrDefault(x => x.SRNumber == SrNo && EntityFunctions.TruncateTime(x.KOTDateTime) == EntityFunctions.TruncateTime(DateTime.Now));
                if (master == null)
                {
                    return new KOTMasterDTO();
                }
                else
                {
                    KOTMasterDTO objtoReturn = new KOTMasterDTO();
                    objtoReturn.IsBillGenerated = master.IsBillGenerated.Value;
                    objtoReturn.KOTDateTime = master.KOTDateTime;
                    objtoReturn.KOTID = master.KOTID;
                    objtoReturn.Quantity = master.Quantity;
                    objtoReturn.SRNumber = master.SRNumber;
                    objtoReturn.TableID = master.TableID;
                    objtoReturn.TobeMaintained = master.TobeMaintained.HasValue ? master.TobeMaintained.Value : false;

                    var details = context.KOTDetail.Where(x => x.KOTID == master.KOTID);
                    objtoReturn.detailList = (from x in details
                                              select new KOTDetailDTO
                                              {
                                                  ID = x.ID,
                                                  IsServed = x.IsServed.Value,
                                                  ItemID = x.ItemID.Value,
                                                  KOTID = x.KOTID.Value,
                                                  Quantity = x.Quantity.Value,
                                                  ItemCode = x.ItemMaster.ItemCode,
                                                  ItemName = x.ItemMaster.ItemName,
                                              }).ToList();

                    return objtoReturn;

                }

            }
        }

        public List<KOTMasterDTO> GetRunningKOT(DateTime dateTime)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var res = (from x in context.ExecuteStoreQuery<KOTMasterDTO>("GetRunningKOT")
                           select new KOTMasterDTO
                           {
                               KOTID = x.KOTID,
                               SRNumber = x.SRNumber,
                               TableNumber = x.TableNumber,
                               NetAmount = x.NetAmount
                           }).ToList();
                return res;
            }
        }

        public List<KOTMasterDTO> GetKotRecordsList()
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var res = (from x in context.KOTMaster
                           select new KOTMasterDTO
                           {
                               KOTDate = EntityFunctions.TruncateTime(x.KOTDateTime),

                           });
                return res.Distinct().OrderByDescending(x => x.KOTDate).ToList();
            }
        }
        public List<KOTMasterDTO> GetKotRecordsList(DateTime date)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var res = (from x in context.GetKotRecordsList(date)
                           select new KOTMasterDTO
                           {
                               IsSelected = x.TobeMaintained,
                               KOTID = x.KOTID,
                               SRNumber = x.SRNumber,
                               strKOTDate = x.strKOTDate,
                               strKOTTime = x.strKOTTime,
                               Quantity = x.Quantity ?? 0,
                               NetAmount = x.NetAmount ?? 0
                           });
                return res.ToList();
            }
        }

        public int Update_TobeMaintain(List<KOTMasterDTO> lstKOT)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                int kotID = 0;
                foreach (KOTMasterDTO obj in lstKOT)
                {
                    KOTMaster objkot = context.KOTMaster.Where(x => x.KOTID == obj.KOTID).SingleOrDefault();
                    if (objkot != null)
                    {
                        objkot.TobeMaintained = obj.TobeMaintained;
                        kotID = objkot.KOTID;
                    }

                }
                context.SaveChanges();
                return kotID;
            }
        }

        public BillMasterDTO GenrateBill(List<Int32> lstkotid)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                BillMasterDTO res = new BillMasterDTO();
                foreach (int kotid in lstkotid)
                {
                    res = (from x in context.GenrateBill(kotid)
                           select new BillMasterDTO
                           {
                               BillID = x.BillID,

                           }).SingleOrDefault();

                }
                return res;
            }
        }
    }
}

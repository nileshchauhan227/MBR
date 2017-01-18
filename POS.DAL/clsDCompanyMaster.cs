using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.DTO;

namespace POS.DAL
{
    public class clsDCompanyMaster : DALBase
    {
        public List<CompanyMasterDTO> GetAllRecordsList()
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var res = (from x in context.CompanyMaster.Where(x => x.IsDeleted == false)

                           select new CompanyMasterDTO
                           {
                               Id = x.Id,
                               CompanyName = x.CompanyName,
                               CompanyAddress = x.CompanyAddress,
                               MobileNo = x.MobileNo,
                               PhoneNo = x.PhoneNo,
                               EmailId = x.EmailId
                           }).ToList();
                return res;
            }
        }
        public Int32 Add(CompanyMasterDTO objToSave)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                bool isAdd = false;
                CompanyMaster c = context.CompanyMaster.Where(x => x.Id != objToSave.Id && x.CompanyName == objToSave.CompanyName && x.IsDeleted == false).SingleOrDefault();
                if (c == null)
                {
                    isAdd = true;

                    c = new CompanyMaster();
                    c.CreatedDate = objToSave.CreatedDate;
                }
                c.CompanyName = objToSave.CompanyName;

                c.CompanyAddress = objToSave.CompanyAddress;
                c.PhoneNo = objToSave.PhoneNo;
                c.MobileNo = objToSave.MobileNo;
                c.EmailId = objToSave.EmailId;
                c.UpdatedDate = objToSave.UpdatedDate;
                c.IsDeleted = objToSave.IsDeleted;
                if (isAdd)
                {
                    context.CompanyMaster.AddObject(c);
                }
                context.SaveChanges();
                return c.Id;
            }
        }
        public Int32 Update(CompanyMasterDTO objToSave)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {

                CompanyMaster c = context.CompanyMaster.Where(x => x.Id == objToSave.Id && x.IsDeleted == false).SingleOrDefault();
                if (c != null)
                {
                    c.CompanyName = objToSave.CompanyName;
                    c.CompanyAddress = objToSave.CompanyAddress;
                    c.PhoneNo = objToSave.PhoneNo;
                    c.MobileNo = objToSave.MobileNo;
                    c.EmailId = objToSave.EmailId;
                    c.UpdatedDate = objToSave.UpdatedDate;
                    c.IsDeleted = objToSave.IsDeleted;
                    context.SaveChanges();
                }
                return c.Id;
            }
        }
        public CompanyMasterDTO FindRecord(Int32 Id)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var res = (from x in context.CompanyMaster.Where(x => x.IsDeleted == false && x.Id == Id)
                           select new CompanyMasterDTO
                           {
                               Id = x.Id,
                               CompanyName = x.CompanyName,
                               CompanyAddress = x.CompanyAddress,
                               MobileNo = x.MobileNo,
                               PhoneNo = x.PhoneNo,
                               EmailId = x.EmailId
                           }).SingleOrDefault();
                return res;
            }
        }
        public Boolean Delete(Int32 Id)
        {
            bool flgDelete = false;
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                CompanyMaster c = context.CompanyMaster.Where(x => x.Id == Id && x.IsDeleted == false).SingleOrDefault();
                if (c != null)
                {
                    c.IsDeleted = true;
                    c.UpdatedDate = DateTime.Now;
                    flgDelete = true;
                    context.SaveChanges();
                }

                return flgDelete;
            }
        }

        public List<CompanyMasterDTO> GetItems(string serachText = "")
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var query = (from x in context.CompanyMaster.Where(x => x.IsDeleted == false)
                             where
                             (
                             x.CompanyName.ToLower().Contains(serachText == "" ? x.CompanyName : serachText.ToLower())
                             || x.PhoneNo.ToLower().Contains(serachText == "" ? x.PhoneNo : serachText.ToLower())
                             || x.MobileNo.ToLower().Contains(serachText == "" ? x.MobileNo : serachText.ToLower())
                             || x.EmailId.ToLower().Contains(serachText == "" ? x.EmailId : serachText.ToLower())
                             )
                             select new CompanyMasterDTO
                             {
                                 Id = x.Id,
                                 CompanyName = x.CompanyName,
                                 CompanyAddress = x.CompanyAddress,
                                 MobileNo = x.MobileNo,
                                 PhoneNo = x.PhoneNo,
                                 EmailId = x.EmailId
                             }).ToList();
                return query;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.DTO;

namespace POS.DAL
{
    public class clsDCustomerMaster : DALBase
    {

        public List<CustomerDTO> GetAllRecordsList()
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var res = (from x in context.CustomerMaster.Where(x => x.IsDeleted == false)
                           select new CustomerDTO
                           {
                               CustomerId = x.CustomerId,
                               CustomerName = x.CustomerName,
                               CustomerAddress = x.CustomerAddress,
                               EmailId = x.EmailId,
                               PhoneNo = x.PhoneNo
                           }).ToList();
                return res;
            }
        }
        public Int32 Add(CustomerDTO objToSave)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                bool isAdd = false;
                CustomerMaster c = context.CustomerMaster.Where(x => x.CustomerId == objToSave.CustomerId && x.IsDeleted == false).SingleOrDefault();
                if (c == null)
                {
                    isAdd = true;
                    c = new CustomerMaster();
                    c.CreatedBy = objToSave.CreatedBy;
                    c.CreatedDate = DateTime.Now;
                }

                c.CustomerName = objToSave.CustomerName;
                c.CustomerAddress = objToSave.CustomerAddress;
                c.EmailId = objToSave.EmailId;
                c.PhoneNo = objToSave.PhoneNo;
                c.UpdatedBy = objToSave.UpdatedBy;
                c.UpdatedDate = DateTime.Now;
                c.IsDeleted = false;
                if (isAdd)
                {
                    context.CustomerMaster.AddObject(c);
                }
                context.SaveChanges();
                return c.CustomerId;
            }
        }


        public static List<CustomerDTO> GetAllRecordsList(string CustomerName)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var res = (from x in context.CustomerMaster.Where(x => x.IsDeleted == false)
                           where x.CustomerName.ToLower() == CustomerName.Trim().ToLower()
                           select new CustomerDTO
                           {
                               CustomerId = x.CustomerId,
                               CustomerName = x.CustomerName,
                               CustomerAddress = x.CustomerAddress,
                               EmailId = x.EmailId,
                               PhoneNo = x.PhoneNo
                           }).ToList();
                return res;
            }
        }
        public bool isExistCode(string Name, int id)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                return (context.CustomerMaster.Any(x => x.CustomerId != id && x.CustomerName.ToLower() == Name.Trim().ToLower() && x.IsDeleted == false));
            }
        }
        public List<CustomerDTO> GetItems(string serachText = "")
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var query = (from x in context.CustomerMaster.Where(x => x.IsDeleted == false)
                             where
                             (
                             x.CustomerName.ToLower().Contains(serachText == "" ? x.CustomerName.ToLower() : serachText.ToLower())
                             || x.EmailId.ToLower().Contains(serachText == "" ? x.EmailId.ToLower() : serachText.ToLower())
                             || x.PhoneNo.ToLower().Contains(serachText == "" ? x.PhoneNo : serachText.ToLower())
                             )
                             select new CustomerDTO
                             {
                                 CustomerId = x.CustomerId,
                                 CustomerName = x.CustomerName,
                                 CustomerAddress = x.CustomerAddress,
                                 EmailId = x.EmailId,
                                 PhoneNo = x.PhoneNo
                             }).ToList();
                return query;
            }
        }
        public CustomerDTO GetItems(Int32 CustomerId)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var query = (from x in context.CustomerMaster.Where(x => x.CustomerId == CustomerId && x.IsDeleted == false)
                             select new CustomerDTO
                             {
                                 CustomerId = x.CustomerId,
                                 CustomerName = x.CustomerName,
                                 CustomerAddress = x.CustomerAddress,
                                 EmailId = x.EmailId,
                                 PhoneNo = x.PhoneNo
                             }).SingleOrDefault();
                return query;
            }
        }
        public bool Delete(int CustomerId)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var objToDelete = context.CustomerMaster.FirstOrDefault(x => x.CustomerId == CustomerId);
                if (objToDelete != null)
                {
                    objToDelete.IsDeleted = true;
                    objToDelete.UpdatedDate = DateTime.Now;
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public List<CustomerDTO> GetFirmDetails(Int32 CustomerId)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var res = (from x in context.CustomerMaster.Where(x => x.CustomerId == CustomerId && x.IsDeleted == false)
                           select new CustomerDTO
                           {
                               CustomerId = x.CustomerId,
                               CustomerName = x.CustomerName,
                               CustomerAddress = x.CustomerAddress,
                               EmailId = x.EmailId,
                               PhoneNo = x.PhoneNo 
                           }).ToList();
                return res;
            }
        }
    }
}

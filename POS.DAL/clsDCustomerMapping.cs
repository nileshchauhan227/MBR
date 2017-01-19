using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.DTO;

namespace POS.DAL
{
    public class clsDCustomerMapping : DALBase
    {
        public List<CustomerMappingDTO> GetAllRecordsList()
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var res = (from x in context.CustomerMapping
                           select new CustomerMappingDTO
                           {
                               MappingId = x.MappingId,
                               CustomerId = x.CustomerId.HasValue ? x.CustomerId.Value : 0,
                               ItemId = x.ItemId.HasValue ? x.ItemId.Value : 0,
                               Rate = x.Rate.HasValue ? x.Rate.Value : 0
                           }).ToList();
                return res;
            }
        }
        public Int32 Add(CustomerMappingDTO objToSave)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                bool isAdd = false;
                CustomerMapping c = context.CustomerMapping.Where(x => x.MappingId == objToSave.MappingId).SingleOrDefault();
                if (c == null)
                {
                    c = new CustomerMapping();
                    isAdd = true;
                }
                c.CustomerId = objToSave.CustomerId;
                c.ItemId = objToSave.ItemId;
                c.Rate = objToSave.Rate;
                if(isAdd)
                    context.CustomerMapping.AddObject(c);

                context.SaveChanges();
                return c.MappingId;
            }
        }


        public List<CustomerMappingDTO> GetAllRecordsList(Int32 CustomerId)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                return (from x in context.CustomerMapping.Where(x => x.CustomerId == CustomerId)
                        select new CustomerMappingDTO
                        {
                            ItemId = x.ItemId.HasValue ? x.ItemId.Value : 0
                        }
                             ).ToList();
            }
        }


        public static List<CustomerMappingDTO> GetAllRecordsList(string CustomerName)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var res = (from x in context.CustomerMapping
                           join y in context.CustomerMaster on x.CustomerId equals y.CustomerId
                           where y.CustomerName.ToLower() == CustomerName.Trim().ToLower()
                           select new CustomerMappingDTO
                           {
                               CustomerId = x.CustomerId.HasValue ? x.CustomerId.Value : 0,
                               ItemId = x.ItemId.HasValue ? x.ItemId.Value : 0,
                               Rate = x.Rate.HasValue ? x.Rate.Value : 0
                           }).ToList();
                return res;
            }
        }
        public bool isExistCode(Int32 CustomerId, Int32 ItemId)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                return (context.CustomerMapping.Any(x => x.CustomerId != CustomerId && x.ItemId == ItemId));
            }
        }
        public List<CustomerMappingDTO> GetItems(string serachText = "")
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var query = (from x in context.CustomerMapping
                             join y in context.CustomerMaster on x.CustomerId equals y.CustomerId
                             join z in context.ItemMaster on x.ItemId equals z.ItemID
                             where
                             (
                             y.CustomerName.ToLower().Contains(serachText == "" ? y.CustomerName.ToLower() : serachText.ToLower())
                             )
                             select new CustomerMappingDTO
                             {
                                 MappingId = x.MappingId,
                                 CustomerId = x.CustomerId.HasValue ? x.CustomerId.Value : 0,
                                 ItemId = x.ItemId.HasValue ? x.ItemId.Value : 0,
                                 Rate = x.Rate.HasValue ? x.Rate.Value : 0,
                                 CustomerName = y.CustomerName,
                                 ItemName = z.ItemName
                             }).ToList();
                return query;
            }
        }
        public CustomerMappingDTO GetItems(int MappingId)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var query = (from x in context.CustomerMapping.Where(x => x.MappingId == MappingId)
                             select new CustomerMappingDTO
                             {
                                 MappingId = x.MappingId,
                                 CustomerId = x.CustomerId.HasValue ? x.CustomerId.Value : 0,
                                 ItemId = x.ItemId.HasValue ? x.ItemId.Value : 0,
                                 Rate = x.Rate.HasValue ? x.Rate.Value : 0
                             }).SingleOrDefault();
                return query;
            }
        }
        public bool Delete(int MappingId)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var objToDelete = context.CustomerMapping.FirstOrDefault(x => x.MappingId == MappingId);
                if (objToDelete != null)
                {
                    context.CustomerMapping.DeleteObject(objToDelete);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public List<CustomerMappingDTO> GetFirmDetails(Int32 CustomerId)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var res = (from x in context.CustomerMapping.Where(x => x.CustomerId == CustomerId)
                           select new CustomerMappingDTO
                           {
                               MappingId = x.MappingId,
                               CustomerId = x.CustomerId.HasValue ? x.CustomerId.Value : 0,
                               ItemId = x.ItemId.HasValue ? x.ItemId.Value : 0,
                               Rate = x.Rate.HasValue ? x.Rate.Value : 0
                           }).ToList();
                return res;
            }
        }
    }
}

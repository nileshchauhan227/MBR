using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.DTO;


namespace POS.DAL
{
    public class clsDCashExpense : DALBase
    {
        public List<CashExpenseDTO> GetAllRecordsList()
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var res = (from x in context.CashExpense.Where(x=> x.IsDeleted == false)

                           select new CashExpenseDTO
                           {
                               Id = x.Id,
                               ExpDetail = x.ExpDetail,
                               ExpDate = x.ExpDate,
                               ReceiverName = x.ReceiverName,
                               Amount = x.Amount
                           }).ToList();
                return res;
            }
        }
        public Int32 Add(CashExpenseDTO objToSave)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                bool isAdd = false;
                CashExpense c = context.CashExpense.Where(x => x.Id == objToSave.Id && x.IsDeleted == false).SingleOrDefault();
                if (c == null)
                {
                    isAdd = true;
                    
                    c = new CashExpense();
                    c.CreatedDate = objToSave.CreatedDate;
                }
                c.ExpDetail = objToSave.ExpDetail;

                c.ReceiverName = objToSave.ReceiverName;
                c.Amount = objToSave.Amount;
                c.ExpDate = objToSave.ExpDate;
                c.UpdatedDate = objToSave.UpdatedDate;
                c.IsDeleted = objToSave.IsDeleted;
                if (isAdd)
                {
                    context.CashExpense.AddObject(c);
                }
                context.SaveChanges();
                return c.Id;
            }
        }
        public CashExpenseDTO FindRecord(Int32 Id)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {                
                var res = (from x in context.CashExpense.Where(x => x.IsDeleted == false && x.Id == Id)
                           select new CashExpenseDTO
                           {
                               Id = x.Id,
                               ExpDetail = x.ExpDetail,
                               ExpDate = x.ExpDate,
                               ReceiverName = x.ReceiverName,
                               Amount = x.Amount
                           }).SingleOrDefault();
                return res;
            }
        }
        public Boolean Delete(Int32 Id)
        {
            bool flgDelete = false;
            using (POS_RutuEntities context = new POS_RutuEntities())
            {                
                CashExpense c = context.CashExpense.Where(x => x.Id == Id && x.IsDeleted == false).SingleOrDefault();
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

        public List<CashExpenseDTO> GetItems(string serachText = "")
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var query = (from x in context.CashExpense.Where(x => x.IsDeleted == false)
                             where
                             (
                             x.ExpDetail.ToLower().Contains(serachText == "" ? x.ExpDetail : serachText.ToLower())
                             || x.ReceiverName.ToLower().Contains(serachText == "" ? x.ReceiverName : serachText.ToLower())                             
                             )
                             select new CashExpenseDTO
                             {
                                 Id = x.Id,
                                 ExpDetail = x.ExpDetail,
                                 ExpDate = x.ExpDate,
                                 ReceiverName = x.ReceiverName,
                                 Amount = x.Amount
                             }).ToList();
                return query;
            }
        }
    }
}

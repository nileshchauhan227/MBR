using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.DTO;

namespace POS.DAL
{
    public class clsDCodeMaster : DALBase
    {

        public List<CodeMasterDTO> GetAllRecordsList()
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var res = (from x in context.CodeMaster

                           select new CodeMasterDTO
                           {
                               ID = x.ID,
                               CodeTypeID = x.CodeTypeID,
                               Code = x.Code,
                               Name = x.Name,
                               CodeType = x.CodeType.Name
                           }).ToList();
                return res;
            }
        }
        public Int32 Add(CodeMasterDTO objToSave)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                bool isAdd = false;
                CodeMaster c = context.CodeMaster.Where(x => x.ID == objToSave.ID).SingleOrDefault();
                if (c == null)
                {
                    isAdd = true;
                    c = new CodeMaster();
                }
                c.Name = objToSave.Name;
                 
                c.Code = objToSave.Code;
                c.CodeTypeID = objToSave.CodeTypeID;

                if (isAdd)
                {
                    context.CodeMaster.AddObject(c);
                }
                context.SaveChanges();
                return c.ID;
            }
        }


        public static List<CodeMasterDTO> GetAllRecordsList(string code)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var res = (from x in context.CodeMaster
                           where x.Code.ToLower() == code.ToLower()
                           select new CodeMasterDTO
                           {
                               ID = x.ID,
                               Code = x.Code,
                               Name = x.Name,
                               CodeTypeID = x.CodeTypeID
                           }).ToList();
                return res;
            }
        }
        public bool isExistCode(string Name, int id)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                return (context.CodeMaster.Any(x => x.Name == Name   && x.ID != id));
            }
        }
        public List<CodeMasterDTO> GetItems(string serachText = "")
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var query = (from x in context.CodeMaster
                             where
                             (
                             x.Code.ToLower().Contains(serachText == "" ? x.Code : serachText.ToLower())
                             || x.Name.ToLower().Contains(serachText == "" ? x.Name : serachText.ToLower())
                             || x.CodeType.Name.ToLower().Contains(serachText == "" ? x.Name : serachText.ToLower())
                             )
                             select new CodeMasterDTO
                             {
                                 ID = x.ID,
                                 Code  = x.Code,
                                 
                                 Name = x.Name,
                                 CodeType = x.CodeType.Name,
                                 CodeTypeID = x.CodeTypeID
                                 
                             }).ToList();
                return query;
            }
        }
        public  CodeMasterDTO GetItems(Int32 CodeID)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var query = (from x in context.CodeMaster.Where(x => x.ID == CodeID)
                             select new CodeMasterDTO
                             {
                                 ID = x.ID,
                                 Code = x.Code,
                                 Name = x.Name,
                                 
                                 CodeType = x.CodeType.Name,
                                 CodeTypeID = x.CodeTypeID

                             }).SingleOrDefault();
                return query;
            }
        }
        public bool Delete(int CodeID)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var objToDelete = context.CodeMaster.FirstOrDefault(x => x.ID == CodeID);
                if (objToDelete != null)
                {
                    context.CodeMaster.DeleteObject(objToDelete);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public List<CodeMasterDTO> GetFirmDetails(Int32 CodeTypeID)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var res = (from x in context.CodeMaster.Where(x => x.CodeTypeID == CodeTypeID)
                           select new CodeMasterDTO
                           {
                               ID = x.ID,
                               Code = x.Code,
                               Name = x.Name
                           }).ToList();
                return res;
            }
        } 
    }
}

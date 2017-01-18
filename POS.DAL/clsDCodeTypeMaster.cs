using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.DTO;

namespace POS.DAL
{
  public  class clsDCodeTypeMaster:DALBase
    {
      public List<CodeTypeDTO> GetAllRecordsList()
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var res = (from x in context.CodeType
                           select new CodeTypeDTO
                           {
                               ID = x.ID,
                               Code = x.Code,
                               Name = x.Name
                           }).ToList();
                return res;
            }
        }
      public  CodeTypeDTO FindRecord(Int32 CodeTypeID)
      {
          using (POS_RutuEntities context = new POS_RutuEntities())
          {
              var res = (from x in context.CodeType.Where(x => x.ID == CodeTypeID)
                         select new CodeTypeDTO
                         {
                             ID = x.ID,
                             Code = x.Code,
                             Name = x.Name
                         }).SingleOrDefault();
              return res;
          }
      }
       
    }
}

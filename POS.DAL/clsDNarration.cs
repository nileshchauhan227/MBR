using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.DTO;

namespace POS.DAL
{
    public class clsDNarration :DALBase
    {
        public  List<NarrationDTO>  GetAllRecordsList()
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var res = (from x in context.tblNarration.Where(x => x.IsDeledted == false)
                           select new NarrationDTO
                           {
                               NarrationId = x.NarrationId,
                               Narration = x.Narration,
                               
                           }).ToList();
                return res;
            }
        }
    }
}

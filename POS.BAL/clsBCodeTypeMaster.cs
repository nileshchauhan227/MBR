using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.DTO;
using POS.DAL;

namespace POS.BAL
{
    public class clsBCodeTypeMaster
    {
        public static List<CodeTypeDTO> GetAllRecordsList()
        {
            using (clsDCodeTypeMaster clsDCodeTypeMaster = new clsDCodeTypeMaster())
            {
                return clsDCodeTypeMaster.GetAllRecordsList();
            }
        }
        public static CodeTypeDTO FindRecord(Int32 CodeTypeID)
        {
            using (clsDCodeTypeMaster clsDCodeTypeMaster = new clsDCodeTypeMaster())
            {
                return clsDCodeTypeMaster.FindRecord(CodeTypeID);
            }
        }
       
    }
}

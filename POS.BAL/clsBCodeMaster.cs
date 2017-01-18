using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.DTO;
using POS.DAL;

namespace POS.BAL
{
    public class clsBCodeMaster
    {

        public static List<CodeMasterDTO> GetAllRecordsList()
        {
            using (clsDCodeMaster clsDCodeMaster = new clsDCodeMaster())
            {
                return clsDCodeMaster.GetAllRecordsList();
            }
        }
       public static List<CodeMasterDTO> GetAllRecordsList(string code)
        {
            using (clsDCodeMaster clsDCodeMaster = new clsDCodeMaster())
            {
                return clsDCodeMaster.GetAllRecordsList(code);
            }
        }

        public static Int32 Add(CodeMasterDTO objToSave)
        {
            using (clsDCodeMaster clsDCodeMaster = new clsDCodeMaster())
            {
                return clsDCodeMaster.Add(objToSave);
            }
        }
        public static bool isExistCode(string Name, int CodeID)
        {
            using (clsDCodeMaster clsDCodeMaster = new clsDCodeMaster())
            {
                return clsDCodeMaster.isExistCode(Name, CodeID);
            }   
        }
        public static  List<CodeMasterDTO> GetItems(string serachText = "")
        {
            using (clsDCodeMaster clsDCodeMaster = new clsDCodeMaster())
            {
                return clsDCodeMaster.GetItems(serachText);
            }
        }
        public static CodeMasterDTO GetItems(Int32 CodeID)
        {
            using (clsDCodeMaster clsDCodeMaster = new clsDCodeMaster())
            {
                return clsDCodeMaster.GetItems(CodeID);
            }
        }
        public static bool Delete(int CodeID)
        {
            using (clsDCodeMaster clsDCodeMaster = new clsDCodeMaster())
            {
                return clsDCodeMaster.Delete(CodeID);
            }
        }
        public static List<CodeMasterDTO> GetFirmDetails(Int32 CodeTypeID)
        {
            using (clsDCodeMaster clsDCodeMaster = new clsDCodeMaster())
            {
                return clsDCodeMaster.GetFirmDetails(CodeTypeID);
            }
        }
        
    }
}

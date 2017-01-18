using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.DTO;
using POS.DAL;

namespace POS.BAL
{
    public class clsBCompanyMaster
    {

        public static List<CompanyMasterDTO> GetAllRecordsList()
        {
            using (clsDCompanyMaster clsDCompanyMaster = new clsDCompanyMaster())
            {
                return clsDCompanyMaster.GetAllRecordsList();
            }
        }
        public static Int32 Add(CompanyMasterDTO objToSave)
        {
            using (clsDCompanyMaster clsDCompanyMaster = new clsDCompanyMaster())
            {
                return clsDCompanyMaster.Add(objToSave);
            }
        }
        public static CompanyMasterDTO FindRecord(Int32 Id)
        {
            using (clsDCompanyMaster clsDCompanyMaster = new clsDCompanyMaster())
            {
                return clsDCompanyMaster.FindRecord(Id);
            }
        }
        public static Int32 Update(CompanyMasterDTO objToSave)
        {
            using (clsDCompanyMaster clsDCompanyMaster = new clsDCompanyMaster())
            {
                return clsDCompanyMaster.Update(objToSave);
            }
        }
        public static Boolean Delete(Int32 Id)
        {
            using (clsDCompanyMaster clsDCompanyMaster = new clsDCompanyMaster())
            {
                return clsDCompanyMaster.Delete(Id);
            }
        }
        public static List<CompanyMasterDTO> GetItems(string serachText = "")
        {
            using (clsDCompanyMaster clsDCompanyMaster = new clsDCompanyMaster())
            {
                return clsDCompanyMaster.GetItems(serachText);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.DAL;
using POS.DTO;

namespace POS.BAL
{
    public class clsBKOT
    {
        public static int GetNextKOTID(DateTime date)
        {
            using (clsDKOT obj = new clsDKOT())
            {
                return obj.GetNextKOTID(date);
            }
        }

        public static int Add(KOTMasterDTO objMaster)
        {
            using (clsDKOT obj = new clsDKOT())
            {
                return obj.Add(objMaster);
            }
        }

        public static int Update(KOTMasterDTO objMaster)
        {
            using (clsDKOT obj = new clsDKOT())
            {
                return obj.Update(objMaster);
            }
        }

        public static bool Delete(int KOTID)
        {
            using (clsDKOT obj = new clsDKOT())
            {
                return obj.Delete(KOTID);
            }
        }

        public static KOTMasterDTO GetKOTDetails(int id)
        {
            using (clsDKOT obj = new clsDKOT())
            {
                return obj.GetKOTDetails(id);
            }
        }

        public static KOTMasterDTO GetKOTDetailsBySrNo(int SrNo)
        {
            using (clsDKOT obj = new clsDKOT())
            {
                return obj.GetKOTDetailsBySrNo(SrNo);
            }
        }

        public static List<KOTMasterDTO> GetRunningKOT(DateTime dateTime)
        {
            using (clsDKOT obj = new clsDKOT())
            {
                return obj.GetRunningKOT(dateTime);
            }
        }

        public static List<KOTMasterDTO> GetKotRecordsList(DateTime? date)
        {
            using (clsDKOT obj = new clsDKOT())
            {
                return obj.GetKotRecordsList(date.Value);
            }
        }
        public static List<KOTMasterDTO> GetKotRecordsList()
        {
            using (clsDKOT obj = new clsDKOT())
            {
                return obj.GetKotRecordsList();
            }
        }        
        public static int Update_TobeMaintain(List<KOTMasterDTO> lstKOT)
        {
            using (clsDKOT obj = new clsDKOT())
            {
                return obj.Update_TobeMaintain(lstKOT);
            }

        }
        public  static BillMasterDTO GenrateBill(List<Int32> lstkotid)
        {
            using (clsDKOT obj = new clsDKOT())
            {
                return obj.GenrateBill(lstkotid);
            }

        }
    }
}

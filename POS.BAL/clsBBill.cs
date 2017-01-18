using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.DAL;
using POS.DTO;

namespace POS.BAL
{
    public class clsBBill
    {
        public static int GetNextInvoiceNumber()
        {
            using (clsDBill objBill = new clsDBill())
            {
                return objBill.GetNextInvoiceNumber();
            }
        }
        public static int AddBill(BillMasterDTO objToSave)
        {
            using (clsDBill objBill = new clsDBill())
            {
                return objBill.AddBill(objToSave);
            }
        }
        public static BillMasterDTO GetBillDetail(int currentRunningNumber, string fetchRecord)
        {
            using (clsDBill objBill = new clsDBill())
            {
                return objBill.GetBillDetail(currentRunningNumber, fetchRecord);
            }
        }
        public static bool Delete(int BillID)
        {
            using (clsDBill obj = new clsDBill())
                return obj.Delete(BillID);
        }

        public static bool UpdatePrintFlagByRunningNumber(int RunningNumber)
        {
            using (clsDBill obj = new clsDBill())
                return obj.UpdatePrintFlagByRunningNumber(RunningNumber);
        }

        public static object Update(BillMasterDTO objMaster)
        {
            using (clsDBill obj = new clsDBill())
                return obj.Update(objMaster);
        }

        public static object GetPendingPrintBill(DateTime dateTime)
        {
            using (clsDBill obj = new clsDBill())
                return obj.GetPendingPrintBill(dateTime);
        }
    }
}

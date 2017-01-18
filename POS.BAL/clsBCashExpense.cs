using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.DTO;
using POS.DAL;

namespace POS.BAL
{
    public class clsBCashExpense
    {
        public static List<CashExpenseDTO> GetAllRecordsList()
        {
            using (clsDCashExpense clsDCashExpense = new clsDCashExpense())
            {
              return  clsDCashExpense.GetAllRecordsList();
            }
        }
        public static Int32 Add(CashExpenseDTO objToSave)
        {
            using (clsDCashExpense clsDCashExpense = new clsDCashExpense())
            {
                return clsDCashExpense.Add(objToSave);
            }
        }
        public static CashExpenseDTO FindRecord(Int32 Id)
        {
            using (clsDCashExpense clsDCashExpense = new clsDCashExpense())
            {
                return clsDCashExpense.FindRecord(Id);
            }
        }
        public static Boolean Delete(Int32 Id)
        {
            using (clsDCashExpense clsDCashExpense = new clsDCashExpense())
            {
                return clsDCashExpense.Delete(Id);
            }
        }
        public static List<CashExpenseDTO> GetItems(string serachText = "")
        {
            using (clsDCashExpense clsDCashExpense = new clsDCashExpense())
            {
                return clsDCashExpense.GetItems(serachText);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.DTO;
using POS.DAL;

namespace POS.BAL
{
    public class clsBCustomerMaster
    {
        public static List<CustomerDTO> GetAllRecordsList()
        {
            using (clsDCustomerMaster clsDCustomerMaster = new clsDCustomerMaster())
            {
                return clsDCustomerMaster.GetAllRecordsList();
            }
        }
        public static List<CustomerDTO> GetAllRecordsList(string CustomerName)
        {
            using (clsDCustomerMaster clsDCustomerMaster = new clsDCustomerMaster())
            {
                return clsDCustomerMaster.GetAllRecordsList(CustomerName);
            }
        }

        public static Int32 Add(CustomerDTO objToSave)
        {
            using (clsDCustomerMaster clsDCustomerMaster = new clsDCustomerMaster())
            {
                return clsDCustomerMaster.Add(objToSave);
            }
        }
        public static bool isExistCode(string Name, int Id)
        {
            using (clsDCustomerMaster clsDCustomerMaster = new clsDCustomerMaster())
            {
                return clsDCustomerMaster.isExistCode(Name, Id);
            }
        }
        public static List<CustomerDTO> GetItems(string serachText = "")
        {
            using (clsDCustomerMaster clsDCustomerMaster = new clsDCustomerMaster())
            {
                return clsDCustomerMaster.GetItems(serachText);
            }
        }
        public static CustomerDTO GetItems(Int32 CustomerId)
        {
            using (clsDCustomerMaster clsDCustomerMaster = new clsDCustomerMaster())
            {
                return clsDCustomerMaster.GetItems(CustomerId);
            }
        }
        public static bool Delete(int CustomerId)
        {
            using (clsDCustomerMaster clsDCustomerMaster = new clsDCustomerMaster())
            {
                return clsDCustomerMaster.Delete(CustomerId);
            }
        }
        public static List<CustomerDTO> GetFirmDetails(Int32 CustomerId)
        {
            using (clsDCustomerMaster clsDCustomerMaster = new clsDCustomerMaster())
            {
                return clsDCustomerMaster.GetFirmDetails(CustomerId);
            }
        }
        
    }
}

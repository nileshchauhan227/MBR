using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.DTO;
using POS.DAL;

namespace POS.BAL
{
    public class clsBCustomerMapping
    {
        public static List<CustomerMappingDTO> GetAllRecordsList()
        {
            using (clsDCustomerMapping clsDCustomerMapping = new clsDCustomerMapping())
            {
                return clsDCustomerMapping.GetAllRecordsList();
            }
        }
        public static Int32 Add(CustomerMappingDTO objToSave)
        {
            using (clsDCustomerMapping clsDCustomerMapping = new clsDCustomerMapping())
            {
                return clsDCustomerMapping.Add(objToSave);
            }
        }


        public static List<CustomerMappingDTO> GetAllRecordsList(Int32 CustomerId)
        {
            using (clsDCustomerMapping clsDCustomerMapping = new clsDCustomerMapping())
            {
                return clsDCustomerMapping.GetAllRecordsList(CustomerId);
            }
        }
        public static bool isExistCode(Int32 CustomerId, Int32 ItemId)
        {
            using (clsDCustomerMapping clsDCustomerMapping = new clsDCustomerMapping())
            {
                return clsDCustomerMapping.isExistCode(CustomerId, ItemId);
            }
        }
        public static List<CustomerMappingDTO> GetItems(string serachText = "")
        {
            using (clsDCustomerMapping clsDCustomerMapping = new clsDCustomerMapping())
            {
                return clsDCustomerMapping.GetItems(serachText);
            }
        }
        public static CustomerMappingDTO GetItems(int CustomerId)
        {
            using (clsDCustomerMapping clsDCustomerMapping = new clsDCustomerMapping())
            {
                return clsDCustomerMapping.GetItems(CustomerId);
            }
        }
        public static bool Delete(int CustomerId)
        {
            using (clsDCustomerMapping clsDCustomerMapping = new clsDCustomerMapping())
            {
                return clsDCustomerMapping.Delete(CustomerId);
            }
        }
        public static List<CustomerMappingDTO> GetFirmDetails(Int32 CustomerId)
        {
            using (clsDCustomerMapping clsDCustomerMapping = new clsDCustomerMapping())
            {
                return clsDCustomerMapping.GetFirmDetails(CustomerId);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.DAL;
using System.Data.SqlClient;
using System.Data;
using POS.DTO;


namespace POS.BAL
{
    public class clsBConfiguration 
    {

       
        public static List<ConfigurationDTO> GetAllRecordsList()
        {
            using (clsDConfiguration clsDConfiguration = new clsDConfiguration())
            {
                return clsDConfiguration.getAllRecordsList();
            }
        }

         /// <summary>
        /// Adding record to database using DAL
        /// </summary>
        /// <param name="objCat"></param>
        public static System.Int32 Add(ConfigurationDTO objDTO)
        {
            using (clsDConfiguration clsDConfiguration = new clsDConfiguration())
            {
                return clsDConfiguration.Add(objDTO);
            }
        }

        public static bool IsKeyExists(string configKey)
        {
            using (clsDConfiguration clsDConfiguration = new clsDConfiguration())
            {
                return clsDConfiguration.IsKeyExists(configKey);
            }
        }
         /// <summary>
        /// Gets the config value.
        /// </summary>
        /// <param name="ConfigKey">The config key.</param>
        /// <returns>Returns configutation value.</returns>
        /// <remarks></remarks>
        public static string GetConfigVal(string ConfigKey)
        {
            using (clsDConfiguration clsDConfiguration = new clsDConfiguration())
            {
                return clsDConfiguration.getConfigVal(ConfigKey);
            }
        }
        /// <summary>
        /// Adding record to database using DAL
        /// </summary>
        /// <param name="objCat"></param>
        public static System.Int32 AddWithMultiple(List<ConfigurationDTO> lstobjDTO)
        {
            using (clsDConfiguration clsDConfiguration = new clsDConfiguration())
            {
                return clsDConfiguration.AddWithMultiple(lstobjDTO);
            }
        }
    }
}



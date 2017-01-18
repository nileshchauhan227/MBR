using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using System.Data.Objects;
using POS.DTO;


namespace POS.DAL
{
    public class clsDConfiguration : DALBase
    {
        #region clsDConfiguration Members

        /// <summary>
        /// Select All Record
        /// </summary>
        /// <returns></returns>
        public List<ConfigurationDTO> getAllRecordsList()
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                return (from x in context.ConfigurationSetting
                        select new ConfigurationDTO
                        {
                            ConfigurationID = x.ConfigurationId,
                            ConfigurationKey = x.ConfigurationKey,
                            ConfigurationValue = x.ConfigurationValue,
                            UpdatedBy = x.UpdatedBy,
                            UpdatedDate = x.UpdatedDate.HasValue ? x.UpdatedDate.Value : DateTime.Now,

                        }).ToList();
            }
        }

        /// <summary>
        /// Add Method of DAL to add Record in the Configuration
        /// </summary>
        /// <param name="objDTO">Object of DTO Class, which will be converted to Entity object</param>
        public System.Int32 Add(ConfigurationDTO objDTO)
        {
            //Assign & Mapping of the DTO Class property to Entity Class 
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                var c = new ConfigurationSetting
                    {
                        ConfigurationId = objDTO.ConfigurationID,
                        ConfigurationKey = objDTO.ConfigurationKey,
                        ConfigurationValue = objDTO.ConfigurationValue,
                        CreatedBy = objDTO.CreatedBy,
                        CreatedDate = objDTO.CreatedDate
                    };
                //Take Entity object 

                context.ConfigurationSetting.AddObject(c);
                //Save Changes.
                context.SaveChanges();

                System.Int32 iReturn = 0;
                iReturn = c.ConfigurationId;
                return iReturn;

            }
        }

        public bool IsKeyExists(string configKey)
        {
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                return context.ConfigurationSetting.Any(x => x.ConfigurationKey.ToLower() == configKey.ToLower());
            }
        }

        /// <summary>
        /// Get Value based on Key
        /// </summary>
        /// <param name="ConfigKey">The config key.</param>
        /// <returns>Returns configutation value.</returns>
        /// <remarks></remarks>
        public string getConfigVal(string ConfigKey)
        {

            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                string objAdd = context.ConfigurationSetting.SingleOrDefault(x => x.ConfigurationKey.ToLower() == ConfigKey.ToLower()).ConfigurationValue;
                return objAdd ?? string.Empty;

            }
        }

        public System.Int32 AddWithMultiple(List<ConfigurationDTO> lstobjDTO)
        {
            //Assign & Mapping of the DTO Class property to Entity Class 
            using (POS_RutuEntities context = new POS_RutuEntities())
            {
                bool isAdd = false;
                foreach (ConfigurationDTO objDTO in lstobjDTO)
                {
                    var c = context.ConfigurationSetting.Where(x => x.ConfigurationKey == objDTO.ConfigurationKey).FirstOrDefault();
                    if (c == null)
                    {
                        isAdd = true;
                        c = new ConfigurationSetting();
                        c.CreatedBy = objDTO.CreatedBy;
                        c.CreatedDate = objDTO.CreatedDate;
                    }
                    else
                    {
                        c.UpdatedBy = objDTO.UpdatedBy;
                        c.UpdatedDate = objDTO.UpdatedDate;
                    }
                    c.ConfigurationKey = objDTO.ConfigurationKey;
                    c.ConfigurationValue = objDTO.ConfigurationValue;

                    //Take Entity object 
                    if (isAdd)
                        context.ConfigurationSetting.AddObject(c);
                    //Save Changes.
                }
                context.SaveChanges();

                System.Int32 iReturn = 1;
                //iReturn = c.ConfigurationId;
                return iReturn;
            }
        }

        #endregion
    }
}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.DAL;

namespace POS.BAL
{
    public class clsBDatabase
    {
        public static bool IsDatabaseExists(string databaseName)
        {
            using (clsDDatabase obj = new clsDDatabase())
            {
                return obj.IsDatabaseExists(databaseName);
            }
        }
        public static bool CreateDatabase(string databaseName, string databasePath)
        {
            using (clsDDatabase obj = new clsDDatabase())
            {
                return obj.CreateDatabase(databaseName, databasePath);
            }
        }
        public static bool CreateTables(string filePath, string databaseName)
        {
            using (clsDDatabase obj = new clsDDatabase())
            {
                return obj.CreateTables(filePath, databaseName);
            }
        }
        public static bool GetDatabaseFullBackup(string storagePath, string databaseName)
        {
            using (clsDDatabase obj = new clsDDatabase())
            {
                return obj.GetDatabaseFullBackup(storagePath, databaseName);
            }
        }
    }
}

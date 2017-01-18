using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.DAL;

namespace POS.BAL
{
    public class clsBBackupService
    {
        private readonly string _connectionString;
        private readonly string _backupFolderFullPath;
        public clsBBackupService(string connectionString, string backupFolderFullPath)
        {
            _connectionString = connectionString;
            _backupFolderFullPath = backupFolderFullPath;
        }
        public void BackupDatabase(string databaseName)
        {
            using (clsDBackupService objservice = new clsDBackupService(_connectionString, _backupFolderFullPath))
            {
                objservice.BackupDatabase(databaseName);
            }
        }
        public void BackupAllUserDatabases()
        {
            using (clsDBackupService objservice = new clsDBackupService(_connectionString, _backupFolderFullPath))
            {
                objservice.BackupAllUserDatabases();
            }
        }
    }
}

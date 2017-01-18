using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using Microsoft.SqlServer.Server;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management;

namespace POS.DAL
{
    public class clsDDatabase : DALBase
    {

        public bool IsDatabaseExists(string databaseName)
        {
            string sqlCreateDBQuery;
            bool result = false;
            try
            {
                SqlConnection tmpConn = new SqlConnection("Server=(local);Integrated security=SSPI;database=master");
                sqlCreateDBQuery = string.Format("SELECT database_id FROM sys.databases WHERE Name = '{0}'", databaseName);

                using (tmpConn)
                {
                    using (SqlCommand sqlCmd = new SqlCommand(sqlCreateDBQuery, tmpConn))
                    {
                        tmpConn.Open();

                        object resultObj = sqlCmd.ExecuteScalar();

                        int databaseID = 0;

                        if (resultObj != null)
                        {
                            int.TryParse(resultObj.ToString(), out databaseID);
                        }

                        tmpConn.Close();

                        result = (databaseID > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        public bool CreateDatabase(string databaseName, string databasePath)
        {
            SqlConnection tmpConn = new SqlConnection("Server=(local);Integrated security=SSPI;database=master");
            String str;
            str = "CREATE DATABASE " + databaseName + " ON PRIMARY " +
                 "(NAME = " + databaseName + ", " +
                 "FILENAME = '" + databasePath + "\\" + databaseName + ".mdf', SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
                 "LOG ON (NAME = " + databaseName + "_Log, FILENAME = '" + databasePath + "\\" + databaseName + ".ldf', SIZE = 1MB, MAXSIZE = 5MB, FILEGROWTH = 10%)";

            SqlCommand myCommand = new SqlCommand(str, tmpConn);
            try
            {
                tmpConn.Open();
                myCommand.ExecuteNonQuery();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
            finally
            {
                if (tmpConn.State == ConnectionState.Open)
                {
                    tmpConn.Close();
                }
            }
        }

        public bool CreateTables(string filePath, string databaseName)
        {
            try
            {
                FileInfo file = new FileInfo(filePath);
                string script = file.OpenText().ReadToEnd();
                SqlConnection conn = new SqlConnection("Server=(local);Integrated security=SSPI;database=" + databaseName);
                conn.Open();
                Server server = new Server(new ServerConnection(conn));
                server.ConnectionContext.ExecuteNonQuery(script);
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool GetDatabaseFullBackup(string storagePath, string databaseName)
        {
            SqlConnection tmpConn = new SqlConnection("Server=(local);Integrated security=SSPI;database=master");
            Server sqlServerInstance = new Server(new Microsoft.SqlServer.Management.Common.ServerConnection(tmpConn));
            Backup objBackup = new Backup();
            objBackup.Devices.AddDevice(storagePath, DeviceType.File);
            objBackup.Database = databaseName;
            objBackup.Action = BackupActionType.Database;
            objBackup.SqlBackup(sqlServerInstance);
            return true;
        }
    }
}

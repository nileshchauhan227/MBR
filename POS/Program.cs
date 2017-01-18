using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using POS.BAL;
using System.Configuration;

namespace POS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        private static Mutex mutex = null;
        [STAThread]
        static void Main()
        {
            const string appName = "POS - TIS";
            bool createdNew;

            mutex = new Mutex(true, appName, out createdNew);

            if (!createdNew)
            {
                //app is already running! Exiting the application   
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmMaintainBill());
            //Application.Run(new Master());

            bool dbcreated = false, usrtableexists = false, isActivationExists = false;
            string databasePath = string.Empty;
            string databasename = ConfigurationManager.AppSettings.Get("DATABASENAME");// _" + Guid.NewGuid().ToString().Replace("-","");
            if (!clsBDatabase.IsDatabaseExists(databasename))
            {
                FolderBrowserDialog folderBrowse = new FolderBrowserDialog();
                folderBrowse.Description = "Specify the database folder";
                folderBrowse.ShowNewFolderButton = true;
                DialogResult result = folderBrowse.ShowDialog();
                if (result == DialogResult.OK)
                {
                    databasePath = folderBrowse.SelectedPath;
                    if (clsBDatabase.CreateDatabase(databasename, databasePath))
                    {
                        dbcreated = true;
                    }
                }
                else
                {
                    Application.Exit();
                }
            }
            else
            {
                dbcreated = true;
            }
            if (dbcreated && clsBDatabase.CreateTables(Environment.CurrentDirectory + "/UserMgt.sql", databasename))
            {
                usrtableexists = true;
            }
            if (dbcreated && usrtableexists && clsBConfiguration.GetAllRecordsList().Count > 0)
            {
                isActivationExists = true;
            }
            else if(dbcreated && usrtableexists)
            {
                using (var objChildform = new CompanySetup(databasePath))
                {
                    objChildform.DatabasePath = databasePath;
                    var result = objChildform.ShowDialog();
                    if (result == DialogResult.OK && clsBDatabase.CreateTables(Environment.CurrentDirectory + "/TISPOSDB.sql", databasename) && clsBDatabase.CreateTables(Environment.CurrentDirectory + "/Data.sql", databasename))
                    {
                        isActivationExists = true;
                    }
                    else
                        isActivationExists = false;
                }
                //dialog form to take entry of user . 
                
            }
            if (dbcreated && usrtableexists && isActivationExists)
            {
                Application.Run(new Login());
                //Application.Run(new Server());
            }
            else
                Application.Exit();
        }
    }
}

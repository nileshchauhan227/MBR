using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using POS.DAL;

namespace POS.BAL
{
    public class clsBReports
    {
        public static DataSet GetEODReport(DateTime FromDate)
        {
            using (clsDReports clsDReports = new clsDReports())
            {
                return clsDReports.GetEODReport(FromDate);
            }
        }
        public static DataSet Reports(String SpName, DateTime FromDate, DateTime ToDate)
        {
            using (clsDReports clsDReports = new clsDReports())
            {
                return clsDReports.Reports(SpName, FromDate, ToDate);
            }
        }
        public static DataSet GetBillDetail(int Billid)
        {
            using (clsDReports clsDReports = new clsDReports())
            {
                return clsDReports.GetBillDetail(Billid);
            }
        }
    }
}

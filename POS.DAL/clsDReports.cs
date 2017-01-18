using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace POS.DAL
{
    public class clsDReports : DALBase
    {

        public DataSet GetEODReport(DateTime FromDate)
        {
            string spName = "EODReport";
            SqlParameter[] param =  {
                                    new SqlParameter("@FromDate",FromDate)
                                    };
            DataSet ds = SqlHelper.ExecuteDataset(spName, param);
            return ds;
        }
        public DataSet Reports(String SpName, DateTime FromDate, DateTime ToDate)
        {
            string spName = SpName;
            SqlParameter[] param =  {
                                    new SqlParameter("@FromDate",FromDate),
                                    new SqlParameter("@ToDate",ToDate)
                                    };
            DataSet ds = SqlHelper.ExecuteDataset(spName, param);
            return ds;
        }

        public static DataSet GetBillDetail(int Billid)
        {
            String connectionString = ConfigurationManager.AppSettings["Connection"].ToString();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    cmd.CommandText = "GetBillDetail";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@BillId", Billid);
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    ds.Tables.Add(dt);

                    cmd.CommandText = "GetConfiguration";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    SqlDataReader dr1 = cmd.ExecuteReader();
                    DataTable dt1 = new DataTable();
                    dt1.Load(dr1);
                    ds.Tables.Add(dt1);

                    //string spName = procedurename;
                    //SqlParameter[] param =  {
                    //                        new SqlParameter("@BillId",Billid),
                    //                        };
                    //DataSet ds = SqlHelper.ExecuteDataset(spName, param);
                    return ds;
                }
            }
        }
    }
}

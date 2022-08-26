using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace TestTask_2.WorkWithDB
{
    public static class dbConn
    {
        public static bool GetConnection(out SqlConnection conn)
        {
            //string dir = Directory.GetCurrentDirectory();
            //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + dir + @"\TestDb.mdf;Integrated Security=True";
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mikheev_av1\source\repos\TestTask_2\TestTask_2\App_Data\TestDb.mdf;Integrated Security=True";
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn = null;
            return false;
        }
    }
}
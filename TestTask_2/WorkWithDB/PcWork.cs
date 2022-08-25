using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TestTask_2.Models;

namespace TestTask_2.WorkWithDB
{
    public class PcWork
    {
        string query;
        SqlCommand cmd;
        SqlConnection conn;

        public void AddUser(Pc item)
        {
            if (dbConn.GetConnection(out conn))
            {
                query = "INSERT PC ('Cpu', 'Memory', 'Hdd') VALUES (@Cpu, @Memory, @Hdd)";
                cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("Cpu", item.Cpu);
                cmd.Parameters.AddWithValue("Memory", item.Memory);
                cmd.Parameters.AddWithValue("Hdd", item.Hdd);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {

                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }

        public void UpdateUser(Pc item)
        {
            if (dbConn.GetConnection(out conn))
            {
                query = "UPDATE PC SET Cpu=@Cpu, Memory=@Memory, Hdd=@Hdd WHERE Id=@Id";
                cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("Cpu", item.Cpu);
                cmd.Parameters.AddWithValue("Memory", item.Memory);
                cmd.Parameters.AddWithValue("Hdd", item.Hdd);
                cmd.Parameters.AddWithValue("Id", item.Id);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {

                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }

        public void DeleteUser(Pc item)
        {
            if (dbConn.GetConnection(out conn))
            {
                query = "DELETE FROM PC WHERE Id=@Id";
                cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("Id", item.Id);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {

                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }
    }
}
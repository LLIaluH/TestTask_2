using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TestTask_2.Models;
using Newtonsoft.Json;

namespace TestTask_2.WorkWithDB
{
    public class PcContext
    {
        string query;
        SqlCommand cmd;
        SqlConnection conn;

        public string Get()
        {
            string result = "";
            if (dbConn.GetConnection(out conn))
            {
                query = "SELECT * FROM PC";
                cmd = conn.CreateCommand();
                cmd.CommandText = query;
                try
                {
                    var reader = cmd.ExecuteReader();
                    var dt = new DataTable();
                    dt.Load(reader);
                    //Возвращаю Json для подготовки к третьему заданию (Web-компоненты)
                    result = JsonConvert.SerializeObject(dt);
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
            return result;
        }

        public void Insert(Pc item)
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

        public void Update(Pc item)
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

        public void Delete(Pc item)
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
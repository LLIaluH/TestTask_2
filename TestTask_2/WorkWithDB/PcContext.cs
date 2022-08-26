using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TestTask_2.Models;
using Newtonsoft.Json;
using TestTask_2.Models.Abstract;
using TestTask_2.WorkWithDB.Interfaces;

namespace TestTask_2.WorkWithDB
{
    public class PcContext : IContext
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

        public void Insert(Model model)
        {
            Pc item = model as Pc;
            if (item != null && dbConn.GetConnection(out conn))
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

        public void Update(Model model)
        {
            Pc item = model as Pc;
            if (item != null && dbConn.GetConnection(out conn))
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

        public void Delete(Model model)
        {
            Pc item = model as Pc;
            if (item != null && dbConn.GetConnection(out conn))
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
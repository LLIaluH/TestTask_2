using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TestTask_2.Models;
using TestTask_2.Models.Abstract;
using TestTask_2.WorkWithDB.Interfaces;

namespace TestTask_2.WorkWithDB
{
    public class DepartamentsContext : IContext
    {
        string query;
        SqlCommand cmd;
        SqlConnection conn;

        public string Get()
        {
            string result = "";
            if (dbConn.GetConnection(out conn))
            {
                query = "SELECT * FROM Departaments";
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

        //public void Insert<T>(T item) where T: Departament
        public void Insert(Model item)
        {
            if (item.GetType() == typeof(Departament))
            {
                item in Departament;
            }
            if (dbConn.GetConnection(out conn))
            {
                query = "INSERT Departaments ('Name') VALUES (@Name)";
                cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("Name", item.Name);
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

        public void Update(Departament item)
        {
            if (dbConn.GetConnection(out conn))
            {
                query = "UPDATE Departaments SET Name=@Name WHERE Id=@Id";
                cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("Cpu", item.Name);
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

        public void Delete(Departament item)
        {
            if (dbConn.GetConnection(out conn))
            {
                query = "DELETE FROM Departaments WHERE Id=@Id";
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
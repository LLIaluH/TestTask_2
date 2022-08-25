using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TestTask_2.Models;

namespace TestTask_2.WorkWithDB
{
    public class DepartamentsWork
    {
        string query;
        SqlCommand cmd;
        SqlConnection conn;

        public void AddUser(Departament item)
        {
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

        public void UpdateUser(Departament item)
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

        public void DeleteUser(Departament item)
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
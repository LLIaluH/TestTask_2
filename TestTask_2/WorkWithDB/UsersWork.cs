using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TestTask_2.Models;

namespace TestTask_2.WorkWithDB
{
    public class UsersWork
    {
        string query;
        SqlCommand cmd;
        SqlConnection conn;

        public void AddUser(User item)
        {
            if (dbConn.GetConnection(out conn))
            {
                query = "INSERT Users ('UserName', 'Salary', 'DepartamentId', 'PCId') VALUES (@UserName, @Salary, @DepartamentId, @PCId)";
                cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("UserName", item.UserName);
                cmd.Parameters.AddWithValue("Salary", item.Salary);
                cmd.Parameters.AddWithValue("DepartamentId", item.DepartamentId);
                cmd.Parameters.AddWithValue("PCId", item.PCId);
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

        public void UpdateUser(User item)
        {
            if (dbConn.GetConnection(out conn))
            {
                query = "UPDATE Users SET UserName=@UserName, Salary=@Salary, DepartamentId=@DepartamentId, PCId=@PCId WHERE Id=@Id";
                cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("UserName", item.UserName);
                cmd.Parameters.AddWithValue("Salary", item.Salary);
                cmd.Parameters.AddWithValue("DepartamentId", item.DepartamentId);
                cmd.Parameters.AddWithValue("PCId", item.PCId);
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

        public void DeleteUser(User item)
        {
            if (dbConn.GetConnection(out conn))
            {
                query = "DELETE FROM Users WHERE Id=@Id";
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
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

        public void AddUser(User user)
        {
            if (dbConn.GetConnection(out conn))
            {
                query = "INSERT Users ('UserName', 'Salary', 'DepartamentId', 'PCId') VALUES (@UserName, @Salary, @DepartamentId, @PCId)";
                cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("UserName", user.UserName);
                cmd.Parameters.AddWithValue("Salary", user.Salary);
                cmd.Parameters.AddWithValue("DepartamentId", user.DepartamentId);
                cmd.Parameters.AddWithValue("PCId", user.PCId);
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

        public void UpdateUser(User user)
        {
            if (dbConn.GetConnection(out conn))
            {
                query = "UPDATE Users SET UserName=@UserName, Salary=@Salary, DepartamentId=@DepartamentId, PCId=@PCId WHERE Id=@Id";
                cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("UserName", user.UserName);
                cmd.Parameters.AddWithValue("Salary", user.Salary);
                cmd.Parameters.AddWithValue("DepartamentId", user.DepartamentId);
                cmd.Parameters.AddWithValue("PCId", user.PCId);
                cmd.Parameters.AddWithValue("Id", user.Id);
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

        public void DeleteUser(User user)
        {
            if (dbConn.GetConnection(out conn))
            {
                query = "DELETE FROM Users WHERE Id=@Id";
                cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("Id", user.Id);
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
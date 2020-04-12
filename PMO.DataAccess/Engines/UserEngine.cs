
using PMO.Models.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PMO.DataAccess.Engines
{
    public class UserEngine : BaseEngine, IUserEngine
    {
        public UserEngine()
        {

        }

        public PmoUser AuthenticateUser(string empId, string passkey)
        {
            string sql = "AuthenticateUser";
            PmoUser user = null;
            using (var connection = new SqlConnection(this.connectionString))
            {
                var sqlCommand = new SqlCommand(sql, connection);
                sqlCommand.Parameters.Add(new SqlParameter("@UserName", empId));
                sqlCommand.Parameters.Add(new SqlParameter("@Passkey", passkey));
                sqlCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    var reader = sqlCommand.ExecuteReader();                    
                    while (reader.Read())
                    {
                        user = new PmoUser();
                        user.EmpName = reader["EmpName"].ToString();
                        user.EmpNo = reader["Emp_No"].ToString();
                        user.Designation = reader["Designation"].ToString();
                        user.Department = reader["Department"].ToString();
                        user.Location = reader["Location"].ToString();
                        user.IsAdmin = reader["AdminID"].ToString() == "N" ? false : true;
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {

                    throw;
                }

                return user;
            }
        }
    }
}

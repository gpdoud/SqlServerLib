using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;

using System;
using System.Collections.Generic;

namespace SqlServerLibrary {

    public class SqlServerLib {

        SqlConnection sqlConn = null;


        public bool UserChange(User user) {
            if (sqlConn == null) { throw new Exception("No connection"); }
            var sql = " UPDATE [Users] Set "
                        + " Username = @Username, "
//                        + " Password = @Password, "
                        + " FirstName = @FirstName, "
                        + " LastName = @LastName, "
                        + " Phone = @Phone, "
                        + " Email = @Email, "
                        + " IsReviewer = @IsReviewer, "
                        + " IsAdmin = @IsAdmin "
                        + " Where Id = @Id; ";
            var sqlcmd = new SqlCommand(sql, sqlConn);
            sqlcmd.Parameters.AddWithValue("@Username", user.Username);
            //sqlcmd.Parameters.AddWithValue("@Password", user.Password);
            sqlcmd.Parameters.AddWithValue("@FirstName", user.FirstName);
            sqlcmd.Parameters.AddWithValue("@LastName", user.LastName);
            sqlcmd.Parameters.AddWithValue("@Phone", user.Phone);
            sqlcmd.Parameters.AddWithValue("@Email", user.Email);
            sqlcmd.Parameters.AddWithValue("@IsReviewer", user.Reviewer);
            sqlcmd.Parameters.AddWithValue("@IsAdmin", user.Admin);
            sqlcmd.Parameters.AddWithValue("@Id", user.Id);
            var rowsAffected = sqlcmd.ExecuteNonQuery();

            return rowsAffected == 1;
        }

        public bool UserCreate(User user) {
            if(sqlConn == null) { throw new Exception("No connection"); }
            var sql = " INSERT into [Users] "
                        + " (Username, Password, FirstName, LastName, Phone, Email, IsReviewer, IsAdmin) "
                        + " VALUES "
                        + " (@Username, @Password, @FirstName, @LastName, @Phone, @Email, @Reviewer, @Admin) ";
            var sqlcmd = new SqlCommand(sql, sqlConn);
            sqlcmd.Parameters.AddWithValue("@Username", user.Username);
            sqlcmd.Parameters.AddWithValue("@Password", user.Password);
            sqlcmd.Parameters.AddWithValue("@FirstName", user.FirstName);
            sqlcmd.Parameters.AddWithValue("@LastName", user.LastName);
            sqlcmd.Parameters.AddWithValue("@Phone", user.Phone);
            sqlcmd.Parameters.AddWithValue("@Email", user.Email);
            sqlcmd.Parameters.AddWithValue("@Reviewer", user.Reviewer);
            sqlcmd.Parameters.AddWithValue("@Admin", user.Admin);
            var rowsAffected = sqlcmd.ExecuteNonQuery();
            return rowsAffected == 1;
        }

        public User UserGetByPK(int Id) {
            if (sqlConn == null) {
                throw new Exception("No connection!");
            }
            var sql = "SELECT * from [Users] Where Id = @Id";
            var sqlcmd = new SqlCommand(sql, sqlConn);
            sqlcmd.Parameters.AddWithValue("@Id", Id);
            var reader = sqlcmd.ExecuteReader();
            if(!reader.HasRows) {
                reader.Close();
                return null;
            }
            reader.Read();
            var user = new User();
            user.Id = Convert.ToInt32(reader["Id"]);
            user.Username = Convert.ToString(reader["Username"]);
            user.FirstName = Convert.ToString(reader["Firstname"]);
            user.LastName = Convert.ToString(reader["Lastname"]);
            user.Phone = Convert.ToString(reader["Phone"]);
            user.Email = Convert.ToString(reader["Email"]);
            user.Reviewer = Convert.ToBoolean(reader["IsReviewer"]);
            user.Admin = Convert.ToBoolean(reader["IsAdmin"]);
            reader.Close();
            return user;
        }

        public List<User> UserGetAll() {
            if(sqlConn == null) {
                throw new Exception("No connection!");
            }
            var sql = "SELECT * From [Users];";
            var sqlcmd = new SqlCommand(sql, sqlConn);
            var reader = sqlcmd.ExecuteReader();
            var users = new List<User>();
            while(reader.Read()) {
                var user = new User();
                user.Id = Convert.ToInt32(reader["Id"]);
                user.Username = Convert.ToString(reader["Username"]);
                user.FirstName = Convert.ToString(reader["Firstname"]);
                user.LastName = Convert.ToString(reader["Lastname"]);
                user.Phone = Convert.ToString(reader["Phone"]);
                user.Email = Convert.ToString(reader["Email"]);
                user.Reviewer = Convert.ToBoolean(reader["IsReviewer"]);
                user.Admin = Convert.ToBoolean(reader["IsAdmin"]);
                users.Add(user);
            }
            reader.Close();
            return users;
        }

        public void Connect(string server, string database) {
            
            var connStr = $"server={server};" 
                            + $"database={database};"
                            + $"trusted_connection=true;";
            sqlConn = new SqlConnection(connStr);
            sqlConn.Open();
            if(sqlConn.State != System.Data.ConnectionState.Open) {
                throw new Exception("Connection did not open!");
            }

        }
        public void Disconnect() {
            if(sqlConn.State == System.Data.ConnectionState.Open) {
                sqlConn.Close();
            }
            sqlConn = null;
        }
    }
}

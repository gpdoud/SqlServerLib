using Microsoft.Data.SqlClient;

using System;

namespace SqlServerLibrary {

    public class SqlServerLib {

        SqlConnection sqlConn;

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
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Infrastructure
{
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Configuration;

    public class Database
    {
        private readonly SqlConnection _connection;

        public Database()
        {
            string connectionStr = ConfigurationManager.ConnectionStrings["localhostconnection"].ConnectionString;

            _connection = new SqlConnection(connectionStr);

            _connection.Open();
        }


        public DbDataReader ExecuteReader(string query)
        {
           
            var sqlQuery = new SqlCommand(query, _connection);

            return sqlQuery.ExecuteReader();
        }

        public int ExecuteNonQuery(string query)
        {
            var sqlQuery = new SqlCommand(query, _connection);

            return sqlQuery.ExecuteNonQuery();
        }

    }
}
using DbContextAdoNet.DataAccess;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DbContextAdoNet.Extensions;

namespace DbContextAdoNet
{
    public class DbContext
    {
        private readonly string connectionString;

        public DbContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<IDataReader> Execute(string Sqlexpression)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                SqlCommand command = new SqlCommand(Sqlexpression, connection);
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    yield return dataReader;
                }

                dataReader.Close();
            }

        }

        public IEnumerable<string> GetValues(string tablename, string column)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                var query = string.Format(Queries.selecFromColumn, column, tablename);
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    yield return dataReader.GetColumnValue(column);
                }

                dataReader.Close();
            }

        }


        public void Insert(string tablename, params SqlParameter[] parameters)
        {
            var sqlparams = Queries.GetInsertParams(parameters);
            string sqlexpression = string.Format(Queries.insertWithParams, tablename, sqlparams.Column, sqlparams.Value);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                SqlCommand command = new SqlCommand(sqlexpression, connection);
                command.Parameters.AddRange(parameters);
                command.ExecuteNonQuery();
            }

        }

        public void Update(string tablename, int id, params SqlParameter[] parameter)
        {
            string sqlparams = Queries.GetUpdateParams(parameter);
            string sqlexpression = string.Format(Queries.updateWithParam,
                 tablename, sqlparams, id);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                SqlCommand command = new SqlCommand(sqlexpression, connection);
                command.Parameters.AddRange(parameter);
                command.ExecuteNonQuery();
            }

        }

        public void Delete(string tablename, int id)
        {
            string sqlexpression = string.Format(Queries.deleteWithId, tablename, id);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                SqlCommand command = new SqlCommand(sqlexpression, connection);
                command.ExecuteNonQuery();
            }

        }



    }
}

using DbContextAdoNet.DataAccess;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

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

        public void Insert(string tablename, params SqlParameter[] parameters)
        {
            var sqlparams = GetInsertParams(parameters);
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
            string sqlparams = GetUpdateParams(parameter);
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
            string sqlexpression = string.Format(Queries.deleteWithParam, tablename, id);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                SqlCommand command = new SqlCommand(sqlexpression, connection);
                command.ExecuteNonQuery();
            }

        }



        private (string Column, string Value) GetInsertParams(SqlParameter[] parameters)
        {
            StringBuilder columns = new StringBuilder();
            StringBuilder values = new StringBuilder();
            foreach (var parameter in parameters)
            {
                columns.Append("[").Append(parameter.ParameterName).Append("]").Append(",");
                values.Append("@").Append(parameter.ParameterName).Append(",");
            }

            return (columns.ToString().TrimEnd(','), values.ToString().TrimEnd(','));
        }


        private string GetUpdateParams(SqlParameter[] parameters)
        {
            StringBuilder updatevalues = new StringBuilder();
            foreach (var parameter in parameters)
            {

                updatevalues.Append("[").Append(parameter.ParameterName).Append("]")
                    .Append("=").Append("@").Append(parameter.ParameterName).Append(",");
            }

            return updatevalues.ToString().TrimEnd(',');
        }


    }
}

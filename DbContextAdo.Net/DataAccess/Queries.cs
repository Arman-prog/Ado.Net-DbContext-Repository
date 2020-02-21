using System.Data.SqlClient;
using System.Text;

namespace DbContextAdoNet.DataAccess
{
    public class Queries
    {
        public const string insertWithParams = "INSERT INTO {0} ({1}) VALUES ({2})";//SELECT CAST(scope_identity() AS int)";
        public const string updateWithParam = "UPDATE {0} SET {1} WHERE Id={2}";
        public const string deleteWithId = "DELETE FROM {0} WHERE Id='{1}'";
        public const string selectWithTableName = "SELECT * FROM {0} ";
        public const string selecFromColumn = "SELECT [{0}] FROM {1} ";

        public static (string Column, string Value) GetInsertParams(SqlParameter[] parameters)
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

        public static string GetUpdateParams(SqlParameter[] parameters)
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


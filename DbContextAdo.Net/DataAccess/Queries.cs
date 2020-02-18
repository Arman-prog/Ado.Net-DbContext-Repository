
namespace DbContextAdoNet.DataAccess
{
    public class Queries
    {
        public const string insertWithParams = "INSERT INTO {0} ({1}) VALUES ({2})";//SELECT CAST(scope_identity() AS int)";
        public const string updateWithParam = "UPDATE {0} SET {1} WHERE Id={2}";
        public const string deleteWithParam = "DELETE FROM {0} WHERE Id='{1}'";

    }
}

using DbContextAdoNet.Attributes;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace DbContextAdoNet.Extensions
{
    public static class ModelExtension
    {
        public static SqlParameter[] ToSqlParameter<TModel>(this TModel model)
            where TModel : class, new()
        {
            var type = model.GetType();
            var members = type.GetProperties()
                .Where(p => p.GetCustomAttribute<IgnoreAttribute>() == null &&
                p.GetCustomAttribute<KeyAttribute>() == null && p.GetValue(model) != null)
                .ToList();

            SqlParameter[] parameters = new SqlParameter[members.Count];
            int i = 0;
            foreach (var member in members)
            {
                var value = member.GetValue(model);
                parameters[i++] = new SqlParameter(member.Name.ToString(), value.ToString());
            }
            return parameters;
        }

        public static string GetTableName<TModel>(this TModel model)
            where TModel : class, new()
        {
            var type = model.GetType();
            var attribute = type.GetCustomAttribute<TableNameAttribute>();
            return attribute == null ? type.Name : attribute.TableName;
        }

    }
}

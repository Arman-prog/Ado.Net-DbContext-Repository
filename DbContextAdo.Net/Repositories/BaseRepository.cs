using DbContextAdoNet.DataAccess;
using DbContextAdoNet.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace DbContextAdoNet.Repositories
{
    public class BaseRepository<TModel> : IBaseRepository<TModel>
         where TModel : class, new()
    {
        private DbContext _dbContext;

        public BaseRepository(DbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public IEnumerable<TModel> AsEnumerable()
        {
            var type = typeof(TModel);
            string query = string.Format(Queries.selectWithTableName, type.Name);

            foreach (var reader in _dbContext.Execute(query))
            {
                yield return reader.ToModel<TModel>();
            }
        }

        public bool Add(TModel model)
        {
           return _dbContext.Insert(model.GetTableName(), model.ToSqlParameter());
        }

        public bool RemoveAt(int id)
        {
            TModel model = new TModel();
            if (Contains("Id",id.ToString()))
            {
               return _dbContext.Delete(model.GetTableName(), id);              
            }
            return false;
        }

        public bool Update(int id,TModel model)
        {           
            if (Contains("Id",id.ToString()))
            {
               return _dbContext.Update(model.GetTableName(), id, model.ToSqlParameter());                
            }
            return false;
        }

        public bool Contains(string column, string value)
        {            
            TModel model = new TModel();
            var values = _dbContext.GetValues(model.GetTableName(), column).ToList();
            return values.Contains(value);
        }

    }
}

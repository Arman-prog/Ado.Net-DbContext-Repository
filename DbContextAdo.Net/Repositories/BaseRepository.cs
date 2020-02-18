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

        public void Add(TModel model)
        {
            _dbContext.Insert(model.GetTableName(), model.ToSqlParameter());
        }

        public bool RemoveAt(int id)
        {            
            var type = typeof(TModel);
            if (Contains("Id",id.ToString()))
            {
                _dbContext.Delete(type.Name, id);
                return true;
            }
            return false;
        }

        public void Update()
        {

        }


        public bool Contains(string column, string value)
        {
            var type = typeof(TModel);
            var values = _dbContext.GetValues(type.Name, column).ToList();
            return values.Contains(value);
        }

    }
}

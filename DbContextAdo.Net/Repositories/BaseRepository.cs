﻿using DbContextAdoNet.DataAccess;
using DbContextAdoNet.Extensions;
using System.Collections.Generic;

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

       
    }
}

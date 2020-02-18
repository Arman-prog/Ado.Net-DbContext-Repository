using System.Collections.Generic;

namespace DbContextAdoNet.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class, new()
    {
        IEnumerable<TEntity> AsEnumerable();
        void Add(TEntity model);

        bool RemoveAt(int id);

        bool Contains(string column, string value);
    }
}

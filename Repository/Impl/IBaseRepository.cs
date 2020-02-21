using System.Collections.Generic;

namespace Repository.Impl
{
    public interface IBaseRepository<TEntity> where TEntity : class, new()
    {
        IEnumerable<TEntity> AsReadable();
        bool Add(TEntity model);
        bool RemoveAt(int id);
        bool Update(int id, TEntity model);
        bool Contains(string column, string value);
    }
}

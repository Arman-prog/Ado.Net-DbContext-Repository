﻿using System.Collections.Generic;

namespace DbContextAdoNet.Repositories
{
    interface IBaseRepository<TEntity> where TEntity: class, new()
    {
        IEnumerable<TEntity> AsEnumerable(string query);
        void Add(TEntity model);
    }
}
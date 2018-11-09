using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fiap.StackOverflow.Core.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IQueryable<TEntity> Queryable();
        void Update(TEntity obj);
        void Remove(TEntity obj);
    }
}

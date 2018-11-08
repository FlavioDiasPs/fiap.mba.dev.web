using Fiap.StackOverflow.Core.Interfaces.Repositories.Base;
using Fiap.StackOverflow.Infra.Data.EntityFramework;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Fiap.StackOverflow.Infra.Data.Repositories.Base
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {

        private readonly StackOverflowContext _context;
        public RepositoryBase(StackOverflowContext context)
        {
            _context = context;
        }
        public void Add(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
            _context.SaveChanges();
        }

        public void Dispose()
        {
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }
        public IQueryable<TEntity> Get()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public void Remove(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}

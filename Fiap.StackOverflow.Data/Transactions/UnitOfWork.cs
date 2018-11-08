using Fiap.StackOverflow.Infra.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.StackOverflow.Infra.Data.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StackOverflowContext _context;

        public UnitOfWork(StackOverflowContext context)
        {
            _context = context;
        }

        public void BeginTransactionAnsyc()
        {
            _context.Database.BeginTransactionAsync();
        }
        public void Commit()
        {
            _context.Database.CommitTransaction();
        }
        public void RollbackTransaction()
        {
            _context.Database.RollbackTransaction();
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}

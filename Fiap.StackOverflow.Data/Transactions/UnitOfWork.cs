using Fiap.StackOverflow.Infra.Data.Context;
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

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}

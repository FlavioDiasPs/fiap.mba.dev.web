using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.StackOverflow.Infra.Data.Transactions
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}

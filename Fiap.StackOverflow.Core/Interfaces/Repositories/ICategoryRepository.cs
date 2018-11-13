using System.Collections.Generic;
using Fiap.StackOverflow.Core.Entities;
using Fiap.StackOverflow.Core.Interfaces.Repositories.Base;

namespace Fiap.StackOverflow.Core.Interfaces.Repositories
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        Category GetCompletedById(int id);
    }
}

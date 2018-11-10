using Fiap.StackOverflow.Core.Entities;
using Fiap.StackOverflow.Core.Interfaces.Repositories.Base;
using System;

namespace Fiap.StackOverflow.Core.Interfaces.Repositories
{
    public interface IAuthorRepository : IRepositoryBase<Author>
    {
        Author GetByIdentityId(string id);
        Author GetCompleteById(int id);
    }
}

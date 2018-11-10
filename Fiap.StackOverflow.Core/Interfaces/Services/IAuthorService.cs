using Fiap.StackOverflow.Core.Entities;
using Fiap.StackOverflow.Core.Interfaces.Services.Base;
using System;

namespace Fiap.StackOverflow.Core.Interfaces.Services
{
    public interface IAuthorService : IServiceBase<Author>
    {
        Author GetByIdentityId(string id);
    }
}

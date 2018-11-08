using Fiap.StackOverflow.Core.Entities;
using Fiap.StackOverflow.Core.Interfaces.Repositories;
using Fiap.StackOverflow.Infra.Data.EntityFramework;
using Fiap.StackOverflow.Infra.Data.Repositories.Base;

namespace Fiap.StackOverflow.Infra.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(StackOverflowContext context) : base(context)
        {
        }
    }
}

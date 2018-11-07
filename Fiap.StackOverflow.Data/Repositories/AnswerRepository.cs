using Fiap.StackOverflow.Core.Entities;
using Fiap.StackOverflow.Core.Interfaces.Repositories;
using Fiap.StackOverflow.Infra.Data.Repositories.Base;

namespace Fiap.StackOverflow.Infra.Data.Repositories
{
    public class AnswerRepository : RepositoryBase<Answer>, IAnswerRepository
    {
    }
}

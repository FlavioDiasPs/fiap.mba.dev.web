using Fiap.StackOverflow.Core.Entities;
using Fiap.StackOverflow.Core.Interfaces.Repositories;
using Fiap.StackOverflow.Infra.Data.EntityFramework;
using Fiap.StackOverflow.Infra.Data.Repositories.Base;

namespace Fiap.StackOverflow.Infra.Data.Repositories
{
    public class QuestionTagRepository : RepositoryBase<QuestionTag>, IQuestionTagRepository
    {
        private readonly StackOverflowContext _context;

        public QuestionTagRepository(StackOverflowContext context) : base(context)
        {
            _context = context;
        }

    }
}

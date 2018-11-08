using Fiap.StackOverflow.Core.Entities;
using Fiap.StackOverflow.Core.Interfaces.Repositories.Base;
using System.Linq;

namespace Fiap.StackOverflow.Core.Interfaces.Repositories
{
    public interface IQuestionRepository : IRepositoryBase<Question>
    {
        IQueryable<Question> GetQuestions();
        Question GetCompleteById(int id);
    }
}

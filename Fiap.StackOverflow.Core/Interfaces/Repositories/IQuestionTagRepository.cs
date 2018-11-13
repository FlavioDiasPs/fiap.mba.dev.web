using System.Collections.Generic;
using System.Linq;
using Fiap.StackOverflow.Core.Entities;
using Fiap.StackOverflow.Core.Interfaces.Repositories.Base;

namespace Fiap.StackOverflow.Core.Interfaces.Repositories
{
    public interface IQuestionTagRepository : IRepositoryBase<QuestionTag>
    {
        IQueryable<QuestionTag> GetQuestionsTagByTagId(int id);
        IQueryable<QuestionTag> GetTagCloud();
    }
}

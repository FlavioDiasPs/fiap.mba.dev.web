using Fiap.StackOverflow.Core.Entities;
using Fiap.StackOverflow.Core.Interfaces.Services.Base;
using System.Collections.Generic;

namespace Fiap.StackOverflow.Core.Interfaces.Services
{
    public interface IQuestionTagService : IServiceBase<QuestionTag>
    {
        IEnumerable<QuestionTag> GetQuestionsTagByTagId(int id);
    }
}

using Fiap.StackOverflow.Core.Entities;
using Fiap.StackOverflow.Core.Interfaces.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.StackOverflow.Core.Interfaces.Services
{
    public interface IQuestionService : IServiceBase<Question>
    {
        IEnumerable<Question> GetQuestions();
        Question GetCompleteById(int id);
        IEnumerable<Question> GetAllComplete();
        IEnumerable<Question> GetLastQuestions(int quantity);
    }
}

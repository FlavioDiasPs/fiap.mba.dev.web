﻿using Fiap.StackOverflow.Core.Entities;
using Fiap.StackOverflow.Core.Interfaces.Repositories.Base;
using System.Collections.Generic;
using System.Linq;

namespace Fiap.StackOverflow.Core.Interfaces.Repositories
{
    public interface IQuestionRepository : IRepositoryBase<Question>
    {
        IQueryable<Question> GetQuestions();
        Question GetCompleteById(int id);
        IQueryable<Question> GetAllComplete();

        IQueryable<Question> GetLastQuestions(int quantity);
        IQueryable<Question> GetQuestionsByTagId(int tagId);
    }
}

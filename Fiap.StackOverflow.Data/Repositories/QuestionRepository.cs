using Fiap.StackOverflow.Core.Entities;
using Fiap.StackOverflow.Core.Interfaces.Repositories;
using Fiap.StackOverflow.Infra.Data.EntityFramework;
using Fiap.StackOverflow.Infra.Data.Repositories.Base;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace Fiap.StackOverflow.Infra.Data.Repositories
{
    public class QuestionRepository : RepositoryBase<Question>, IQuestionRepository
    {
        private readonly StackOverflowContext _context;
        public QuestionRepository(StackOverflowContext context)
        {
            _context = context;
        }
        public IQueryable<Question> GetQuestions()
        {
            return _context.Questions
                        .Include(x => x.Answers)
                        .Include(x => x.Author);
        }
    }
}

﻿using Fiap.StackOverflow.Core.Entities;
using Fiap.StackOverflow.Core.Interfaces.Repositories;
using Fiap.StackOverflow.Infra.Data.EntityFramework;
using Fiap.StackOverflow.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Fiap.StackOverflow.Infra.Data.Repositories
{
    public class QuestionRepository : RepositoryBase<Question>, IQuestionRepository
    {
        private readonly StackOverflowContext _context;

        public QuestionRepository(StackOverflowContext context) : base(context)
        {
            _context = context;
        }
        public Question GetCompleteById(int id)
        {
            return _context.Questions
                .Include(x => x.Author)
                //.Include(x => x.Answers)
                //.Include(x => x.Answers.Select(y => y.Author))
                .FirstOrDefault(x => x.Id == id);
        }
        public IQueryable<Question> GetQuestions()
        {
            return _context.Questions
                        .Include(x => x.Answers)
                        .Include(x => x.Author);
        }
    }
}

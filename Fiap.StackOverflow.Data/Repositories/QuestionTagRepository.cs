﻿using System.Linq;
using Fiap.StackOverflow.Core.Entities;
using Fiap.StackOverflow.Core.Interfaces.Repositories;
using Fiap.StackOverflow.Infra.Data.EntityFramework;
using Fiap.StackOverflow.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Fiap.StackOverflow.Infra.Data.Repositories
{
    public class QuestionTagRepository : RepositoryBase<QuestionTag>, IQuestionTagRepository
    {
        private readonly StackOverflowContext _context;

        public QuestionTagRepository(StackOverflowContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<QuestionTag> GetQuestionsTagByTagId(int id)
        {
            return  _context.QuestionsTag
                .Include(x => x.Question)
                .Include("Question.Author")
                .Where(x => x.TagId == id);
        }

        public IQueryable<QuestionTag> GetTagCloud()
        {
            return _context.QuestionsTag;
        }
    }
}

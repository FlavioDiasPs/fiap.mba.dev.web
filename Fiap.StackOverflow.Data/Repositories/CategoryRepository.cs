using System.Collections.Generic;
using System.Linq;
using Fiap.StackOverflow.Core.Entities;
using Fiap.StackOverflow.Core.Interfaces.Repositories;
using Fiap.StackOverflow.Infra.Data.EntityFramework;
using Fiap.StackOverflow.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Fiap.StackOverflow.Infra.Data.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        private readonly StackOverflowContext _context;

        public CategoryRepository(StackOverflowContext context) : base(context)
        {
            _context = context;
        }

        public Category GetCompletedById(int id)
        {
            return _context.Categories
                .Include(x => x.Questions)
                .Include("Questions.Author")
                .FirstOrDefault(x => x.Id == id);
        }
    }
}

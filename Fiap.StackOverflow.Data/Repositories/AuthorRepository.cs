using Fiap.StackOverflow.Core.Entities;
using Fiap.StackOverflow.Core.Interfaces.Repositories;
using Fiap.StackOverflow.Infra.Data.EntityFramework;
using Fiap.StackOverflow.Infra.Data.Repositories.Base;
using System;
using System.Linq;

namespace Fiap.StackOverflow.Infra.Data.Repositories
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        private readonly StackOverflowContext _context;

        public AuthorRepository(StackOverflowContext context) : base(context)
        {
            _context = context;
        }

        public Author GetByIdentityId(string id)
        {
            return _context.Authors.FirstOrDefault(x => x.IdentityId.ToString() == id);
        }
    }
}

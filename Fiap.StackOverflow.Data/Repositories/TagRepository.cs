using System.Linq;
using Fiap.StackOverflow.Core.Entities;
using Fiap.StackOverflow.Core.Interfaces.Repositories;
using Fiap.StackOverflow.Infra.Data.EntityFramework;
using Fiap.StackOverflow.Infra.Data.Repositories.Base;

namespace Fiap.StackOverflow.Infra.Data.Repositories
{
    public class TagRepository : RepositoryBase<Tag>, ITagRepository
    {
        private readonly StackOverflowContext _context;

        public TagRepository(StackOverflowContext context) : base(context)
        {
            _context = context;
        }
    }
}

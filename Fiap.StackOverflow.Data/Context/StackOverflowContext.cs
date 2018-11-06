using Fiap.StackOverflow.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fiap.StackOverflow.Infra.Data.Context
{
    public class StackOverflowContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

    }
}

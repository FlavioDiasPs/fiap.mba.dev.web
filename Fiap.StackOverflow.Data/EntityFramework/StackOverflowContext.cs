using Fiap.StackOverflow.Core.Entities;
using Fiap.StackOverflow.Infra.Data.EntityFramework.Map;
using Microsoft.EntityFrameworkCore;

namespace Fiap.StackOverflow.Infra.Data.EntityFramework
{
    public class StackOverflowContext : DbContext
    {

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jonas\source\repos\Fiap.StackOverflow.Web\Fiap.StackOverflow.Data\App_Data\dbStackOverflow.mdf;Integrated Security=True;Connect Timeout=30;Database=DefaultConnection (AspnetIdentitySample); Trusted_Connection=Yes;Integrated Security=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //aplicar configurações
            modelBuilder.ApplyConfiguration(new MapQuestion());
            modelBuilder.ApplyConfiguration(new MapAnswser());

            base.OnModelCreating(modelBuilder);
        }

    }
}

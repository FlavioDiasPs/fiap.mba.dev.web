using Fiap.StackOverflow.Core.Entities;
using Fiap.StackOverflow.Infra.Data.EntityFramework.Map;
using Fiap.StackOverflow.Infra.Data.IdentityExtension;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;

namespace Fiap.StackOverflow.Infra.Data.EntityFramework
{
    public class StackOverflowContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public StackOverflowContext(DbContextOptions<StackOverflowContext> options) : base(options)
        {
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //aplicar configurações
            modelBuilder.ApplyConfiguration(new MapQuestion());
            modelBuilder.ApplyConfiguration(new MapAnswser());
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(string)))
                    {
                        property.AsProperty().Builder
                            .HasMaxLength(256, ConfigurationSource.Convention);
                        property.AsProperty().Builder
                            .IsUnicode(false, ConfigurationSource.Convention);
                    }

            base.OnModelCreating(modelBuilder);
        }
        


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=sqlserver01.mkth.hospedagemdesites.ws;Initial Catalog=mkth23;User ID=mkth23;Password=F14p#MBA*net1B");
        //}

    }
}

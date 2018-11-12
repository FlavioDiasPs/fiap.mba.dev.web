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
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //aplicar configurações
            modelBuilder.ApplyConfiguration(new MapAuthor());
            modelBuilder.ApplyConfiguration(new MapQuestion());
            modelBuilder.ApplyConfiguration(new MapAnswser());
            modelBuilder.ApplyConfiguration(new MapCategory());
            modelBuilder.ApplyConfiguration(new MapTag());
            modelBuilder.ApplyConfiguration(new MapQuestionTag());
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
        

        //"Data Source=sqlserver01.mkth.hospedagemdesites.ws;Initial Catalog=mkth23;User ID=mkth23;Password=F14p#MBA*net1B"
        //public string conn = "@\"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Jonas\\source\\repos\\Fiap.StackOverflow.Web\\Fiap.StackOverflow.Data\\App_Data\\dbStackOverflow.mdf;Integrated Security=True;Connect Timeout=30;Database=DefaultConnection (AspnetIdentitySample); Truste";
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jonas\source\repos\Fiap.StackOverflow.Web\Fiap.StackOverflow.Data\App_Data\dbStackOverflow.mdf;Integrated Security=True;Connect Timeout=30");
        //}

    }
}

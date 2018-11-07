using Fiap.StackOverflow.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiap.StackOverflow.Infra.Data.EntityFramework.Map
{
    public class MapUser : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //Tabela
            builder.ToTable("User");
            //Foreign-key
            //builder.HasOne(x => x.Usuario).WithMany().HasForeignKey("IdUsuario");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.HasMany(x => x.Questions)
                .WithOne(x => x.Author)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
            //builder.Property(x => x.UrlLogo).HasMaxLength(255).IsRequired();


        }
    }
}

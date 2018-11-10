using Fiap.StackOverflow.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiap.StackOverflow.Infra.Data.EntityFramework.Map
{
    public class MapAuthor : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            //Tabela
            builder.ToTable("Author");
            //Foreign-key
            //builder.HasOne(x => x.Usuario).WithMany().HasForeignKey("IdUsuario");
            //builder.HasOne(x => x.IdentityUser).WithMany().HasForeignKey("Id");

            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Questions)
                .WithOne(x => x.Author)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Answers)
                .WithOne(x => x.Author)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
            //builder.Property(x => x.UrlLogo).HasMaxLength(255).IsRequired();


        }
    }
}

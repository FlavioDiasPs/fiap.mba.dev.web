using Fiap.StackOverflow.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiap.StackOverflow.Infra.Data.EntityFramework.Map
{
    public class MapAnswser : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            //Tabela
            builder.ToTable("Answer");
            //Foreign-key
            builder.HasOne(x => x.Author).WithMany().HasForeignKey("AuthorId");
            //builder.HasOne(x => x.Question).WithMany().HasForeignKey("QuestionId");

            builder.HasKey(x => x.Id);
            //builder.Property(x => x.Nome).HasMaxLength(50).IsRequired();
            //builder.Property(x => x.UrlLogo).HasMaxLength(255).IsRequired();


        }
    }
}

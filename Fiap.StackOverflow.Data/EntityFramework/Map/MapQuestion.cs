using Fiap.StackOverflow.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.StackOverflow.Infra.Data.EntityFramework.Map
{
    public class MapQuestion : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            //Tabela
            builder.ToTable("Question");
            //Foreign-key
            builder.HasOne(x => x.Author).WithMany(x => x.Questions).HasForeignKey("AuthorId");

            builder.HasKey(x => x.Id);

            builder.HasMany(g => g.Answers)
                .WithOne(s => s.Question)
                .HasForeignKey(s => s.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder.Property(x => x.Nome).HasMaxLength(50).IsRequired();
            //builder.Property(x => x.UrlLogo).HasMaxLength(255).IsRequired();


        }
    }
}

using Fiap.StackOverflow.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiap.StackOverflow.Infra.Data.EntityFramework.Map
{
    public class MapQuestionTag : IEntityTypeConfiguration<QuestionTag>
    {
        public void Configure(EntityTypeBuilder<QuestionTag> builder)
        {
            //Tabela
            builder.ToTable("QuestionTag");

            //builder.HasOne(x => x.Question).WithMany().HasForeignKey("QuestionId");
            builder.HasOne(x => x.Tag).WithMany().HasForeignKey("TagId");




        }
    }
}

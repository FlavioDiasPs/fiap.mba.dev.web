using Fiap.StackOverflow.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiap.StackOverflow.Infra.Data.EntityFramework.Map
{
    public class MapTag : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            //Tabela
            builder.ToTable("Tag");

            builder.Property(x => x.Name)
                .HasMaxLength(128)
                .IsRequired();
        }
    }
}

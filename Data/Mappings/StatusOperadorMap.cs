using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;

namespace Models.Data.Mappings
{
    public class StatusOperadorMap : IEntityTypeConfiguration<StatusOperador>
    {
        public void Configure(EntityTypeBuilder<StatusOperador> builder)
        {
            // Define o nome da tabela
            builder.ToTable("StatusOperador");

            // Define a chave primária com Identity (auto incremento)
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
                   .UseIdentityColumn();

            // Define a propriedade 'Descricao' como obrigatória e com limite de caracteres
            builder.Property(s => s.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("NVARCHAR")
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }
}
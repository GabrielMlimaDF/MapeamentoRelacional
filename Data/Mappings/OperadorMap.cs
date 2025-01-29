using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;

namespace Models.Data.Mappings
{
    public class OperadorMap : IEntityTypeConfiguration<Operador>
    {
        public void Configure(EntityTypeBuilder<Operador> builder)
        {
            // Define o nome da tabela
            builder.ToTable("Operador");

            // Define a chave primária com Identity
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id)
                   .UseIdentityColumn();

            // Define a propriedade 'Nome' como obrigatória e com limite de caracteres
            builder.Property(o => o.Nome)
                .HasColumnName("Nome")
                .HasColumnType("NVARCHAR")
                   .IsRequired()
                   .HasMaxLength(150);

            // Configuração da chave estrangeira com StatusOperador
            builder.HasOne(o => o.StatusOperador)
                   .WithMany()
                   .HasForeignKey(o => o.StatusOperadorId)
                   .OnDelete(DeleteBehavior.Restrict); // Evita exclusão em cascata
        }
    }
}
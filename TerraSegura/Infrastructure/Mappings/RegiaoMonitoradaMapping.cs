using Microsoft.EntityFrameworkCore;
using TerraSegura.Domain.Entity;

namespace TerraSegura.Infrastructure.Mappings
{
    public class RegiaoMonitoradaMapping : IEntityTypeConfiguration<RegiaoMonitorada>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<RegiaoMonitorada> builder)
        {
            builder.ToTable("RegiaoMonitoradaNET");
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(r => r.Nome)
                .HasColumnName("Nome")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(r => r.Descricao)
                .HasColumnName("Descricao")
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(r => r.Latitude)
                .HasColumnName("Latitude")
                .IsRequired()
                .HasColumnType("NUMBER(9,6)");

            builder.Property(r => r.Longitude)
                .HasColumnName("Longitude")
                .IsRequired()
                .HasColumnType("NUMBER(9,6)");

            builder.Property(r => r.NivelRisco)
                .HasColumnName("NivelRisco")
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(50);

        }
    }
}

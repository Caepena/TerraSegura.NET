using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TerraSegura.Domain.Entity;

namespace TerraSegura.Infrastructure.Mappings
{
    public class SensorLeituraMapping : IEntityTypeConfiguration<SensorLeitura>
    {
        public void Configure(EntityTypeBuilder<SensorLeitura> builder)
        {
            builder.ToTable("SensorLeitura");

            builder.HasKey(sl => sl.Id);

            builder.Property(sl => sl.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(sl => sl.Valor)
                .HasColumnName("Valor")
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(sl => sl.DataHora)
                .HasColumnName("DataHora")
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(sl => sl.TipoSensor)
                .HasColumnName("TipoSensor")
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(50);
        }
    }
}

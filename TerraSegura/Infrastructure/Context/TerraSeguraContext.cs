using Microsoft.EntityFrameworkCore;
using TerraSegura.Domain.Entity;
using TerraSegura.Infrastructure.Mappings;

namespace TerraSegura.Infrastructure.Context
{
    public class TerraSeguraContext(DbContextOptions<TerraSeguraContext> options) : DbContext(options)
    {
        public DbSet<RegiaoMonitorada> regiaoMonitoradas { get; set; }
        public DbSet<SensorLeitura> sensorLeituras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RegiaoMonitoradaMapping());

            modelBuilder.ApplyConfiguration(new SensorLeituraMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}

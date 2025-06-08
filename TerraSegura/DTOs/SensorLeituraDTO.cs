namespace TerraSegura.DTOs
{
    namespace TerraSegura.DTOs
    {
        public class SensorLeituraCreateDto
        {
            public Guid RegiaoMonitoradaId { get; set; }
            public decimal Valor { get; set; }
            public DateTime DataHora { get; set; }
            public string TipoSensor { get; set; }
        }
    }

}

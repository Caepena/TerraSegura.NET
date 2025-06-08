using TerraSegura.Domain.Enums;

namespace TerraSegura.Domain.Entity
{
    public class SensorLeitura
    {
        public Guid Id { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataHora { get; private set; }
        public TipoSensor TipoSensor { get; private set; }
        public Guid RegiaoMonitoradaId { get; set; }

        public SensorLeitura(decimal valor, DateTime dataHora, TipoSensor tipoSensor, Guid regiaoMonitoradaId)
        {
            Valor = valor;
            DataHora = dataHora;
            TipoSensor = tipoSensor;
            RegiaoMonitoradaId = regiaoMonitoradaId;
        }
    }
}

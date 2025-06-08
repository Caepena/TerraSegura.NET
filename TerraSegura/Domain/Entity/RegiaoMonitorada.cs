using TerraSegura.Domain.Enums;

namespace TerraSegura.Domain.Entity
{
    public class RegiaoMonitorada
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Latitude { get; private set; }
        public decimal Longitude { get; private set; }
        public NivelRisco NivelRisco { get; private set; }

        public List<SensorLeitura> SensoresLeituras { get; private set; } = new List<SensorLeitura>();

        public RegiaoMonitorada(string nome, string descricao, decimal latitude, decimal longitude, NivelRisco nivelRisco)
        {
            Nome = nome;
            Descricao = descricao;
            Latitude = latitude;
            Longitude = longitude;
            NivelRisco = nivelRisco;
        }
    }
}

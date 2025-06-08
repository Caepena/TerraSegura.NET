using TerraSegura.Domain.Enums;

namespace TerraSegura.DTOs
{
    public class RegiaoMonitoradaCreateDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public NivelRisco NivelRisco { get; set; }
    }

}

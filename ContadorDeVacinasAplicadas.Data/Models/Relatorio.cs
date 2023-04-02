using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ContadorDeVacinasAplicadas.Data.Models
{
    public class Relatorio
    {
        public Relatorio(DateTime dataDaAplicacao)
        {
            Id = Guid.NewGuid();
            DataDoRelatorio = DateTime.Now;
            Descricao = $"Relatório Vacinas Pfizer aplicadas no RJ {dataDaAplicacao.ToString("dd/MM/yyyy")}";
            DataDaAplicacao= dataDaAplicacao;
        }

        [Key]
        public Guid Id { get; set; }
        public DateTime DataDoRelatorio { get; set; }
        public string Descricao { get; set; }
        public DateTime DataDaAplicacao { get; set; }
        public int QuantidadeDeVacinados { get; set; }

        [ForeignKey(nameof(Usuario))]
        public Guid IdUsuario { get; set; }
        [JsonIgnore]
        public virtual Usuario Usuario { get; set; }

    }
}

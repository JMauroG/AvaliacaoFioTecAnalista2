using System.Text.Json.Serialization;

namespace ContadorDeVacinasAplicadas.Data.ViewModel
{
    public class APIResponseViewModel
    {
        [JsonPropertyName("_scroll_id")]
        public string ScrollId { get; set; }

        [JsonPropertyName("took")]
        public int? Took { get; set; }

        [JsonPropertyName("timed_out")]
        public bool? TimedOut { get; set; }

        [JsonPropertyName("_shards")]
        public Shards? Shards { get; set; }

        [JsonPropertyName("hits")]
        public Hits? Hits { get; set; }
    }

    public class Shards
    {
        [JsonPropertyName("total")]
        public int? Total { get; set; }

        [JsonPropertyName("successful")]
        public int? Successful { get; set; }

        [JsonPropertyName("skipped")]
        public int? Skipped { get; set; }

        [JsonPropertyName("failed")]
        public int? Failed { get; set; }
    }

    public class Hits
    {
        [JsonPropertyName("total")]
        public Total? Total { get; set; }

        [JsonPropertyName("max_score")]
        public decimal? MaxScore { get; set; }

        [JsonPropertyName("hits")]
        public List<DadosAplicacaoVacina>? DadosAplicacaoVacinaList { get; set; }

    }

    public class Total
    {
        [JsonPropertyName("value")]
        public int? Value { get; set;}

        [JsonPropertyName("relation")]
        public string Relation { get; set; }
    }
}

using ContadorDeVacinasAplicadas.Utils.Enums;
using System.Text.Json.Serialization;

namespace ContadorDeVacinasAplicadas.Data.ViewModel
{
    public class DadosAplicacaoVacina
    {
        [JsonPropertyName("_index")]
        public string Index { get; set; }

        [JsonPropertyName("_type")]
        public string Type { get; set; }

        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("_score")]
        public decimal? Score { get; set; }

        [JsonPropertyName("_source")]
        public AplicacaoVacina? AplicacaoVacina { get; set; }
    }

    public class AplicacaoVacina
    {
        [JsonPropertyName("vacina_grupoAtendimento_nome")]
        public string NomeGrupoAtendimento { get; set; }

        [JsonPropertyName("vacina_codigo")]
        public string CodigoVacina { get; set; }

        [JsonPropertyName("paciente_dataNascimento")]
        public string DataNascimentoPaciente { get; set; }

        [JsonPropertyName("ds_condicao_maternal")]
        public string CondicaoMaternalDS { get; set; }

        [JsonPropertyName("paciente_endereco_nmPais")]
        public string NumeroPaisPaciente { get; set; }

        [JsonPropertyName("paciente_racaCor_valor")]
        public string RacaCorPaciente { get; set; }

        [JsonPropertyName("sistema_origem")]
        public string SistemaOrigem { get; set; }

        [JsonPropertyName("paciente_id")]
        public string IdPaciente { get; set; }

        [JsonPropertyName("paciente_endereco_uf")]
        public string UFPaciente { get; set; }

        [JsonPropertyName("paciente_idade")]
        public int? IdadePaciente { get; set; }

        [JsonPropertyName("paciente_endereco_cep")]
        public string CepPaciente { get; set; }

        [JsonPropertyName("estabelecimento_valor")]
        public string ValorEstabelecimento { get; set; }

        [JsonPropertyName("estabelecimento_municipio_codigo")]
        public string CodigoMunicipioEstabelecimento { get; set; }

        [JsonPropertyName("data_importacao_datalake")]
        public DateTime? DataImportacaoDataLake { get; set; }

        [JsonPropertyName("paciente_enumSexoBiologico")]
        public string SexoBiologicoPaciente { get; set; }

        [JsonPropertyName("estabelecimento_municipio_nome")]
        public string MunicipioEstabelecimento { get; set; }

        [JsonPropertyName("vacina_grupoAtendimento_codigo")]
        public string CodigoGrupoAtendimento { get; set; }

        [JsonPropertyName("vacina_descricao_dose")]
        public string DescricaoDoseVacina { get; set; }

        [JsonPropertyName("paciente_endereco_nmMunicipio")]
        public string NumeroMunicipioPaciente { get; set; }

        [JsonPropertyName("vacina_categoria_nome")]
        public string NomeCategoriaVacina { get; set; }

        [JsonPropertyName("vacina_fabricante_nome")]
        public string NomeFabricanteVacina { get; set; }

        [JsonPropertyName("vacina_categoria_codigo")]
        public string CodigoCategoriaVacina { get; set; }

        [JsonPropertyName("dt_deleted")]
        public DateTime? DataDelecao { get; set; }

        [JsonPropertyName("paciente_nacionalidade_enumNacionalidade")]
        public string NacionalidadePaciente { get; set; }

        [JsonPropertyName("vacina_numDose")]
        public string NumeroDoseVacina { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("document_id")]
        public string IdDocumento { get; set; }

        [JsonPropertyName("vacina_lote")]
        public string LoteVacina { get; set; }

        [JsonPropertyName("id_sistema_origem")]
        public string OrigemSistema { get; set; }

        [JsonPropertyName("@timestamp")]
        public DateTime? Timestamp { get; set; }

        [JsonPropertyName("estalecimento_noFantasia")]
        public string NomeFantasiaEstabelecimento { get; set; }

        [JsonPropertyName("@version")]
        public string Versao { get; set; }

        [JsonPropertyName("paciente_racaCor_codigo")]
        public string CodigoRacaCorPaciente { get; set; }

        [JsonPropertyName("estabelecimento_razaoSocial")]
        public string RazaoSocialEstabelecimento { get; set; }

        [JsonPropertyName("vacina_nome")]
        public string NomeVacina { get; set; }

        [JsonPropertyName("estabelecimento_uf")]
        public string UfEstabelecimento { get; set; }

        [JsonPropertyName("data_importacao_rnds")]
        public DateTime? DataImportacaoRNDS { get; set; }

        [JsonPropertyName("vacina_dataAplicacao")]
        public DateTime? DataAplicacao { get; set; }

        [JsonPropertyName("co_condicao_maternal")]
        public int? CondicaoMaternalCO { get; set; }

        [JsonPropertyName("paciente_endereco_coPais")]
        public string PaisCO { get; set; }

        [JsonPropertyName("vacina_fabricante_referencia")]
        public string ReferenciaFabricanteVacina { get; set; }

        [JsonPropertyName("paciente_endereco_coIbgeMunicipio")]
        public string IBGEMunicipioCOPaciente { get; set; }
    }
}

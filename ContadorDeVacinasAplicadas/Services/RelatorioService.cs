using Azure;
using ContadorDeVacinasAplicadas.API.Services.Interfaces;
using ContadorDeVacinasAplicadas.Data.Models;
using ContadorDeVacinasAplicadas.Data.Repositorios.Interfaces;
using ContadorDeVacinasAplicadas.Data.ViewModel;
using ContadorDeVacinasAplicadas.Utils.Helpers;
using System;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ContadorDeVacinasAplicadas.API.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly IRelatorioRepository _repository;

        public RelatorioService(IRelatorioRepository repository)
        {
            _repository = repository;
        }

        public async Task<Relatorio> RecuperarVacinasAplicadasPorData(GerarRelatorioViewModel model)
        {
            try
            {
                var relatorio = new Relatorio(model.DataAplicacao.Value);
                var apiResponse = await RecuperarDadosAPIVacina(model.DataAplicacao.Value);

                relatorio.QuantidadeDeVacinados = apiResponse.Count();

                return relatorio;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao preencher a quantidade de vacinas aplicadas no relatorio.\nErro:\n" + ex.Message);
            }
        }

        public async Task CadastrarRelatorioAsync(Relatorio relatorio)
        {
            try
            {
               await _repository.CadastrarRelatorioAsync(relatorio);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Relatorio>> RecuperarTodosRelatoriosAsync()
        {
            try
            {
                return await _repository.RecuperarTodosRelatoriosAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }


        private async Task<List<DadosAplicacaoVacina>> RecuperarDadosAPIVacina(DateTime dataAplicacao)
        {
            try
            {
                var client = SetupHttpClient();

                var apiResponseViewModel = await ExecutarRequisicaoPostAsync(dataAplicacao, client);

                var dadosAplicacaoVacinaList = new List<DadosAplicacaoVacina>();
                dadosAplicacaoVacinaList.AddRange(apiResponseViewModel.Hits.DadosAplicacaoVacinaList);

                var ultimaRequisicao = false;

                // Enquanto não chegarmos na ultima requisição necessária, retornaremos à api para recuperar os dados restantes
                while (ultimaRequisicao == false)
                {
                    apiResponseViewModel = await ExecutarRequisicaoGetAsync(apiResponseViewModel.ScrollId, client);

                    if (!apiResponseViewModel.Hits.DadosAplicacaoVacinaList.Any())
                    {
                        ultimaRequisicao = true;
                        break;
                    }

                    dadosAplicacaoVacinaList.AddRange(apiResponseViewModel.Hits.DadosAplicacaoVacinaList);
                }

                return dadosAplicacaoVacinaList;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao fazer a requisição para a API DataSUS \nErro:\n" + ex.Message);
            }
        }

        private HttpClient SetupHttpClient()
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "aW11bml6YWNhb19wdWJsaWM6cWx0bzV0JjdyX0ArI1Rsc3RpZ2k=");
            client.DefaultRequestHeaders.CacheControl = CacheControlHeaderValue.Parse("no-cache");

            var productValue = new ProductInfoHeaderValue("AvaliacaoFiotec", "1.0");
            client.DefaultRequestHeaders.UserAgent.Add(productValue);

            return client;
        }

        private async Task<APIResponseViewModel> ExecutarRequisicaoPostAsync(DateTime dataAplicacao, HttpClient client)
        {
            var url = "https://imunizacao-es.saude.gov.br/_search?scroll=1m";

            // Cria um novo DateTime para limpar as horas, minutos e segundos.
            var jsonDataAplicacao = new DateTime(dataAplicacao.Year, dataAplicacao.Month, dataAplicacao.Day);
            var requestBodyJson = JsonHelper.MontarJsonQuery(jsonDataAplicacao);

            var response = await client.PostAsync(url, new StringContent(requestBodyJson, null, "application/json"));
            response.EnsureSuccessStatusCode();


            string result = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<APIResponseViewModel>(result);
        }

        private async Task<APIResponseViewModel> ExecutarRequisicaoGetAsync(string scrollId, HttpClient client)
        {
            var requestBodyJson = JsonSerializer.Serialize(new { scroll_id = scrollId, scroll = "1m" });

            var url = "https://imunizacao-es.saude.gov.br/_search/scroll";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Content = new StringContent(requestBodyJson, Encoding.UTF8, "application/json");

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<APIResponseViewModel>(result);
        }
    }
}

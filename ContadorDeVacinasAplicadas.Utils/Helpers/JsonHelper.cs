using Newtonsoft.Json;

namespace ContadorDeVacinasAplicadas.Utils.Helpers
{
    public class JsonHelper
    {
        public static string MontarJsonQuery(DateTime dataAplicacao)
        {
            var queryBool = new QueryBool();

            // Lista de filtros no padrao exigido pelo elasticSearch
            var queryFilterList = new List<object>
            {
                new
                {
                    term = new
                    {
                        estabelecimento_uf = "RJ"
                    }
                },

                new
                {
                    term = new
                    {
                        vacina_fabricante_nome = "PFIZER"
                    }
                },

                new
                {
                    term = new
                    {
                        vacina_dataAplicacao = dataAplicacao
                    }
                }
            };

            queryBool.filter = queryFilterList;
           
            var query = new Query();
            query.Bool = queryBool;

            var requestBody = new RequestBody();
            requestBody.size = 10000;
            requestBody.query = query;

            var json = JsonConvert.SerializeObject(requestBody);

            // Remove algumas \ e renomeia o objeto bool por ser uma palavra reservada do C#
            json = json.Replace("\\", "");
            json = json.Replace("Bool", "bool");

            return json;
        }
    }

    public class RequestBody
    {
        public int size { get; set; }
        public Query query { get; set; }
    }

    public class Query
    {
        // objeto bool do query precisa ser com B maiusculo por ser uma palavra reservada
        public QueryBool Bool { get; set; }
    }

    public class QueryBool
    {
        public List<object> filter { get; set; }
    }

}

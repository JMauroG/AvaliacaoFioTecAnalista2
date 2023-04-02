using ContadorDeVacinasAplicadas.Data.Models;
using ContadorDeVacinasAplicadas.Data.ViewModel;

namespace ContadorDeVacinasAplicadas.API.Services.Interfaces
{
    public interface IRelatorioService
    {
        Task CadastrarRelatorioAsync(Relatorio relatorio);
        Task<Relatorio> RecuperarVacinasAplicadasPorData(GerarRelatorioViewModel model);
        Task<List<Relatorio>> RecuperarTodosRelatoriosAsync();
    }
}

using ContadorDeVacinasAplicadas.Data.Models;

namespace ContadorDeVacinasAplicadas.Data.Repositorios.Interfaces
{
    public interface IRelatorioRepository
    {
        Task CadastrarRelatorioAsync(Relatorio relatorio);
        Task<List<Relatorio>> RecuperarTodosRelatoriosAsync();
    }
}

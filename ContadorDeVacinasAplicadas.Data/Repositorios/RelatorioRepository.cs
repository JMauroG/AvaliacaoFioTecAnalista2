using ContadorDeVacinasAplicadas.Data.Models;
using ContadorDeVacinasAplicadas.Data.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContadorDeVacinasAplicadas.Data.Repositorios
{
    public class RelatorioRepository : IRelatorioRepository
    {
        private readonly AppDbContext _context;

        public RelatorioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CadastrarRelatorioAsync(Relatorio relatorio)
        {
            try
            {
                await _context.Relatorios.AddAsync(relatorio);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar um relatorio no banco de dados:\n" + ex.Message);
            }
        }

        public async Task<List<Relatorio>> RecuperarTodosRelatoriosAsync()
        {
            try
            {
                return await _context.Relatorios.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao recuperar os relatorios no banco de dados:\n" + ex.Message);
            }
        }

    }
}


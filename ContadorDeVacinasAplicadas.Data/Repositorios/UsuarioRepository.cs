using ContadorDeVacinasAplicadas.Data.Models;
using ContadorDeVacinasAplicadas.Data.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContadorDeVacinasAplicadas.Data.Repositorios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CadastrarUsuarioAsync(Usuario usuario)
        {
            try
            {
                await _context.Usuarios.AddAsync(usuario);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar usuario no banco de dados:\n " + ex.Message);
            }
        }

        public async Task<Usuario> RecuperarUsuarioPorCPFAsync(string cpf)
        {
            try
            {
                var usuario = await _context.Usuarios
                    .FirstOrDefaultAsync(x => x.CPF!.Equals(cpf));

                return usuario!;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar o usuario no banco de dados:\n " + ex.Message);
            }
        }
    }
}

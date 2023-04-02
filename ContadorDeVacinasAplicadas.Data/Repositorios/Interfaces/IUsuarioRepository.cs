using ContadorDeVacinasAplicadas.Data.Models;

namespace ContadorDeVacinasAplicadas.Data.Repositorios.Interfaces
{
    public interface IUsuarioRepository
    {
        Task CadastrarUsuarioAsync(Usuario usuario);
        Task<Usuario> RecuperarUsuarioPorCPFAsync(string cpf);
    }
}

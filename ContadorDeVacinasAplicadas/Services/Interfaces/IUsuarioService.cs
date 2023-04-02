using ContadorDeVacinasAplicadas.Data.Models;

namespace ContadorDeVacinasAplicadas.API.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task CadastrarUsuarioAsync(string Nome, string CPF);
        Task<Usuario> RecuperarUsuarioPorCPFAsync(string cpf);
    }
}

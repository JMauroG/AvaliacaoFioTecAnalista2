using ContadorDeVacinasAplicadas.API.Services.Interfaces;
using ContadorDeVacinasAplicadas.Data.Models;
using ContadorDeVacinasAplicadas.Data.Repositorios.Interfaces;

namespace ContadorDeVacinasAplicadas.API.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task CadastrarUsuarioAsync(string Nome, string CPF)
        {
            try
            {
                var usuarioCadastrado = await RecuperarUsuarioPorCPFAsync(CPF);

                if (usuarioCadastrado != null)
                    return;

                CPF = NormalizarCPF(CPF);
                usuarioCadastrado = new Usuario(Nome, CPF);

                await _repository.CadastrarUsuarioAsync(usuarioCadastrado);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao cadastrar Usuario");
            }
        }

        public async Task<Usuario> RecuperarUsuarioPorCPFAsync(string cpf)
        {
            try
            {
                cpf = NormalizarCPF(cpf);
                return await _repository.RecuperarUsuarioPorCPFAsync(cpf);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao Recuperar o usuario por CPF");
            }
        }


        private string NormalizarCPF(string cpf)
        {
            var str = cpf.Replace(".", "");
            str = str.Replace("-", "");
            return str;
        }
    }
}

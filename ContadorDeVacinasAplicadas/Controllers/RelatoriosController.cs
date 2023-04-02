using ContadorDeVacinasAplicadas.API.Services.Interfaces;
using ContadorDeVacinasAplicadas.Data.Models;
using ContadorDeVacinasAplicadas.Data.ViewModel;
using ContadorDeVacinasAplicadas.Data.ViewModel.Validations;
using ContadorDeVacinasAplicadas.Utils.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace ContadorDeVacinasAplicadas.API.Controllers
{
    /// <summary>
    /// Controlador referente a entidade Relatorio
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class RelatoriosController : ControllerBase
    {
        private readonly IRelatorioService _service;
        private readonly IUsuarioService _usuarioService;
        private readonly IValidationService _validationService;

        /// <summary>
        /// Construtor de RelatoriosController
        /// </summary>
        /// <param name="service">Serviço de Relatorios</param>
        public RelatoriosController(IRelatorioService service,
                                    IUsuarioService usuarioService,
                                    IValidationService validationService)
        {
            _service = service;
            _usuarioService = usuarioService;
            _validationService = validationService;
        }

        /// <summary>
        /// Retorna o relatório de vacinas PFIZER aplicadas no Rio de Janeiro no dia específicado.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RecuperarRelatorioVacinasAplicadasPorData([FromBody] GerarRelatorioViewModel model)
        {
            try
            {
                // Valida a viewModel utilizando o FluentValidation
                var validation = await _validationService.ValidateAsync<GerarRelatorioViewModelValidation, GerarRelatorioViewModel>(model);

                if (!validation.IsValid)
                    return BadRequest(new { erros = ErrorHelper.ListarErros(validation.Errors) });

                // Cadastra o usuario caso ele já não exista na base
                await _usuarioService.CadastrarUsuarioAsync(model.Nome, model.CPF);
                var usuario = await _usuarioService.RecuperarUsuarioPorCPFAsync(model.CPF);

                var relatorio = await _service.RecuperarVacinasAplicadasPorData(model);

                relatorio.IdUsuario = usuario.Id;

                await _service.CadastrarRelatorioAsync(relatorio);

                return Ok(relatorio);
            }
            catch (Exception)
            {
                return StatusCode(500, new { Mensagem = "Ocorreu um erro no servidor ao processar sua requisição!" });
            }
        }

        /// <summary>
        /// Retorna todos o relatórios salvos no banco
        /// </summary>
        /// <returns>Retorna uma lista de objetos do tipo Relatorio</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RecuperarRelatorios()
        {
            try
            {
                List<Relatorio> relatorios = await _service.RecuperarTodosRelatoriosAsync();

                if(relatorios == null)
                    return NotFound("Não há relatórios salvos no banco de dados!");

                return Ok(relatorios);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { Mensagem = "Ocorreu um erro no servidor ao processar sua requisição!" });
            }
        }

    }
}

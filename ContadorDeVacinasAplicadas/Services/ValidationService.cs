using ContadorDeVacinasAplicadas.API.Services.Interfaces;
using FluentValidation;
using FluentValidation.Results;

namespace ContadorDeVacinasAplicadas.API.Services
{
    public class ValidationService : IValidationService
    {
        public ValidationService() { }

        public async Task<ValidationResult> ValidateAsync<T1, T2>(T2 model)
            where T1 : IValidator<T2>
        {
            try
            {
                // Cria uma instancia generica para o validator
                var validator = (T1)Activator.CreateInstance(typeof(T1));

                return await validator.ValidateAsync(model);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

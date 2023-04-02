using FluentValidation;
using FluentValidation.Results;

namespace ContadorDeVacinasAplicadas.API.Services.Interfaces
{
    public interface IValidationService
    {
        Task<ValidationResult> ValidateAsync<T1, T2>(T2 model) where T1 : IValidator<T2>;
    }
}

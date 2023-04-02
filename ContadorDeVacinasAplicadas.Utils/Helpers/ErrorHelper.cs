using FluentValidation.Results;

namespace ContadorDeVacinasAplicadas.Utils.Helpers
{
    public class ErrorHelper
    {
        public static List<string> ListarErros(List<ValidationFailure> errors)
        {
            var errorList = new List<string>();

            foreach (var error in errors)
            {
                errorList.Add(error.ErrorMessage);
            }

            return errorList;
        }
    }
}

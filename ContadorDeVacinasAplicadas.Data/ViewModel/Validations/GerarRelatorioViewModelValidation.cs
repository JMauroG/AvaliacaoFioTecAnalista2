using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContadorDeVacinasAplicadas.Data.ViewModel.Validations
{
    public class GerarRelatorioViewModelValidation : AbstractValidator<GerarRelatorioViewModel>
    {
        public GerarRelatorioViewModelValidation()
        {
            RuleFor(x => x.Nome)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Nome é um dado obrigatório !")
                .NotEmpty().WithMessage("Nome é um dado obrigatório !");

            RuleFor(x => x.CPF)
               .Cascade(CascadeMode.Stop)
               .NotNull().WithMessage("CPF é um dado obrigatório !")
               .NotEmpty().WithMessage("CPF é um dado obrigatório !")
               .MaximumLength(14).WithMessage("CPF com tamanho inválido")
               .Must(ValidarCPF).WithMessage("CPF inválido !");

            RuleFor(x => x.DataAplicacao)
               .Cascade(CascadeMode.Stop)
               .NotNull().WithMessage("Data de aplicação é um dado obrigatório !")
               .NotEmpty().WithMessage("Data de aplicação é um dado obrigatório !")
               .Must(ValidarData).WithMessage("Data de aplicação não pode ser um dia futuro!");
        }

        public static bool ValidarCPF(string cpf)
        {
            var multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf;
            string digito;

            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        public static bool ValidarData(DateTime? DataAplicacao)
        {
            var dataAtual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            DataAplicacao = new DateTime(DataAplicacao.Value.Year, DataAplicacao.Value.Month, DataAplicacao.Value.Day);
            return !(DataAplicacao > dataAtual);
        }

    }


}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace ContadorDeVacinasAplicadas.Data.Models
{
    public class Usuario
    {
        public Usuario(string nome, string cpf)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            CPF = cpf;
        }

        public Usuario() { }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string? Nome { get; set; }

        [Required]
        public string? CPF { get; set; }
    }
}

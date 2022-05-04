using System.ComponentModel.DataAnnotations;

namespace PrimeiraAPI.Models.Entities.Clientes
{
    public class PostClientesRequest
    {
        [Required, MaxLength(120)]
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

    }
}

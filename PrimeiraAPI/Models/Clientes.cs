using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeiraAPI.Models
{

    [Table("clientes_padaria")]
    public class Clientes
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(120)]
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        [NotMapped]
        public string Idade { get; set; }

        
    }
}

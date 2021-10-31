using APIContaBanco.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIContaBanco.Models
{
    [Table("Endereco")]
    public class Endereco
    {
        [Key]
        public long Id { get; set; }

        public Cliente Cliente { get; set; }

        public long ClienteId { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string Logradouro { get; set; }

        [Required]
        [MaxLength(15)]
        public string Numero { get; set; }

        [Required]
        [MaxLength(100)]
        public string Cidade { get; set; }

        [Required]
        [MaxLength(20)]
        public string Cep { get; set; }

        public Estado Estado { get; set; }

        public Pais Pais { get; set; }
    }
}

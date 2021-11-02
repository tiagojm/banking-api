using APIContaBanco.Repository;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIContaBanco.Models
{
    [Table("Cliente")]
    public class Cliente : TEntity
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [MaxLength(100)]
        public string NomePreferencia { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public string FotoPath { get; set; }

        [NotMapped]
        public ICollection<TelefoneContato> Telefones { get; set; }
        
        public Endereco Endereco { get; set; }

        public ICollection<Conta> Contas { get; set; }

        public Cliente()
        {
            Telefones = new Collection<TelefoneContato>();
            Contas = new Collection<Conta>();
        }
    }
}

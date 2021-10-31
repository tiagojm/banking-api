using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIContaBanco.Models
{
    public class TipoConta
    {
        public long Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Descricao { get; set; }
    }
}

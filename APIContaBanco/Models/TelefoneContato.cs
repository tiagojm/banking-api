using APIContaBanco.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIContaBanco.Models
{
    
    [Keyless]
    public class TelefoneContato
    {
        public Cliente Cliente { get; set; }
        //public long ClienteId { get; set; }

        [Required]
        public TipoTelefone TipoTelefone { get; set; }

        [Required]
        public string Numero { get; set; }
    }
}

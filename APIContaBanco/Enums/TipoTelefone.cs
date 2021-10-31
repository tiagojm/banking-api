using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace APIContaBanco.Enums
{
    public enum TipoTelefone
    {
        [Description("Telefone Fixo")]
        TelefoneFIxo = 0,
        [Description("Celular")]
        Celular = 1
    }
}

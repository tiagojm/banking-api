using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace APIContaBanco.Enums
{
    public enum TipoOperacao
    {
        [Description("Crédito")]
        Credito = 0,
        [Description("Débito")]
        Debito = 1
    }
}

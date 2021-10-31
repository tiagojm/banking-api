using System;

namespace APIContaBanco.Interface
{
    public interface IConta
    {
        void OperacaoCredito(DateTime DataOperacao, double Valor);
        void OperacaoDebito(DateTime DataOperacao, double Valor);
    }
}

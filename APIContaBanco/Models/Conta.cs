using APIContaBanco.Enums;
using APIContaBanco.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIContaBanco.Models
{
    public class Conta : IConta
    {
        public long Id { get; set; }
        public TipoConta TipoConta { get; set; }
        protected internal double Saldo { get; set; }

        [NotMapped]
        public List<Operacao> Operacoes { get; set; }

        public Conta(double saldoInicial)
        {
            this.Saldo = saldoInicial;
        }

        public void OperacaoCredito(DateTime DataOperacao, double Valor)
        {
            var operacao = new Operacao(this, "Operação Padrão de Adição de Valor no Saldo", DateTime.Now, TipoOperacao.Credito, Valor, this.Saldo);
            operacao.Efetua();
        }

        public void OperacaoDebito(DateTime DataOperacao, double Valor)
        {
            var operacao = new Operacao(this, "Operação Padrão de Substração de Valor no Saldo", DateTime.Now, TipoOperacao.Debito, Valor, this.Saldo);
            operacao.Efetua();
        }
    }
}

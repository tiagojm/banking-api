using APIContaBanco.Enums;
using APIContaBanco.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIContaBanco.Models
{
    public class Operacao : IOperacao
    {
        public Conta Conta { get; }
        public long ContaId { get; }
        public string Descricao { get; set; }
        public DateTime Data { get; }
        public TipoOperacao Tipo { get; }
        public double Valor { get; }
        public double SaldoAnterior { get; }
        protected internal double SaldoAposOperacao { get; set; }


        public Operacao(Conta ContaOperacao, string DescricaoOperacao, DateTime DataOperacao, TipoOperacao TipoOperacao, double Valor, double SaldoAnterior) 
        {
            this.Conta = ContaOperacao;
            this.Descricao = DescricaoOperacao;
            this.ContaId = ContaOperacao.Id;
            this.Data = DataOperacao;
            this.Tipo = TipoOperacao;
            this.Valor = Valor;
            this.SaldoAnterior = SaldoAnterior;
        }

        public void Efetua()
        {
            if(this.Tipo == TipoOperacao.Credito)
            {
                this.SaldoAposOperacao = this.SaldoAnterior + Valor;
            }
            
            if(this.Tipo == TipoOperacao.Debito)
            {
                this.SaldoAposOperacao = this.SaldoAnterior - Valor;
            }

            this.Conta.Saldo = SaldoAposOperacao;
        }
    }
}

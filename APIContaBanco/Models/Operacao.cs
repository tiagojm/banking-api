using APIContaBanco.Enums;
using APIContaBanco.Interface;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace APIContaBanco.Models
{
    public class Operacao : IOperacao
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public Conta Conta { get; }
        [BsonElement("Descricao")]
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

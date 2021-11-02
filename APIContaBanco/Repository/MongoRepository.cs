using APIContaBanco.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIContaBanco.Repository
{
    public class MongoRepository
    {
        private readonly IMongoCollection<Operacao> _operacoes;

        public MongoRepository(IBankingOperationsMongoSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            if (settings.UseSSL)
            {
                client.Settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
            }

            _operacoes = database.GetCollection<Operacao>(settings.CollectionName);
        }

        public List<Operacao> Get() => _operacoes.Find(op => true).ToList();
        public async Task<List<Operacao>> GetAsync() => await _operacoes.FindAsync(op => true).Result.ToListAsync();
        
        public Operacao Get(string id) => _operacoes.Find(op => op.Id == id).FirstOrDefault();
        public async Task<Operacao> GetAsync(string id) => await _operacoes.FindAsync(op => op.Id == id).Result.FirstOrDefaultAsync();
        
        public Operacao Create(Operacao operacao)
        {
            _operacoes.InsertOne(operacao);
            return operacao;
        }
        public async Task<Operacao> CreateAsync(Operacao operacao)
        {
            await _operacoes.InsertOneAsync(operacao);
            return operacao;
        }

        public void Update(string id, Operacao operacaoIn) => _operacoes.ReplaceOne(op => op.Id == id, operacaoIn);
        public async Task UpdateAsync(string id, Operacao operacaoIn) => await _operacoes.ReplaceOneAsync(op => op.Id == id, operacaoIn);

        public void Remove(Operacao operacaoIn) => _operacoes.DeleteOne(op => op.Id == operacaoIn.Id);
        public async Task RemoveAsync(Operacao operacaoIn) => await _operacoes.DeleteOneAsync(op => op.Id == operacaoIn.Id);
        public void Remove(string id) => _operacoes.DeleteOne(op => op.Id == id);
        public async Task RemoveAsync(string id) => await _operacoes.DeleteOneAsync(op => op.Id == id);
    }
}

using APIContaBanco.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIContaBanco.Repository
{
    public class UnityOfWork : IUnityOfWork, IDisposable, IAsyncDisposable
    {
        private readonly AppDbContext _context;
        private ClienteRepository _clienteRepository;
        
        public IClienteRepository clienteRepository 
        { 
            get 
            {
                return _clienteRepository = this._clienteRepository ?? new ClienteRepository(_context); 
            } 
        }

        public UnityOfWork(AppDbContext context)
        {
            _context = context;
        }


        public void Commit() 
        {
            this._context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await this._context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}

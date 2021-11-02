using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIContaBanco.Repository
{
    public interface IUnityOfWork
    {
        IClienteRepository clienteRepository { get; }

        void Commit();

        Task CommitAsync();
    }
}

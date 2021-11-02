using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIContaBanco.Repository
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();
        Task<IList<T>> GetAsync();

        T GetById(Func<T, bool> predicate);
        Task<T> GetByIdAsync(params object[] id);

        void Insert(T entity);
        Task InsertAsync(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}

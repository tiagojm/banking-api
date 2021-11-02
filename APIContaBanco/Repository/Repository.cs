using APIContaBanco.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIContaBanco.Repository
{
    public class Repository<T> : IRepository<T> where T : class, TEntity
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Get()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public async Task<IList<T>> GetAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public T GetById(Func<T, bool> predicate)
        {
            return _context.Set<T>().AsNoTracking().Where(predicate).FirstOrDefault();
        }

        public async Task<T> GetByIdAsync(params object[] id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public bool TryGetById(long id, out T entity)
        {
            entity = this.GetById(e => e.Id == id);
            return entity != null ? true : false;
        }

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public async Task InsertAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}

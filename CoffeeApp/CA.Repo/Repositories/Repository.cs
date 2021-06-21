using CA.Data;
using CA.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA.Data.Entityes.Base;

namespace CA.Repo.Repositories
{
    public class Repository<T, K> : IRepository<T, K> where T : BaseEntity<K>
    {
        
        protected readonly EFDBContext _context;
        private DbSet<T> _dbSet;

        public Repository(EFDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        public T GetById(K entityId)
        {
            return _dbSet.Find(entityId);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Create(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}

using CA.Data;
using CA.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Repo.Repositories
{
    public class Repository<T, K> : IRepository<T, K> where T : class
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

        public T GetById(K coffeeMachineId)
        {
            return _dbSet.Find(coffeeMachineId);
        }

        public void Update(T coffeeMachine)
        {
            _context.Entry(coffeeMachine).State = EntityState.Modified;
        }

        public void Create(T coffeeMachine)
        {
            _dbSet.Add(coffeeMachine);
        }

        public void Delete(T coffeeMachine)
        {
            _dbSet.Remove(coffeeMachine);
        }
    }
}

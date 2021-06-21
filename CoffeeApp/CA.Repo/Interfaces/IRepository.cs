using CA.Data.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA.Data.Entityes.Base;

namespace CA.Repo.Interfaces
{
    public interface IRepository<T, K>  where T : BaseEntity<K>
    {
        void Create(T entity);
        T GetById(K id);
        IEnumerable<T> GetAll();
        void Delete(T entity);
        void Update(T entity);
    }
}

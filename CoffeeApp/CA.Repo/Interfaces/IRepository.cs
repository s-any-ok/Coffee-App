using CA.Data.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Repo.Interfaces
{
    public interface IRepository<T>  where T : class
    {
        void Create(T item);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Delete(T item);
        void Update(T item);
    }
}

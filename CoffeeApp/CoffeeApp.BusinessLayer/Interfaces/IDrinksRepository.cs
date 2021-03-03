using CoffeeApp.DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.BusinessLayer.Interfaces
{
    public interface IDrinksRepository
    {
        IEnumerable<Drink> GetAll();
        Drink GetById(int drinktId);
        void Save(Drink drink);
        void Delete(Drink drink);
    }
}

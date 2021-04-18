using CA.Data;
using CA.Data.Entityes;
using CA.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Repo.Repositories
{
    public class IngredientTypeRepository : IRepository<IngredientType>
    {
        private EFDBContext context;
        public IngredientTypeRepository(EFDBContext context)
        {
            this.context = context;
        }
        public IEnumerable<IngredientType> GetAll()
        {
            return context.IngredientType.ToList();
        }

        public IEnumerable<IngredientType> GetAll(int id)
        {
            return GetAll();
        }

        public IngredientType GetById(int ingredientId)
        {
            return context.IngredientType.FirstOrDefault(x => x.Id == ingredientId);
        }

        public void Update(IngredientType ingredient)
        {
            context.Entry(ingredient).State = EntityState.Modified;
        }

        public void Create(IngredientType ingredient)
        {
            if (ingredient.Id == 0)
                context.IngredientType.Add(ingredient);
            else
                context.Entry(ingredient).State = EntityState.Modified;
        }

        public void Delete(IngredientType ingredient)
        {
            context.IngredientType.Remove(ingredient);
        }
    }
}

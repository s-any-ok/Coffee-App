﻿using CoffeeApp.BusinessLayer.Interfaces;
using CoffeeApp.DataLayer;
using CoffeeApp.DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.BusinessLayer.Implementations
{
    public class CoffeeMachinesRepository : ICoffeeMachinesRepository
    {

        private EFDBContext context;
        public CoffeeMachinesRepository(EFDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<CoffeeMachine> GetAll()
        {
            //if (includeMaterials)
            //    return context.Set<CoffeeMachine>().Include(x => x.Materials).AsNoTracking().ToList();
            //else
                return context.CoffeeMachine.ToList();
        }

        public CoffeeMachine GetById(int coffeeMachineId)
        {
            //if (includeMaterials)
            //    return context.Set<CoffeeMachine>().Include(x => x.Materials).AsNoTracking().FirstOrDefault(x => x.Id == coffeeMachineId);
            //else
                return context.CoffeeMachine.FirstOrDefault(x => x.Id == coffeeMachineId);
        }

        public void Save(CoffeeMachine coffeeMachine)
        {
            if (coffeeMachine.Id == 0)
                context.CoffeeMachine.Add(coffeeMachine);
            else
                context.Entry(coffeeMachine).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(CoffeeMachine coffeeMachine)
        {
            context.CoffeeMachine.Remove(coffeeMachine);
            context.SaveChanges();
        }
    }
}
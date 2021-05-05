using CA.Repo;
using CA.Data.Entityes;
using CA.Service.Models;
using CA.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace CA.Service.Services
{
    public class CoffeeMachineService : ICoffeeMachineService
    {
        private UnitOfWork _unitOfWork;
        public CoffeeMachineService()
        {
            this._unitOfWork = new UnitOfWork();
        }
        public IEnumerable<CoffeeMachineDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CoffeeMachine, CoffeeMachineDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<CoffeeMachine>, List<CoffeeMachineDTO>>(_unitOfWork.CoffeeMachines.GetAll());
        }

        public CoffeeMachineDTO GetById(int id)
        {
            var coffeeMachine = _unitOfWork.CoffeeMachines.GetById(id);
            return new CoffeeMachineDTO { Id = coffeeMachine.Id, CoffeeMachineName = coffeeMachine.CoffeeMachineName, Producer = coffeeMachine.Producer };
        }

        public bool IsEnoughIngredients(int id) 
        {
            bool isEnough = true;
            /*var defIngs = GetIngredients(id, true);
            var curIngs = GetIngredients(id, false);*/
            var ingredients = GetIngredients(id);

            foreach (var ingredient in ingredients)
            {
                if (ingredient.MaxVolume * 0.2f >= ingredient.Volume)
                {
                    isEnough = false;
                }
            }
            return isEnough;
        }

        public IEnumerable<DrinkDTO> GetDrinks(int id)
        {
            var drinks = _unitOfWork.Drinks.GetAll();
            if (!String.IsNullOrEmpty(id.ToString()))
            {
                drinks = _unitOfWork.Drinks.GetAll(id);
            }
            
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Drink, DrinkDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Drink>, List<DrinkDTO>>(drinks);
        }

        public IEnumerable<CoffeeMachineIngredientDTO> GetIngredients(int id)
        {
            /*var coffeeMachineIngredients = _unitOfWork.CoffeeMachineIngredients.GetAll().Where(i => i.IsDefault == IsDefault);*/
            /*if (!String.IsNullOrEmpty(id.ToString()))
            {
                var coffeeMachineIngredients = _unitOfWork.CoffeeMachineIngredients.GetAll()
                    .Where(d => d.CoffeeMachineId == id);
            }*/
            
            var coffeeMachineIngredients = _unitOfWork.CoffeeMachineIngredients.GetAll()
                .Where(d => d.CoffeeMachineId == id);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CoffeeMachineIngredient, CoffeeMachineIngredientDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<CoffeeMachineIngredient>, List<CoffeeMachineIngredientDTO>>(coffeeMachineIngredients);
        }

        public TimeSpan GetTimeToRefreshIngredients(int id)
        {
            List<DateTime> times = new List<DateTime>();
            var drks = GetDrinks(id).ToList();
            drks.ForEach(drk =>
            {
                var orders = _unitOfWork.Orders.GetAll().Where(order => order.DrinkId == drk.Id).ToList();
                orders.ForEach(order =>
                {
                    times.Add(order.OrderDate);
                });
            }
            );

            /*var coffeeMachineIngredientsDefault = GetIngredients(id, true).ToList();
            var coffeeMachineIngredientsCurrent = GetIngredients(id, false).ToList();*/
            
            var coffeeMachineIngredients = GetIngredients(id).ToList();

            var duration = GetTimeDuration(times);
            var coeff = GetIngredientsCoeff(coffeeMachineIngredients);
            var result = coeff * duration.TotalSeconds;

            TimeSpan tresultTime = TimeSpan.FromSeconds(result);

            return tresultTime;
        }

        private List<DateTime> SortDateTimes(List<DateTime> dates) 
        {
            dates.Sort((a, b) => a.CompareTo(b));
            return dates;
        }

        private TimeSpan GetTimeDuration(List<DateTime> dates)
        {
            if (dates.Count == 1) return DateTime.Now - dates[0];
            if (dates.Count == 0) return TimeSpan.Zero;
            var sortedDates = SortDateTimes(dates);
            var firstDate = sortedDates.First();
            var lastDate = sortedDates.Last();
            TimeSpan duration = lastDate - firstDate;
            return duration;
        }

        private double GetIngredientsCoeff(List<CoffeeMachineIngredientDTO> coffeeMachineIngredients)
        {
            var coeffs = new List<double>();
            foreach (var ingredient in coffeeMachineIngredients)
            {
                var diff = ingredient.MaxVolume - ingredient.Volume;
                var coeff = (ingredient.MaxVolume / diff) - 1;
                if (coeff > 0) coeffs.Add(coeff);
            }

            double lowestCoeff = coeffs.Any() ? coeffs.Min() : 0;
            return lowestCoeff;
        }

        #region NotImplemented

        /*public void AddCoffeeMachine(CoffeeMachineDTO coffeeMachineDTO)
        {
            throw new NotImplementedException();
        }

        public void EditCoffeeMachine(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteCoffeeMachine(int id)
        {
            throw new NotImplementedException();
        }*/
        
        /*public DrinkDTO GetDrinkById(int id)
        {
            throw new NotImplementedException();
        }*/

        #endregion
        
    }
}

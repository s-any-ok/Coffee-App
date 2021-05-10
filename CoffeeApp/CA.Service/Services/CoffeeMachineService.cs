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
        public IEnumerable<CoffeeMachineView> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CoffeeMachine, CoffeeMachineView>()).CreateMapper();
            return mapper.Map<IEnumerable<CoffeeMachine>, List<CoffeeMachineView>>(_unitOfWork.CoffeeMachines.GetAll());
        }

        public CoffeeMachineView GetById(int id)
        {
            var coffeeMachine = _unitOfWork.CoffeeMachines.GetById(id);
            return new CoffeeMachineView { Id = coffeeMachine.Id, CoffeeMachineName = coffeeMachine.CoffeeMachineName, Producer = coffeeMachine.Producer };
        }

        public bool IsEnoughIngredients(int id) 
        {
            bool isEnough = true;
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

        public IEnumerable<DrinkView> GetDrinks(int id)
        {
            var drinks = _unitOfWork.Drinks.GetAll(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Drink, DrinkView>()).CreateMapper();
            return mapper.Map<IEnumerable<Drink>, List<DrinkView>>(drinks);
        }

        public IEnumerable<OrderView> GetOrders(int id)
        {
            var orders = _unitOfWork.Orders.GetAll(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderView>()).CreateMapper();
            return mapper.Map<IEnumerable<Order>, List<OrderView>>(orders);
        }

        public IEnumerable<CoffeeMachineIngredientView> GetIngredients(int id)
        {
            var coffeeMachineIngredients = _unitOfWork.CoffeeMachineIngredients.GetAllByCoffeeMachineId(id);
           
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CoffeeMachineIngredient ,CoffeeMachineIngredientView>()
                    .ForMember("IngredientName", opt => opt.MapFrom(ing => GetIngridientName(ing.IngredientTypeId)))
                    .ForMember("Fulfilment", opt => opt.MapFrom(ing => GetFulfilment(ing.Volume, ing.MaxVolume))));
            var mapper = new Mapper(config);
            return mapper.Map<IEnumerable <CoffeeMachineIngredient>, List <CoffeeMachineIngredientView>> (coffeeMachineIngredients);
        }

        public TimeSpan GetTimeToRefreshIngredients(int id)
        {
            List<DateTime> times = new List<DateTime>();
            var drks = GetDrinks(id).ToList();
            drks.ForEach(drk =>
            {
                var orders = _unitOfWork.Orders.GetAllByDrinkId(drk.Id).ToList();
                orders.ForEach(order =>
                {
                    times.Add(order.OrderDate);
                });
            }
            );

            var coffeeMachineIngredients = GetIngredients(id).ToList();

            var duration = GetTimeDuration(times);
            var coeff = GetIngredientsCoeff(coffeeMachineIngredients);
            var result = coeff * duration.TotalSeconds;

            TimeSpan tresultTime = TimeSpan.FromSeconds(result);

            return tresultTime;
        }

        public TimeSpan GetTimeToRefreshIngredientsInDuration(int id, DateTime firstDate, DateTime lastDate)
        {

            var coffeeMachineIngredients = GetIngredients(id).ToList();
            TimeSpan duration = lastDate - firstDate;
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

        private double GetIngredientsCoeff(List<CoffeeMachineIngredientView> coffeeMachineIngredients)
        {
            var coeffs = new List<double>();
            foreach (var ingredient in coffeeMachineIngredients)
            {
                if (ingredient.MaxVolume - ingredient.Volume > 0)
                {
                    var diff = ingredient.MaxVolume - ingredient.Volume;
                    var coeff = (ingredient.MaxVolume / diff) - 1;
                    if (coeff > 0) coeffs.Add(coeff);
                }
            }

            double lowestCoeff = coeffs.Any() ? coeffs.Min() : 0;
            return lowestCoeff;
        }

        private string GetIngridientName(int Id) => _unitOfWork.IngredientTypes.GetById(Id).IngredientName;
        private float GetFulfilment(float currentValue, float maxValue) => (100f * currentValue) / maxValue;

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

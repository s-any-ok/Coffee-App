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
using CA.Repo.Interfaces;
using CA.Service.Mappers;

namespace CA.Service.Services
{
    public class CoffeeMachineService : ICoffeeMachineService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CoffeeMachineService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<CoffeeMachineView> GetAll()
        {
            return _unitOfWork.CoffeeMachines.GetAll().Select(CoffeeMachineEntityViewMappper.MapToView);
        }

        public CoffeeMachineView GetById(int id)
        {
            return CoffeeMachineEntityViewMappper.MapToView(_unitOfWork.CoffeeMachines.GetById(id));
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
            return _unitOfWork.Drinks.GetAllByCoffeeMachineId(id).Select(DrinkEntityViewMappper.MapToView);
        }

        public IEnumerable<OrderView> GetOrders(int id)
        {
            return _unitOfWork.Orders.GetAllBCoffeeMachineId(id).Select(OrderEntityViewMappper.MapToView);
        }

        public IEnumerable<CoffeeMachineIngredientView> GetIngredients(int id)
        {
            return _unitOfWork.CoffeeMachineIngredients
                .GetAllByCoffeeMachineId(id)
                .Select(CoffeeMachineIngredientEntityViewMappper.MapToView);
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

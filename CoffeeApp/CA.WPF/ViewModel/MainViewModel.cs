using CA.Service;
using CA.Service.Interfaces;
using CA.Service.Models;
using CA.Service.Services;
using CA.WPF.Model;
using ManageStaff.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.WPF.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private ICoffeeMachineService _coffeeMachineService;
        private IDrinkService _drinkService;
        private IIngredientService _ingredientService;
        private IOrderService _orderService;

        private ObservableCollection<CoffeeMachineView> _coffeeMachines;
        private ObservableCollection<DrinkView> _drinks;
        private ObservableCollection<CoffeeMachineIngredientView> _ingredients;
        private ObservableCollection<OrderView> _orders;

        private CoffeeMachineView _selectedCoffeeMachine;

        public ObservableCollection<CoffeeMachineView> CoffeeMachines
        {
            get => _coffeeMachines;
            private set
            {
                _coffeeMachines = value;
                OnPropertyChanged(nameof(CoffeeMachines));
            }
        }

        public CoffeeMachineView SelectedCoffeeMachine
        {
            get => _selectedCoffeeMachine;
            set
            {
                _selectedCoffeeMachine = value;
                OnPropertyChanged(nameof(SelectedCoffeeMachine));
            }
        }

        public MainViewModel()
        {
            _coffeeMachineService = new CoffeeMachineService();
            var result = _coffeeMachineService.GetAll();
            CoffeeMachines = new ObservableCollection<CoffeeMachineView>(result);
            //while (true) {
            //    Console.WriteLine(SelectedCoffeeMachine);
            //}
        }
    }
}

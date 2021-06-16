using CA.Service;
using CA.Service.Models;
using CA.Service.Services;
using CA.WPF.Commands;
using CA.WPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.WPF.ViewModel
{
    public class OrderViewModel : ObservableObject
    {
        private ICoffeeMachineService _coffeeMachineService;
        private IOrderService _orderService;

        private ObservableCollection<CoffeeMachineView> _coffeeMachines;
        private ObservableCollection<DrinkView> _drinks;
        public ObservableCollection<CoffeeMachineView> CoffeeMachines
        {
            get => _coffeeMachines;
            set
            {
                _coffeeMachines = value;
                OnPropertyChanged(nameof(CoffeeMachines));
            }
        }
        public ObservableCollection<DrinkView> Drinks
        {
            get => _drinks;
            set
            {
                _drinks = value;
                OnPropertyChanged(nameof(Drinks));
            }
        }

        private CoffeeMachineView _selectedCoffeeMachine;
        public CoffeeMachineView SelectedCoffeeMachine
        {
            get => _selectedCoffeeMachine;
            set
            {
                _selectedCoffeeMachine = value;
                OnPropertyChanged(nameof(SelectedCoffeeMachine));
            }
        }

        private DrinkView _selectedDrink;
        public DrinkView SelectedDrink
        {
            get => _selectedDrink;
            set
            {
                _selectedDrink = value;
                OnPropertyChanged(nameof(SelectedDrink));
            }
        }

        private RelayCommand _getDrinks;
        public RelayCommand GetDrinks
        {
            get
            {
                return _getDrinks ??= new RelayCommand(obj =>
                {
                    int id = SelectedCoffeeMachine.Id;
                    var result = _coffeeMachineService.GetDrinks(id);
                    Drinks = new ObservableCollection<DrinkView>(result);
                }
                );
            }
        }

        private RelayCommand _makeOrder;
        public RelayCommand MakeOrder
        {
            get
            {
                return _makeOrder ??= new RelayCommand(obj =>
                {

                    int coffeeMachineId = SelectedCoffeeMachine.Id;
                    int drinkId = SelectedDrink.Id;
                    OrderView order = new OrderView() { DrinkId = drinkId, CoffeeMachineId = coffeeMachineId };
                    if (_orderService.IsCorrectOrder(order))
                    {
                        _orderService.AddOrder(order);
                    }
                }
                );
            }
        }

        public OrderViewModel(ICoffeeMachineService coffeeMachineService, IOrderService orderService)
        {
            _coffeeMachineService = coffeeMachineService;
            _orderService = orderService;
            Init();
        }

        private void Init()
        {
            var result = _coffeeMachineService.GetAll();
            CoffeeMachines = new ObservableCollection<CoffeeMachineView>(result);
        }
    }
}

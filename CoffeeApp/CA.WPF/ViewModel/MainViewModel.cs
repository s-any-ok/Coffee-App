using CA.Service;
using CA.Service.Interfaces;
using CA.Service.Models;
using CA.Service.Services;
using CA.WPF.Model;
using CA.WPF.View;
using CA.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CA.WPF.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        private ICoffeeMachineService _coffeeMachineService;
        private IDrinkService _drinkService;
        private IIngredientService _ingredientService;
        private IOrderService _orderService;

        private ObservableCollection<CoffeeMachineView> _coffeeMachines;
        private ObservableCollection<DrinkView> _drinks;
        private ObservableCollection<CoffeeMachineIngredientView> _coffeeMachineIngredients;
        private ObservableCollection<OrderView> _orders;

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

        public ObservableCollection<CoffeeMachineView> CoffeeMachines
        {
            get => _coffeeMachines;
            private set
            {
                _coffeeMachines = value;
                OnPropertyChanged(nameof(CoffeeMachines));
            }
        }
        public ObservableCollection<DrinkView> Drinks
        {
            get => _drinks;
            private set
            {
                _drinks = value;
                OnPropertyChanged(nameof(Drinks));
            }
        }
        public ObservableCollection<CoffeeMachineIngredientView> CoffeeMachineIngredients
        {
            get => _coffeeMachineIngredients;
            private set
            {
                _coffeeMachineIngredients = value;
                OnPropertyChanged(nameof(CoffeeMachineIngredients));
            }
        }
        public ObservableCollection<OrderView> Orders
        {
            get => _orders;
            private set
            {
                _orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }

        private RelayCommand _getDrinks;
        public RelayCommand GetDrinks
        {
            get
            {
                return _getDrinks ?? new RelayCommand(obj =>
                {
                    int id = SelectedCoffeeMachine.Id;
                    var result = _coffeeMachineService.GetDrinks(id);
                    Drinks = new ObservableCollection<DrinkView>(result);
                }
                );
            }
        }

        private RelayCommand _getIngredients;
        public RelayCommand GetIngredients
        {
            get
            {
                return _getIngredients ?? new RelayCommand(obj =>
                {
                    int id = SelectedCoffeeMachine.Id;
                    var result = _coffeeMachineService.GetIngredients(id);
                    CoffeeMachineIngredients = new ObservableCollection<CoffeeMachineIngredientView>(result);
                }
                );
            }
        }

        private RelayCommand _getOrders;
        public RelayCommand GetOrders
        {
            get
            {
                return _getOrders ?? new RelayCommand(obj =>
                {
                    int id = SelectedCoffeeMachine.Id;
                    var result = _coffeeMachineService.GetOrders(id);
                    Orders = new ObservableCollection<OrderView>(result);
                }
                );
            }
        }

        private RelayCommand _getAll;
        public RelayCommand GetAll
        {
            get
            {
                return _getAll ?? new RelayCommand(obj =>
                {
                    int id = SelectedCoffeeMachine.Id;
                    var resultDrinks = _coffeeMachineService.GetDrinks(id);
                    var resultIngredients = _coffeeMachineService.GetIngredients(id);
                    var resultOrders = _coffeeMachineService.GetOrders(id);
                    Drinks = new ObservableCollection<DrinkView>(resultDrinks);
                    CoffeeMachineIngredients = new ObservableCollection<CoffeeMachineIngredientView>(resultIngredients);
                    Orders = new ObservableCollection<OrderView>(resultOrders);
                }
                );
            }
        }

        public MainViewModel()
        {
            _coffeeMachineService = new CoffeeMachineService();
            _drinkService = new DrinkService();
            _ingredientService = new IngredientService();
            _orderService = new OrderService();
            Init();
           
        }

        private RelayCommand _opneMakeOrderWindow;
        public RelayCommand OpenMakeOrderWnd
        {
            get
            {
                return _opneMakeOrderWindow ?? new RelayCommand(obj =>
                {
                    OpenMakeOrderWindow();
                }
                );
            }
        }

        private RelayCommand _opneTimeToRechargeWindow;
        public RelayCommand OpenTimeToRechargeWnd
        {
            get
            {
                return _opneTimeToRechargeWindow ?? new RelayCommand(obj =>
                {
                    OpenTimeToRechargeWindow();
                }
                );
            }
        }

        private void OpenMakeOrderWindow()
        {
            MakeOrderWindow makeOrderWindow = new MakeOrderWindow();
            SetCenterPositionAndOpen(makeOrderWindow);
        }

        private void OpenTimeToRechargeWindow()
        {
            TimeToRechargeWindow timeToRechargeWindow = new TimeToRechargeWindow();
            SetCenterPositionAndOpen(timeToRechargeWindow);
        }

        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }

        private void Init()
        {
            var result = _coffeeMachineService.GetAll();
            CoffeeMachines = new ObservableCollection<CoffeeMachineView>(result);
        }
    }
}

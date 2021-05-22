using CA.Service;
using CA.Service.Models;
using CA.Service.Services;
using CA.WPF.Commands;
using CA.WPF.Model;
using System;
using System.Collections.ObjectModel;

namespace CA.WPF.ViewModel
{
    public class TimeToRechargeViewModel : ObservableObject
    {
        private ICoffeeMachineService _coffeeMachineService;
        private IOrderService _orderService;

        private ObservableCollection<CoffeeMachineView> _coffeeMachines;
        public ObservableCollection<CoffeeMachineView> CoffeeMachines
        {
            get => _coffeeMachines;
            set
            {
                _coffeeMachines = value;
                OnPropertyChanged(nameof(CoffeeMachines));
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

        private string _timeToRecharge;
        public string TimeToRecharge
        {
            get => _timeToRecharge;
            set
            {
                _timeToRecharge = value;
                OnPropertyChanged(nameof(TimeToRecharge));
            }
        }

        private DateTime _dateFrom;

        public DateTime DateFrom
        {
            get => _dateFrom;
            set
            {
                _dateFrom = value;
                OnPropertyChanged(nameof(DateFrom));
            }
        }

        private DateTime _dateTo;

        public DateTime DateTo
        {
            get => _dateTo;
            set
            {
                _dateTo = value;
                OnPropertyChanged(nameof(DateTo));
            }
        }

        private RelayCommand _setCoffeeMachine;
        public RelayCommand SetCoffeeMachine
        {
            get
            {
                return _setCoffeeMachine ??= new RelayCommand(obj =>
                {

                    int coffeeMachineId = SelectedCoffeeMachine.Id;
                    DateFrom = _orderService.GetFirstOrderDate(coffeeMachineId);
                    DateTo = _orderService.GetLastOrderDate(coffeeMachineId);
                }
                );
            }
        }

        private RelayCommand _getTimeToRecharge;
        public RelayCommand GetTimeToRecharge
        {
            get
            {
                return _getTimeToRecharge ??= new RelayCommand(obj =>
                {

                    int coffeeMachineId = SelectedCoffeeMachine.Id;
                    TimeSpan time = _coffeeMachineService.GetTimeToRefreshIngredientsInDuration(coffeeMachineId, DateFrom, DateTo);
                    if (time == null) time = _coffeeMachineService.GetTimeToRefreshIngredients(coffeeMachineId);
                    TimeToRecharge = String.Format("{0:%d} d, {0:%h} h, {0:%m} m, {0:%s} s", time);
                }
                );
            }
        }

        public TimeToRechargeViewModel()
        {
            _coffeeMachineService = new CoffeeMachineService();
            _orderService = new OrderService();
            Init();
        }

        private void Init()
        {
            var result = _coffeeMachineService.GetAll();
            CoffeeMachines = new ObservableCollection<CoffeeMachineView>(result);
        }
    }
}

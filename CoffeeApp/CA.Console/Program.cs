using CA.Repo;
using CA.Repo.Implementations;
using CA.Service;
using System;

namespace CoffeeApp.Console
{
    class Program
    {
        CoffeeMachinesRepository rep = new CoffeeMachinesRepository();
        private DataManager _datamanager;
        private ServicesManager _servicesmanager;
        public Program()
        {
            _datamanager = new DataManager();
            _servicesmanager = new ServicesManager(_datamanager);
        }

        public void getList()
        {
            var CoffeeMachines = _servicesmanager.CoffeeMachines.GetCoffeeMachinesList();
            CoffeeMachines.ForEach(x => System.Console.WriteLine(x.CoffeeMachine));
        }

        

        static void Main(string[] args)
        {
            Program controller = new Program();
            controller.getList();
            System.Console.WriteLine("Hello World!");
        }
    }

    class Controller {
        private DataManager _datamanager;
        private ServicesManager _servicesmanager;

        public Controller(DataManager dataManager)
        {
            _datamanager = dataManager;
            _servicesmanager = new ServicesManager(dataManager);
        }

        public Controller()
        {
            _datamanager = new DataManager();
            _servicesmanager = new ServicesManager(_datamanager);
        }

        public void getList()
        {
            var CoffeeMachines = _servicesmanager.CoffeeMachines.GetCoffeeMachinesList();
            CoffeeMachines.ForEach(x => System.Console.WriteLine(x));
        }
    }
}

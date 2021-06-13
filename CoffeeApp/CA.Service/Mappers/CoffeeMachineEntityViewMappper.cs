using CA.Data.Entityes;
using CA.Service.Models;

namespace CA.Service.Mappers
{
    public static class CoffeeMachineEntityViewMappper
    {
        public static CoffeeMachine MapToEntity(this CoffeeMachineView view)
        {
            return new CoffeeMachine()
            {
                Id = view.Id,
                CoffeeMachineName = view.CoffeeMachineName,
                Producer = view.Producer
            };
        }

        public static CoffeeMachineView MapToView(this CoffeeMachine entity)
        {
            return new CoffeeMachineView()
            {
                Id = entity.Id,
                CoffeeMachineName = entity.CoffeeMachineName,
                Producer = entity.Producer
            };
        }
    }
}

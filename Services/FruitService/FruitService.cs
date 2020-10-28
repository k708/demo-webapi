using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_webapi.Models;

namespace demo_webapi.Services.FruitService
{
    public class FruitService : IFruitService
    {
        private static List<Fruit> _fruits = new List<Fruit> {
            new Fruit { Id = 1, Name = "Apple" },
            new Fruit { Id = 2, Name = "Banana" }
        };

        public async Task<ServiceResponse<List<Fruit>>> AddFruit(Fruit newFruit)
        {
            ServiceResponse<List<Fruit>> response = new ServiceResponse<List<Fruit>>();
            _fruits.Add(newFruit);
            response.Data = _fruits;
            return response;
        }

        public async Task<ServiceResponse<List<Fruit>>> GetAllFruits()
        {
            ServiceResponse<List<Fruit>> response = new ServiceResponse<List<Fruit>>();
            response.Data = _fruits;
            return response;
        }

        public async Task<ServiceResponse<Fruit>> GetFruitById(int id)
        {
            ServiceResponse<Fruit> response = new ServiceResponse<Fruit>();
            var fruit = _fruits.FirstOrDefault(f => f.Id == id);
            response.Data = fruit;
            return response;
        }
    }
}
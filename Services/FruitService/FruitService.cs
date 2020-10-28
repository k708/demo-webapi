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
        
        public async Task<List<Fruit>> AddFruit(Fruit newFruit)
        {
            _fruits.Add(newFruit);
            return _fruits;
        }

        public async Task<List<Fruit>> GetAllFruits()
        {
            return _fruits;
        }

        public async Task<Fruit> GetFruitById(int id)
        {
            var fruit = _fruits.FirstOrDefault(f => f.Id == id);
            return fruit;
        }
    }
}
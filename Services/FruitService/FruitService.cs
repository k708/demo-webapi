using System.Collections.Generic;
using System.Linq;
using demo_webapi.Models;

namespace demo_webapi.Services.FruitService
{
    public class FruitService : IFruitService
    {
        private static List<Fruit> _fruits = new List<Fruit> {
            new Fruit { Id = 1, Name = "Apple" },
            new Fruit { Id = 2, Name = "Banana" }
        };
        
        public List<Fruit> AddFruit(Fruit newFruit)
        {
            _fruits.Add(newFruit);
            return _fruits;
        }

        public List<Fruit> GetAllFruits()
        {
            return _fruits;
        }

        public Fruit GetFruitById(int id)
        {
            var fruit = _fruits.FirstOrDefault(f => f.Id == id);
            return fruit;
        }
    }
}
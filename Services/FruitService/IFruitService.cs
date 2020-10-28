using System.Collections.Generic;
using demo_webapi.Models;

namespace demo_webapi.Services.FruitService
{
    public interface IFruitService
    {
        List<Fruit> GetAllFruits();
        Fruit GetFruitById(int id);
        List<Fruit> AddFruit(Fruit newFruit);
    }
}
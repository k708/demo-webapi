using System.Collections.Generic;
using System.Threading.Tasks;
using demo_webapi.Models;

namespace demo_webapi.Services.FruitService
{
    public interface IFruitService
    {
        Task<List<Fruit>> GetAllFruits();
        Task<Fruit> GetFruitById(int id);
        Task<List<Fruit>> AddFruit(Fruit newFruit);
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using demo_webapi.Models;

namespace demo_webapi.Services.FruitService
{
    public interface IFruitService
    {
        Task<ServiceResponse<List<Fruit>>> GetAllFruits();
        Task<ServiceResponse<Fruit>> GetFruitById(int id);
        Task<ServiceResponse<List<Fruit>>> AddFruit(Fruit newFruit);
    }
}
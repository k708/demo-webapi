using System.Collections.Generic;
using System.Threading.Tasks;
using demo_webapi.Models;
using demo_webapi.Models.Dtos.Fruit;

namespace demo_webapi.Services.FruitService
{
    public interface IFruitService
    {
        Task<ServiceResponse<List<GetFruitDto>>> GetAllFruits();
        Task<ServiceResponse<GetFruitDto>> GetFruitById(int id);
        Task<ServiceResponse<List<GetFruitDto>>> AddFruit(AddFruitDto newFruit);
    }
}
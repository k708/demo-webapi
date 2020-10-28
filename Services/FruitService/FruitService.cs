using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using demo_webapi.Models;
using demo_webapi.Models.Dtos.Fruit;

namespace demo_webapi.Services.FruitService
{
    public class FruitService : IFruitService
    {
        private static List<Fruit> _fruits = new List<Fruit> {
            new Fruit { Id = 1, Name = "Apple" , Stock = 10 },
            new Fruit { Id = 2, Name = "Banana", Stock = 0 },
            new Fruit { Id = 3, Name = "Cherry", Stock = 30 }
        };
        private readonly IMapper _mapper;

        public FruitService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetFruitDto>>> AddFruit(AddFruitDto newFruit)
        {
            ServiceResponse<List<GetFruitDto>> response = new ServiceResponse<List<GetFruitDto>>();
            Fruit fruit = _mapper.Map<Fruit>(newFruit);
            fruit.Id = _fruits.Max(c => c.Id) + 1;
            _fruits.Add(fruit);
            response.Data = (_fruits.Select(c => _mapper.Map<GetFruitDto>(c))).ToList();
            return response;
        }

        public async Task<ServiceResponse<List<GetFruitDto>>> GetAllFruits()
        {
            ServiceResponse<List<GetFruitDto>> response = new ServiceResponse<List<GetFruitDto>>();
            response.Data = (_fruits.Where(p => p.Stock > 0)
                                    .Select(c => _mapper.Map<GetFruitDto>(c))
                            ).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetFruitDto>> GetFruitById(int id)
        {
            ServiceResponse<GetFruitDto> response = new ServiceResponse<GetFruitDto>();
            var fruit = _mapper.Map<GetFruitDto>(_fruits.FirstOrDefault(f => f.Id == id));
            response.Data = fruit;
            return response;
        }
    }
}
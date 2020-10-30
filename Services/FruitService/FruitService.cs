using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using demo_webapi.Database;
using demo_webapi.Models;
using demo_webapi.Models.Dtos.Fruit;

namespace demo_webapi.Services.FruitService
{
    public class FruitService : IFruitService
    {
        private readonly IMapper _mapper;
        private readonly DatabaseContext _dbContext;

        public FruitService(IMapper mapper, DatabaseContext dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetFruitDto>>> GetAllFruits()
        {
            var response = new ServiceResponse<List<GetFruitDto>>();
            response.Data = _dbContext.Fruits.Where(p => p.Stock > 0)
                                             .Select(s => _mapper.Map<GetFruitDto>(s))
                                             .ToList();
            return response;
        }

        public async Task<ServiceResponse<GetFruitDto>> GetFruitById(int id)
        {
            var response = new ServiceResponse<GetFruitDto>();
            var fruit = _mapper.Map<GetFruitDto>(_dbContext.Fruits.FirstOrDefault(p => p.Id == id));
            response.Data = fruit;
            return response;
        }

        public async Task<ServiceResponse<List<GetFruitDto>>> AddFruit(AddFruitDto newFruit)
        {
            var response = new ServiceResponse<List<GetFruitDto>>();
            Fruit fruit = _mapper.Map<Fruit>(newFruit);
            fruit.Id = (_dbContext.Fruits.Count() > 0) ? _dbContext.Fruits.Max(s => s.Id) + 1 : 1;
            _dbContext.Fruits.Add(fruit);
            _dbContext.SaveChanges();
            response.Data = _dbContext.Fruits.Select(s => _mapper.Map<GetFruitDto>(s)).ToList();
            return response;
        }
        public async Task<ServiceResponse<List<GetFruitDto>>> UpdateFruit(UpdateFruitDto updatedFruit)
        {
            var response = new ServiceResponse<List<GetFruitDto>>();
            try
            {
                Fruit fruit = _dbContext.Fruits.FirstOrDefault(p => p.Id == updatedFruit.Id);
                fruit.Name = updatedFruit.Name;
                fruit.BestSeason = updatedFruit.BestSeason;
                fruit.Price = updatedFruit.Price;
                fruit.Stock = updatedFruit.Stock;
                _dbContext.SaveChanges();
                response.Data = _dbContext.Fruits.Where(p => p.Stock > 0)
                                                 .Select(c => _mapper.Map<GetFruitDto>(c))
                                                 .ToList();
            }
            catch (Exception e)
            {
                response.Sccess = false;
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetFruitDto>>> DeleteFruit(int id)
        {
            var response = new ServiceResponse<List<GetFruitDto>>();
            try
            {
                Fruit fruit = _dbContext.Fruits.First(p => p.Id == id);
                _dbContext.Fruits.Remove(fruit);
                _dbContext.SaveChanges();
                response.Data = _dbContext.Fruits.Where(p => p.Stock > 0)
                                                 .Select(c => _mapper.Map<GetFruitDto>(c))
                                                 .ToList();
            }
            catch (Exception e)
            {
                response.Sccess = false;
                response.Message = e.Message;
            }
            return response;
        }
    }
}
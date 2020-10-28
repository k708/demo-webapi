using AutoMapper;
using demo_webapi.Models;
using demo_webapi.Models.Dtos.Fruit;

namespace demo_webapi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
         CreateMap<Fruit, GetFruitDto>();
         CreateMap<AddFruitDto, Fruit>();   
        }
    }
}
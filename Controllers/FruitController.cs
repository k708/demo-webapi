using demo_webapi.Models;
using demo_webapi.Services.FruitService;
using Microsoft.AspNetCore.Mvc;

namespace demo_webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FruitController: ControllerBase
    {
        private readonly IFruitService _fruitService;

        public FruitController(IFruitService fruitService)
        {
            _fruitService = fruitService;
        }

        [HttpGet]
        public IActionResult Get() {
            return Ok(_fruitService.GetAllFruits());
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id) {
            return Ok(_fruitService.GetFruitById(id));
        }
        
        [HttpPost]
        public IActionResult AddFruit(Fruit newFruit) {
            return Ok(_fruitService.AddFruit(newFruit));
        }
    }
}
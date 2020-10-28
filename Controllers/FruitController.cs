using System.Threading.Tasks;
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
        public async Task<IActionResult> Get() {
            return Ok(await _fruitService.GetAllFruits());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id) {
            return Ok(await _fruitService.GetFruitById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddFruit(Fruit newFruit) {
            return Ok(await _fruitService.AddFruit(newFruit));
        }
    }
}
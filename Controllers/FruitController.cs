using System.Collections.Generic;
using System.Linq;
using demo_webapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace demo_webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FruitController: ControllerBase
    {
        private static List<Fruit> _fruits = new List<Fruit> {
            new Fruit { Id = 1, Name = "Apple" },
            new Fruit { Id = 2, Name = "Banana" }
        };
        
        [HttpGet]
        public IActionResult GetAll() {
            return Ok(_fruits);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetSingle(int id) {
            var fruit = _fruits.FirstOrDefault(f => f.Id == id);
            return Ok(fruit);
        }
    }
}
using demo_webapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace demo_webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FruitController: ControllerBase
    {
        private static Fruit fruit = new Fruit();
        
        public IActionResult GetAction() {
            return Ok(fruit);
        }
    }
}
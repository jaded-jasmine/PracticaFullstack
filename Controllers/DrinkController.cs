using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrinkController : Controller
    {
        private readonly DrinkService _drinkService;
        public DrinkController(DrinkService drinkService)
        {
            _drinkService = drinkService;
        }

        [HttpGet]
        public ActionResult<List<DrinkModel>> GetAll()
        {
            return _drinkService.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult<DrinkModel> GetById(int id)
        {
            var result = _drinkService.GetById(id);
            if (result == null) return NotFound($"Drink with ID {id} not found.");
            return Ok(result);
        }
        [HttpGet("random")]//endpoint diferit sa nu interfereze cu GetById
        public ActionResult<DrinkModel> GetRandomDrink()
        {
            var result = _drinkService.GetRandom();
            if (result == null) return NotFound("No drinks available.");
            return Ok(result);
        }

        [HttpPost]
        public ActionResult AddDrink([FromBody] DrinkModel drink)
        {
            if (drink == null || string.IsNullOrWhiteSpace(drink.Name) || string.IsNullOrWhiteSpace(drink.Description) || drink.Id == null) return BadRequest("Drink cannot be null and must have a name, description and ID.");
            _drinkService.AddDrink(drink);
            return CreatedAtAction(nameof(GetById), new { id = drink.Id }, drink);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteById(int id)
        {
            _drinkService.DeleteDrink(id);
            return Ok($"Drink with ID {id} deleted successfully.");
        }

        [HttpPut("{id}")]
        public ActionResult<string> Update(int id, [FromBody] DrinkModel drink)
        {
            if (drink == null || string.IsNullOrWhiteSpace(drink.Name) || string.IsNullOrWhiteSpace(drink.Description)) return BadRequest("Drink cannot be null and must have a name and description.");
            var result = _drinkService.Update(id, drink.Name, drink.Description, drink.IsAlcoholic);
            if (result.Contains("not found")) return NotFound(result);
            return Ok(result);
        }
    }
}

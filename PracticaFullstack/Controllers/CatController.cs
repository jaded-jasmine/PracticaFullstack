using Microsoft.AspNetCore.Mvc;
using PracticaFullstack.Models;

namespace Practica_22072025.Controllers
{
    public class CatController : Controller
    {
        private CatService _catService;

        public CatController(CatService catService)
        {
            _catService = catService;
            
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll() { 
        var result = _catService.GetAll();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _catService.GetById(id);
            return Ok(result);
        }

        [HttpPost("AddCat")]
        public IActionResult AddCat(Cat newCat)
        {
            var result = _catService.AddCat(newCat);
            return Ok(result);
        }

        [HttpDelete("DeleteCat")]
        public IActionResult DeleteCat(int id)
        {
            var result = _catService.DeleteCat(id);
            return Ok(result);
        }

        [HttpGet("FindCat")]
        public IActionResult FindCat(string partialName)
        {
            var result = _catService.FindCat(partialName);
            return Ok(result);
        }

        [HttpPut("UpdateCat")]
        public IActionResult UpdateCat(Cat updatedCat)
        {
            var result = _catService.UpdateCat(updatedCat);
            return Ok(result);
        }

        [HttpGet("GetRandomCat")]
        public IActionResult GetRandomCat()
        {
            var result = _catService.GetRandomCat();
            return Ok(result);
        }


        [HttpGet("Test")]
        public IActionResult Get()
        {
            return Ok(2);
        }
    }
}

using FootballStore.DataAccess.Repository.Interfaces;
using FootballStore.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FootballStore.API
{
    [Route("api/products")]
    [ApiController]
    public class FootballStoreAPI : ControllerBase
    {
        private IActionUnit _action;
        public FootballStoreAPI(IActionUnit action)
        {
            _action = action;
        }
        
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _action.Product.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _action.Product.GetT(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateNewProduct([FromBody] Product product)
        {
            if (product == null) { return BadRequest("Некорректные данные"); }
            _action.Product.Add(product);
            _action.Save();
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProductById(int id, [FromBody] Product updatedproduct)
        {
            var product = _action.Product.GetT(x => x.Id == id);
            if (product == null) { return NotFound("Продукт не найден."); }
            _action.Product.Update(updatedproduct);
            _action.Save();
            return Ok(product);
        }

        // DELETE api/<API>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProductById(int id)
        {
            var product = _action.Product.GetT(x => x.Id == id);
            if (product == null) { return NotFound("Продукт не найден."); }
            _action.Product.Delete(product);
            _action.Save();
            return Ok("Продукт успешно удален.");
        }
    }
}

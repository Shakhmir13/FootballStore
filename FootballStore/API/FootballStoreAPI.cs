using FootballStore.DataAccess.Repository.Interfaces;
using FootballStore.Models;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace FootballStore.API
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private IActionUnit _action;
        public ProductController(IActionUnit action)
        {
            _action = action;
        }

        /// <summary>
        /// Получение списка товаров
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Список товаров</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/products
        ///
        /// </remarks>
        /// <response code="200">Возвращает список товаров</response>
        /// <response code="400">Если каталог товаров пуст</response>
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

    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private IActionUnit _action;
        public CategoryController(IActionUnit action)
        {
            _action = action;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _action.Category.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var category = _action.Category.GetT(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public IActionResult CreateNewCategory([FromBody] Category category)
        {
            if (category == null) { return BadRequest("Некорректные данные"); }
            _action.Category.Add(category);
            _action.Save();
            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategoryById(int id, [FromBody] Category updatedcategory)
        {
            var category = _action.Category.GetT(x => x.Id == id);
            if (category == null) { return NotFound("Категория не найдена."); }
            _action.Category.Update(updatedcategory);
            _action.Save();
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategoryById(int id)
        {
            var category = _action.Category.GetT(x => x.Id == id);
            if (category == null) { return NotFound("Категория не найдена."); }
            _action.Category.Delete(category);
            _action.Save();
            return Ok("Категория успешно удалена.");
        }
    }

    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private IActionUnit _action;
        public OrderController(IActionUnit action)
        {
            _action = action;
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var orders = _action.Order.GetAll();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            var order = _action.Order.GetT(x => x.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public IActionResult CreateNewOrder([FromBody] Order order)
        {
            if (order == null) { return BadRequest("Некорректные данные"); }
            _action.Order.Add(order);
            _action.Save();
            return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
        }

        [ApiController]
        [Route("api/orderdetails")]
        public class OrderDetailsController : ControllerBase
        {
            private IActionUnit _action;
            public OrderDetailsController(IActionUnit action)
            {
                _action = action;
            }

            [HttpGet("{id}")]
            public IActionResult GetOrderDetailsByOrderId(int id)
            {
                var orderdetails = _action.OrderDetail.GetT(x => x.OrderId == id);
                if (orderdetails == null)
                {
                    return NotFound();
                }
                return Ok(orderdetails);
            }
        }
    }

    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private IActionUnit _action;
        public UsersController(IActionUnit action)
        {
            _action = action;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _action.ApplicationUser.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(string id)
        {
            var user = _action.ApplicationUser.GetT(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateNewUser([FromBody] ApplicationUser user)
        {
            if (user == null) { return BadRequest("Некорректные данные"); }
            _action.ApplicationUser.Add(user);
            _action.Save();
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUserById(string id, [FromBody] ApplicationUser updateduser)
        {
            var user = _action.ApplicationUser.GetT(x => x.Id == id);
            if (user == null) { return NotFound("Пользователь не найден."); }
            _action.ApplicationUser.Update(updateduser);
            _action.Save();
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUserById(string id)
        {
            var user = _action.ApplicationUser.GetT(x => x.Id == id);
            if (user == null) { return NotFound("Продукт не найден."); }
            _action.ApplicationUser.Delete(user);
            _action.Save();
            return Ok("Пользователь успешно удален.");
        }
    }
}

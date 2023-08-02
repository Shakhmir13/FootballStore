using FootballStore.DataAccess.Repository.Interfaces;
using FootballStore.DataAccess.ViewModels;
using FootballStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace FootballStore.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IActionUnit _action;
        public FilterVM ProductVM { get; set; }

        public HomeController(ILogger<HomeController> logger, IActionUnit action)
        {
            _logger = logger;
            _action = action;
        }

        public IActionResult Index()
        {
            ProductVM = new FilterVM();
            ProductVM.products = _action.Product.GetAll(includeProperties: "Category");
            ProductVM.Categories = _action.Category.GetAll();
            return View(ProductVM);
        }
        public IActionResult Filter(int categoryid, string? query)
        {
            ProductVM = new FilterVM();
            ProductVM.products = _action.Product.GetAll(x => x.CategoryId == categoryid || x.Name == query, includeProperties: "Category");
            ProductVM.Categories = _action.Category.GetAll();
            return View("Index", ProductVM);
        }
        public IActionResult Category()
        {
            IEnumerable<Category> categories = _action.Category.GetAll();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Details(int? productId)
        {
            Cart cart = new Cart()
            {
                Product = _action.Product.GetT(x => x.Id == productId, includeProperties: "Category"),
                Count = 1,
                ProductId = (int)productId
            };
            return View(cart);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Details(Cart cart)
        {
            if (ModelState.IsValid)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                cart.ApplicationUserId = claims.Value;
                var cartItem = _action.Cart.GetT(x => x.ProductId == cart.ProductId && x.ApplicationUserId == claims.Value);
                if (cartItem == null)
                {
                    _action.Cart.Add(cart);
                    _action.Save();

                }
                else
                {
                    _action.Cart.IncrementCartItem(cartItem, cart.Count);
                    _action.Save();
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using FootballStore.DataAccess.Repository.Interfaces;
using FootballStore.DataAccess.ViewModels;
using FootballStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FootballStore.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class CartController : Controller
    {
        private IActionUnit _action;
        public CartVM vm { get; set; }
        public CartController(IActionUnit action)
        {
            _action = action;
        }
        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            vm = new CartVM()
            {
                ListOfCart = _action.Cart.GetAll(x => x.ApplicationUserId == claims.Value, includeProperties: "Product"),
                Order = new Order()
            };
            foreach (var item in vm.ListOfCart)
            {
                vm.Order.Total += (item.Product.Price * item.Count);
            }
            return View(vm);
        }
        public IActionResult Summary()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            vm = new CartVM()
            {
                ListOfCart = _action.Cart.GetAll(x => x.ApplicationUserId == claims.Value, includeProperties: "Product"),
                Order = new Order()
            };
            ApplicationUser user = _action.ApplicationUser.GetT(x => x.Id == claims.Value);
            vm.Order.ApplicationUser = user;
            vm.Order.Address = user.Address;
            vm.Order.City = user.City;
            vm.Order.Phone = user.PhoneNumber;

            foreach (var item in vm.ListOfCart)
            {
                vm.Order.Total += (item.Product.Price * item.Count);
            }
            return View(vm);

        }

        [HttpPost]
        public IActionResult Summary(CartVM vm)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var cart = _action.Cart.GetT(x => x.ApplicationUserId == claims.Value, includeProperties: "Product");
            vm.ListOfCart = _action.Cart.GetAll(x => x.ApplicationUserId == claims.Value, includeProperties: "Product");

            vm.Order.ApplicationUserId = claims.Value;
            vm.Order.DateOfOrder = DateTime.Now.ToUniversalTime();


            foreach (var item in vm.ListOfCart)
            {
                vm.Order.Total += (item.Product.Price * item.Count);
            }
            _action.Order.Add(vm.Order);
            _action.Save();
            foreach (var item in vm.ListOfCart)
            {
                OrderDetail detail = new OrderDetail()
                {
                    ProductId = item.ProductId,
                    OrderId = vm.Order.Id,
                    Count = item.Count,
                    Price = item.Product.Price,
                };
                _action.OrderDetail.Add(detail);
                _action.Save();
            }

            _action.Cart.Delete(cart);
            _action.Save();
            return RedirectToAction("Index", "Order");

        }
        [HttpGet]
        public IActionResult plus(int id)
        {
            var cart = _action.Cart.GetT(x => x.Id == id);
            _action.Cart.IncrementCartItem(cart, 1);
            _action.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult minus(int id)
        {
            var cart = _action.Cart.GetT(x => x.Id == id);
            if (cart.Count <= 1)
            {
                _action.Cart.Delete(cart);
            }
            else
            {
                _action.Cart.DecrementalCartItem(cart, 1);
            }
            _action.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult delete(int id)
        {
            var cart = _action.Cart.GetT(x => x.Id == id);
            _action.Cart.Delete(cart);
            _action.Save();
            return RedirectToAction(nameof(Index));
        }

    }
}

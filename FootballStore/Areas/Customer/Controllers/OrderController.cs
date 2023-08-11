using FootballStore.DataAccess.Repository.Interfaces;
using FootballStore.DataAccess.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FootballStore.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class OrderController : Controller
    {
        private IActionUnit _action;
        public OrderVM vm { get; set; }
        public OrderController(IActionUnit action)
        {
            _action = action;
        }
        public ActionResult Index()
        {
            OrderVM vm = new OrderVM();
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            vm.orders = _action.Order.GetAll(x => x.ApplicationUserId == claims.Value);
            return View(vm);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

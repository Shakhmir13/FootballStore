using FootballStore.DataAccess.Repository.Interfaces;
using FootballStore.DataAccess.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FootballStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private IActionUnit _action;
        public CategoryController(IActionUnit action)
        {
            _action = action;
        }
        public IActionResult Index()
        {
            CategoryVM categoryVM = new CategoryVM();
            categoryVM.categories = _action.Category.GetAll();
            return View(categoryVM);
        }

        [HttpGet]
        public IActionResult CreateUpdate(int? id)
        {
            CategoryVM vm = new CategoryVM();
            if (id == null || id == 0)
            {
                return View(vm);
            }
            else
            {
                vm.category = _action.Category.GetT(x => x.Id == id);
                if (vm.category == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(vm);
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUpdate(CategoryVM vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.category.Id == 0)
                {
                    _action.Category.Add(vm.category);
                    TempData["success"] = "Категория добавлена";
                }
                else
                {
                    _action.Category.Update(vm.category);
                    TempData["success"] = "Категория обновлена";
                }
                _action.Save();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _action.Category.GetT(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteData(int id)
        {
            var category = _action.Category.GetT(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _action.Category.Delete(category);
            _action.Save();
            TempData["success"] = "Удалено";
            return RedirectToAction("Index");
        }
    }
}

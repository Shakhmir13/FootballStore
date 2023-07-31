using FootballStore.DataAccess.Repository;
using FootballStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using FootballStore.DataAccess.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace FootballStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private IActionUnit _action;
        private IWebHostEnvironment _hostingEnvironment;
        public ProductController(IActionUnit action, IWebHostEnvironment hostingEnvironment)
        {
            _action = action;
            _hostingEnvironment = hostingEnvironment;
        }
        
        public IActionResult AllProducts()
        {
            var products = _action.Product.GetAll(includeProperties: "Category");
            return Json(new { data = products });
        }
        
        public IActionResult Index()
        {
            //ProductVM productVM = new ProductVM();
            //productVM.Products = _action.Product.GetAll();
            return View();
        }

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(Category category)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _action.CAtegory.Add(category);
        //        _action.Save();
        //        TempData["success"] = "Категория создана";
        //        return RedirectToAction("Index");
        //    }
        //    return View(category);
        //}

        [HttpGet]
        public IActionResult CreateUpdate(int? id) 
        {
            ProductVM vm = new ProductVM()
            {
                product = new(),
                Categories = _action.Category.GetAll().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
            };
            if (id == null || id == 0)
            {
                return View(vm);
            }
            else
            {
                vm.product = _action.Product.GetT(x => x.Id == id);
                if (vm.product == null)
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
        public IActionResult CreateUpdate(ProductVM vm, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string fileName = String.Empty;
                if (file != null)
                {
                    string uploadPath = Path.Combine(_hostingEnvironment.WebRootPath, "ProductImage");
                    fileName = Guid.NewGuid().ToString()+file.FileName;
                    string filePath = Path.Combine(uploadPath, fileName);

                    if (vm.product.ImageUrl!=null)
                    {
                        var oldImagePath = Path.Combine(_hostingEnvironment.WebRootPath, vm.product.ImageUrl.TrimStart('\\'));
                        if(System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    vm.product.ImageUrl = @"\ProductImage\" + fileName;
                }
                if (vm.product.Id == 0)
                {
                    _action.Product.Add(vm.product);
                    TempData["success"] = "Товар добавлен";
                }
                else
                {
                    _action.Product.Update(vm.product);
                    TempData["success"] = "Товар изменен";
                }

                _action.Save();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        //[HttpGet]
        //public IActionResult Delete(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    var category = _action.Category.GetT(x => x.Id == id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(category);
        //}

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var product = _action.Product.GetT(x => x.Id == id);
            if (product != null)
            {
                return Json(new { success = false, message = "Ошибка" });
            }
            else
            {
                var oldImagePath = Path.Combine(_hostingEnvironment.WebRootPath, product.ImageUrl.TrimStart('\\'));
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
                _action.Product.Delete(product);
                _action.Save();
                return Json(new { success = true, message = "Товар удален"});
            }
        }
        
    }
}

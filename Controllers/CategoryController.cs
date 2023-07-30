using Ecommerce.Repository;
using ecommerce_testProject.Models;
using EcommerceModels.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_testProject.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository _categoryRepository;

        public CategoryController()
        {
            _categoryRepository = new CategoryRepository();
        }
        public IActionResult Index()
        {

            var category = _categoryRepository.GetAll();

            ICollection<CategoryListVM> categoryListVM = category.Select(ct => new CategoryListVM()
            {
                Id = ct.Id,
                Name = ct.Name,
                Description = ct.Description,
              
            }).ToList();

            return View(categoryListVM);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryCreate model)
        {
            if (ModelState.IsValid)
            {
                var category = new Category
                {
                    Name = model.Name,
                    Description = model.Description,
                   
                };

                bool isSuccess = _categoryRepository.Add(category);
                if (isSuccess)
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }


        public IActionResult Edit(int? id)
        {
            if (id <= 0)
            {
                ViewBag.Error = "Please Enter Valid Id ";
                return View();
            }
            var category = _categoryRepository.GetById((int)id);
            if (category == null)
            {
                ViewBag.Error = "Product Not Found";
                return View();
            }

            var categoryEditVM = new CategoryEditVM
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };

            return View(categoryEditVM);
        }

        [HttpPost]
        public IActionResult Edit(CategoryEditVM model)
        {
            if (ModelState.IsValid)
            {
                var category = new Category
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description
                };

                bool isSuccess = _categoryRepository.Update(category);
                if (isSuccess)
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        public IActionResult Details(int id)
        {
            if (id <= 0)
            {
                ViewBag.Error = "Please Enter Valid Id ";
                return View();
            }
            var category = _categoryRepository.GetById(id);
            if (category == null)
            {
                ViewBag.Error = "Product Not Found";
                return View();
            }

            var categoryDetailsVM = new CategoryListVM
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };

            return View(categoryDetailsVM);
        }

        public IActionResult Delete(int id)
        {

            var category = _categoryRepository.GetById(id);

            if (category == null)
            {
                return NotFound();
            }

            // Database operations 
            bool isSuccess = _categoryRepository.Delete(category);

            if (isSuccess)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}

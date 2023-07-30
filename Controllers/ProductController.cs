using Ecommerce.Repository;
using ecommerce_testProject.Models;
using EcommerceModels.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_testProject.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository _productRepository;

        public ProductController()
        {
            _productRepository = new ProductRepository();
        }
        public IActionResult Index()
        {
            
            var product = _productRepository.GetAll();

            ICollection<ProductListVM> productListVM = product.Select(p => new ProductListVM()
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Color = p.Color,
                Size = p.Size,
                Price = p.Price
            }).ToList();

            return View(productListVM);
        }

       public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductCreate model)
        {
            if(ModelState.IsValid)
            {
                var product = new Product
                {
                    Name = model.Name,
                    Description = model.Description,
                    Color = model.Color,
                    Size = model.Size,
                    Price = model.Price
                };

                bool isSuccess = _productRepository.Add(product);
                if(isSuccess)
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }


        public IActionResult Edit(int? id) 
        {
            if(id<=0)
            {
                ViewBag.Error = "Please Enter Valid Id ";
                return View();
            }
            var product = _productRepository.GetById((int)id);
            if(product==null)
            {
                ViewBag.Error = "Product Not Found";
                return View();
            }

            var productEditVM = new ProductEditVM
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Color = product.Color,
                Size = product.Size,
                Price = product.Price
            };

            return View(productEditVM);
        }

        [HttpPost]
        public IActionResult Edit(ProductEditVM model)
        {
            if(ModelState.IsValid)
            {
                var product = new Product
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    Color = model.Color,
                    Size = model.Size,
                    Price = model.Price
                };

                bool isSuccess = _productRepository.Update(product);
                if(isSuccess)
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        public IActionResult Details(int? id)
        {
            if(id<=0)
            {
                ViewBag.Error = "Please Enter Valid Id ";
                return View();
            }
            var product = _productRepository.GetById((int)id);
            if(product==null)
            {
                ViewBag.Error = "Product Not Found";
                return View();
            }

            var productDetailsVM = new ProductListVM
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Color = product.Color,
                Size = product.Size,
                Price = product.Price
            };

            return View(productDetailsVM);
        }

        public IActionResult Delete(int id)
        {

            var product = _productRepository.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            // Database operations 
            bool isSuccess = _productRepository.Delete(product);

            if (isSuccess)
            {
                return RedirectToAction("Index");
            }

            return View();
        }


    }
}

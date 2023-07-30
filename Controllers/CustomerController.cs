using Ecommerce.Repository;
using ecommerce_testProject.Models;
using EcommerceModels.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_testProject.Controllers
{
    public class CustomerController : Controller
    {
        CustomerRepository _customerRepository;

        public CustomerController()
        {
            _customerRepository = new CustomerRepository();
        }
        public IActionResult Index()
        {
            var customer = _customerRepository.GetAll();

            ICollection<CustomerListViewModel> customerListViewModels = customer.Select(c => new CustomerListViewModel()
            {
                Id = c.Id,
                Name = c.Name,
                PhoneNumber = c.PhoneNumber,
                Email = c.Email
            }).ToList();

            return View(customerListViewModels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerCreate model)
        {
          /* return $"Customer Name: {customer.Name}, Phone Number: {customer.PhoneNumber}, Email: {customer.Email}";*/
            

           if( ModelState.IsValid)
            {
                //database operation
                var customer = new Customer
                {
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    Country=model.Country,
                    City=model.City
                };

                bool isSuccess = _customerRepository.Add(customer);
                if(isSuccess)
                {
                    return RedirectToAction("Index");
                }               
            }

            return View();
        }

        public IActionResult Details(int id)
        {
            // Retrieve the customer by id
            var customer = _customerRepository.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }

            // Map the customer to the CustomerEdit model
            var model = new CustomerListViewModel()
            {
                Id = customer.Id,
                Name = customer.Name,
                PhoneNumber = customer.PhoneNumber,
                Email = customer.Email,
                Country=customer.Country,
                City=customer.City
            };

            return View(model);
        }


        public IActionResult Edit(int? id)
        {
            if(id == null || id<=0)
            {
                ViewBag.Error="Provide valid id";
                return View();
            }

            var customer = _customerRepository.GetById((int)id);

            if(customer == null)
            {
                ViewBag.Error = "Customer not found";
                return View();
            }

            var customerEditVM = new CustomerEditVM
            {
                Id = customer.Id,
                Name = customer.Name,
                PhoneNumber = customer.PhoneNumber,
                Email = customer.Email,
                Country=customer.Country,
                City=customer.City
            };


            return View(customerEditVM);
        }

        [HttpPost]
        public IActionResult Edit(CustomerEditVM model)
        {
            if (ModelState.IsValid)
            {
                var customer = _customerRepository.GetById(model.Id);
                {

                    customer.Name = model.Name;
                    customer.PhoneNumber = model.PhoneNumber;
                    customer.Country = model.Country;
                    customer.City = model.City;
                };

                bool isSuccess = _customerRepository.Update(customer);
                if (isSuccess)
                {
                    return RedirectToAction("Index");
                }

                return View();
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var customer = _customerRepository.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }

            // Database operations 
            bool isSuccess = _customerRepository.Delete(customer);

            if (isSuccess)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
    
}

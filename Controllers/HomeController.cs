using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServerVKR.Models;
using ServerVKR.Services;

namespace ServerVKR.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductsService _productsService;
        private readonly CategoryService _categoryService;
        private readonly OrdersService _ordersService;
        public HomeController(CategoryService categoryService, ProductsService productsService, OrdersService ordersService) {
            _productsService = productsService;
            _categoryService = categoryService;
            _ordersService = ordersService;
        }
        public IActionResult Index()
        {
            var categories = _categoryService.GetCategories();

            return View(categories);
        }

        public IActionResult Catalog(Guid categoryId)
        {
            var categories = _categoryService.GetCategories();

            var category = categories.SingleOrDefault(c => c.Id == categoryId);
            
            CatalogViewModel model = new CatalogViewModel {
                Categories = categories,
                Products = category == null ? _productsService.GetProducts() : category.Products
            };
            
            return View(model);
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order model)
        {
            _ordersService.AddOrder(model);            
            
            return RedirectToAction("Index");
        }

        public IActionResult Cart()
        {
            return View();
        }
        public IActionResult Aboutshop()
        {
            return View();
        }
        public IActionResult DeliveryPayment()
        {
            return View();
        }

        [HttpGet]
         public IActionResult Product(Guid? id)
        {
            Product product = _productsService.GetProduct(id);

            return View(product);
        }
       
        public IActionResult CheckIn()
        {
            return View();
        }
        public IActionResult Enter()
        {
            return View();
        }
        public IActionResult Reviews()
        {
            return View();
        }

        public IActionResult CakeFilling()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

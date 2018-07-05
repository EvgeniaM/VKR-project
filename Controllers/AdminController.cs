using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServerVKR.Models;
using ServerVKR.Data;
using ServerVKR.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace ServerVKR.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminController : Controller
    {
        
        private readonly ProductsService _productsService;
        private readonly CategoryService _categoryService;
        private readonly OrdersService _ordersService;
        private readonly DeliveryService _deliveryService;
        private readonly ReviewsService _reviewsService;
        public AdminController(ProductsService productsService, CategoryService categoryService, OrdersService ordersService, DeliveryService deliveryService, ReviewsService reviewsService) {
            _productsService = productsService;
            _categoryService = categoryService;
            _ordersService = ordersService;
            _deliveryService = deliveryService;
            _reviewsService = reviewsService;
            
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdminReviews()
        {
            var reviews = _reviewsService.GetReviews();
            return View(reviews);
        }
        public IActionResult ReviewRemove(Guid? id) { 

            _reviewsService.RemoveReview(id);

            return RedirectToAction("AdminReviews");
        }
        //Заказы
        public IActionResult Orders()
        {
            var orders = _ordersService.GetOrders().Where(o => o.Status != "Выполнен").ToList();
            
            return View(orders);
        }
        public IActionResult DoneOrders()
        {
            var orders = _ordersService.GetOrders().Where(o => o.Status == "Выполнен").ToList();
            
            return View(orders);
        }
        public IActionResult OrderRemove(Guid? id) { 

            _ordersService.RemoveOrder(id);

            return RedirectToAction("Orders");
        }
         public IActionResult Order(Guid? id)
        {
            
            Order order = _ordersService.GetOrder(id);

            return View(order);
        }
        [HttpGet]
        public IActionResult OrderEdit(Guid? id) {
            Order order = _ordersService.GetOrder(id);

            return View(order);
        }
        [HttpPost]
        public IActionResult OrderEdit(Order order) { 

            _ordersService.EditOrder(order);
            
            return RedirectToAction("Orders");
        }
        //Товары
        public IActionResult Products()
        {
            var products = _productsService.GetProducts();

            return View(products);
        }

        [HttpGet]
        public IActionResult ProductAddEdit(Guid? id) {
            Product product = id == null ? new Product { NewItem = true } : _productsService.GetProduct(id);
            if (product.Category != null) {
                product.IdForCategory = product.Category.Id;
            }
            var categories = _categoryService.GetCategories();
            product.Categories = categories;
            return View(product);
        }

        [HttpPost]
        public IActionResult ProductAddEdit(Product product) { 
            if (product.NewItem) {
                _productsService.AddProduct(product);
            } else {
                _productsService.EditProduct(product);
            }
            
            return RedirectToAction("Products");
        }

        
        public IActionResult ProductRemove(Guid? id) { 

            _productsService.RemoveProduct(id);

            return RedirectToAction("Products");
        }
        //Категории
        public IActionResult Categories()
        {
            var categories = _categoryService.GetCategories();
            
            return View(categories);
        }
        
        [HttpGet]
        public IActionResult CategoryAddEdit(Guid? id) {
            Category category = id == null ? new Category { NewItem = true } : _categoryService.GetCategory(id);

            return View(category);
        }

        [HttpPost]
        public IActionResult CategoryAddEdit(Category category) { 
            if (category.NewItem) {
                _categoryService.AddCategory(category);
            } else {
                _categoryService.EditCategory(category);
            }

            return RedirectToAction("Categories");
        }

        public IActionResult CategoryRemove(Guid? id) { 

            _categoryService.RemoveCategory(id);

            return RedirectToAction("Categories");
        }

        public IActionResult CategorysProducts(Guid categoryId)
        {
            var categories = _categoryService.GetCategories();

            var category = categories.SingleOrDefault(c => c.Id == categoryId);
            
            CatalogViewModel model = new CatalogViewModel {
                Categories = categories,
                Products = category == null ? _productsService.GetProducts().Where(p => p.Category == null).ToList() : category.Products.Where(p => p.IsRemoved ==false).ToList()
            };
        
            return View(model);
        }

        public IActionResult DeliveryMethods() 
        {
            var methods = _deliveryService.GetDeliveryMethods();
            
            return View(methods);
        }
        [HttpGet]
        public IActionResult DeliveryMethodsAddEdit(Guid? id) 
        {
            Delivery method = id == null ? new Delivery { NewItem = true } : _deliveryService.GetDeliveryMethod(id);

            return View(method);
        }
        
        [HttpPost]
        public IActionResult DeliveryMethodsAddEdit(Delivery method) { 
            if (method.NewItem) {
                _deliveryService.AddMethod(method);
            } else {
                _deliveryService.EditMethod(method);
            }

            return RedirectToAction("DeliveryMethods");
        }

        public IActionResult DeliveryRemove(Guid? id) { 
            
            _deliveryService.RemoveMethod(id);

            return RedirectToAction("DeliveryMethods");
        }
    }
}
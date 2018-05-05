using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServerVKR.Models;
using ServerVKR.Data;
using ServerVKR.Services;

namespace ServerVKR.Controllers
{
    public class AdminController : Controller
    {
        
        private readonly ProductsService _productsService;
        private readonly CategoryService _categoryService;
        public AdminController(ProductsService productsService, CategoryService categoryService) {
            _productsService = productsService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Store.BL.ProductLogic;
using Store.Models.Product;

namespace Store.Controllers
{
    public class ProductController : Controller
    {
        public readonly ProductRepo _productRepo;
        public ProductController(ProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet]
        public IActionResult GetProducts(int id)
        {
            ProductsVM model = new ProductsVM();
            model.products = _productRepo.GetProducts(id);
            return View(model);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            ProductVM model = new ProductVM();
            model.product = _productRepo.Detail(id);
            return View(model);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            ProductsVM model = new ProductsVM();
            model.products = _productRepo.GetAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductModel product) 
        {
            if (ModelState.IsValid)
            {
                decimal k =_productRepo.CreateProduct(product);
                if (k != 0)
                {
                    return RedirectToAction(nameof(GetAll));
                }
            }
            return View(product);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ProductVM product = new ProductVM();
            product.product =_productRepo.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                _productRepo.UpdateProduct(product);

                return RedirectToAction(nameof(GetAll));
            }
            return View(product);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ProductVM product = new ProductVM();
            product.product = _productRepo.Find(id);
            
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpDelete]
        public IActionResult DeleteConfirmed(int id)
        {
            _productRepo.DeleteProduct(id);
            return RedirectToAction(nameof(GetAll));
        }
    }
}
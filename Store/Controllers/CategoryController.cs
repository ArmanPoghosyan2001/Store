using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.BL.CategoryLogic;
using Store.Models.Category;

namespace Store.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryRepo _categoryRepo;

        public CategoryController(CategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public IActionResult Index()
        {
            CategoryVM model = new CategoryVM();
            model.categories = _categoryRepo.GetCategories();
            return View(model);
        }
    }
}
using Models;
using Store.DAL.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.BL.CategoryLogic
{
    public class CategoryRepo
    {
        public readonly CategoryContext _categoryContext;

        public CategoryRepo()
        {
            _categoryContext = new CategoryContext();
        }
        public List<CategoryModel> GetCategories()
        {
            return _categoryContext.GetCategories();
        }
    }
}

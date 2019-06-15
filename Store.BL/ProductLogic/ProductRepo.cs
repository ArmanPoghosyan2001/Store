using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Store.DAL.Product;

namespace Store.BL.ProductLogic
{
    public class ProductRepo : IProductRepo
    {
        public ProductContext _productContext;

        public ProductRepo()
        {
            _productContext = new ProductContext();
        }

        public decimal CreateProduct(ProductModel product)
        {
            return _productContext.CreateProduct(product);
        }

        public int UpdateProduct(ProductModel product)
        {
            return _productContext.UpdateProduct(product);
        }

        public int DeleteProduct(int id)
        {
            return _productContext.DeleteProduct(id);
        }

        public List<ProductModel> GetAll()
        {
            return _productContext.GetAll();
        }

        public ProductModel Detail(int id)
        {
            return _productContext.Detail(id);
        }

        public List<ProductModel> GetProducts(int id)
        {
            return _productContext.GetProducts(id);
        }

        public ProductModel Find(int id)
        {
            return _productContext.Find(id);
        }
        
    }
}

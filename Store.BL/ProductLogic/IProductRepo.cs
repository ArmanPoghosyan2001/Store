using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.BL.ProductLogic
{
    public interface IProductRepo
    {
        decimal CreateProduct(ProductModel product);
        int UpdateProduct(ProductModel product);
        int DeleteProduct(int id);
        ProductModel Detail(int id);
        List<ProductModel> GetProducts(int id);
        List<ProductModel> GetAll();
    }
}

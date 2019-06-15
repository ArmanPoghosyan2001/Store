﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ProductInfo { get; set; }
    }
}

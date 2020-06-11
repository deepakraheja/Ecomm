﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using uccApiCore2.Entities;

namespace uccApiCore2.Repository.Interface
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductBySubcatecode(Product obj);
        Task<List<Product>> GetAllProductBySupplierId(Product obj);
        Task<List<Product>> GetProductById(Product obj);
        Task<int> SaveProduct(Product obj);
        Task<List<Product>> GetProductByPopular();
		 Task<int> SaveProductSizeColor(ProductSizeColor obj);
        Task<List<ProductSizeColor>> GetProductSizeColorById(ProductSizeColor obj);
        Task<int> DeleteProductSizeColor(ProductSizeColor obj);

        Task<List<Product>> GetBannerProduct();
        Task<List<Product>> GetProductBybyRowID(Product obj);
    }
}

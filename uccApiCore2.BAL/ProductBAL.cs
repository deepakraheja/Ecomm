﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using uccApiCore2.BAL.Interface;
using uccApiCore2.Entities;
using uccApiCore2.Repository.Interface;

namespace uccApiCore2.BAL
{
    public class ProductBAL : IProductBAL
    {
        IProductRepository _IProductRepository;

        public ProductBAL(IProductRepository IProductRepository)
        {
            _IProductRepository = IProductRepository;
        }

        public Task<List<Product>> GetProductBySubcatecode(Product obj)
        {
            return _IProductRepository.GetProductBySubcatecode(obj);
        }

        public Task<List<Product>> GetAllProductBySupplierId(Product obj)
        {
            return _IProductRepository.GetAllProductBySupplierId(obj);
        }
        public Task<List<Product>> GetProductById(Product obj)
        {
            return _IProductRepository.GetProductById(obj);
        }

        public Task<List<Product>> GetProductByRowID(Product obj)
        {
            return _IProductRepository.GetProductByRowID(obj);
        }
        public Task<List<ProductSizeColor>> GetProductSizeColorByRowID(ProductSizeColor obj)
        {
            return _IProductRepository.GetProductSizeColorByRowID(obj);
        }
        public Task<int> SaveProduct(Product obj)
        {
            return _IProductRepository.SaveProduct(obj);
        }

        public Task<List<Product>> GetProductByPopular()
        {
            return _IProductRepository.GetProductByPopular();
        }
        public Task<int> SaveProductSizeColor(ProductSizeColor obj)
        {
            return _IProductRepository.SaveProductSizeColor(obj);
        }
        public Task<List<ProductSizeColor>> GetProductSizeColorById(ProductSizeColor obj)
        {
            return _IProductRepository.GetProductSizeColorById(obj);
        }

        public Task<List<ProductSizeColor>> GetProductSizeColorByRowID(string RowID)
        {
            return _IProductRepository.GetProductSizeColorByRowID(RowID);
        }

        public Task<int> DeleteProductSizeColor(ProductSizeColor obj)
        {
            return _IProductRepository.DeleteProductSizeColor(obj);
        }

        public Task<List<Product>> GetBannerProduct()
        {
            return _IProductRepository.GetBannerProduct();
        }
      

        public string[] GetProductColorByRowID(string RowID)
        {
            return _IProductRepository.GetProductColorByRowID(RowID);
        }

        public string[] GetProductSizeByRowID(string RowID)
        {
            return _IProductRepository.GetProductSizeByRowID(RowID);
        }
    }
}

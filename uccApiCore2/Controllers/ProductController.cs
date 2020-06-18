using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using uccApiCore2.BAL.Interface;
using uccApiCore2.Controllers.Common;
using uccApiCore2.Entities;

namespace uccApiCore2.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : BaseController<ProductController>
    {
        IProductBAL _IProductBAL;
        Utilities _utilities = new Utilities();
        public static string webRootPath;

        public ProductController(IHostingEnvironment hostingEnvironment, IProductBAL ProductBAL)
        {
            _IProductBAL = ProductBAL;
            webRootPath = hostingEnvironment.WebRootPath;
        }

        [HttpPost]
        [Route("GetProductBySubcatecode")]
        public async Task<List<Product>> GetProductBySubcatecode([FromBody] Product obj)
        {
            try
            {
                return await this._IProductBAL.GetProductBySubcatecode(obj);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside ProductController GetProductBySubcatecode action: {ex.Message}");
                return null;
            }
        }



        [HttpPost]
        [Route("GetProductByPopular")]
        public async Task<List<Product>> GetProductByPopular()
        {
            try
            {
                return await this._IProductBAL.GetProductByPopular();
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside ProductController GetProductByPopular action: {ex.Message}");
                return null;
            }
        }


        [HttpPost]
        [Route("GetBannerProduct")]
        public async Task<List<Product>> GetBannerProduct()
        {
            try
            {
                return await this._IProductBAL.GetBannerProduct();
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside ProductController GetBannerProduct action: {ex.Message}");
                return null;
            }
        }

        [HttpPost]
        [Route("GetAllProductBySupplierId")]
        public async Task<List<Product>> GetAllProductBySupplierId([FromBody] Product obj)
        {
            try
            {
                return await this._IProductBAL.GetAllProductBySupplierId(obj);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside ProductController GetAllProductBySupplierId action: {ex.Message}");
                return null;
            }
        }

        [HttpPost]
        [Route("GetProductByRowID")]
        public async Task<List<Product>> GetProductByRowID([FromBody] Product obj)
        {
            try
            {
                List<Product> lst = this._IProductBAL.GetProductByRowID(obj).Result;
                //lst[0].BannerImg = _utilities.ProductImagePath(obj.ProductID, "bannerImage", webRootPath);
                lst[0].ProductImg = _utilities.ProductImage(lst[0].ProductID, "productColorImage", webRootPath);

                //lst[0].ProductImg = _utilities.ProductImage(lst[0].ProductID, "productImages", webRootPath);
                return await Task.Run(() => new List<Product>(lst));
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside ProductController GetProductBybyRowID action: {ex.Message}");
                return null;
            }
        }
                ///return await this._IProductBAL.GetProductBybyRowID(obj);
        [HttpPost]
        [Route("GetProductSizeColorByRowID")]
        public async Task<List<ProductSizeColor>> GetProductSizeColorByRowID([FromBody] ProductSizeColor obj)
        {
            try
            {
                List<ProductSizeColor> lst = this._IProductBAL.GetProductSizeColorByRowID(obj).Result;
                return await Task.Run(() => new List<ProductSizeColor>(lst));
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside ProductController GetProductBybyRowID action: {ex.Message}");
                return null;
            }
        }

        [HttpPost]
        [Route("GetProductById")]
        public async Task<List<Product>> GetProductById([FromBody] Product obj)
        {
            try
            {
                List<Product> lst = this._IProductBAL.GetProductById(obj).Result;
                lst[0].BannerImg = _utilities.ProductImagePath(obj.ProductID, "bannerImage", webRootPath);
                lst[0].SmallImg = _utilities.ProductImagePath(obj.ProductID, "frontImage", webRootPath);
                //lst[0].ProductImg = _utilities.ProductImagePath(obj.ProductID, "productImages", webRootPath);
                return await Task.Run(() => new List<Product>(lst));
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside ProductController GetProductById action: {ex.Message}");
                return null;
            }
        }

        [HttpPost]
        [Route("SaveProduct")]
        public async Task<int> SaveProduct([FromBody] Product obj)
        {
            try
            {
                int NewProductId = await this._IProductBAL.SaveProduct(obj);
                if (obj.ProductID > 0)
                {
                    _utilities.SaveImage(obj.ProductID, obj.BannerImg, "bannerImage", webRootPath);
                    _utilities.SaveImage(obj.ProductID, obj.SmallImg, "frontImage", webRootPath);
                    //_utilities.SaveImage(obj.ProductID, obj.ProductImg, "productImages", webRootPath);
                    return obj.ProductID;
                }
                else
                {
                    _utilities.SaveImage(NewProductId, obj.BannerImg, "bannerImage", webRootPath);
                    _utilities.SaveImage(NewProductId, obj.SmallImg, "frontImage", webRootPath);
                    //_utilities.SaveImage(NewProductId, obj.ProductImg, "productImages", webRootPath);
                    return NewProductId;
                }


            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside ProductController SaveProduct action: {ex.Message}");
                return -1;
            }
        }

        [HttpPost]
        [Route("SaveProductSizeColor")]
        public async Task<int> SaveProductSizeColor([FromBody] ProductSizeColor obj)
        {
            try
            {
                int ProductSizeColorId = await this._IProductBAL.SaveProductSizeColor(obj);
                return ProductSizeColorId;
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside ProductController SaveProductSizeColor action: {ex.Message}");
                return -1;
            }
        }
        [HttpPost]
        [Route("SaveProductSizeColorImages")]
        public async Task<int> SaveProductSizeColorImages([FromBody] ProductSizeColor obj)
        {
            try
            {
                if (obj.ProductSizeColorId > 0)
                {
                    _utilities.SaveImage(obj.ProductId, obj.ProductImg, ("productColorImage/" + obj.ProductSizeColorId), webRootPath);
                }
                return await Task.Run(() => obj.ProductSizeColorId);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside ProductController SaveProductSizeColor action: {ex.Message}");
                return -1;
            }
        }
        [HttpPost]
        [Route("GetProductSizeColorById")]
        public async Task<List<ProductSizeColor>> GetProductSizeColorById([FromBody] ProductSizeColor obj)
        {
            try
            {
                List<ProductSizeColor> lst = this._IProductBAL.GetProductSizeColorById(obj).Result;
                foreach (var item in lst)
                {
                    item.ProductImg = _utilities.ProductImagePath(item.ProductId, ("productColorImage/" + item.ProductSizeColorId), webRootPath);
                }

                return await Task.Run(() => new List<ProductSizeColor>(lst));
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside ProductController GetProductSizeColorById action: {ex.Message}");
                return null;
            }
        }
        [HttpPost]
        [Route("DeleteProductSizeColor")]
        public async Task<int> DeleteProductSizeColor([FromBody] ProductSizeColor obj)
        {
            try
            {
                return await this._IProductBAL.DeleteProductSizeColor(obj);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside ProductController DeleteProductSizeColor action: {ex.Message}");
                return -1;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
       
        
        public ProductController(IProductBAL ProductBAL)
        {
            _IProductBAL = ProductBAL;
            
        }
   
        [HttpPost]
        [Route("GetProductBySubcatecode")]
        public async Task<List<Product>> GetProductBySubcatecode([FromBody]Product obj)
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
        [Route("GetProductById")]
        public async Task<List<Product>> GetProductById([FromBody]Product obj)
        {
            try
            {
                return await this._IProductBAL.GetProductById(obj);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside ProductController GetProductById action: {ex.Message}");
                return null;
            }
        }
    }
}
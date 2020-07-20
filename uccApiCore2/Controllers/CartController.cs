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
    public class CartController : BaseController<CartController>
    {
        ICartBAL _ICartBAL;
        Utilities _utilities = new Utilities();
        public static string webRootPath;
        public CartController(IHostingEnvironment hostingEnvironment, ICartBAL CartBAL)
        {
            _ICartBAL = CartBAL;
            webRootPath = hostingEnvironment.WebRootPath;
        }

        [HttpPost]
        [Route("AddToCart")]
        public async Task<int> AddToCart([FromBody] Cart obj)
        {
            try
            {
                return await this._ICartBAL.AddToCart(obj);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside CartController AddToCart action: {ex.Message}");
                return -1;
            }
        }

        [HttpPost]
        [Route("DelCartById")]
        public async Task<List<Cart>> DelCartById([FromBody] Cart obj)
        {
            try
            {
                return await this._ICartBAL.DelCartById(obj);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside CartController DelCartById action: {ex.Message}");
                return null;
            }
        }

        [HttpPost]
        [Route("GetCartById")]
        public async Task<List<Cart>> GetCartById([FromBody] Cart obj)
        {
            try
            {
                //return await this._ICartBAL.GetCartById(obj);
                List<Cart> lst = this._ICartBAL.GetCartById(obj).Result;
                foreach (var item in lst)
                {
                    item.ProductImg = _utilities.ProductImagePath(item.ProductId, ("productColorImage/" + item.ProductSizeColorId), webRootPath);
                }

                return await Task.Run(() => new List<Cart>(lst));
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside CartController GetCartById action: {ex.Message}");
                return null;
            }
        }
    }
}

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
    public class OrderController : BaseController<OrderController>
    {
        IOrderBAL _IOrderBAL;
        Utilities _utilities = new Utilities();
        public static string webRootPath;
        public OrderController(IHostingEnvironment hostingEnvironment, IOrderBAL OrderBAL)
        {
            _IOrderBAL = OrderBAL;
            webRootPath = hostingEnvironment.WebRootPath;
        }

        [HttpPost]
        [Route("SaveOrder")]
        public async Task<int> SaveOrder([FromBody] Order obj)
        {
            try
            {
                return await this._IOrderBAL.SaveOrder(obj);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside OrderController SaveOrder action: {ex.Message}");
                return -1;
            }
        }

        [HttpPost]
        [Route("GetOrderByOrderId")]
        public async Task<List<Order>> GetOrderByOrderId([FromBody] Order obj)
        {
            try
            {
                List<Order> lst = this._IOrderBAL.GetOrderByOrderId(obj).Result;
                lst[0].OrderDetails = this._IOrderBAL.GetOrderDetailsByOrderId(obj).Result;
                foreach (var item in lst[0].OrderDetails)
                {
                    if (item.SetNo > 0)
                        item.ProductImg = _utilities.ProductImage(item.ProductId, "productSetImage", webRootPath, item.SetNo);
                    else
                        item.ProductImg = _utilities.ProductImage(item.ProductId, "productColorImage", webRootPath, item.ProductSizeColorId);
                }
                return await Task.Run(() => new List<Order>(lst));
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside OrderController GetOrderByOrderId action: {ex.Message}");
                return null;
            }
        }

        [HttpPost]
        [Route("GetOrderByUserId")]
        public async Task<List<Order>> GetOrderByUserId([FromBody] Order obj)
        {
            try
            {
                List<Order> lst = this._IOrderBAL.GetOrderByUserId(obj).Result;
                lst[0].OrderDetails = this._IOrderBAL.GetOrderDetailsByUserId(obj).Result;
                foreach (var item in lst[0].OrderDetails)
                {
                    if (item.SetNo > 0)
                        item.ProductImg = _utilities.ProductImagePath(item.ProductId, ("productSetImage/" + item.SetNo), webRootPath);
                    else
                        item.ProductImg = _utilities.ProductImagePath(item.ProductId, ("productColorImage/" + item.ProductSizeColorId), webRootPath);
                }
                return await Task.Run(() => new List<Order>(lst));
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside OrderController GetOrderByUserId action: {ex.Message}");
                return null;
            }
        }
    }
}

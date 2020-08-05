using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using uccApiCore2.BAL.Interface;
using uccApiCore2.Controllers.Common;
using uccApiCore2.Entities;
namespace uccApiCore2.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    public class BillingAddressController : BaseController<BillingAddressController>
    {
        IBillingAddressBAL _IBillingAddressBAL;
        Utilities _utilities = new Utilities();
        public static string webRootPath;
        public BillingAddressController(IHostingEnvironment hostingEnvironment, IBillingAddressBAL BillingAddressBAL)
        {
            _IBillingAddressBAL = BillingAddressBAL;
            webRootPath = hostingEnvironment.WebRootPath;
        }

        [HttpPost]
        [Route("SaveBillingAddress")]
        public async Task<List<BillingAddress>> SaveBillingAddress([FromBody] BillingAddress obj)
        {
            try
            {
                return await this._IBillingAddressBAL.SaveBillingAddress(obj);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside BillingAddressController SaveBillingAddress action: {ex.Message}");
                return null;
            }
        }

        [HttpPost]
        [Route("GetBillingAddress")]
        public async Task<List<BillingAddress>> GetBillingAddress([FromBody] BillingAddress obj)
        {
            try
            {
                return await this._IBillingAddressBAL.GetBillingAddress(obj);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside BillingAddressController GetBillingAddress action: {ex.Message}");
                return null;
            }
        }

        [HttpPost]
        [Route("DeleteBillingAddress")]
        public async Task<List<BillingAddress>> DeleteBillingAddress([FromBody] BillingAddress obj)
        {
            try
            {
                return await this._IBillingAddressBAL.DeleteBillingAddress(obj);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside BillingAddressController DeleteBillingAddress action: {ex.Message}");
                return null;
            }
        }
    }
}

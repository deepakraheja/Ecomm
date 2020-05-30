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
    public class BrandController : BaseController<BrandController>
    {
        IBrandBAL _Brand;


        public BrandController(IBrandBAL Brand)
        {
            _Brand = Brand;

        }

        [HttpPost]
        [Route("GetBrand")]
        public async Task<List<Brand>> GetBrand([FromBody]Brand obj)
        {
            try
            {
                return await this._Brand.GetBrand(obj);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside BrandController GetBrand action: {ex.Message}");
                return null;
            }
        }

    }
}
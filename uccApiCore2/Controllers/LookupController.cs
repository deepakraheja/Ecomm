using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using uccApiCore2.BAL.Interface;
using uccApiCore2.Controllers.Common;
using uccApiCore2.Entities;

namespace uccApiCore2.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    public class LookupController : BaseController<LookupController>
    {
        ILookupBAL _lookupBAL;
        public LookupController(ILookupBAL lookupBAL)
        {
            _lookupBAL = lookupBAL;
        }

        [HttpPost]
        [Route("GetActiveColor")]
        public async Task<List<LookupColor>> GetActiveColor()
        {
            return await _lookupBAL.GetActiveColor();
        }
        [HttpPost]
        [Route("GetActiveSize")]
        public async Task<List<LookupSize>> GetActiveSize()
        {
            return await _lookupBAL.GetActiveSize();
        }
        [HttpPost]
        [Route("GetOrderStatus")]
        public async Task<List<LookupOrderStatus>> GetOrderStatus()
        {
            return await _lookupBAL.GetOrderStatus();
        }
    }
}

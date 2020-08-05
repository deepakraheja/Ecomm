using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    public class TagController : BaseController<TagController>
    {
        ILookupTagBAL _lookupTag;
        public TagController(ILookupTagBAL lookupTag)
        {
            _lookupTag = lookupTag;

        }

        [HttpPost]
        [Route("GetTag")]
        public async Task<List<LookupTag>> GetTag([FromBody] LookupTag obj)
        {
            try
            {
                return await this._lookupTag.GetTag(obj);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside TagController GetTag action: {ex.Message}");
                return null;
            }
        }

        [HttpPost]
        [Route("GetAllTag")]
        public async Task<List<LookupTag>> GetAllTag([FromBody] LookupTag obj)
        {
            try
            {
                return await this._lookupTag.GetAllTag(obj);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside TagController GetAllTag action: {ex.Message}");
                return null;
            }
        }

        [HttpPost]
        [Route("SaveTag")]
        public async Task<int> SaveTag([FromBody] LookupTag obj)
        {
            try
            {
                return await this._lookupTag.SaveTag(obj);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside TagController SaveTag action: {ex.Message}");
                return -1;
            }
        }
    }
}

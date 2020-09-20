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
    public class TransportController : BaseController<TransportController>
    {
        ITransportBAL _Transport;
        public TransportController(ITransportBAL Transport)
        {
            _Transport = Transport;
        }
        [HttpPost]
        [Route("GetTransport")]
        public async Task<List<Transport>> GetTransport([FromBody] Transport obj)
        {
            try
            {
                return await this._Transport.GetTransport(obj);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside TransportController GetTransport action: {ex.Message}");
                return null;
            }
        }
        [HttpPost]
        [Route("GetAllTransport")]
        public async Task<List<Transport>> GetAllTransport()
        {
            try
            {
                return await this._Transport.GetAllTransport();
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside TransportController GetAllTransport action: {ex.Message}");
                return null;
            }
        }
        [HttpPost]
        [Route("SaveTransport")]
        public async Task<int> SaveTransport([FromBody] Transport obj)
        {
            try
            {
                return await this._Transport.SaveTransport(obj);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside TransportController SaveTransport action: {ex.Message}");
                return -1;
            }
        }
    }
}
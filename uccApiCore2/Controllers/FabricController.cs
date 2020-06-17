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
    public class FabricController : BaseController<FabricController>
    {
        IFabricBAL _Fabric;


        public FabricController(IFabricBAL Fabric)
        {
            _Fabric = Fabric;

        }

        [HttpPost]
        [Route("GetFabric")]
        public async Task<List<Fabric>> GetFabric([FromBody] Fabric obj)
        {
            try
            {
                return await this._Fabric.GetFabric(obj);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside FabricController GetFabric action: {ex.Message}");
                return null;
            }
        }

        [HttpPost]
        [Route("GetAllFabric")]
        public async Task<List<Fabric>> GetAllFabric([FromBody] Fabric obj)
        {
            try
            {
                return await this._Fabric.GetAllFabric(obj);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside FabricController GetAllFabric action: {ex.Message}");
                return null;
            }
        }

        [HttpPost]
        [Route("SaveFabric")]
        public async Task<int> SaveFabric([FromBody] Fabric obj)
        {
            try
            {
                return await this._Fabric.SaveFabric(obj);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside FabricController SaveFabric action: {ex.Message}");
                return -1;
            }
        }
    }
}

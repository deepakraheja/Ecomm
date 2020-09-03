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
    public class AgentController : BaseController<AgentController>
    {
        IAgentBAL _Agent;

        public AgentController(IAgentBAL Agent)
        {
            _Agent = Agent;
        }
        [HttpPost]
        [Route("AgentRegistration")]
        public async Task<int> AgentRegistration([FromBody] Agents obj)
        {
            try
            {
                return await this._Agent.AgentRegistration(obj);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside AgentController AgentRegistration action: {ex.Message}");
                return -1;
            }
        }
        [HttpPost]
        [Route("UpdateAgent")]
        public async Task<int> UpdateAgent([FromBody] Agents obj)
        {
            try
            {
                return await this._Agent.UpdateAgent(obj);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside AgentController UpdateAgent action: {ex.Message}");
                return -1;
            }
        }

        [HttpPost]
        [Route("GetAgentInfo")]
        public async Task<List<Agents>> GetAgentInfo([FromBody] Agents obj)
        {
            try
            {
                return await this._Agent.GetAgentInfo(obj);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside AgentController GetAgentInfo action: {ex.Message}");
                return null;
            }
        }

    }
}

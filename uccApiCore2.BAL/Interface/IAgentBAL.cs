using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using uccApiCore2.Entities;

namespace uccApiCore2.BAL.Interface
{
    public interface IAgentBAL
    {
        Task<int> AgentRegistration(Agents obj);
        Task<int> UpdateAgent(Agents obj);
        Task<List<Agents>> GetAgentInfo(Agents obj);
    }
}

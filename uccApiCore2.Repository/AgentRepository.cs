using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uccApiCore2.Entities;
using uccApiCore2.Repository.Interface;
using static System.Data.CommandType;

namespace uccApiCore2.Repository
{
    public class AgentRepository : BaseRepository, IAgentRepository
    {
        public async Task<int> AgentRegistration(Agents obj)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Email", obj.Email);
                parameters.Add("@Fname", obj.Fname);
                parameters.Add("@LName", obj.LName);
                parameters.Add("@Mobile", obj.Mobile);
                parameters.Add("@CreatedBy", obj.CreatedBy);
                parameters.Add("@CreatedDate", obj.CreatedDate);
                parameters.Add("@IsActive", obj.IsActive);
                var res = await SqlMapper.ExecuteScalarAsync(con, "p_Agent_ins", param: parameters, commandType: StoredProcedure);
                return Convert.ToInt32(res);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<int> UpdateAgent(Agents obj)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@AgentId", obj.AgentId);
                parameters.Add("@Email", obj.Email);
                parameters.Add("@Fname", obj.Fname);
                parameters.Add("@LName", obj.LName);
                parameters.Add("@Mobile", obj.Mobile);
                parameters.Add("@CreatedBy", obj.CreatedBy);
                parameters.Add("@CreatedDate", obj.CreatedDate);
                parameters.Add("@IsActive", obj.IsActive);
                var res = await SqlMapper.ExecuteScalarAsync(con, "p_Agent_upd", param: parameters, commandType: StoredProcedure);
                return Convert.ToInt32(res);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<List<Agents>> GetAgentInfo(Agents obj)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                if (obj.AgentId > 0)
                    parameters.Add("@AgentId", obj.AgentId);
                List<Agents> lst = (await SqlMapper.QueryAsync<Agents>(con, "p_Agent_sel", param: parameters, commandType: StoredProcedure)).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}

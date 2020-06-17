using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uccApiCore2.Entities;
using uccApiCore2.Repository.Interface;
using static System.Data.CommandType;

namespace uccApiCore2.Repository
{
    public class FabricRepository: BaseRepository, IFabricRepository
    {
        public async Task<List<Fabric>> GetFabric(Fabric obj)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@IsActive", obj.IsActive);
                List<Fabric> lst = (await SqlMapper.QueryAsync<Fabric>(con, "p_Fabric_sel", param: parameters, commandType: StoredProcedure)).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<List<Fabric>> GetAllFabric(Fabric obj)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                List<Fabric> lst = (await SqlMapper.QueryAsync<Fabric>(con, "p_Fabric_sel", param: parameters, commandType: StoredProcedure)).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<int> SaveFabric(Fabric obj)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@FabricId", obj.FabricId);
                parameters.Add("@name", obj.Name);
                parameters.Add("@IsActive", obj.IsActive);
                parameters.Add("@UserId", obj.CreatedBy);
                var res = await SqlMapper.ExecuteAsync(con, "p_Fabric_ins", param: parameters, commandType: StoredProcedure);
                return res;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}

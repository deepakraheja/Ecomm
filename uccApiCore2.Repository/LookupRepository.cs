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
    public class LookupRepository : BaseRepository, ILookupRepository
    {
        public async Task<List<LookupColor>> GetActiveColor()
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                List<LookupColor> lst = (await SqlMapper.QueryAsync<LookupColor>(con, "p_LookupColor_Sel", param: parameters, commandType: StoredProcedure)).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<List<LookupSize>> GetActiveSize()
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                List<LookupSize> lst = (await SqlMapper.QueryAsync<LookupSize>(con, "p_LookupSize_Sel", param: parameters, commandType: StoredProcedure)).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public async Task<List<LookupOrderStatus>> GetOrderStatus()
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                List<LookupOrderStatus> lst = (await SqlMapper.QueryAsync<LookupOrderStatus>(con, "p_LookupOrderStatus_Sel", param: parameters, commandType: StoredProcedure)).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}

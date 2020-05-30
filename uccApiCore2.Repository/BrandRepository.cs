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
    public class BrandRepository : BaseRepository, IBrandRepository
    {
        

        public async Task<List<Brand>> GetBrand(Brand obj)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Active", obj.Active);
                List<Brand> lst = (await SqlMapper.QueryAsync<Brand>(con, "p_Brand_sel", param: parameters, commandType: StoredProcedure)).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
               
    }
}

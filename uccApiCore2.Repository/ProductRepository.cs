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
    public class ProductRepository : BaseRepository, IProductRepository
    {


        public async Task<List<Product>> GetProductBySubcatecode(Product obj)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                if (!string.IsNullOrEmpty(obj.Subcatecode) && (obj.Subcatecode != "all"))
                    parameters.Add("@Subcatecode", obj.Subcatecode);
                if (obj.BrandId > 0)
                    parameters.Add("@BrandId", obj.BrandId);

                List<Product> lst = (await SqlMapper.QueryAsync<Product>(con, "p_product_selbySubcatecode", param: parameters, commandType: StoredProcedure)).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public async Task<List<Product>> GetProductById(Product obj)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ProductID", obj.ProductID);
                List<Product> lst = (await SqlMapper.QueryAsync<Product>(con, "p_product_selbyId", param: parameters, commandType: StoredProcedure)).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
}

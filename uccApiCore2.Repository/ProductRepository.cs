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

        public async Task<List<Product>> GetAllProductBySupplierId(Product obj)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SupplierID", obj.SupplierID);
                List<Product> lst = (await SqlMapper.QueryAsync<Product>(con, "p_GetAllproductBySupplierId", param: parameters, commandType: StoredProcedure)).ToList();
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

        public async Task<int> SaveProduct(Product obj)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ProductID", obj.ProductID); //int
                parameters.Add("@ProductName", obj.ProductName); //nvarchar
                parameters.Add("@ShortDetails", obj.ShortDetails); //ntext
                parameters.Add("@Description", obj.Description); //ntext
                parameters.Add("@SupplierID", obj.SupplierID); //int
                parameters.Add("@SubCategoryID", obj.SubCategoryID); //int
                parameters.Add("@BrandId", obj.BrandId); //int
                parameters.Add("@StockQty", obj.StockQty); //int
                parameters.Add("@Price", obj.Price); //decimal
                parameters.Add("@SalePrice", obj.SalePrice); //decimal
                parameters.Add("@AvailableSize", obj.AvailableSize); //bit
                parameters.Add("@AvailableColors", obj.AvailableColors); //bit
                parameters.Add("@Size", obj.Size); //nvarchar
                parameters.Add("@Color", obj.Color); //nvarchar
                parameters.Add("@Discount", obj.Discount); //decimal
                parameters.Add("@DiscountAvailable", obj.DiscountAvailable); //bit
                parameters.Add("@ProductAvailable", obj.ProductAvailable); //bit
                parameters.Add("@CreatedBy", obj.CreatedBy); //int
                //parameters.Add("@CreatedDate", obj.CreatedDate); //datetime
                parameters.Add("@Modifiedby", obj.Modifiedby); //int
                //parameters.Add("@ModifiedDate", obj.ModifiedDate); //datetime
                parameters.Add("@Featured", obj.Featured); //bit
                parameters.Add("@Latest", obj.Latest); //bit
                parameters.Add("@OnSale", obj.OnSale); //bit
                parameters.Add("@TopSelling", obj.TopSelling); //bit
                parameters.Add("@HotOffer", obj.HotOffer); //bit
                parameters.Add("@Active", obj.Active); //bit
                var res = await SqlMapper.ExecuteAsync(con, "p_Product_ins", param: parameters, commandType: StoredProcedure);
                return Convert.ToInt32(res);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}

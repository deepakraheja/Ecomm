using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using uccApiCore2.Entities;

namespace uccApiCore2.BAL.Interface
{
    public interface IProductBAL
    {

        Task<List<Product>> GetProductBySubcatecode(Product obj);
        Task<List<Product>> GetProductById(Product obj);
    }
}

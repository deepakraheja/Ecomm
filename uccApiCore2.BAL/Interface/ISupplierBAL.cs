using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using uccApiCore2.Entities;

namespace uccApiCore2.BAL.Interface
{
    public interface ISupplierBAL
    {
        Task<List<Supplier>> GetSupplier(Supplier obj);
        Task<List<Supplier>> GetAllSupplier();
        Task<int> SaveSupplier(Supplier obj);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using uccApiCore2.Entities;

namespace uccApiCore2.Repository.Interface
{
    public interface ISupplierRepository
    {
        Task<List<Supplier>> GetSupplier(Supplier obj);
        Task<List<Supplier>> GetAllSupplier();
        Task<int> SaveSupplier(Supplier obj);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using uccApiCore2.BAL.Interface;
using uccApiCore2.Entities;
using uccApiCore2.Repository.Interface;

namespace uccApiCore2.BAL
{
    public class SupplierBAL : ISupplierBAL
    {
        ISupplierRepository _supplier;

        public SupplierBAL(ISupplierRepository supplier)
        {
            _supplier = supplier;
        }

        public Task<List<Supplier>> GetSupplier(Supplier obj)
        {
            return _supplier.GetSupplier(obj);
        }
        public Task<List<Supplier>> GetAllSupplier()
        {
            return _supplier.GetAllSupplier();
        }
        public Task<int> SaveSupplier(Supplier obj)
        {
            return _supplier.SaveSupplier(obj);
        }
    }
}

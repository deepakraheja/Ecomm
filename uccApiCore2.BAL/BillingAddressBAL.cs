using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using uccApiCore2.BAL.Interface;
using uccApiCore2.Entities;
using uccApiCore2.Repository.Interface;

namespace uccApiCore2.BAL
{
    public class BillingAddressBAL : IBillingAddressBAL
    {
        IBillingAddressRepository _BillingAddressRepository;

        public BillingAddressBAL(IBillingAddressRepository BillingAddressRepository)
        {
            _BillingAddressRepository = BillingAddressRepository;
        }

        public Task<List<BillingAddress>> SaveBillingAddress(BillingAddress obj)
        {
            return _BillingAddressRepository.SaveBillingAddress(obj);
        }
        public Task<List<BillingAddress>> GetBillingAddress(BillingAddress obj)
        {
            return _BillingAddressRepository.GetBillingAddress(obj);
        }
        public Task<List<BillingAddress>> DeleteBillingAddress(BillingAddress obj)
        {
            return _BillingAddressRepository.DeleteBillingAddress(obj);
        }
    }
}

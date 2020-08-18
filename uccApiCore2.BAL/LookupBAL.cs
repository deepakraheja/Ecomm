using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using uccApiCore2.BAL.Interface;
using uccApiCore2.Entities;
using uccApiCore2.Repository.Interface;

namespace uccApiCore2.BAL
{
    public class LookupBAL : ILookupBAL
    {
        ILookupRepository _lookupRepository;
        public LookupBAL(ILookupRepository lookupRepository)
        {
            _lookupRepository = lookupRepository;
        }

        public Task<List<LookupColor>> GetActiveColor()
        {
            return _lookupRepository.GetActiveColor();
        }
        public Task<List<LookupSize>> GetActiveSize()
        {
            return _lookupRepository.GetActiveSize();
        }
        public Task<List<LookupOrderStatus>> GetOrderStatus()
        {
            return _lookupRepository.GetOrderStatus();
        }
    }
}

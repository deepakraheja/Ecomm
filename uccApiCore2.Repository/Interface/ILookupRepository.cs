using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using uccApiCore2.Entities;

namespace uccApiCore2.Repository.Interface
{
    public interface ILookupRepository
    {
        Task<List<LookupColor>> GetActiveColor();
        Task<List<LookupSize>> GetActiveSize();
        Task<List<LookupOrderStatus>> GetOrderStatus();
    }
}

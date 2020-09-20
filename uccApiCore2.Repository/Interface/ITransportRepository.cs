using System.Collections.Generic;
using System.Threading.Tasks;
using uccApiCore2.Entities;

namespace uccApiCore2.Repository.Interface
{
    public interface ITransportRepository
    {
        Task<List<Transport>> GetTransport(Transport obj);
        Task<List<Transport>> GetAllTransport();
        Task<int> SaveTransport(Transport obj);
    }
}

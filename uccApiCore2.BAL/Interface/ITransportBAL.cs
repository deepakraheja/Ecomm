using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using uccApiCore2.Entities;

namespace uccApiCore2.BAL.Interface
{
    public interface ITransportBAL
    {
        Task<List<Transport>> GetTransport(Transport obj);
        Task<List<Transport>> GetAllTransport();
        Task<int> SaveTransport(Transport obj);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using uccApiCore2.BAL.Interface;
using uccApiCore2.Entities;
using uccApiCore2.Repository.Interface;

namespace uccApiCore2.BAL
{
    public class FabricBAL : IFabricBAL
    {
        IFabricRepository _FabricRepository;

        public FabricBAL(IFabricRepository FabricRepository)
        {
            _FabricRepository = FabricRepository;
        }

        public Task<List<Fabric>> GetFabric(Fabric obj)
        {
            return _FabricRepository.GetFabric(obj);
        }

        public Task<List<Fabric>> GetAllFabric(Fabric obj)
        {
            return _FabricRepository.GetAllFabric(obj);
        }

        public Task<int> SaveFabric(Fabric obj)
        {
            return _FabricRepository.SaveFabric(obj);
        }

    }
}
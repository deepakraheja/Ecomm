using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using uccApiCore2.BAL.Interface;
using uccApiCore2.Entities;
using uccApiCore2.Repository.Interface;

namespace uccApiCore2.BAL
{
    public class BrandBAL : IBrandBAL
    {
        IBrandRepository _BrandRepository;

        public BrandBAL(IBrandRepository BrandRepository)
        {
            _BrandRepository = BrandRepository;
        }

        public Task<List<Brand>> GetBrand(Brand obj)
        {
            return _BrandRepository.GetBrand(obj);
        }

        public Task<List<Brand>> GetAllBrand(Brand obj)
        {
            return _BrandRepository.GetAllBrand(obj);
        }

        public Task<int> SaveBrand(Brand obj)
        {
            return _BrandRepository.SaveBrand(obj);
        }

    }
}

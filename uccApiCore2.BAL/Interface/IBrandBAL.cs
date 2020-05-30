using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using uccApiCore2.Entities;

namespace uccApiCore2.BAL.Interface
{
    public interface IBrandBAL
    {
       
        Task<List<Brand>> GetBrand(Brand obj);
       
    }
}

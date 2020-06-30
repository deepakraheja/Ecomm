using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using uccApiCore2.Entities;

namespace uccApiCore2.Repository.Interface
{
    public interface ILookupTagRepository
    {
        Task<List<LookupTag>> GetTag(LookupTag obj);
        Task<List<LookupTag>> GetAllTag(LookupTag obj);
        Task<int> SaveTag(LookupTag obj);
    }
}

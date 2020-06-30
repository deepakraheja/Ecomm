using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using uccApiCore2.BAL.Interface;
using uccApiCore2.Entities;
using uccApiCore2.Repository.Interface;

namespace uccApiCore2.BAL
{
    public class LookupTagBAL : ILookupTagBAL
    {
        ILookupTagRepository _lookupTag;

        public LookupTagBAL(ILookupTagRepository lookupTag)
        {
            _lookupTag = lookupTag;
        }

        public Task<List<LookupTag>> GetTag(LookupTag obj)
        {
            return _lookupTag.GetTag(obj);
        }

        public Task<List<LookupTag>> GetAllTag(LookupTag obj)
        {
            return _lookupTag.GetAllTag(obj);
        }

        public Task<int> SaveTag(LookupTag obj)
        {
            return _lookupTag.SaveTag(obj);
        }

    }
}
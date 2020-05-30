using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using uccApiCore2.BAL.Interface;
using uccApiCore2.Entities;
using uccApiCore2.Repository.Interface;

namespace uccApiCore2.BAL
{
    public class SubCategoryBAL : ISubCategoryBAL
    {
        ISubCategoryRepository _SubCategoryRepository;

        public SubCategoryBAL(ISubCategoryRepository SubCategoryRepository)
        {
            _SubCategoryRepository = SubCategoryRepository;
        }
      
        public Task<List<SubCategory>> GetSubcategoryByCatid(SubCategory obj)
        {
            return _SubCategoryRepository.GetSubcategoryByCatid(obj);
        }

        public Task<List<SubCategory>> GetSideSubcategory(SubCategory obj)
        {
            return _SubCategoryRepository.GetSideSubcategory(obj);
        }
    }
}

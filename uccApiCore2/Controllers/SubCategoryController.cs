using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using uccApiCore2.BAL.Interface;
using uccApiCore2.Controllers.Common;
using uccApiCore2.Entities;

namespace uccApiCore2.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    public class SubCategoryController : BaseController<SubCategoryController>
    {
        ISubCategoryBAL _SubCategory;
       
        
        public SubCategoryController(ISubCategoryBAL SubCategorySetting)
        {
            _SubCategory = SubCategorySetting;
            
        }
   
        [HttpPost]
        [Route("GetSubcategoryByCatId")]
        [AllowAnonymous]
        public async Task<List<SubCategory>> GetSubcategoryByCatId([FromBody]SubCategory obj)
        {
            try
            {
                return await this._SubCategory.GetSubcategoryByCatid(obj);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside SubCategoryController GetSubcategoryByCatId action: {ex.Message}");
                return null;
            }
        }

        [HttpPost]
        [Route("GetSideSubcategory")]
        [AllowAnonymous]
        public async Task<List<SubCategory>> GetSideSubcategory([FromBody]SubCategory obj)
        {
            try
            {
                return await this._SubCategory.GetSideSubcategory(obj);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside SubCategoryController GetSideSubcategory action: {ex.Message}");
                return null;
            }
        }


    }
}
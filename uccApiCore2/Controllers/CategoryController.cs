using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using uccApiCore2.BAL.Interface;
using uccApiCore2.Controllers.Common;
using uccApiCore2.Entities;

namespace uccApiCore2.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : BaseController<CategoryController>
    {
        ICategoryBAL _Category;
       
        
        public CategoryController(ICategoryBAL Category)
        {
            _Category = Category;
            
        }

        [HttpGet]
        [Route("GetCategoryJson")]
        public string GetCategoryJson()
        {
            try
            {
                var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\{"Json\\leftMenuItems.json"}");
                var JSON = System.IO.File.ReadAllText(folderDetails);

                return JSON;
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside CategoryController GetCategory action: {ex.Message}");
                return null;
            }
        }

        [HttpPost]
        [Route("GetCategory")]
        public async Task<List<Category>> GetCategory([FromBody]Category obj)
        {
            try
            {


                return await this._Category.GetCategory(obj);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside CategoryController GetCategory action: {ex.Message}");
                return null;
            }
        }

        [HttpPost]
        [Route("GetAllCategory")]
        public async Task<List<Category>> GetAllCategory([FromBody] Category obj)
        {
            try
            {
                return await this._Category.GetAllCategory(obj);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside CategoryController GetAllCategory action: {ex.Message}");
                return null;
            }
        }

        [HttpPost]
        [Route("SaveCategory")]
        public async Task<int> SaveCategory([FromBody] Category obj)
        {
            try
            {
                return await this._Category.SaveCategory(obj);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside CategoryController SaveCategory action: {ex.Message}");
                return -1;
            }
        }

        [HttpPost]
        [Route("GetSubCategory")]
        public async Task<List<Category>> GetSubCategory([FromBody] Category obj)
        {
            try
            {
                return await this._Category.GetSubCategory(obj);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside CategoryController GetSubCategory action: {ex.Message}");
                return null;
            }
        }

        [HttpPost]
        [Route("GetAllSubCategory")]
        public async Task<List<Category>> GetAllSubCategory([FromBody] Category obj)
        {
            try
            {
                return await this._Category.GetAllSubCategory(obj);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside CategoryController GetAllSubCategory action: {ex.Message}");
                return null;
            }
        }

        [HttpPost]
        [Route("SaveSubCategory")]
        public async Task<int> SaveSubCategory([FromBody] Category obj)
        {
            try
            {
                return await this._Category.SaveSubCategory(obj);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside CategoryController SaveSubCategory action: {ex.Message}");
                return -1;
            }
        }

    }
}
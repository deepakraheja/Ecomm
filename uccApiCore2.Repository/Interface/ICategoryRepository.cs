﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using uccApiCore2.Entities;

namespace uccApiCore2.Repository.Interface
{
    public interface ICategoryRepository
    {
        
        Task<List<Category>> GetCategory(Category obj);
        Task<List<Category>> GetAllCategory(Category obj);
        Task<int> SaveCategory(Category obj);
        Task<List<Category>> GetSubCategory(Category obj);
        Task<List<Category>> GetAllSubCategory(Category obj);
        Task<int> SaveSubCategory(Category obj);
    }
}
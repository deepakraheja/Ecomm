﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using uccApiCore2.Entities;

namespace uccApiCore2.Repository.Interface
{
    public interface IOrderRepository
    {
        Task<int> SaveOrder(Order obj);
        Task<List<Order>> GetOrderByOrderId(Order obj);
        Task<List<Order>> GetOrderDetailsByOrderId(Order obj);
        Task<List<Order>> GetOrderByUserId(Order obj);
        Task<List<Order>> GetOrderDetailsByUserId(Order obj);
    }
}
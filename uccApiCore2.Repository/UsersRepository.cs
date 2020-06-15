﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using uccApiCore2.Entities;
using uccApiCore2.Repository.Interface;
using static System.Data.CommandType;

namespace uccApiCore2.Repository
{
    public class UsersRepository : BaseRepository, IUsersRepository
    {
        public async Task<int> UserRegistration(Users obj)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PASSWORD", obj.password);
                parameters.Add("@email", obj.email);
                parameters.Add("@Name", obj.Name);
                parameters.Add("@MobileNo", obj.MobileNo);
                var res = await SqlMapper.ExecuteScalarAsync(con, "p_Users_ins", param: parameters, commandType: StoredProcedure);
                return Convert.ToInt32(res);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<List<Users>> ValidLogin(Users obj)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@LoginId", obj.LoginId);
                parameters.Add("@PASSWORD", obj.password);
                List<Users> lst = (await SqlMapper.QueryAsync<Users>(con, "p_ValidLogin", param: parameters, commandType: StoredProcedure)).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
using System;
using System.Collections.Generic;
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
    public class UsersController : BaseController<UsersController>
    {
        IUsersBAL _usersBAL;
        public UsersController(IUsersBAL usersBAL)
        {
            _usersBAL = usersBAL;
        }

        [HttpPost]
        [Route("ValidLogin")]
        public async Task<List<Users>> ValidLogin([FromBody] Users obj)
        {
            try
            {
                return await this._usersBAL.ValidLogin(obj);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside UsersController ValidLogin action: {ex.Message}");
                return null;
            }
        }

        [HttpPost]
        [Route("UserRegistration")]
        public async Task<int> UserRegistration([FromBody] Users obj)
        {
            try
            {
                return await this._usersBAL.UserRegistration(obj);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside UsersController UserRegistration action: {ex.Message}");
                return -1;
            }
        }
        [HttpPost]
        [Route("UserRegistration1")]
        public async Task<int> UserRegistration1([FromBody] Users obj)
        {
            try
            {
                return await this._usersBAL.UserRegistration(obj);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside UsersController UserRegistration action: {ex.Message}");
                return -1;
            }
        }
    }


}

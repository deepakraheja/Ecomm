using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using uccApiCore2.BAL;
using uccApiCore2.BAL.Interface;
using uccApiCore2.Controllers.Common;
using uccApiCore2.Entities;
using uccApiCore2.JWT;
using static uccApiCore2.Controllers.Common.SendEmails;

namespace uccApiCore2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UsersController : BaseController<UsersController>
    {
        IUsersBAL _usersBAL;
        IEmailTemplateBAL _IEmailTemplateBAL;
        private readonly ApplicationSettings _appSettings;

        public UsersController(IUsersBAL usersBAL, IOptions<ApplicationSettings> appSettings, IEmailTemplateBAL emailTemplateBAL)
        {
            _usersBAL = usersBAL;
            _appSettings = appSettings.Value;
            _IEmailTemplateBAL = emailTemplateBAL;
        }

        [HttpPost]
        [Route("UserRegistration")]
        [AllowAnonymous]
        public async Task<int> UserRegistration([FromBody] Users obj)
        {
            try
            {
                int res= await this._usersBAL.UserRegistration(obj);
                SendEmails sendEmails = new SendEmails(_usersBAL,_IEmailTemplateBAL);
                sendEmails.setMailContent(res, EStatus.Registration.ToString());
                return res;
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside UsersController UserRegistration action: {ex.Message}");
                return -1;
            }
        }
        [HttpPost]
        [Route("ValidLogin")]
        [AllowAnonymous]
        public async Task<List<Users>> ValidLogin([FromBody] Users obj)
        {
            try
            {
                List<Users> lstLogin = new List<Users>();
                lstLogin = await this._usersBAL.ValidLogin(obj);

                if (lstLogin.Count > 0)
                {
                    AuthorizeService auth = new AuthorizeService();
                    string _token = auth.Authenticate(Convert.ToString(lstLogin[0].UserID), _appSettings);
                    lstLogin[0].Token = _token;
                   // return lstLogin;
                }
               
                return lstLogin;

            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside UsersController ValidLogin action: {ex.Message}");
                return null;
            }
        }

        [HttpPost]
        [Route("GetAllUsers")]
        public async Task<List<Users>> GetAllUsers()
        {
            try
            {
                return await this._usersBAL.GetAllUsers();
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside UsersController GetAllUsers action: {ex.Message}");
                return null;
            }
        }
        [HttpPost]
        [Route("UpdateUser")]
        public async Task<int> UpdateUser([FromBody] Users obj)
        {
            try
            {
                return await this._usersBAL.UpdateUser(obj);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside UsersController UpdateUser action: {ex.Message}");
                return -1;
            }
        }

        [HttpPost]
        [Route("UpdatePwd")]
        public async Task<int> UpdatePwd([FromBody] Users obj)
        {
            try
            {
                return await this._usersBAL.UpdatePwd(obj);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside UsersController UpdatePwd action: {ex.Message}");
                return -1;
            }
        }
    }


}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
    public class EmailTemplateController : BaseController<EmailTemplateController>
    {
        IEmailTemplateBAL _IEmailTemplateBAL;
        Utilities _utilities = new Utilities();
        public static string webRootPath;
        public EmailTemplateController(IHostingEnvironment hostingEnvironment, IEmailTemplateBAL EmailTemplateBAL)
        {
            _IEmailTemplateBAL = EmailTemplateBAL;
            webRootPath = hostingEnvironment.WebRootPath;
        }

        [HttpPost]
        [Route("SaveEmailTemplate")]
        public async Task<int> SaveEmailTemplate([FromBody] EmailTemplate obj)
        {
            try
            {
                return await this._IEmailTemplateBAL.SaveEmailTemplate(obj);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside EmailTemplateController SaveEmailTemplate action: {ex.Message}");
                return -1;
            }
        }
        [HttpPost]
        [Route("GetEmailTemplate")]
        public async Task<List<EmailTemplate>> GetEmailTemplate([FromBody] EmailTemplate obj)
        {
            try
            {
                return await this._IEmailTemplateBAL.GetEmailTemplate(obj);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Something went wrong inside EmailTemplateController GetEmailTemplate action: {ex.Message}");
                return null;
            }
        }
    }
}

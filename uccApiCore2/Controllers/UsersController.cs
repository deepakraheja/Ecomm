using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
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
        [Route("SendEmail")]
        [AllowAnonymous]
        public void SendEmail()
        {
            string strFrom = "esales@vikramcreations.com";

            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();

            string userId = "esales@vikramcreations.com";// Convert.ToString(ConfigurationManager.AppSettings["MailUserId"]); //MAIL ID FOR AUTHENTICATION
            string password = "Sales@123";// Convert.ToString(ConfigurationManager.AppSettings["MailPassword"]); ;//PASSWORD FOR AUTHENTICATION
            bool EnableSsl = true;

            bool flag = true;
            string strSub = "Hello";
            string strBody = "Hello, This is Email sending test using gmail.";

            //  string addMessage = Convert.ToString(ConfigurationManager.AppSettings["Subject"]);
            String host = "smtp.gmail.com";// ConfigurationManager.AppSettings["mailServer"];
            MailAddress FromAddress = new MailAddress(strFrom);
            try
            {
                smtpClient.EnableSsl = EnableSsl;//Convert.ToBoolean(EnableSsl);
                smtpClient.Host = host;
                message.From = FromAddress;
                message.To.Add("deepakrahejain@gmail.com");
                //message.CC.Add(strCc);
                //message.Bcc.Add(strBcc);
                message.Subject = strSub;
                message.Body = strBody;
                message.IsBodyHtml = true;
                if (flag)
                {
                    NetworkCredential oCredential = new NetworkCredential(userId, password);
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = oCredential;
                }
                else
                {
                    smtpClient.UseDefaultCredentials = true;

                }
                smtpClient.Send(message);

            }
            catch (Exception exx)
            {
                string str = exx.Message.ToString();

            }



            //try
            //{
            //    string smtpAddress = "smtp.gmail.com";
            //    int portNumber = 587;
            //    bool enableSSL = true;
            //    string emailFromAddress = "esales@vikramcreations.com"; //Sender Email Address  
            //    string password = "Sales@123"; //Sender Password  
            //    string emailToAddress = "deepakrahejain@gmail.com"; //Receiver Email Address  
            //    string subject = "Hello";
            //    string body = "Hello, This is Email sending test using gmail.";

            //    using (MailMessage mail = new MailMessage())
            //    {
            //        mail.From = new MailAddress(emailFromAddress);
            //        mail.To.Add(emailToAddress);
            //        mail.Subject = subject;
            //        mail.Body = body;
            //        mail.IsBodyHtml = true;
            //        //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
            //        using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
            //        {
            //            smtp.Credentials = new NetworkCredential(emailFromAddress, password);
            //            smtp.EnableSsl = enableSSL;
            //            smtp.Send(mail);

            //        }

            //    }
            //}
            //catch (Exception ex)
            //{
            //    Logger.LogError($"Something went wrong inside UsersController GetAllUsers action: {ex.Message}");

            //}
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

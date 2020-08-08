using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using uccApiCore2.BAL;
using uccApiCore2.BAL.Interface;
using uccApiCore2.Entities;
using uccApiCore2.Repository.Interface;

namespace uccApiCore2.Controllers.Common
{
    public class SendEmails
    {
        public enum EStatus
        {

            All = 0,
            Registration = 1,
            PasswordReset = 2,
        }
        //public static readonly logger = "";//LogManager.GetLogger(typeof(SendEmails));
        private static IConfiguration configuration;

        public void EmailSetting(IConfiguration iConfig)
        {
            configuration = iConfig;
        }

        public int PlayerId { get; set; }
        IUsersBAL _usersBAL;
        IEmailTemplateBAL _IEmailTemplateBAL;
        public SendEmails(IUsersBAL usersBAL, IEmailTemplateBAL emailTemplateBAL)
        {
            _usersBAL = usersBAL;
            _IEmailTemplateBAL = emailTemplateBAL;
        }

        static string UsesmtpSSL = Startup.UsesmtpSSL;
        static string enableMail = Startup.enableMail;
        static string mailServer = Startup.mailServer;
        static string userId = Startup.userId;
        static string password = Startup.password;
        static string authenticate = Startup.authenticate;
        static string AdminEmailID = Startup.AdminEmailID;
        static string fromEmailID = Startup.fromEmailID;
        static string DomainName = Startup.DomainName;
        static string AllowSendMails = Startup.AllowSendMails;
        static string UserName = Startup.UserName;

        public void setMailContent(int UserID, string Type, string subject = null, string emailBody = null)
        {
            Users objUser = new Users();
            objUser.UserID = UserID;
            var sendOnType = (EStatus)Enum.Parse(typeof(EStatus), Type);

            List<Users> objuserInfo = GetUserInfo(objUser, sendOnType);

            switch (sendOnType)
            {
                case EStatus.Registration:
                    {
                        Users emailParameters = new Users()
                        {
                            Name = objuserInfo[0].Name,
                            password = objuserInfo[0].password,
                            XMLFilePath = "1",
                            email = objuserInfo[0].email,
                            Subject = "Application Received"
                        };

                        SendEmail(emailParameters);
                    }
                    break;
                case EStatus.PasswordReset:
                    {
                        Users emailParameters = new Users()
                        {
                            Name = objuserInfo[0].Name,
                            password = objuserInfo[0].password,
                            Subject = "Password reset successfully.",
                            XMLFilePath = "2",
                        };
                        SendEmail(emailParameters);
                    }
                    break;
            }
        }

        public string GetMailBody(Users objEP)
        {
            try
            {
                EmailTemplate objEmailTemplate = new EmailTemplate
                {
                    EmailType = objEP.XMLFilePath
                };
                List<EmailTemplate> objET = _IEmailTemplateBAL.GetEmailTemplate(objEmailTemplate).Result;
                string template = objET[0].Template;
                template = template.Replace("[Name]", objEP.Name ?? "");
                template = template.Replace("[Email]", objEP.email ?? "");
                template = template.Replace("[Password]", objEP.password ?? "");
                return template;
            }
            catch (Exception)
            {
                return "";
            }
        }
        public List<Users> GetUserInfo(Users objUser, EStatus obj)
        {
            List<Users> objLstUser = new List<Users>();
            //if (obj != EStatus.Registration)
            //{
            objLstUser = _usersBAL.GetUserInfo(objUser).Result;
            //}
            //else
            //{
            //    objLstUser = _usersBAL.GetUserInfo(objUser).Result;
            //}
            return objLstUser;
        }

        //public string GetTime(String time)
        //{
        //    string str = Convert.ToDateTime(DateTime.Now).ToShortDateString() + " " + time.Substring(0, 5) + " " + time.Substring(time.Length - 2);
        //    DateTime objDate = Convert.ToDateTime(str);
        //    return objDate.ToString("HH:mm");
        //}

        public void SendEmail(Users emailParameters, List<Attachment> strAttachment = null, AlternateView EventData = null)
        {
            //string xmlData = emailParameters.GetXML();
            // string strBody = !String.IsNullOrEmpty(emailParameters.EmailBody) ? emailParameters.EmailBody : MailerUtility.GetMailBody(HttpContext.Current.Server.MapPath("~") + "\\xslt\\" + emailParameters.XMLFilePath, xmlData);
            Utilities utilities = new Utilities();
            string strBody = GetMailBody(emailParameters);
            //****************Calling the Send Mail Function *******************************
            MailContent objMailContent = new MailContent() { From = "esales@vikramcreations.com", toEmailaddress = emailParameters.email, displayName = "Vikram Creations Private Limited", subject = emailParameters.Subject, emailBody = strBody, strAttachment = strAttachment, EventData = EventData };
            SendEmailInBackgroundThread(objMailContent);
        }

        public void SendEmailInBackgroundThread(MailContent objMailContent)
        {
            //Thread bgThread = new Thread(new ParameterizedThreadStart(SendAttachment));
            //bgThread.IsBackground = true;
            //bgThread.Start(objMailContent);
            SendAttachment(objMailContent, UserName);
        }

        public static void SendAttachment(Object objMail, string UserName)
        {
            MailContent objMC = (MailContent)objMail;
            try
            {

                SmtpClient smtpClient = new SmtpClient();
                MailMessage message = new MailMessage();
                bool EnableSsl = true;
                bool flag = true;
                string strSub = objMC.subject;
                string strBody = objMC.emailBody;
                MailAddress FromAddress = new MailAddress(fromEmailID.ToString(), objMC.displayName);

                smtpClient.EnableSsl = EnableSsl;//Convert.ToBoolean(EnableSsl);
                smtpClient.Host = mailServer.ToString();
                message.From = FromAddress;
                message.To.Add(objMC.toEmailaddress);
                //message.CC.Add(strCc);
                //message.Bcc.Add(strBcc);
                message.Subject = strSub;
                message.Body = strBody;
                message.IsBodyHtml = true;
                if (flag)
                {
                    NetworkCredential oCredential = new NetworkCredential(userId.ToString(), password.ToString());
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = oCredential;
                }
                else
                {
                    smtpClient.UseDefaultCredentials = true;

                }
                smtpClient.Send(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }


    public class MailContent
    {
        public string toEmailaddress { get; set; }
        public string displayName { get; set; }
        public string subject { get; set; }
        public string emailBody { get; set; }
        public List<Attachment> strAttachment { get; set; }
        public AlternateView EventData { get; set; }
        public string From { get; set; }
        List<String> _copyList = new List<string>();
        public List<String> CopyTo { get { return _copyList; } }
        public int BranchId { get; set; }
    }

    //public class SendEmailUserInfo
    //{

    //    public string FullName { get; set; }
    //    public string LogginedUserFullName { get; set; }
    //    public string Email { get; set; }
    //    public string LogginedUserEmail { get; set; }
    //    public string UserType { get; set; }
    //    public int UserID { get; set; }
    //    public string ApplicationNumber { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public string Address { get; set; }
    //    public string InterviewDate { get; set; }
    //    public string InterviewTime { get; set; }
    //    public string Password { get; set; }
    //    public string VenueName { get; set; }
    //    public string VenueAddress { get; set; }
    //    public string VenueId { get; set; }
    //    public string RoomNo { get; set; }
    //    public string ParkingInstructions { get; set; }
    //    public string InterviewType { get; set; }
    //    public string StartTime { get; set; }
    //    public string EndTime { get; set; }
    //    public string Duration { get; set; }
    //    public int Sessions { get; set; }
    //    public string Branch { get; set; }
    //    public string BranchEmail { get; set; }
    //    public int BranchId { get; set; }
    //    public string Interviewlink { get; set; }
    //    public string OnlineInterview { get; set; }
    //    public string Comment { get; set; }
    //}
}
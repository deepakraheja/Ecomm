using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using uccApiCore2.BAL.Interface;
using uccApiCore2.Entities;
using uccApiCore2.Repository.Interface;

namespace uccApiCore2.BAL
{
    public class EmailTemplateBAL : IEmailTemplateBAL
    {
        IEmailTemplateRepository _EmailTemplateRepository;

        public EmailTemplateBAL(IEmailTemplateRepository EmailTemplateRepository)
        {
            _EmailTemplateRepository = EmailTemplateRepository;
        }

        public Task<int> SaveEmailTemplate(EmailTemplate obj)
        {
            return _EmailTemplateRepository.SaveEmailTemplate(obj);
        }

        public Task<List<EmailTemplate>> GetEmailTemplate(EmailTemplate obj)
        {
            return _EmailTemplateRepository.GetEmailTemplate(obj);
        }
    }
}

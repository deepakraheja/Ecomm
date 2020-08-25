using System;
using System.Collections.Generic;
using System.Text;

namespace uccApiCore2.Entities
{
   public class OtpLog
    {
         public int OtpLogId { get; set; }
         public string MobileNo { get; set; }
        public string OTP { get; set; }
        public string SessionId { get; set; }

    }
}

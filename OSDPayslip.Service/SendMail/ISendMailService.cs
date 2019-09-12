using System;
using System.Collections.Generic;
using System.Text;

namespace OSDPayslip.Service.SendMail
{
    public interface ISendMailService
    {
        bool SendMail(int RequestID);
    }
}

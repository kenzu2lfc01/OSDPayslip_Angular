using System;
using System.Collections.Generic;
using System.Text;

namespace OSDPayslip.Service.HandlePdf
{
    public interface IHandlePdfService
    {
        void ConvertHtmlToPdf(string month, int RequestID);
    }
}

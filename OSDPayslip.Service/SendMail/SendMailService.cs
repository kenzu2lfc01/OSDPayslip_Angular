using MailKit.Net.Smtp;
using MimeKit;
using OSDPayslip.Application.Reponsitories.Interfaces;
using System;
using System.Linq;

namespace OSDPayslip.Service.SendMail
{
    public class SendMailService : ISendMailService
    {
        private IEmployeeReponsitory _employeeReponsitory;
        private IPayslipDetailReponsitory _payslipDetailReponsitory;
        private IRequestDetailReponsitory _requestDetailReponsitory;

        public SendMailService(IEmployeeReponsitory employeeReponsitory, IPayslipDetailReponsitory payslipDetailReponsitory, IRequestDetailReponsitory requestDetailReponsitory)
        {
            _employeeReponsitory = employeeReponsitory;
            _payslipDetailReponsitory = payslipDetailReponsitory;
            _requestDetailReponsitory = requestDetailReponsitory;
        }

        public bool SendMail(int RequestID)
        {
            try
            {
                string[] months = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
                SmtpClient client = new SmtpClient();
                client.Connect("smtp.gmail.com", 587, true);
                client.Authenticate("nkoxken65@gmail.com", "Nqthang#10898");
                var payslipDetails = _payslipDetailReponsitory.FindAll().Where(x => x.RequestID == RequestID);
                var request = _requestDetailReponsitory.FindById(RequestID);
                MimeMessage message = new MimeMessage();
                MailboxAddress from = new MailboxAddress("Hr",
                "nkoxken65@gmail.com");
                message.From.Add(from);
                foreach (var payslip in payslipDetails)
                {
                    BodyBuilder bodyBuilder = new BodyBuilder();
                    var employee = _employeeReponsitory.FindById(payslip.EmployeeID);
                    MailboxAddress to = new MailboxAddress(employee.FullName, employee.Email);
                    message.To.Add(to);
                    message.Subject = "Payslip for " + months[Convert.ToInt32(request.PayslipForMonth) - 1];
                    bodyBuilder.Attachments.Add(@"..\OSDPayslip.Web\wwwroot\PDF\" + employee.Id + "_Payslips_" + months[Convert.ToInt32(request.PayslipForMonth) - 1] + ".pdf");
                    message.Body = bodyBuilder.ToMessageBody();
                    client.Send(message);
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
    }
}
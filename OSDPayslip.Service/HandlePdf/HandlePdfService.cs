using IronPdf;
using OSDPayslip.Application.Reponsitories.Interfaces;
using OSDPayslip.Service.HandlePdf.DTO;
using OSDPayslip.Service.ViewRender;
using System;
using System.Linq;

namespace OSDPayslip.Service.HandlePdf
{
    public class HandlePdfService : IHandlePdfService
    {
        private readonly IViewRenderService _viewRenderService;
        private readonly IPayslipDetailReponsitory _payslipDetailReponsitory;
        private readonly IEmployeeReponsitory _employeeReponsitory;

        public HandlePdfService(IViewRenderService viewRenderService, IPayslipDetailReponsitory payslipDetailReponsitory, IEmployeeReponsitory employeeReponsitory)
        {
            _viewRenderService = viewRenderService;
            _employeeReponsitory = employeeReponsitory;
            _payslipDetailReponsitory = payslipDetailReponsitory;
        }

        public void ConvertHtmlToPdf(string month, int RequestID)
        {
            var payslips = _payslipDetailReponsitory.FindAll().Where(x => x.RequestID == RequestID).ToList();
            foreach (var item in payslips)
            {
                var date = DateTime.Now;
                InputPdfFile model = new InputPdfFile()
                {
                    Id = item.EmployeeID,
                    FullName = item.Employee.FullName,
                    DeptTeam = item.Employee.DeptTeam,
                    StandardWorkingDay = item.StandardWorkingDay,
                    ActualWorkingDay = item.ActualWorkingDay,
                    UnpaidLeave = item.UnpaidLeave,
                    LeaveBalance = item.LeaveBalance,
                    Holidays = item.Holidays,
                    BasicSalary = item.BasicSalary,
                    GrossSalary = item.GrossSalary,
                    ActuaSalary = item.ActuaSalary,
                    Allowance = item.Allowance,
                    Bonus = item.Bonus,
                    Salary13Th = item.Salary13Th,
                    IncomeOther = item.IncomeOther,
                    OtherDeductions = item.OtherDeductions,
                    Insurance = item.Insurance,
                    SocialInsurance = item.SocialInsurance,
                    HealthInsurance = item.HealthInsurance,
                    UnemploymentInsurance = item.UnemploymentInsurance,
                    NoOfDependants = item.NoOfDependants,
                    PersonalIncomeTax = item.PersonalIncomeTax,
                    PaymentFromSocialInsurance = item.PaymentFromSocialInsurance,
                    FinalizationOfPIT = item.FinalizationOfPIT,
                    PaymentOther = item.PaymentOther,
                    NetIncome = item.NetIncome,
                    MonthYear = date.Month.ToString() + date.Year.ToString(),
                };

                var StringHtml = _viewRenderService.RenderToStringAsync(@".../../Pages/PayslipTemplate", model).GetAwaiter().GetResult();

                var pdfPrintOptions = new PdfPrintOptions()
                {
                    DPI = 300,
                    PaperSize = PdfPrintOptions.PdfPaperSize.A4,
                };
                HtmlToPdf Renderer = new HtmlToPdf(pdfPrintOptions);
                Renderer.RenderHtmlAsPdf(StringHtml).SaveAs(@"..\wwwroot\PDF\" + model.Id + "_Payslips_" + month + ".pdf");
                PdfDocument Pdf = PdfDocument.FromFile(@"..\wwwroot\PDF\" + model.Id + "_Payslips_" + month + ".pdf");
                Pdf.Password = "luong" + date.Month.ToString() + date.Year.ToString();
                Pdf.SaveAs(@"..\wwwroot\PDF\" + model.Id + "_Payslips_" + month + ".pdf");
            }
        }
    }
}
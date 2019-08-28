using OSDPayslip.Models.ViewModels;
using System.Collections.Generic;
using System.IO;

namespace OSDPayslip.Service.Payslip
{
    public interface IPayslipService
    {
        PayslipDetailViewModel Add(PayslipDetailViewModel payslipDetail);

        PayslipDetailViewModel Update(PayslipDetailViewModel payslipDetail);

        void Delete(string id);

        IEnumerable<PayslipDetailViewModel> GetAll();

        IEnumerable<PayslipDetailViewModel> GetAllById(string id);

        PayslipDetailViewModel GetById(string id);

        void Save();

        int HandleExcelFile();
        void MoveFile(string base64);
    }
}
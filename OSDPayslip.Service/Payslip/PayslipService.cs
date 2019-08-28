using AutoMapper;
using OfficeOpenXml;
using OSDPayslip.Application.Reponsitories.Interfaces;
using OSDPayslip.Models.Models;
using OSDPayslip.Models.ViewModels;
using OSDPayslip.Service.Employees;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OSDPayslip.Service.Payslip
{
    public class PayslipService : IPayslipService
    {
        private readonly IPayslipDetailReponsitory _payslipDetailReponsitory;
        private readonly Mapper _mapper;
        private readonly IEmployeeService _employeeService;

        public PayslipService(IPayslipDetailReponsitory payslipDetailReponsitory, Mapper mapper, IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            _payslipDetailReponsitory = payslipDetailReponsitory;
            _mapper = mapper;
        }

        public PayslipDetailViewModel Add(PayslipDetailViewModel payslipDetail)
        {
            var temp = _mapper.Map<PayslipDetailViewModel, PayslipDetail>(payslipDetail);
            _payslipDetailReponsitory.Add(temp);
            return payslipDetail;
        }

        public void Delete(string id)
        {
            _payslipDetailReponsitory.Remove(id);
        }

        public IEnumerable<PayslipDetailViewModel> GetAll()
        {
            var lst = _payslipDetailReponsitory.FindAll().ToList();
            IEnumerable<PayslipDetailViewModel> payslipDetailViewModels = new List<PayslipDetailViewModel>();
            return payslipDetailViewModels = _mapper.Map<List<PayslipDetail>, List<PayslipDetailViewModel>>(lst);
        }

        public IEnumerable<PayslipDetailViewModel> GetAllById(string id)
        {
            var lst = _payslipDetailReponsitory.FindAll().Where(x => x.Id == id).ToList();
            IEnumerable<PayslipDetailViewModel> payslipDetailViewModels = new List<PayslipDetailViewModel>();
            return payslipDetailViewModels = _mapper.Map<List<PayslipDetail>, List<PayslipDetailViewModel>>(lst);
        }

        public PayslipDetailViewModel GetById(string id)
        {
            var item = _payslipDetailReponsitory.FindAll().Where(x => x.Id == id).FirstOrDefault();
            PayslipDetailViewModel payslipDetailViewModels = new PayslipDetailViewModel();
            return payslipDetailViewModels = _mapper.Map<PayslipDetail, PayslipDetailViewModel>(item);
        }

        public void Save()
        {
            _payslipDetailReponsitory.Commit();
        }

        public PayslipDetailViewModel Update(PayslipDetailViewModel payslipDetail)
        {
            var temp = _mapper.Map<PayslipDetailViewModel, PayslipDetail>(payslipDetail);
            _payslipDetailReponsitory.Update(temp);
            return payslipDetail;
        }

        public void MoveFile(string base64)
        {
            string filePath = @"./Publics/ExcelFile/Payslip.xlxs";
            var decodedFileBytes = Convert.FromBase64String(base64);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            File.WriteAllBytes(filePath, decodedFileBytes);
        }

        public int HandleExcelFile()
        {
            string filePath = @".\Publics\ExcelFile\";
            string fileName = "Payslip.xlxs";
            FileInfo fileInfo = new FileInfo(Path.Combine(filePath, fileName));
            int rowCount = 0;
            using (ExcelPackage excel = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = excel.Workbook.Worksheets[1];
                rowCount = worksheet.Dimension.Rows;
                int ColCount = worksheet.Dimension.Columns;
                for (int row = 6; row < rowCount; row++)
                {
                    EmployeeViewModel e = new EmployeeViewModel()
                    {
                        EmployeeID = worksheet.Cells[row, 2].Value.ToString(),
                        FullName = worksheet.Cells[row, 3].Value.ToString(),
                        Position = worksheet.Cells[row, 4].Value.ToString(),
                        DeptTeam = worksheet.Cells[row, 5].Value.ToString(),
                        StartDay = Convert.ToDateTime(worksheet.Cells[row, 6].Value),
                    };
                    PayslipDetailViewModel payslipDetailViewModel = new PayslipDetailViewModel()
                    {
                        StandardWorkingDay = Convert.ToInt32(worksheet.Cells[row, 7].Value),
                        UnpaidLeave = Convert.ToInt32(worksheet.Cells[row, 8].Value),
                        ActualWorkingDay = Convert.ToInt32(worksheet.Cells[row, 9].Value),
                        LeaveBalance = Convert.ToInt32(worksheet.Cells[row, 10].Value),
                        //Total grosss incom
                        GrossSalary = Convert.ToDouble(worksheet.Cells[row, 11].Value),
                        ActuaSalary = Convert.ToDouble(worksheet.Cells[row, 12].Value),
                        BasicSalary = Convert.ToDouble(worksheet.Cells[row, 13].Value),
                        Allowance = Convert.ToDouble(worksheet.Cells[row, 14].Value),
                        Bonus = Convert.ToDouble(worksheet.Cells[row, 15].Value),
                        Salary13Th = Convert.ToDouble(worksheet.Cells[row, 16].Value),
                        IncomeOther = Convert.ToDouble(worksheet.Cells[row, 17].Value),
                        OtherDeductions = Convert.ToDouble(worksheet.Cells[row, 19].Value),
                        ///Deductions
                        SocialInsurance = Convert.ToDouble(worksheet.Cells[row, 22].Value),
                        HealthInsurance = Convert.ToDouble(worksheet.Cells[row, 23].Value),
                        UnemploymentInsurance = Convert.ToDouble(worksheet.Cells[row, 24].Value),
                        NoOfDependants = Convert.ToInt32(worksheet.Cells[row, 28].Value),
                        PersonalIncomeTax = Convert.ToDouble(worksheet.Cells[row, 32].Value),
                        PaymentFromSocialInsurance = Convert.ToDouble(worksheet.Cells[row, 33].Value),
                        PaymentOther = Convert.ToDouble(worksheet.Cells[row, 34].Value),
                        FinalizationOfPIT = Convert.ToDouble(worksheet.Cells[row, 35].Value),
                        NetIncome = Convert.ToDouble(worksheet.Cells[row, 36].Value)
                    };
                    _employeeService.Add(e);
                    Add(payslipDetailViewModel);
                    Save();
                }
            }
            return rowCount;
        }
    }
}
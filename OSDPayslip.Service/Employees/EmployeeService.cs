using AutoMapper;
using OSDPayslip.Application.Reponsitories;
using OSDPayslip.Application.Reponsitories.Interfaces;
using OSDPayslip.Models.Models;
using OSDPayslip.Models.ViewModels;

namespace OSDPayslip.Service.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeReponsitory _employeeReponsitory;
        private readonly Mapper _mapper;

        public EmployeeService(IEmployeeReponsitory employeeReponsitory, Mapper mapper)
        {
            _employeeReponsitory = employeeReponsitory;
            _mapper = mapper;
        }

        public EmployeeViewModel Add(EmployeeViewModel vm)
        {
            var temp = _mapper.Map<EmployeeViewModel, Employee>(vm);
            _employeeReponsitory.Add(temp);
            return vm;
        }
    }
}
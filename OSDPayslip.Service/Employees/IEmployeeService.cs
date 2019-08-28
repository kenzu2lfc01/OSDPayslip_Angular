using OSDPayslip.Models.ViewModels;

namespace OSDPayslip.Service.Employees
{
    public interface IEmployeeService
    {
        EmployeeViewModel Add(EmployeeViewModel vm);
    }
}
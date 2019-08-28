using System;

namespace OSDPayslip.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public string EmployeeID { get; set; }
        public string FullName { get; set; }
        public string DeptTeam { get; set; }
        public string Position { get; set; }
        public DateTime StartDay { get; set; }
    }
}
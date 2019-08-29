using OSDPayslip.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OSDPayslip.Models.Models
{
    public class Employee : DomainEntity<string>
    {
   
        public string FullName { get; set; }
        public string DeptTeam { get; set; }
        public string Position { get; set; }
        public DateTime StartDay { get; set; }
        public virtual IEnumerable<PayslipDetail> PayslipDetails { get; set; }
    }
}
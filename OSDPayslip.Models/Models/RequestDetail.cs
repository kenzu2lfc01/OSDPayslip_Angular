using OSDPayslip.Models.Abstract;
using OSDPayslip.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OSDPayslip.Models.Models
{
    public class RequestDetail : DomainEntity<int>
    {
        public int? NoOfDeployee { get; set; }
        public int? PayslipForMonth { get; set; }
        public virtual IEnumerable<PayslipDetail> PayslipDetails { get; set; }
    }
}
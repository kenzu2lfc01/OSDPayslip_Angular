using OSDPayslip.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace OSDPayslip.Models.Abstract
{
    public class Auditable : IAuditable
    {
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyBy { get; set; }
        public Status Status { get; set; }
    }
}

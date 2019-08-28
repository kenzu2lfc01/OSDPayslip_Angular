using System;
using System.Collections.Generic;
using System.Text;

namespace OSDPayslip.Models.Abstract
{
    public interface IAuditable
    {
        DateTime? CreateDate { get; set;}
        string CreateBy { get; set; }
        DateTime? ModifyDate { get; set;}
        string ModifyBy { get; set; }
        Status Status { get; set; }
       
    }
}

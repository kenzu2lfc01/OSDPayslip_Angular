using OSDPayslip.Models.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace OSDPayslip.Models.Infrastructure
{
    public class DomainEntity<T> : Auditable
    {
        [Key]
        public T Id { get; set; }

        public bool IsTransient()
        {
            return Id.Equals(default(T));
        }
    }
}
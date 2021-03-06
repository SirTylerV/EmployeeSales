using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeSales.Models.DB
{
    public class Purchase
    {
        public long Id { get; set; }
        public int EmployeeId { get; set; }
        public int ProductId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CommissionId { get; set; }
        [Required]
        [Range(typeof(decimal), "0", "900000")] 
        public decimal SalePrice { get; set; }
        public decimal CommissionMade { get; set; }

        public virtual Product Product { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Commission Commission { get; set; }
    }
}

using System;

namespace EmployeeSales.Models.DB
{
    public class Purchase
    {
        public long Id { get; set; }
        public int EmployeeId { get; set; }
        public int ProductId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CommissionId { get; set; }
        public decimal SalePrice { get; set; }
        public decimal CommissionMade { get; set; }

        public Product Product { get; set; }
        public Employee Employee { get; set; }
        public Commission Commission { get; set; }
    }
}

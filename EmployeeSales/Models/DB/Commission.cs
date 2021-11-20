using System.Collections.Generic;

namespace EmployeeSales.Models.DB
{
    public class Commission 
    {
        public int Id { get; set; }
        public decimal Percent { get; set; }
        public decimal ProfitEligibility { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}

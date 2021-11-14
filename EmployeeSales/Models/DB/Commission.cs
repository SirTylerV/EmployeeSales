using System.Collections.Generic;

namespace EmployeeSales.Models.DB
{
    public class Commission 
    {
        public int Id { get; set; }
        public double Percent { get; set; }
        public double ProfitEligibility { get; set; }

        public ICollection<Purchase> Purchases { get; set; }
    }
}

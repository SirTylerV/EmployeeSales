using EmployeeSales.Models.Purchase;
using System;
using System.Collections.Generic;

namespace EmployeeSales.Models.Employee
{
    public class ExtendedEmployeeModel : BaseEmployeeModel
    {
        public decimal LifetimeCommissionMade { get; set; }
        public string FormattedLifetimeCommissionMade
        {
            get { return string.Format("{0:C}", LifetimeCommissionMade); }
        }
        public DateTime HireDate { get; set; }
        public string FormattedHireDate { 
            get { return HireDate.ToString("MMMM d, yyyy"); }
        }
        public int MostSoldProductId { get; set; }
        public string MostSoldProduct { get; set; }
        public int MostSoldProductTotal { get; set; } 
        public List<BasePurchaseModel> Sales { get; set; }
    }
}

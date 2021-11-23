using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSales.Models.Purchase
{
    public class ExtendedPurchaseModel : BasePurchaseModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public decimal CommissionEligibility { get; set; }
        public string FormattedCommissionEligibility {
            get { return Math.Floor(CommissionEligibility * 100).ToString() + "%"; } 
        }
        public decimal CommissionProfit { get; set; }
        public string FormattedCommissionProfit
        {
            get { return Math.Floor(CommissionProfit * 100).ToString() + "%"; }
        }
        public string ProductDescription { get; set; }

    }
}

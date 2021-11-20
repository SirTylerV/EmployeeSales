using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSales.Models.Employee
{
    public class BaseEmployeeModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string EmploymentStatus { get; set; }
        public decimal GrossCommission { get; set; }
        public string FormattedGrossYearlyProfit
        {
            get { return string.Format("{0:C}", GrossCommission); }
        }
    }
}

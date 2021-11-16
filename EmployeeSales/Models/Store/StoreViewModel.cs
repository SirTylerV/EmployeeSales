using EmployeeSales.Models.Employee;
using System.Collections.Generic;


namespace EmployeeSales.Models.Store
{
    public class StoreViewModel
    {
        public int Id { get; set; }
        public string StoreName { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public decimal GrossYearlyProfit { get; set; }
        public List<EmployeeListModel> Employees { get; set; }


        public string FormattedGrossYearlyProfit {
            get { return string.Format("{0:C}", GrossYearlyProfit); }
        }
        public decimal YearlyProfit { get; set; }
        public string FormattedYearlyProfit
        {
            get { return string.Format("{0:C}", YearlyProfit); }
        }
        public decimal InventoryCost { get; set; }
        public string FormattedInventoryCost
        {
            get { return string.Format("{0:C}", InventoryCost); }
        }
        
    }
}

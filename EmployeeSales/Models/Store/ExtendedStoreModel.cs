using EmployeeSales.Models.Employee;
using System.Collections.Generic;


namespace EmployeeSales.Models.Store
{
    public class ExtendedStoreModel : BaseStoreModel
    {
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
        public List<BaseEmployeeModel> Employees { get; set; }
    }
}

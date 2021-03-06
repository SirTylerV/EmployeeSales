using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSales.Models.Store
{
    public class BaseStoreModel
    {
        public int Id { get; set; }
        public string StoreName { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public decimal GrossYearlyProfit { get; set; }
        public string FormattedGrossYearlyProfit
        {
            get { return string.Format("{0:C}", GrossYearlyProfit); }
        }
    }
}

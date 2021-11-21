using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSales.Models.Purchase
{
    public class BasePurchaseModel
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FormattedCreatedAt
        {
            get { return CreatedAt.ToString("MMMM d, yyyy"); }
        }
        public int ProductId { get; set;  }
        public string ProductName { get; set; }
        public decimal Wholesale { get; set; }
        public string FormattedWholesale
        {
            get { return string.Format("{0:C}", Wholesale); }
        }
        public decimal SalePrice { get; set; }
        public string FormattedSalePrice
        {
            get { return string.Format("{0:C}", SalePrice); }
        }
        public decimal CommissionMade { get; set; }
        public string FormattedCommissionMade
        {
            get { return string.Format("{0:C}", CommissionMade); }
        }
    }
}

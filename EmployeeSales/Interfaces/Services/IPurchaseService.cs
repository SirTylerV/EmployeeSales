using EmployeeSales.Models.DB;
using EmployeeSales.Models.Purchase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeSales.Interfaces.Services
{
    public interface IPurchaseService
    {
        Task CreatePurchase(Purchase purchase);
        Task<ExtendedPurchaseModel> GetExtendedPurchases(int id);
        List<BasePurchaseModel> GetPurchases(string direction, string property);
        List<BasePurchaseModel> SortPurchaseList(IEnumerable<BasePurchaseModel> purchases, string direction, string property);
    }
}

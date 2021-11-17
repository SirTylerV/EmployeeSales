using EmployeeSales.Models.Store;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeSales.Interfaces.Services
{
    public interface IStoreService
    {
        List<StoreListModel> GetStores(string direction, string property);
        Task<StoreViewModel> GetStoreView(int storeId);
        List<StoreListModel> SortStoreList(IEnumerable<StoreListModel> stores, string direction, string property);
    }
}
